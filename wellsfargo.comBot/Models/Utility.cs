using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Cookie = System.Net.Cookie;

namespace wellsfargo.comBot.Models
{
    public static class Utility
    {
        public static string ConnectionString = "Data Source=system.db;Version=3;";
        public static string SimpleDateFormat = "dd/MM/yyyy HH:mm:ss";

        public static void SaveSession(this ChromeDriver driver)
        {
            var cookies = new Dictionary<string, string>();
            foreach (var cookie in driver.Manage().Cookies.AllCookies)
            {
                cookies.Add(cookie.Name, cookie.Value);
            }

            File.WriteAllText("ses", JsonConvert.SerializeObject(cookies));
        }

        public static void LoadSession(this ChromeDriver driver, string url)
        {
            if (!File.Exists("ses"))
                throw new KnownException("no session");
            driver.Navigate().GoToUrl(url);
            var cookies = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("ses"));
            foreach (var cookie in cookies)
            {
                driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Key,cookie.Value));
            }
            driver.Navigate().GoToUrl(url);
        }

        public static async Task<IWebElement> Xpath(this ChromeDriver driver, string path, int timeout = 0)
        {
            int tries = 0;
            do
            {
                try
                {
                    var t = driver.FindElement(By.XPath(path));
                    return t;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    //
                }

                tries++;
                if (tries > timeout * 10)
                    return null;
                await Task.Delay(100);
            } while (true);
        }

        public static void SaveCookies(CookieContainer cookieContainer, string url)
        {
            try
            {
                var cookies = new List<Cookie>();
                foreach (Cookie cookie in cookieContainer.GetCookies(new Uri(url)))
                    cookies.Add(new Cookie { Name = cookie.Name, Value = cookie.Value });
                File.WriteAllText("ses", JsonConvert.SerializeObject(cookies));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static string BetweenStrings(this string text, string start, string end)
        {
            var p1 = text.IndexOf(start, StringComparison.Ordinal) + start.Length;
            var p2 = text.IndexOf(end, p1, StringComparison.Ordinal);
            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }

        public static CookieContainer LoadCookies(string url)
        {
            var cookieContainer = new CookieContainer();
            try
            {
                var myCookies = JsonConvert.DeserializeObject<List<Cookie>>(File.ReadAllText("ses"));
                foreach (var myCookie in myCookies)
                    cookieContainer.Add(new Uri(url), new Cookie(myCookie.Name, myCookie.Value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return cookieContainer;
        }
    }
}