using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using wellsfargo.comBot.Models;

namespace wellsfargo.comBot
{
    public partial class MainForm : MetroForm
    {
        public bool LogToUi = true;
        public bool LogToFile = true;

        private readonly string _path = Application.StartupPath;
        private int _delay;
        private Dictionary<string, string> _config;
        public HttpCaller HttpCaller = new HttpCaller();
        private ChromeDriver _driver;
        private int _minMonth;
        private int _minYear;
        private int _maxMonth;
        private int _maxYear;
        private List<string> _accounts;

        public MainForm()
        {
            InitializeComponent();
        }


        async Task InitDriverWithExt()
        {
            NormalLog("Initializing driver");
            var options = new ChromeOptions();
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("no-sandbox");
            options.AddArgument($"--load-extension={_path}/ext");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            _driver = new ChromeDriver(service, options);
            //_driver.LoadSession("https://www.wellsfargo.com/");
            _driver.Navigate().GoToUrl("https://www.wellsfargo.com/");
            await Task.Delay(25000);
            NormalLog("Waiting for login from extension");
            if ((await _driver.Xpath("//span[text()='Welcome']", 5) == null))
                throw new KnownException($"Failed to login");
            NormalLog("logged in");
        }

        void InitDriverAttach()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions
            {
                DebuggerAddress = "127.0.0.1:9222"
            };
            _driver = new ChromeDriver(chromeDriverService, options);
        }

