using MetroFramework.Forms;
namespace wellsfargo.comBot
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.ProgressB = new System.Windows.Forms.ProgressBar();
            this.displayT = new System.Windows.Forms.Label();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.passI = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userI = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.activitiesFromI = new MetroFramework.Controls.MetroDateTime();
            this.downloadActivitiesI = new MetroFramework.Controls.MetroCheckBox();
            this.downloadStatementsI = new MetroFramework.Controls.MetroCheckBox();
            this.toYearI = new MetroFramework.Controls.MetroComboBox();
            this.fromYearI = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toMonthI = new MetroFramework.Controls.MetroComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fromMonthI = new MetroFramework.Controls.MetroComboBox();
            this.logToFileI = new MetroFramework.Controls.MetroCheckBox();
            this.logToUII = new MetroFramework.Controls.MetroCheckBox();
            this.openOutputB = new MetroFramework.Controls.MetroButton();
            this.openInputB = new MetroFramework.Controls.MetroButton();
            this.loadOutputB = new MetroFramework.Controls.MetroButton();
            this.loadInputB = new MetroFramework.Controls.MetroButton();
            this.outputPdfI = new MetroFramework.Controls.MetroTextBox();
            this.outputCsvI = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.delayI = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.startB = new MetroFramework.Controls.MetroButton();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.DebugT = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayI)).BeginInit();
            this.panel1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Controls.Add(this.ProgressB);
            this.panel3.Controls.Add(this.displayT);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(27, 685);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1254, 70);
            this.panel3.TabIndex = 15;
            // 
            // ProgressB
            // 
            this.ProgressB.Location = new System.Drawing.Point(5, 43);
            this.ProgressB.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressB.Name = "ProgressB";
            this.ProgressB.Size = new System.Drawing.Size(1244, 17);
            this.ProgressB.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressB.TabIndex = 4;
            // 
            // displayT
            // 
            this.displayT.AutoSize = true;
            this.displayT.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayT.ForeColor = System.Drawing.Color.Black;
            this.displayT.Location = new System.Drawing.Point(29, 12);
            this.displayT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.displayT.Name = "displayT";
            this.displayT.Size = new System.Drawing.Size(0, 20);
            this.displayT.TabIndex = 2;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(27, 74);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1254, 611);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTabControl1.TabIndex = 16;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroTabPage1.Controls.Add(this.panel2);
            this.metroTabPage1.Controls.Add(this.panel1);
            this.metroTabPage1.ForeColor = System.Drawing.Color.Black;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 0;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1246, 566);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Options";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.passI);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.userI);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.activitiesFromI);
            this.panel2.Controls.Add(this.downloadActivitiesI);
            this.panel2.Controls.Add(this.downloadStatementsI);
            this.panel2.Controls.Add(this.toYearI);
            this.panel2.Controls.Add(this.fromYearI);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.toMonthI);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.fromMonthI);
            this.panel2.Controls.Add(this.logToFileI);
            this.panel2.Controls.Add(this.logToUII);
            this.panel2.Controls.Add(this.openOutputB);
            this.panel2.Controls.Add(this.openInputB);
            this.panel2.Controls.Add(this.loadOutputB);
            this.panel2.Controls.Add(this.loadInputB);
            this.panel2.Controls.Add(this.outputPdfI);
            this.panel2.Controls.Add(this.outputCsvI);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.delayI);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1019, 566);
            this.panel2.TabIndex = 14;
            // 
            // passI
            // 
            // 
            // 
            // 
            this.passI.CustomButton.Image = null;
            this.passI.CustomButton.Location = new System.Drawing.Point(197, 2);
            this.passI.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.passI.CustomButton.Name = "";
            this.passI.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.passI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passI.CustomButton.TabIndex = 1;
            this.passI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passI.CustomButton.UseSelectable = true;
            this.passI.CustomButton.Visible = false;
            this.passI.Lines = new string[0];
            this.passI.Location = new System.Drawing.Point(126, 267);
            this.passI.Margin = new System.Windows.Forms.Padding(4);
            this.passI.MaxLength = 32767;
            this.passI.Name = "passI";
            this.passI.PasswordChar = '*';
            this.passI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passI.SelectedText = "";
            this.passI.SelectionLength = 0;
            this.passI.SelectionStart = 0;
            this.passI.ShortcutsEnabled = true;
            this.passI.Size = new System.Drawing.Size(223, 28);
            this.passI.Style = MetroFramework.MetroColorStyle.Orange;
            this.passI.TabIndex = 41;
            this.passI.UseSelectable = true;
            this.passI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(43, 267);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Pass";
            // 
            // userI
            // 
            // 
            // 
            // 
            this.userI.CustomButton.Image = null;
            this.userI.CustomButton.Location = new System.Drawing.Point(197, 2);
            this.userI.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.userI.CustomButton.Name = "";
            this.userI.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.userI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.userI.CustomButton.TabIndex = 1;
            this.userI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.userI.CustomButton.UseSelectable = true;
            this.userI.CustomButton.Visible = false;
            this.userI.Lines = new string[0];
            this.userI.Location = new System.Drawing.Point(126, 207);
            this.userI.Margin = new System.Windows.Forms.Padding(4);
            this.userI.MaxLength = 32767;
            this.userI.Name = "userI";
            this.userI.PasswordChar = '\0';
            this.userI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.userI.SelectedText = "";
            this.userI.SelectionLength = 0;
            this.userI.SelectionStart = 0;
            this.userI.ShortcutsEnabled = true;
            this.userI.Size = new System.Drawing.Size(223, 28);
            this.userI.Style = MetroFramework.MetroColorStyle.Orange;
            this.userI.TabIndex = 39;
            this.userI.UseSelectable = true;
            this.userI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.userI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(43, 207);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(255, 343);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "From";
            // 
            // activitiesFromI
            // 
            this.activitiesFromI.CustomFormat = "dd/MM/yyyy";
            this.activitiesFromI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.activitiesFromI.Location = new System.Drawing.Point(338, 337);
            this.activitiesFromI.MinimumSize = new System.Drawing.Size(0, 30);
            this.activitiesFromI.Name = "activitiesFromI";
            this.activitiesFromI.Size = new System.Drawing.Size(220, 30);
            this.activitiesFromI.Style = MetroFramework.MetroColorStyle.Orange;
            this.activitiesFromI.TabIndex = 36;
            // 
            // downloadActivitiesI
            // 
            this.downloadActivitiesI.AutoSize = true;
            this.downloadActivitiesI.Location = new System.Drawing.Point(39, 346);
            this.downloadActivitiesI.Margin = new System.Windows.Forms.Padding(4);
            this.downloadActivitiesI.Name = "downloadActivitiesI";
            this.downloadActivitiesI.Size = new System.Drawing.Size(137, 17);
            this.downloadActivitiesI.Style = MetroFramework.MetroColorStyle.Orange;
            this.downloadActivitiesI.TabIndex = 35;
            this.downloadActivitiesI.Text = "Download Activities";
            this.downloadActivitiesI.UseSelectable = true;
            // 
            // downloadStatementsI
            // 
            this.downloadStatementsI.AutoSize = true;
            this.downloadStatementsI.Location = new System.Drawing.Point(39, 402);
            this.downloadStatementsI.Margin = new System.Windows.Forms.Padding(4);
            this.downloadStatementsI.Name = "downloadStatementsI";
            this.downloadStatementsI.Size = new System.Drawing.Size(151, 17);
            this.downloadStatementsI.Style = MetroFramework.MetroColorStyle.Orange;
            this.downloadStatementsI.TabIndex = 34;
            this.downloadStatementsI.Text = "Download Statements";
            this.downloadStatementsI.UseSelectable = true;
            // 
            // toYearI
            // 
            this.toYearI.FormattingEnabled = true;
            this.toYearI.ItemHeight = 24;
            this.toYearI.Items.AddRange(new object[] { "2022", "2021", "2020", "2019", "2018", "2017", "2016", "2015", "2022", "2021", "2020", "2019", "2018", "2017", "2016", "2015" });
            this.toYearI.Location = new System.Drawing.Point(758, 396);
            this.toYearI.Name = "toYearI";
            this.toYearI.Size = new System.Drawing.Size(105, 30);
            this.toYearI.TabIndex = 33;
            this.toYearI.UseSelectable = true;
            // 
            // fromYearI
            // 
            this.fromYearI.FormattingEnabled = true;
            this.fromYearI.ItemHeight = 24;
            this.fromYearI.Items.AddRange(new object[] { "2022", "2021", "2020", "2019", "2018", "2017", "2016", "2015", "2022", "2021", "2020", "2019", "2018", "2017", "2016", "2015" });
            this.fromYearI.Location = new System.Drawing.Point(453, 395);
            this.fromYearI.Name = "fromYearI";
            this.fromYearI.Size = new System.Drawing.Size(105, 30);
            this.fromYearI.Style = MetroFramework.MetroColorStyle.Orange;
            this.fromYearI.TabIndex = 32;
            this.fromYearI.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(590, 400);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "To";
            // 
            // toMonthI
            // 
            this.toMonthI.FormattingEnabled = true;
            this.toMonthI.ItemHeight = 24;
            this.toMonthI.Items.AddRange(new object[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec", "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec" });
            this.toMonthI.Location = new System.Drawing.Point(647, 395);
            this.toMonthI.Name = "toMonthI";
            this.toMonthI.Size = new System.Drawing.Size(105, 30);
            this.toMonthI.TabIndex = 30;
            this.toMonthI.UseSelectable = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(255, 399);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "From";
            // 
            // fromMonthI
            // 
            this.fromMonthI.FormattingEnabled = true;
            this.fromMonthI.ItemHeight = 24;
            this.fromMonthI.Items.AddRange(new object[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec", "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec" });
            this.fromMonthI.Location = new System.Drawing.Point(338, 395);
            this.fromMonthI.Name = "fromMonthI";
            this.fromMonthI.Size = new System.Drawing.Size(105, 30);
            this.fromMonthI.Style = MetroFramework.MetroColorStyle.Orange;
            this.fromMonthI.TabIndex = 28;
            this.fromMonthI.UseSelectable = true;
            // 
            // logToFileI
            // 
            this.logToFileI.AutoSize = true;
            this.logToFileI.Location = new System.Drawing.Point(43, 536);
            this.logToFileI.Margin = new System.Windows.Forms.Padding(4);
            this.logToFileI.Name = "logToFileI";
            this.logToFileI.Size = new System.Drawing.Size(87, 17);
            this.logToFileI.Style = MetroFramework.MetroColorStyle.Orange;
            this.logToFileI.TabIndex = 27;
            this.logToFileI.Text = "Log To File";
            this.logToFileI.UseSelectable = true;
            // 
            // logToUII
            // 
            this.logToUII.AutoSize = true;
            this.logToUII.Location = new System.Drawing.Point(43, 495);
            this.logToUII.Margin = new System.Windows.Forms.Padding(4);
            this.logToUII.Name = "logToUII";
            this.logToUII.Size = new System.Drawing.Size(80, 17);
            this.logToUII.Style = MetroFramework.MetroColorStyle.Orange;
            this.logToUII.TabIndex = 26;
            this.logToUII.Text = "Log To UI";
            this.logToUII.UseSelectable = true;
            // 
            // openOutputB
            // 
            this.openOutputB.Location = new System.Drawing.Point(824, 151);
            this.openOutputB.Margin = new System.Windows.Forms.Padding(4);
            this.openOutputB.Name = "openOutputB";
            this.openOutputB.Size = new System.Drawing.Size(148, 28);
            this.openOutputB.Style = MetroFramework.MetroColorStyle.Orange;
            this.openOutputB.TabIndex = 25;
            this.openOutputB.Text = "Open folder";
            this.openOutputB.UseSelectable = true;
            this.openOutputB.UseStyleColors = true;
            this.openOutputB.Click += new System.EventHandler(this.openOutputB_Click_1);
            // 
            // openInputB
            // 
            this.openInputB.Location = new System.Drawing.Point(824, 106);
            this.openInputB.Margin = new System.Windows.Forms.Padding(4);
            this.openInputB.Name = "openInputB";
            this.openInputB.Size = new System.Drawing.Size(148, 28);
            this.openInputB.Style = MetroFramework.MetroColorStyle.Orange;
            this.openInputB.TabIndex = 24;
            this.openInputB.Text = "Open folder";
            this.openInputB.UseSelectable = true;
            this.openInputB.UseStyleColors = true;
            this.openInputB.Click += new System.EventHandler(this.openInputB_Click_1);
            // 
            // loadOutputB
            // 
            this.loadOutputB.Location = new System.Drawing.Point(651, 151);
            this.loadOutputB.Margin = new System.Windows.Forms.Padding(4);
            this.loadOutputB.Name = "loadOutputB";
            this.loadOutputB.Size = new System.Drawing.Size(148, 28);
            this.loadOutputB.Style = MetroFramework.MetroColorStyle.Orange;
            this.loadOutputB.TabIndex = 23;
            this.loadOutputB.Text = "Pdf Output Folder";
            this.loadOutputB.UseSelectable = true;
            this.loadOutputB.UseStyleColors = true;
            this.loadOutputB.Click += new System.EventHandler(this.loadOutputB_Click_1);
            // 
            // loadInputB
            // 
            this.loadInputB.Location = new System.Drawing.Point(651, 106);
            this.loadInputB.Margin = new System.Windows.Forms.Padding(4);
            this.loadInputB.Name = "loadInputB";
            this.loadInputB.Size = new System.Drawing.Size(148, 28);
            this.loadInputB.Style = MetroFramework.MetroColorStyle.Orange;
            this.loadInputB.TabIndex = 22;
            this.loadInputB.Text = "Csv Output Folder";
            this.loadInputB.UseSelectable = true;
            this.loadInputB.UseStyleColors = true;
            this.loadInputB.Click += new System.EventHandler(this.loadInputB_Click_1);
            // 
            // outputPdfI
            // 
            // 
            // 
            // 
            this.outputPdfI.CustomButton.Image = null;
            this.outputPdfI.CustomButton.Location = new System.Drawing.Point(535, 2);
            this.outputPdfI.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.outputPdfI.CustomButton.Name = "";
            this.outputPdfI.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.outputPdfI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.outputPdfI.CustomButton.TabIndex = 1;
            this.outputPdfI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.outputPdfI.CustomButton.UseSelectable = true;
            this.outputPdfI.CustomButton.Visible = false;
            this.outputPdfI.Lines = new string[0];
            this.outputPdfI.Location = new System.Drawing.Point(43, 155);
            this.outputPdfI.Margin = new System.Windows.Forms.Padding(4);
            this.outputPdfI.MaxLength = 32767;
            this.outputPdfI.Name = "outputPdfI";
            this.outputPdfI.PasswordChar = '\0';
            this.outputPdfI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.outputPdfI.SelectedText = "";
            this.outputPdfI.SelectionLength = 0;
            this.outputPdfI.SelectionStart = 0;
            this.outputPdfI.ShortcutsEnabled = true;
            this.outputPdfI.Size = new System.Drawing.Size(561, 28);
            this.outputPdfI.Style = MetroFramework.MetroColorStyle.Orange;
            this.outputPdfI.TabIndex = 21;
            this.outputPdfI.UseSelectable = true;
            this.outputPdfI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.outputPdfI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // outputCsvI
            // 
            // 
            // 
            // 
            this.outputCsvI.CustomButton.Image = null;
            this.outputCsvI.CustomButton.Location = new System.Drawing.Point(535, 2);
            this.outputCsvI.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.outputCsvI.CustomButton.Name = "";
            this.outputCsvI.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.outputCsvI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.outputCsvI.CustomButton.TabIndex = 1;
            this.outputCsvI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.outputCsvI.CustomButton.UseSelectable = true;
            this.outputCsvI.CustomButton.Visible = false;
            this.outputCsvI.Lines = new string[0];
            this.outputCsvI.Location = new System.Drawing.Point(43, 106);
            this.outputCsvI.Margin = new System.Windows.Forms.Padding(4);
            this.outputCsvI.MaxLength = 32767;
            this.outputCsvI.Name = "outputCsvI";
            this.outputCsvI.PasswordChar = '\0';
            this.outputCsvI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.outputCsvI.SelectedText = "";
            this.outputCsvI.SelectionLength = 0;
            this.outputCsvI.SelectionStart = 0;
            this.outputCsvI.ShortcutsEnabled = true;
            this.outputCsvI.Size = new System.Drawing.Size(561, 28);
            this.outputCsvI.Style = MetroFramework.MetroColorStyle.Orange;
            this.outputCsvI.TabIndex = 20;
            this.outputCsvI.UseSelectable = true;
            this.outputCsvI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.outputCsvI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Delay";
            // 
            // delayI
            // 
            this.delayI.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delayI.Location = new System.Drawing.Point(177, 47);
            this.delayI.Margin = new System.Windows.Forms.Padding(4);
            this.delayI.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            this.delayI.Name = "delayI";
            this.delayI.Size = new System.Drawing.Size(77, 24);
            this.delayI.TabIndex = 6;
            this.delayI.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.startB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1019, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 566);
            this.panel1.TabIndex = 6;
            // 
            // startB
            // 
            this.startB.Location = new System.Drawing.Point(45, 380);
            this.startB.Margin = new System.Windows.Forms.Padding(4);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(148, 53);
            this.startB.Style = MetroFramework.MetroColorStyle.Orange;
            this.startB.TabIndex = 23;
            this.startB.Text = "Start";
            this.startB.UseSelectable = true;
            this.startB.UseStyleColors = true;
            this.startB.Click += new System.EventHandler(this.startB_Click_1);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroPanel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = false;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 0;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1246, 566);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Logs";
            this.metroTabPage2.VerticalScrollbarBarColor = false;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 0;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.DebugT);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 12;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1246, 566);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 13;
            // 
            // DebugT
            // 
            this.DebugT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DebugT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DebugT.Cursor = System.Windows.Forms.Cursors.Default;
            this.DebugT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugT.Location = new System.Drawing.Point(0, 0);
            this.DebugT.Margin = new System.Windows.Forms.Padding(5);
            this.DebugT.Name = "DebugT";
            this.DebugT.ReadOnly = true;
            this.DebugT.Size = new System.Drawing.Size(1246, 566);
            this.DebugT.TabIndex = 1;
            this.DebugT.Text = "";
            this.DebugT.WordWrap = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::wellsfargo.comBot.Properties.Resources.clipart196740;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(27, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1308, 780);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.panel3);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "         wellsfargo.comBot 1.01";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayI)).EndInit();
            this.panel1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox userI;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroTextBox passI;

        private MetroFramework.Controls.MetroCheckBox downloadStatementsI;
        private MetroFramework.Controls.MetroCheckBox downloadActivitiesI;
        private MetroFramework.Controls.MetroDateTime activitiesFromI;
        private System.Windows.Forms.Label label4;

        private MetroFramework.Controls.MetroComboBox fromYearI;
        private MetroFramework.Controls.MetroComboBox toYearI;
        private MetroFramework.Controls.MetroComboBox toMonthI;

        private MetroFramework.Controls.MetroComboBox fromMonthI;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox metroComboBox2;

        private System.Windows.Forms.Label label2;

        private MetroFramework.Controls.MetroComboBox metroComboBox1;

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar ProgressB;
        private System.Windows.Forms.Label displayT;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown delayI;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        internal System.Windows.Forms.RichTextBox DebugT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox outputCsvI;
        private MetroFramework.Controls.MetroTextBox outputPdfI;
        private MetroFramework.Controls.MetroButton loadInputB;
        private MetroFramework.Controls.MetroButton openOutputB;
        private MetroFramework.Controls.MetroButton openInputB;
        private MetroFramework.Controls.MetroButton loadOutputB;
        private MetroFramework.Controls.MetroButton startB;
        private MetroFramework.Controls.MetroCheckBox logToUII;
        private MetroFramework.Controls.MetroCheckBox logToFileI;
    }
}