        async Task InitDriverAttachRun()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }

            foreach (var process in Process.GetProcessesByName("chrome"))
            {
                process.CloseMainWindow();
            }

            Process proc = new Process();
            //var userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/AppData/Local/Google/Chrome/User Data";
            var userDir = "C:\\temp";
            var chromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            if (!File.Exists(chromePath))
                chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            proc.StartInfo.FileName = chromePath;
            //proc.StartInfo.Arguments = $"https://www.bet365.com.au/  --remote-debugging-port=9222"; //#/HO/
            proc.StartInfo.Arguments = $" --remote-debugging-port=9222"; //#/HO/
            proc.StartInfo.Arguments = proc.StartInfo.Arguments + $" --user-data-dir={userDir}";
            proc.StartInfo.Arguments = proc.StartInfo.Arguments + $@" --load-extension={_path}\ext";
            proc.Start();
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions
            {
                DebuggerAddress = "127.0.0.1:9222"
            };
            _driver = new ChromeDriver(chromeDriverService, options);
            _driver.Navigate().GoToUrl("https://www.wellsfargo.com/");
            await Task.Delay(25000);
            NormalLog("Waiting for login from extension");
            if ((await _driver.Xpath("//span[text()='Welcome']", 5) == null))
                throw new KnownException($"Failed to login");
            NormalLog("logged in");
        }

        private async Task DownloadCsv()
        {
            NormalLog("Opening Account activity");
            (await _driver.Xpath("//span[text()='Accounts']/..", 3)).Click();
            await Task.Delay(3000);
            // (await _driver.Xpath("//span[text()='View Statements & Documents']/../../..", 3)).Click();
            (await _driver.Xpath("//span[text()='Download Account Activity']/../../..", 3)).Click();
            await Task.Delay(8000);
            var link = "https://connect.secure.wellsfargo.com" + _driver.FindElement(By.Id("commaDelimited")).GetAttribute("data-url");
            NormalLog(link);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(_driver.PageSource);
            var accounts = new Dictionary<string, string>();

            //var options = _driver.FindElements(By.XPath("//select[@id='selectedAccountId']/option"));
            var options = doc.DocumentNode.SelectNodes("//select[@id='selectedAccountId']/option");
            foreach (var webElement in options)
            {
                var t = webElement.InnerText;
                var code = t.Substring(t.IndexOf("...", StringComparison.Ordinal) + 3).Trim();
                if (_accounts.Count != 0)
                {
                    if (_accounts.Contains(code))
                        accounts.Add(webElement.GetAttributeValue("value", ""), code);
                }
                else
                {
                    accounts.Add(webElement.GetAttributeValue("value", ""), code);
                }
            }

            NormalLog($"{accounts.Count} accounts detected");
            if (accounts.Count == 0)
                return;

            _driver.SaveSession();
            HttpCaller = new HttpCaller(true);


            var r = 1;
            foreach (var account in accounts)
            {
                Display($"Downloading activity : {r}/{accounts.Count}");
                r++;
                await HttpCaller.DownloadFile(link, $"{outputCsvI.Text}/WF-{account.Value}-{activitiesFromI.Value:MMddyyyy}-{activitiesToI.Value:MMddyyyy}.csv", new Dictionary<string, string>
                {
                    { "selectedAccountId", account.Key },
                    { "fromDate", activitiesFromI.Value.ToString("MM/dd/yyyy") },
                    { "toDate", activitiesToI.Value.ToString("MM/dd/yyyy") },
                    { "fileFormat", "commaDelimited" },
                });

                await Task.Delay(1000 * _delay);
            }
        }


        private async Task<List<StatementLink>> GetStatements(string url)
        {
            var j = await HttpCaller.PostJson(url, "{}");
            var js = j.BetweenStrings("/*WellFargoProprietary%", "%WellFargoProprietary*/").Replace("\\\"", "\"");
            var statementResponse = JsonConvert.DeserializeObject<StatementsResponse>(js);
            var statementLinks = new List<StatementLink>();
            foreach (var statement in statementResponse.statementsDisclosuresInfo.statements)
            {
                var m = statement.documentDisplayName.BetweenStrings("Statement", "/").Trim();
                var b = int.TryParse(m, out int month);
                if (!b)
                    throw new KnownException($"Failed to parse month : {b} / {statement.documentDisplayName}");

                if (month < _minMonth || month > _maxMonth) continue;
                statementLinks.Add(new StatementLink
                {
                    Period = month.ToString(),
                    Url = statement.url
                });
            }

            return statementLinks;
        }

        private async Task<List<StatementLink>> GetAccountStatements(string url)
        {
            var j = await HttpCaller.PostJson(url, "{}");
            var js = j.BetweenStrings("/*WellFargoProprietary%", "%WellFargoProprietary*/").Replace("\\\"", "\"");
            var statementResponse = JsonConvert.DeserializeObject<StatementsResponse>(js);
            var allStatements = new List<StatementLink>();
            foreach (var periodList in statementResponse.statementsDisclosuresInfo.timePeriodList.Where(x => !x.timePeriod.Equals("Recent statements")))
            {
                var b = int.TryParse(periodList.timePeriod, out int p);
                if (!b)
                    throw new KnownException($"Failed to parse year on account statement : {periodList.timePeriod}");
                if (p < _minYear || p > _maxYear) continue;
                var statements = await GetStatements($"https://connect.secure.wellsfargo.com{periodList.url.Replace("\\u0026", "&")}");
                foreach (var s in statements) s.Year = periodList.timePeriod;
                allStatements.AddRange(statements);
            }

            return allStatements;
        }

        async Task WorkOnStatements()
        {
            _driver.SwitchTo().Window(_driver.CurrentWindowHandle);
            // try
            // {
            //     _driver.FindElement(By.XPath("//div[@class='wf-logo']")).Click();
            // }
            // catch (Exception e)
            // {
            //     //
            //     NormalLog("no Wf-logo");
            // }

            await Task.Delay(3000);
            NormalLog("Opening statements tab");
            (await _driver.Xpath("//span[text()='Accounts']/..", 3)).Click();
            await Task.Delay(5000);
            (await _driver.Xpath("//span[text()='View Statements & Documents']/../../..", 8)).Click();
            // var u = "https://connect.secure.wellsfargo.com" + (await _driver.Xpath("//a[contains(@data-url,'statementsdocs_moremenu')]", 3)).GetAttribute("data-url");
            // _driver.Navigate().GoToUrl(u);
            // (await _driver.Xpath("//span[text()='Statements and Disclosures']/../../../..",5)).Click();
            await Task.Delay(6000);
            _driver.SaveSession();
            HttpCaller = new HttpCaller(true);

            // var json = _driver.PageSource.BetweenStrings("window.mwfGlobals.eDocsHomeModel = \"/*WellFargoProprietary%", "%WellFargoProprietary*/").Replace("\\\"", "\"");
            var url = _driver.PageSource.BetweenStrings("window.mwfGlobals.statementDisclosuresUrl = '", "';");
            // NormalLog("Statements explorer : " + url);
            var statements = "https://connect.secure.wellsfargo.com/edocs" + url;
            var t = 0;
            string j;
            j = await HttpCaller.PostJson(statements, "{\"nds-pmd\":\"\"}");
            if (j.Contains("<h1>Online Banking is temporarily unavailable</h1>"))
                throw new KnownException("Online Banking is temporarily unavailable");

            // do
            // {
            //     j = await HttpCaller.PostJson(statements, "{\"nds-pmd\":\"\"}");
            //     if (!j.Contains("/*WellFargoProprietary%"))
            //     {
            //         if (!j.Contains("<h1>Online Banking is temporarily unavailable</h1>"))
            //             throw new KnownException($"Something went wrong on statements scan :\n {j}");
            //         t++;
            //         if (t == 3)
            //             throw new KnownException($"Something went wrong on statements scan (tries 3 times) :\n {j}");
            //         await Task.Delay(2000);
            //     }
            //     else
            //     {
            //         break;
            //     }
            // } while (true);


            var js = j.BetweenStrings("/*WellFargoProprietary%", "%WellFargoProprietary*/").Replace("\\\"", "\"");

            var statementResponse = JsonConvert.DeserializeObject<StatementsResponse>(js);

            for (var i = 0; i < statementResponse.statementsDisclosuresInfo.accountList.Count; i++)
            {
                var accountList = statementResponse.statementsDisclosuresInfo.accountList[i];
                var code = accountList.accountDisplayName.Substring(accountList.accountDisplayName.IndexOf("...", StringComparison.Ordinal) + 3).Trim();
                if (_accounts.Count != 0 && !_accounts.Contains(code)) continue;
                Display($"Working on account {i + 1}/{statementResponse.statementsDisclosuresInfo.accountList.Count}");
                var statementLinks = await GetAccountStatements($"https://connect.secure.wellsfargo.com{accountList.url.Replace("\\u0026", "&")}");
                for (var n = 0; n < statementLinks.Count; n++)
                {
                    var statementLink = statementLinks[n];
                    Display($"Downloading statement {n + 1}/{statementLinks.Count}");
                    var p = statementLink.Period.Length == 1 ? $"0{statementLink.Period}" : statementLink.Period;
                    await HttpCaller.DownloadFile($"https://connect.secure.wellsfargo.com{statementLink.Url.Replace("\\u0026", "&")}", outputPdfI.Text + $"/WF-{code}-{p}-{statementLink.Year}.pdf");
                    await Task.Delay(1000 * _delay);
                }
            }

            // var url = "https://connect.secure.wellsfargo.com" + statementResponse.statementsDisclosuresInfo.statements.First().url;
            // NormalLog(url);
        }

        private async Task MainWork()
        {
            if (!downloadActivitiesI.Checked && !downloadStatementsI.Checked)
                throw new KnownException("At least one operation need to be selected");

            await InitDriverWithExt();
            // InitDriverAttach();
            // await InitDriverAttachRun();
            _driver.SaveSession();

            HttpCaller = new HttpCaller(true);


            if (downloadStatementsI.Checked)
            {
                await WorkOnStatements();
                // for (int i = 0; i < 5; i++)
                // {
                //     try
                //     {
                //         await WorkOnStatements();
                //         break;
                //     }
                //     catch (KnownException e)
                //     {
                //         await Task.Delay(10000);
                //         if (e.Message == "Online Banking is temporarily unavailable")
                //         {
                //            // await WorkOnStatements();
                //            if (i == 4)
                //                throw;
                //         }
                //         else
                //             throw;
                //     }
                // }
            }

            if (downloadActivitiesI.Checked)
                await DownloadCsv();


            Display("Completed");
            // await HttpCaller.DownloadFile(url, "fg.pdf");
            // Process.Start("fg.pdf");


            // (await _driver.Xpath("//span[text()='Accounts']/..", 3)).Click();
            // await Task.Delay(3000);
            // (await _driver.Xpath("//span[text()='Download Account Activity']/../../..", 3)).Click();

            // (await _driver.Xpath("//div[@data-form-element='selectedAccountId']")).Click();
            // var ul = await _driver.Xpath("//ul[@id='selectedAccountId-list']", 6);
            // ul.FindElements(By.XPath("./li"))[1].Click();

            // _driver.ExecuteScript("arguments[0].value='09/05/2021'", _driver.FindElement(By.Id("fromDate")));
            // //_driver.FindElement(By.Id("fromDate")).SendKeys("09/05/2021");
            // _driver.FindElement(By.XPath("//span[@data-for='commaDelimited']")).Click();
            // _driver.FindElement(By.Id("btn-continue")).Click();

            // _driver.Navigate().GoToUrl("https://connect.secure.wellsfargo.com/auth/login/present?origin=cob&error=yes");
            // await Task.Delay(10000);
            // NormalLog(a);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServicePointManager.DefaultConnectionLimit = 65000;
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Directory.CreateDirectory("data");
            outputCsvI.Text = _path;
            outputPdfI.Text = _path;
            LoadConfig();
        }

        void InitControls(Control parent)
        {
            try
            {
                foreach (Control x in parent.Controls)
                {
                    try
                    {
                        if (x.Name.EndsWith("I"))
                        {
                            switch (x)
                            {
                                case MetroDateTime d:
                                    d.Value = DateTime.Parse(_config[d.Name]);
                                    break;
                                case MetroComboBox c:
                                    c.SelectedIndex = int.Parse(_config[c.Name]);
                                    break;
                                case MetroCheckBox _:
                                case CheckBox _:
                                    ((CheckBox)x).Checked = bool.Parse(_config[((CheckBox)x).Name]);
                                    break;
                                case RadioButton radioButton:
                                    radioButton.Checked = bool.Parse(_config[radioButton.Name]);
                                    break;
                                case TextBox _:
                                case RichTextBox _:
                                case MetroTextBox _:
                                    x.Text = _config[x.Name];
                                    break;
                                case NumericUpDown numericUpDown:
                                    numericUpDown.Value = int.Parse(_config[numericUpDown.Name]);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    InitControls(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void SaveControls(Control parent)
        {
            try
            {
                foreach (Control x in parent.Controls)
                {
                    #region Add key value to disctionarry

                    if (x.Name.EndsWith("I"))
                    {
                        switch (x)
                        {
                            case MetroDateTime d:
                                _config.Add(d.Name, d.Value.ToString());
                                break;
                            case MetroComboBox c:
                                _config.Add(c.Name, c.SelectedIndex.ToString());
                                break;
                            case MetroCheckBox _:
                            case RadioButton _:
                            case CheckBox _:
                                _config.Add(x.Name, ((CheckBox)x).Checked + "");
                                break;
                            case TextBox _:
                            case RichTextBox _:
                            case MetroTextBox _:
                                _config.Add(x.Name, x.Text);
                                break;
                            case NumericUpDown _:
                                _config.Add(x.Name, ((NumericUpDown)x).Value + "");
                                break;
                            default:
                                Console.WriteLine(@"could not find a type for " + x.Name);
                                break;
                        }
                    }

                    #endregion

                    SaveControls(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SaveConfig()
        {
            _config = new Dictionary<string, string>();
            SaveControls(this);
            try
            {
                File.WriteAllText("config.txt", JsonConvert.SerializeObject(_config, Formatting.Indented));
            }
            catch (Exception e)
            {
                ErrorLog(e.ToString());
            }
        }

        private void LoadConfig()
        {
            try
            {
                _config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("config.txt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            InitControls(this);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), @"Unhandled Thread Exception");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception)?.ToString(), @"Unhandled UI Exception");
        }

        #region UIFunctions

        public delegate void WriteToLogD(string s, Color c);

        public void WriteToLog(string s, Color c)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new WriteToLogD(WriteToLog), s, c);
                    return;
                }

                if (LogToUi)
                {
                    if (DebugT.Lines.Length > 5000)
                    {
                        DebugT.Text = "";
                    }

                    DebugT.SelectionStart = DebugT.Text.Length;
                    DebugT.SelectionColor = c;
                    DebugT.AppendText(DateTime.Now.ToString(Utility.SimpleDateFormat) + " : " + s + Environment.NewLine);
                }

                Console.WriteLine(DateTime.Now.ToString(Utility.SimpleDateFormat) + @" : " + s);
                if (LogToFile)
                {
                    File.AppendAllText(_path + "/data/log.txt", DateTime.Now.ToString(Utility.SimpleDateFormat) + @" : " + s + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void NormalLog(string s)
        {
            WriteToLog(s, Color.Black);
            Display(s);
        }

        public void ErrorLog(string s)
        {
            WriteToLog(s, Color.Red);
        }

        public void SuccessLog(string s)
        {
            WriteToLog(s, Color.Green);
        }

        public void CommandLog(string s)
        {
            WriteToLog(s, Color.Blue);
        }

        public delegate void SetProgressD(int x);

        public void SetProgress(int x)
        {
            if (InvokeRequired)
            {
                Invoke(new SetProgressD(SetProgress), x);
                return;
            }

            if ((x <= 100))
            {
                ProgressB.Value = x;
            }
        }

        public delegate void DisplayD(string s);

        public void Display(string s)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayD(Display), s);
                return;
            }

            displayT.Text = s;
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
            _driver?.Quit();
        }

        private void loadInputB_Click_1(object sender, EventArgs e)
        {
            var o = new FolderBrowserDialog { SelectedPath = _path };
            if (o.ShowDialog() == DialogResult.OK)
            {
                outputCsvI.Text = o.SelectedPath;
            }
        }

        private void openInputB_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(outputCsvI.Text);
            }
            catch (Exception ex)
            {
                ErrorLog(ex.ToString());
            }
        }

        private void openOutputB_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(outputPdfI.Text);
            }
            catch (Exception ex)
            {
                ErrorLog(ex.ToString());
            }
        }

        private void loadOutputB_Click_1(object sender, EventArgs e)
        {
            var o = new FolderBrowserDialog { SelectedPath = _path };
            if (o.ShowDialog() == DialogResult.OK)
            {
                outputPdfI.Text = o.SelectedPath;
            }
        }

        private async void startB_Click_1(object sender, EventArgs e)
        {
            SaveConfig();
            LogToUi = logToUII.Checked;
            LogToFile = logToFileI.Checked;
            _delay = (int)delayI.Value;

            _minMonth = fromMonthI.SelectedIndex + 1;
            _maxMonth = toMonthI.SelectedIndex + 1;
            _minYear = int.Parse(fromYearI.Text);
            _maxYear = int.Parse(toYearI.Text);

            _accounts = new List<string>();
            if (accountsI.Text.Trim() != "")
            {
                _accounts = accountsI.Text.Trim().Split(',').ToList().Select(x=>x.Trim()).ToList();
            }

            //var s="let username='dkwfadmin';\nlet password='dkWFADMIN-321';\n\nvar login = async function () {\n    try{\n        let w=await Get(\"//span[text()='Welcome']\",10);\n        if(w!==null)\n        {\n            return;\n        }\n        getElementByXpath(\"//input[@id='userid']\").value=username;\n        getElementByXpath(\"//input[@id='password']\").value=password;\n        getElementByXpath(\"//input[@id='btnSignon']\").click();\n        let welcome=await Get(\"//span[text()='Welcome']\",10);\n        if(welcome!==null)\n            console.log(\"logged in\");\n    }catch (e) {\n     console.log(e);\n    }\n\n\n}\n\n\n\nconsole.log(\"injected : \"+window.location.href);\nlogin();\n\n\nfunction getElementByXpath(path, parent = null) {\n    return document.evaluate(path, parent || document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;\n}\n\nfunction getElementsByXPath(xpath, parent = null) {\n    let results = [];\n    let query = document.evaluate(xpath, parent || document,\n        null, XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null);\n    for (let i = 0, length = query.snapshotLength; i < length; ++i) {\n        results.push(query.snapshotItem(i));\n    }\n    return results;\n}\n\nasync function Get(path,t) {\n    var i = 0;\n    while (true) {\n        const node = getElementByXpath(path);\n        if (node) {\n            console.log(path + \" \" + i)\n            return node;\n        }\n        i++;\n        if (i == t*2)\n            return null;\n        await new Promise(r => setTimeout(r, 500));\n    }\n}\n"
            var s = "let username='" + userI.Text + "';\nlet password='" + passI.Text + "';\n\nvar login = async function () {\n    try{\n        let w=await Get(\"//span[text()='Welcome']\",10);\n        if(w!==null)\n        {\n            return;\n        }\n        getElementByXpath(\"//input[@id='userid']\").value=username;\n        getElementByXpath(\"//input[@id='password']\").value=password;\n        getElementByXpath(\"//input[@id='btnSignon']\").click();\n        let welcome=await Get(\"//span[text()='Welcome']\",10);\n        if(welcome!==null)\n            console.log(\"logged in\");\n    }catch (e) {\n     console.log(e);\n    }\n\n\n}\n\n\n\nconsole.log(\"injected : \"+window.location.href);\nlogin();\n\n\nfunction getElementByXpath(path, parent = null) {\n    return document.evaluate(path, parent || document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;\n}\n\nfunction getElementsByXPath(xpath, parent = null) {\n    let results = [];\n    let query = document.evaluate(xpath, parent || document,\n        null, XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null);\n    for (let i = 0, length = query.snapshotLength; i < length; ++i) {\n        results.push(query.snapshotItem(i));\n    }\n    return results;\n}\n\nasync function Get(path,t) {\n    var i = 0;\n    while (true) {\n        const node = getElementByXpath(path);\n        if (node) {\n            console.log(path + \" \" + i)\n            return node;\n        }\n        i++;\n        if (i == t*2)\n            return null;\n        await new Promise(r => setTimeout(r, 500));\n    }\n}\n";
            File.WriteAllText($"{_path}/ext/injector.js", s);
            try
            {
                await Task.Run(MainWork);
            }
            catch (KnownException knownException)
            {
                ErrorLog(knownException.Message);
            }
            catch (Exception ex)
            {
                ErrorLog(ex.ToString());
            }
        }

        private async void stopB_Click(object sender, EventArgs e)
        {
            //_driver.FindElement(By.Id("j_username")).SendKeys("dkwfadmin");
            //_driver.FindElement(By.Id("j_password")).SendKeys("dkWFADMIN-321");
            //_driver.FindElement(By.Id("j_password")).Submit();


            _driver.FindElement(By.Id("userid")).Click();
            await Task.Delay(1000);
            _driver.FindElement(By.Id("userid")).SendKeys("dkwfadmin");
            await Task.Delay(5000);
            _driver.FindElement(By.Id("password")).Click();
            await Task.Delay(1000);
            _driver.FindElement(By.Id("password")).SendKeys("dkWFADMIN-321");
            //await Task.Delay(6000);
            //_driver.FindElement(By.Id("btnSignon")).Click();

            //_driver.FindElement(By.XPath("//button[@data-testid='signon-button']")).Click();
        }
    }
}