using SystemUpdateVersion.Hepler;
using SystemUpdateVersion.Models;

namespace SystemUpdateVersion
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabCMain = new System.Windows.Forms.TabControl();
            this.tabPAuthentication = new System.Windows.Forms.TabPage();
            this.groupBAuthen = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBLanguage = new System.Windows.Forms.ComboBox();
            this.labLanguage = new System.Windows.Forms.Label();
            this.comboBFactory = new System.Windows.Forms.ComboBox();
            this.labFactory = new System.Windows.Forms.Label();
            this.textBUserName = new System.Windows.Forms.TextBox();
            this.butCloseAuten = new System.Windows.Forms.Button();
            this.labUserName = new System.Windows.Forms.Label();
            this.butLogin = new System.Windows.Forms.Button();
            this.labPassword = new System.Windows.Forms.Label();
            this.textBPWD = new System.Windows.Forms.TextBox();
            this.tabPAPConfig = new System.Windows.Forms.TabPage();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.butCloseConfig = new System.Windows.Forms.Button();
            this.butAddConfig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFactory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProjectFolderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMSApConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateAPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshAPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TestFTPConnector = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPAPOperation = new System.Windows.Forms.TabPage();
            this.gBOperation = new System.Windows.Forms.GroupBox();
            this.butPool = new System.Windows.Forms.Button();
            this.checkBoxUploadLock = new System.Windows.Forms.CheckBox();
            this.checkBoxBackVersion = new System.Windows.Forms.CheckBox();
            this.checkBBackupLock = new System.Windows.Forms.CheckBox();
            this.butClose = new System.Windows.Forms.Button();
            this.cbBBackVersion = new System.Windows.Forms.ComboBox();
            this.labBackVersion = new System.Windows.Forms.Label();
            this.butBackVersion = new System.Windows.Forms.Button();
            this.labBackup = new System.Windows.Forms.Label();
            this.teBBackupDir = new System.Windows.Forms.TextBox();
            this.butBackup = new System.Windows.Forms.Button();
            this.liVFTPRes = new System.Windows.Forms.ListView();
            this.cHFTPResIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHFTPResDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHFTPResMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butDownload = new System.Windows.Forms.Button();
            this.butUpload = new System.Windows.Forms.Button();
            this.gBSelectAP = new System.Windows.Forms.GroupBox();
            this.checkBUpload = new System.Windows.Forms.CheckBox();
            this.checkBoIsSetRemotePath = new System.Windows.Forms.CheckBox();
            this.checkBBackVersion = new System.Windows.Forms.CheckBox();
            this.checkBIsFirst = new System.Windows.Forms.CheckBox();
            this.butUpdateTypeAP = new System.Windows.Forms.Button();
            this.cLBAPS = new System.Windows.Forms.CheckedListBox();
            this.labSelectAP = new System.Windows.Forms.Label();
            this.cBUpdateType = new System.Windows.Forms.ComboBox();
            this.labSelectType = new System.Windows.Forms.Label();
            this.gbLocal = new System.Windows.Forms.GroupBox();
            this.labRemote = new System.Windows.Forms.Label();
            this.teBUploadPath = new System.Windows.Forms.TextBox();
            this.butSelectFiles = new System.Windows.Forms.Button();
            this.tBMFilesPath = new System.Windows.Forms.TextBox();
            this.butSelectFolder = new System.Windows.Forms.Button();
            this.tBFolderPath = new System.Windows.Forms.TextBox();
            this.labSelectFolder = new System.Windows.Forms.Label();
            this.tabPMonitor = new System.Windows.Forms.TabPage();
            this.butOpenMonitor = new System.Windows.Forms.Button();
            this.butSaveFolderPath = new System.Windows.Forms.Button();
            this.checkBCamstarPortal = new System.Windows.Forms.CheckBox();
            this.listVCamstarPortal = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butCamstarPortal = new System.Windows.Forms.Button();
            this.textBCamstarPortal = new System.Windows.Forms.TextBox();
            this.labCamstarPortal = new System.Windows.Forms.Label();
            this.checkBCIMPDA = new System.Windows.Forms.CheckBox();
            this.listVCIMPDA = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butCIMPDA = new System.Windows.Forms.Button();
            this.textBCIMPDA = new System.Windows.Forms.TextBox();
            this.labCIMPDA = new System.Windows.Forms.Label();
            this.checkBPDA = new System.Windows.Forms.CheckBox();
            this.listVPDA = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butPDA = new System.Windows.Forms.Button();
            this.textBPDA = new System.Windows.Forms.TextBox();
            this.labPDA = new System.Windows.Forms.Label();
            this.checkBWebApi = new System.Windows.Forms.CheckBox();
            this.listVWebApi = new System.Windows.Forms.ListView();
            this.colHTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butWebApi = new System.Windows.Forms.Button();
            this.textBWebApi = new System.Windows.Forms.TextBox();
            this.labelWebApi = new System.Windows.Forms.Label();
            this.labSchedule = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labNum = new System.Windows.Forms.Label();
            this.labRole = new System.Windows.Forms.Label();
            this.labWorkNumber = new System.Windows.Forms.Label();
            this.labFactoryTag = new System.Windows.Forms.Label();
            this.labFactoryValue = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabCMain.SuspendLayout();
            this.tabPAuthentication.SuspendLayout();
            this.groupBAuthen.SuspendLayout();
            this.tabPAPConfig.SuspendLayout();
            this.gbConfig.SuspendLayout();
            this.cMSApConfig.SuspendLayout();
            this.tabPAPOperation.SuspendLayout();
            this.gBOperation.SuspendLayout();
            this.gBSelectAP.SuspendLayout();
            this.gbLocal.SuspendLayout();
            this.tabPMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCMain
            // 
            this.tabCMain.Controls.Add(this.tabPAuthentication);
            this.tabCMain.Controls.Add(this.tabPAPConfig);
            this.tabCMain.Controls.Add(this.tabPAPOperation);
            this.tabCMain.Controls.Add(this.tabPMonitor);
            this.tabCMain.Location = new System.Drawing.Point(4, 2);
            this.tabCMain.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabCMain.Name = "tabCMain";
            this.tabCMain.SelectedIndex = 0;
            this.tabCMain.Size = new System.Drawing.Size(1950, 853);
            this.tabCMain.TabIndex = 0;
            // 
            // tabPAuthentication
            // 
            this.tabPAuthentication.Controls.Add(this.groupBAuthen);
            this.tabPAuthentication.Location = new System.Drawing.Point(4, 31);
            this.tabPAuthentication.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPAuthentication.Name = "tabPAuthentication";
            this.tabPAuthentication.Size = new System.Drawing.Size(1942, 818);
            this.tabPAuthentication.TabIndex = 2;
            this.tabPAuthentication.Text = "Operation Authentication";
            this.tabPAuthentication.UseVisualStyleBackColor = true;
            // 
            // groupBAuthen
            // 
            this.groupBAuthen.Controls.Add(this.label2);
            this.groupBAuthen.Controls.Add(this.comboBLanguage);
            this.groupBAuthen.Controls.Add(this.labLanguage);
            this.groupBAuthen.Controls.Add(this.comboBFactory);
            this.groupBAuthen.Controls.Add(this.labFactory);
            this.groupBAuthen.Controls.Add(this.textBUserName);
            this.groupBAuthen.Controls.Add(this.butCloseAuten);
            this.groupBAuthen.Controls.Add(this.labUserName);
            this.groupBAuthen.Controls.Add(this.butLogin);
            this.groupBAuthen.Controls.Add(this.labPassword);
            this.groupBAuthen.Controls.Add(this.textBPWD);
            this.groupBAuthen.Location = new System.Drawing.Point(468, 145);
            this.groupBAuthen.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBAuthen.Name = "groupBAuthen";
            this.groupBAuthen.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBAuthen.Size = new System.Drawing.Size(1003, 473);
            this.groupBAuthen.TabIndex = 6;
            this.groupBAuthen.TabStop = false;
            this.groupBAuthen.Text = " 操作授权 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(777, 299);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 21);
            this.label2.TabIndex = 10;
            // 
            // comboBLanguage
            // 
            this.comboBLanguage.FormattingEnabled = true;
            this.comboBLanguage.Location = new System.Drawing.Point(356, 292);
            this.comboBLanguage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBLanguage.Name = "comboBLanguage";
            this.comboBLanguage.Size = new System.Drawing.Size(407, 29);
            this.comboBLanguage.TabIndex = 9;
            this.comboBLanguage.SelectionChangeCommitted += new System.EventHandler(this.comboBLanguage_SelectionChangeCommitted);
            // 
            // labLanguage
            // 
            this.labLanguage.Location = new System.Drawing.Point(154, 299);
            this.labLanguage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labLanguage.Name = "labLanguage";
            this.labLanguage.Size = new System.Drawing.Size(183, 21);
            this.labLanguage.TabIndex = 8;
            this.labLanguage.Text = "语言：";
            this.labLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBFactory
            // 
            this.comboBFactory.FormattingEnabled = true;
            this.comboBFactory.Location = new System.Drawing.Point(356, 215);
            this.comboBFactory.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBFactory.Name = "comboBFactory";
            this.comboBFactory.Size = new System.Drawing.Size(407, 29);
            this.comboBFactory.TabIndex = 7;
            this.comboBFactory.SelectedIndexChanged += new System.EventHandler(this.comboBFactory_SelectedIndexChanged);
            // 
            // labFactory
            // 
            this.labFactory.Location = new System.Drawing.Point(154, 221);
            this.labFactory.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labFactory.Name = "labFactory";
            this.labFactory.Size = new System.Drawing.Size(183, 21);
            this.labFactory.TabIndex = 6;
            this.labFactory.Text = "厂区：";
            this.labFactory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBUserName
            // 
            this.textBUserName.Location = new System.Drawing.Point(356, 52);
            this.textBUserName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBUserName.Name = "textBUserName";
            this.textBUserName.Size = new System.Drawing.Size(407, 31);
            this.textBUserName.TabIndex = 2;
            // 
            // butCloseAuten
            // 
            this.butCloseAuten.Location = new System.Drawing.Point(600, 383);
            this.butCloseAuten.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butCloseAuten.Name = "butCloseAuten";
            this.butCloseAuten.Size = new System.Drawing.Size(167, 37);
            this.butCloseAuten.TabIndex = 5;
            this.butCloseAuten.Text = "退出";
            this.butCloseAuten.UseVisualStyleBackColor = true;
            this.butCloseAuten.Click += new System.EventHandler(this.butCloseAuten_Click);
            // 
            // labUserName
            // 
            this.labUserName.Location = new System.Drawing.Point(154, 57);
            this.labUserName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(183, 21);
            this.labUserName.TabIndex = 0;
            this.labUserName.Text = "工号：";
            this.labUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butLogin
            // 
            this.butLogin.Location = new System.Drawing.Point(356, 383);
            this.butLogin.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(167, 37);
            this.butLogin.TabIndex = 4;
            this.butLogin.Text = "授权";
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // labPassword
            // 
            this.labPassword.Location = new System.Drawing.Point(154, 136);
            this.labPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(183, 21);
            this.labPassword.TabIndex = 1;
            this.labPassword.Text = "秘钥：";
            this.labPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBPWD
            // 
            this.textBPWD.Location = new System.Drawing.Point(356, 132);
            this.textBPWD.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBPWD.Name = "textBPWD";
            this.textBPWD.PasswordChar = '*';
            this.textBPWD.Size = new System.Drawing.Size(407, 31);
            this.textBPWD.TabIndex = 3;
            this.textBPWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBPWD_KeyPress);
            // 
            // tabPAPConfig
            // 
            this.tabPAPConfig.Controls.Add(this.gbConfig);
            this.tabPAPConfig.Controls.Add(this.listView1);
            this.tabPAPConfig.Location = new System.Drawing.Point(4, 31);
            this.tabPAPConfig.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPAPConfig.Name = "tabPAPConfig";
            this.tabPAPConfig.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPAPConfig.Size = new System.Drawing.Size(1942, 818);
            this.tabPAPConfig.TabIndex = 0;
            this.tabPAPConfig.Text = "AP Service Config";
            this.tabPAPConfig.UseVisualStyleBackColor = true;
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.butCloseConfig);
            this.gbConfig.Controls.Add(this.butAddConfig);
            this.gbConfig.Controls.Add(this.button1);
            this.gbConfig.Location = new System.Drawing.Point(11, 688);
            this.gbConfig.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbConfig.Size = new System.Drawing.Size(1919, 110);
            this.gbConfig.TabIndex = 2;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Config";
            // 
            // butCloseConfig
            // 
            this.butCloseConfig.Location = new System.Drawing.Point(1698, 40);
            this.butCloseConfig.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butCloseConfig.Name = "butCloseConfig";
            this.butCloseConfig.Size = new System.Drawing.Size(196, 42);
            this.butCloseConfig.TabIndex = 11;
            this.butCloseConfig.Text = "退出";
            this.butCloseConfig.UseVisualStyleBackColor = true;
            this.butCloseConfig.Click += new System.EventHandler(this.butCloseConfig_Click);
            // 
            // butAddConfig
            // 
            this.butAddConfig.Location = new System.Drawing.Point(308, 40);
            this.butAddConfig.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butAddConfig.Name = "butAddConfig";
            this.butAddConfig.Size = new System.Drawing.Size(262, 42);
            this.butAddConfig.TabIndex = 1;
            this.butAddConfig.Text = "添加AP配置";
            this.butAddConfig.UseVisualStyleBackColor = true;
            this.butAddConfig.Click += new System.EventHandler(this.butAddConfig_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 40);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "刷新所有AP配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.chFactory,
            this.chIP,
            this.cHPort,
            this.chType,
            this.chPath,
            this.chProjectFolderPath,
            this.chUserName,
            this.chRemarks});
            this.listView1.ContextMenuStrip = this.cMSApConfig;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1930, 676);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "NO";
            // 
            // chFactory
            // 
            this.chFactory.Text = "Factory";
            // 
            // chIP
            // 
            this.chIP.Text = "IP";
            this.chIP.Width = 140;
            // 
            // cHPort
            // 
            this.cHPort.Text = "Port";
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 120;
            // 
            // chPath
            // 
            this.chPath.Text = "Path";
            this.chPath.Width = 100;
            // 
            // chProjectFolderPath
            // 
            this.chProjectFolderPath.Text = "ProjectFolderPath";
            this.chProjectFolderPath.Width = 250;
            // 
            // chUserName
            // 
            this.chUserName.Text = "FTPUserName";
            this.chUserName.Width = 100;
            // 
            // chRemarks
            // 
            this.chRemarks.Text = "备注说明";
            this.chRemarks.Width = 120;
            // 
            // cMSApConfig
            // 
            this.cMSApConfig.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.cMSApConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateAPConfig,
            this.DeleteAPConfig,
            this.RefreshAPConfig,
            this.TestFTPConnector});
            this.cMSApConfig.Name = "cMSApConfig";
            this.cMSApConfig.Size = new System.Drawing.Size(231, 140);
            // 
            // UpdateAPConfig
            // 
            this.UpdateAPConfig.Name = "UpdateAPConfig";
            this.UpdateAPConfig.Size = new System.Drawing.Size(230, 34);
            this.UpdateAPConfig.Text = "修改数据(&U)";
            this.UpdateAPConfig.Click += new System.EventHandler(this.CMSIUpdate_Click);
            // 
            // DeleteAPConfig
            // 
            this.DeleteAPConfig.Name = "DeleteAPConfig";
            this.DeleteAPConfig.Size = new System.Drawing.Size(230, 34);
            this.DeleteAPConfig.Text = "删除数据(&D)";
            this.DeleteAPConfig.Click += new System.EventHandler(this.CMSIDelete_Click);
            // 
            // RefreshAPConfig
            // 
            this.RefreshAPConfig.Name = "RefreshAPConfig";
            this.RefreshAPConfig.Size = new System.Drawing.Size(230, 34);
            this.RefreshAPConfig.Text = "刷新数据(&F)";
            this.RefreshAPConfig.Click += new System.EventHandler(this.CMSIF_Click);
            // 
            // TestFTPConnector
            // 
            this.TestFTPConnector.Name = "TestFTPConnector";
            this.TestFTPConnector.Size = new System.Drawing.Size(230, 34);
            this.TestFTPConnector.Text = "测试FTP连接(&T)";
            this.TestFTPConnector.Click += new System.EventHandler(this.CMSTESTFTP_Click);
            // 
            // tabPAPOperation
            // 
            this.tabPAPOperation.Controls.Add(this.gBOperation);
            this.tabPAPOperation.Controls.Add(this.gBSelectAP);
            this.tabPAPOperation.Controls.Add(this.gbLocal);
            this.tabPAPOperation.Location = new System.Drawing.Point(4, 31);
            this.tabPAPOperation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPAPOperation.Name = "tabPAPOperation";
            this.tabPAPOperation.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPAPOperation.Size = new System.Drawing.Size(1942, 818);
            this.tabPAPOperation.TabIndex = 1;
            this.tabPAPOperation.Text = "AP Service Operation";
            this.tabPAPOperation.UseVisualStyleBackColor = true;
            // 
            // gBOperation
            // 
            this.gBOperation.Controls.Add(this.butPool);
            this.gBOperation.Controls.Add(this.checkBoxUploadLock);
            this.gBOperation.Controls.Add(this.checkBoxBackVersion);
            this.gBOperation.Controls.Add(this.checkBBackupLock);
            this.gBOperation.Controls.Add(this.butClose);
            this.gBOperation.Controls.Add(this.cbBBackVersion);
            this.gBOperation.Controls.Add(this.labBackVersion);
            this.gBOperation.Controls.Add(this.butBackVersion);
            this.gBOperation.Controls.Add(this.labBackup);
            this.gBOperation.Controls.Add(this.teBBackupDir);
            this.gBOperation.Controls.Add(this.butBackup);
            this.gBOperation.Controls.Add(this.liVFTPRes);
            this.gBOperation.Controls.Add(this.butDownload);
            this.gBOperation.Controls.Add(this.butUpload);
            this.gBOperation.Location = new System.Drawing.Point(901, 299);
            this.gBOperation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gBOperation.Name = "gBOperation";
            this.gBOperation.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gBOperation.Size = new System.Drawing.Size(1031, 499);
            this.gBOperation.TabIndex = 2;
            this.gBOperation.TabStop = false;
            this.gBOperation.Text = "更版操作";
            // 
            // butPool
            // 
            this.butPool.Enabled = false;
            this.butPool.Location = new System.Drawing.Point(830, 99);
            this.butPool.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butPool.Name = "butPool";
            this.butPool.Size = new System.Drawing.Size(189, 37);
            this.butPool.TabIndex = 14;
            this.butPool.Text = "回收Pool";
            this.butPool.UseVisualStyleBackColor = true;
            this.butPool.Click += new System.EventHandler(this.butPool_Click);
            // 
            // checkBoxUploadLock
            // 
            this.checkBoxUploadLock.AutoSize = true;
            this.checkBoxUploadLock.ForeColor = System.Drawing.Color.DarkOrange;
            this.checkBoxUploadLock.Location = new System.Drawing.Point(638, 102);
            this.checkBoxUploadLock.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBoxUploadLock.Name = "checkBoxUploadLock";
            this.checkBoxUploadLock.Size = new System.Drawing.Size(190, 25);
            this.checkBoxUploadLock.TabIndex = 13;
            this.checkBoxUploadLock.Text = "UploadOpenLock";
            this.checkBoxUploadLock.UseVisualStyleBackColor = true;
            // 
            // checkBoxBackVersion
            // 
            this.checkBoxBackVersion.AutoSize = true;
            this.checkBoxBackVersion.ForeColor = System.Drawing.Color.DarkOrange;
            this.checkBoxBackVersion.Location = new System.Drawing.Point(638, 166);
            this.checkBoxBackVersion.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBoxBackVersion.Name = "checkBoxBackVersion";
            this.checkBoxBackVersion.Size = new System.Drawing.Size(168, 25);
            this.checkBoxBackVersion.TabIndex = 12;
            this.checkBoxBackVersion.Text = "BackOpenLock";
            this.checkBoxBackVersion.UseVisualStyleBackColor = true;
            // 
            // checkBBackupLock
            // 
            this.checkBBackupLock.AutoSize = true;
            this.checkBBackupLock.ForeColor = System.Drawing.Color.DarkOrange;
            this.checkBBackupLock.Location = new System.Drawing.Point(638, 37);
            this.checkBBackupLock.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBBackupLock.Name = "checkBBackupLock";
            this.checkBBackupLock.Size = new System.Drawing.Size(190, 25);
            this.checkBBackupLock.TabIndex = 11;
            this.checkBBackupLock.Text = "BackupOpenLock";
            this.checkBBackupLock.UseVisualStyleBackColor = true;
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(830, 160);
            this.butClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(189, 37);
            this.butClose.TabIndex = 10;
            this.butClose.Text = "关闭程序";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // cbBBackVersion
            // 
            this.cbBBackVersion.FormattingEnabled = true;
            this.cbBBackVersion.Location = new System.Drawing.Point(384, 163);
            this.cbBBackVersion.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbBBackVersion.Name = "cbBBackVersion";
            this.cbBBackVersion.Size = new System.Drawing.Size(244, 29);
            this.cbBBackVersion.TabIndex = 1;
            this.cbBBackVersion.SelectionChangeCommitted += new System.EventHandler(this.cbBBackVersion_SelectionChangeCommitted);
            // 
            // labBackVersion
            // 
            this.labBackVersion.AutoSize = true;
            this.labBackVersion.Location = new System.Drawing.Point(231, 168);
            this.labBackVersion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labBackVersion.Name = "labBackVersion";
            this.labBackVersion.Size = new System.Drawing.Size(136, 21);
            this.labBackVersion.TabIndex = 9;
            this.labBackVersion.Text = "备份文件夹：";
            // 
            // butBackVersion
            // 
            this.butBackVersion.Location = new System.Drawing.Point(11, 162);
            this.butBackVersion.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butBackVersion.Name = "butBackVersion";
            this.butBackVersion.Size = new System.Drawing.Size(193, 37);
            this.butBackVersion.TabIndex = 8;
            this.butBackVersion.Text = "退版";
            this.butBackVersion.UseVisualStyleBackColor = true;
            this.butBackVersion.Click += new System.EventHandler(this.butBackVersion_Click);
            // 
            // labBackup
            // 
            this.labBackup.AutoSize = true;
            this.labBackup.Location = new System.Drawing.Point(230, 42);
            this.labBackup.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labBackup.Name = "labBackup";
            this.labBackup.Size = new System.Drawing.Size(136, 21);
            this.labBackup.TabIndex = 5;
            this.labBackup.Text = "备份文件夹：";
            // 
            // teBBackupDir
            // 
            this.teBBackupDir.Enabled = false;
            this.teBBackupDir.Location = new System.Drawing.Point(384, 36);
            this.teBBackupDir.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.teBBackupDir.Name = "teBBackupDir";
            this.teBBackupDir.Size = new System.Drawing.Size(244, 31);
            this.teBBackupDir.TabIndex = 7;
            // 
            // butBackup
            // 
            this.butBackup.Location = new System.Drawing.Point(11, 36);
            this.butBackup.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butBackup.Name = "butBackup";
            this.butBackup.Size = new System.Drawing.Size(193, 37);
            this.butBackup.TabIndex = 3;
            this.butBackup.Text = "备份版本";
            this.butBackup.UseVisualStyleBackColor = true;
            this.butBackup.Click += new System.EventHandler(this.butBackup_Click);
            // 
            // liVFTPRes
            // 
            this.liVFTPRes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHFTPResIP,
            this.cHFTPResDate,
            this.cHFTPResMsg});
            this.liVFTPRes.GridLines = true;
            this.liVFTPRes.HideSelection = false;
            this.liVFTPRes.Location = new System.Drawing.Point(11, 221);
            this.liVFTPRes.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.liVFTPRes.Name = "liVFTPRes";
            this.liVFTPRes.Size = new System.Drawing.Size(1008, 266);
            this.liVFTPRes.TabIndex = 2;
            this.liVFTPRes.UseCompatibleStateImageBehavior = false;
            this.liVFTPRes.View = System.Windows.Forms.View.Details;
            // 
            // cHFTPResIP
            // 
            this.cHFTPResIP.Text = "IP";
            this.cHFTPResIP.Width = 80;
            // 
            // cHFTPResDate
            // 
            this.cHFTPResDate.Text = "Date";
            this.cHFTPResDate.Width = 120;
            // 
            // cHFTPResMsg
            // 
            this.cHFTPResMsg.Text = "状态";
            this.cHFTPResMsg.Width = 320;
            // 
            // butDownload
            // 
            this.butDownload.Enabled = false;
            this.butDownload.Location = new System.Drawing.Point(830, 31);
            this.butDownload.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butDownload.Name = "butDownload";
            this.butDownload.Size = new System.Drawing.Size(189, 37);
            this.butDownload.TabIndex = 1;
            this.butDownload.Text = "下载文件";
            this.butDownload.UseVisualStyleBackColor = true;
            this.butDownload.Visible = false;
            this.butDownload.Click += new System.EventHandler(this.butDownload_Click);
            // 
            // butUpload
            // 
            this.butUpload.Location = new System.Drawing.Point(11, 99);
            this.butUpload.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butUpload.Name = "butUpload";
            this.butUpload.Size = new System.Drawing.Size(193, 37);
            this.butUpload.TabIndex = 0;
            this.butUpload.Text = "上传版本";
            this.butUpload.UseVisualStyleBackColor = true;
            this.butUpload.Click += new System.EventHandler(this.butUpload_Click);
            // 
            // gBSelectAP
            // 
            this.gBSelectAP.Controls.Add(this.checkBUpload);
            this.gBSelectAP.Controls.Add(this.checkBoIsSetRemotePath);
            this.gBSelectAP.Controls.Add(this.checkBBackVersion);
            this.gBSelectAP.Controls.Add(this.checkBIsFirst);
            this.gBSelectAP.Controls.Add(this.butUpdateTypeAP);
            this.gBSelectAP.Controls.Add(this.cLBAPS);
            this.gBSelectAP.Controls.Add(this.labSelectAP);
            this.gBSelectAP.Controls.Add(this.cBUpdateType);
            this.gBSelectAP.Controls.Add(this.labSelectType);
            this.gBSelectAP.Location = new System.Drawing.Point(11, 297);
            this.gBSelectAP.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gBSelectAP.Name = "gBSelectAP";
            this.gBSelectAP.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gBSelectAP.Size = new System.Drawing.Size(861, 499);
            this.gBSelectAP.TabIndex = 1;
            this.gBSelectAP.TabStop = false;
            this.gBSelectAP.Text = "选择AP";
            // 
            // checkBUpload
            // 
            this.checkBUpload.AutoSize = true;
            this.checkBUpload.Location = new System.Drawing.Point(15, 250);
            this.checkBUpload.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBUpload.Name = "checkBUpload";
            this.checkBUpload.Size = new System.Drawing.Size(162, 25);
            this.checkBUpload.TabIndex = 9;
            this.checkBUpload.Text = "单独上传版本";
            this.checkBUpload.UseVisualStyleBackColor = true;
            this.checkBUpload.CheckedChanged += new System.EventHandler(this.checkBUpload_CheckedChanged);
            // 
            // checkBoIsSetRemotePath
            // 
            this.checkBoIsSetRemotePath.AutoSize = true;
            this.checkBoIsSetRemotePath.Checked = true;
            this.checkBoIsSetRemotePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoIsSetRemotePath.Location = new System.Drawing.Point(15, 205);
            this.checkBoIsSetRemotePath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBoIsSetRemotePath.Name = "checkBoIsSetRemotePath";
            this.checkBoIsSetRemotePath.Size = new System.Drawing.Size(246, 25);
            this.checkBoIsSetRemotePath.TabIndex = 8;
            this.checkBoIsSetRemotePath.Text = "是否独立设置远程路径";
            this.checkBoIsSetRemotePath.UseVisualStyleBackColor = true;
            this.checkBoIsSetRemotePath.CheckedChanged += new System.EventHandler(this.checkBoIsSetRemotePath_CheckedChanged_1);
            // 
            // checkBBackVersion
            // 
            this.checkBBackVersion.AutoSize = true;
            this.checkBBackVersion.Location = new System.Drawing.Point(15, 160);
            this.checkBBackVersion.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBBackVersion.Name = "checkBBackVersion";
            this.checkBBackVersion.Size = new System.Drawing.Size(162, 25);
            this.checkBBackVersion.TabIndex = 7;
            this.checkBBackVersion.Text = "单独进行退版";
            this.checkBBackVersion.UseVisualStyleBackColor = true;
            this.checkBBackVersion.CheckedChanged += new System.EventHandler(this.checkBBackVersion_CheckedChanged);
            // 
            // checkBIsFirst
            // 
            this.checkBIsFirst.AutoSize = true;
            this.checkBIsFirst.Location = new System.Drawing.Point(15, 108);
            this.checkBIsFirst.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBIsFirst.Name = "checkBIsFirst";
            this.checkBIsFirst.Size = new System.Drawing.Size(246, 25);
            this.checkBIsFirst.TabIndex = 6;
            this.checkBIsFirst.Text = "是否首次上传更版文件";
            this.checkBIsFirst.UseVisualStyleBackColor = true;
            this.checkBIsFirst.CheckedChanged += new System.EventHandler(this.checkBIsFirst_CheckedChanged);
            // 
            // butUpdateTypeAP
            // 
            this.butUpdateTypeAP.Location = new System.Drawing.Point(605, 34);
            this.butUpdateTypeAP.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butUpdateTypeAP.Name = "butUpdateTypeAP";
            this.butUpdateTypeAP.Size = new System.Drawing.Size(235, 37);
            this.butUpdateTypeAP.TabIndex = 4;
            this.butUpdateTypeAP.Text = "查询TypeAP";
            this.butUpdateTypeAP.UseVisualStyleBackColor = true;
            this.butUpdateTypeAP.Click += new System.EventHandler(this.butUpdateTypeAP_Click);
            // 
            // cLBAPS
            // 
            this.cLBAPS.FormattingEnabled = true;
            this.cLBAPS.Location = new System.Drawing.Point(537, 108);
            this.cLBAPS.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cLBAPS.Name = "cLBAPS";
            this.cLBAPS.Size = new System.Drawing.Size(303, 340);
            this.cLBAPS.TabIndex = 3;
            this.cLBAPS.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cLBAPS_ItemCheck);
            // 
            // labSelectAP
            // 
            this.labSelectAP.Location = new System.Drawing.Point(330, 110);
            this.labSelectAP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labSelectAP.Name = "labSelectAP";
            this.labSelectAP.Size = new System.Drawing.Size(202, 21);
            this.labSelectAP.TabIndex = 2;
            this.labSelectAP.Text = "选择更版AP：";
            this.labSelectAP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cBUpdateType
            // 
            this.cBUpdateType.FormattingEnabled = true;
            this.cBUpdateType.Items.AddRange(new object[] {
            "**请选择更版类型**",
            "WebApi",
            "PDA",
            "CIMPDA",
            "CamstarPortal"});
            this.cBUpdateType.Location = new System.Drawing.Point(247, 41);
            this.cBUpdateType.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cBUpdateType.Name = "cBUpdateType";
            this.cBUpdateType.Size = new System.Drawing.Size(315, 29);
            this.cBUpdateType.TabIndex = 1;
            // 
            // labSelectType
            // 
            this.labSelectType.Location = new System.Drawing.Point(1, 47);
            this.labSelectType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labSelectType.Name = "labSelectType";
            this.labSelectType.Size = new System.Drawing.Size(237, 21);
            this.labSelectType.TabIndex = 0;
            this.labSelectType.Text = "选择更版类型：";
            this.labSelectType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbLocal
            // 
            this.gbLocal.Controls.Add(this.labRemote);
            this.gbLocal.Controls.Add(this.teBUploadPath);
            this.gbLocal.Controls.Add(this.butSelectFiles);
            this.gbLocal.Controls.Add(this.tBMFilesPath);
            this.gbLocal.Controls.Add(this.butSelectFolder);
            this.gbLocal.Controls.Add(this.tBFolderPath);
            this.gbLocal.Controls.Add(this.labSelectFolder);
            this.gbLocal.Location = new System.Drawing.Point(11, 10);
            this.gbLocal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbLocal.Name = "gbLocal";
            this.gbLocal.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbLocal.Size = new System.Drawing.Size(1922, 278);
            this.gbLocal.TabIndex = 0;
            this.gbLocal.TabStop = false;
            this.gbLocal.Text = "本地文件";
            // 
            // labRemote
            // 
            this.labRemote.AutoSize = true;
            this.labRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRemote.ForeColor = System.Drawing.Color.Red;
            this.labRemote.Location = new System.Drawing.Point(1300, 44);
            this.labRemote.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labRemote.Name = "labRemote";
            this.labRemote.Size = new System.Drawing.Size(446, 20);
            this.labRemote.TabIndex = 6;
            this.labRemote.Text = "左侧待上传文件对应远程目录(远程必须存在该路径文件夹)";
            // 
            // teBUploadPath
            // 
            this.teBUploadPath.Location = new System.Drawing.Point(1298, 87);
            this.teBUploadPath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.teBUploadPath.Multiline = true;
            this.teBUploadPath.Name = "teBUploadPath";
            this.teBUploadPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.teBUploadPath.Size = new System.Drawing.Size(593, 178);
            this.teBUploadPath.TabIndex = 5;
            // 
            // butSelectFiles
            // 
            this.butSelectFiles.Location = new System.Drawing.Point(997, 36);
            this.butSelectFiles.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butSelectFiles.Name = "butSelectFiles";
            this.butSelectFiles.Size = new System.Drawing.Size(260, 37);
            this.butSelectFiles.TabIndex = 4;
            this.butSelectFiles.Text = "扫描全部更版文件";
            this.butSelectFiles.UseVisualStyleBackColor = true;
            this.butSelectFiles.Click += new System.EventHandler(this.butSelectFiles_Click);
            // 
            // tBMFilesPath
            // 
            this.tBMFilesPath.Location = new System.Drawing.Point(16, 87);
            this.tBMFilesPath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tBMFilesPath.Multiline = true;
            this.tBMFilesPath.Name = "tBMFilesPath";
            this.tBMFilesPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBMFilesPath.Size = new System.Drawing.Size(1241, 178);
            this.tBMFilesPath.TabIndex = 3;
            // 
            // butSelectFolder
            // 
            this.butSelectFolder.Location = new System.Drawing.Point(792, 36);
            this.butSelectFolder.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butSelectFolder.Name = "butSelectFolder";
            this.butSelectFolder.Size = new System.Drawing.Size(167, 37);
            this.butSelectFolder.TabIndex = 2;
            this.butSelectFolder.Text = "选择文件夹";
            this.butSelectFolder.UseVisualStyleBackColor = true;
            this.butSelectFolder.Click += new System.EventHandler(this.butSelectFolder_Click);
            // 
            // tBFolderPath
            // 
            this.tBFolderPath.Location = new System.Drawing.Point(220, 39);
            this.tBFolderPath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tBFolderPath.Name = "tBFolderPath";
            this.tBFolderPath.Size = new System.Drawing.Size(548, 31);
            this.tBFolderPath.TabIndex = 1;
            // 
            // labSelectFolder
            // 
            this.labSelectFolder.AutoSize = true;
            this.labSelectFolder.Location = new System.Drawing.Point(11, 44);
            this.labSelectFolder.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labSelectFolder.Name = "labSelectFolder";
            this.labSelectFolder.Size = new System.Drawing.Size(178, 21);
            this.labSelectFolder.TabIndex = 0;
            this.labSelectFolder.Text = "选择更版文件夹：";
            // 
            // tabPMonitor
            // 
            this.tabPMonitor.Controls.Add(this.butOpenMonitor);
            this.tabPMonitor.Controls.Add(this.butSaveFolderPath);
            this.tabPMonitor.Controls.Add(this.checkBCamstarPortal);
            this.tabPMonitor.Controls.Add(this.listVCamstarPortal);
            this.tabPMonitor.Controls.Add(this.butCamstarPortal);
            this.tabPMonitor.Controls.Add(this.textBCamstarPortal);
            this.tabPMonitor.Controls.Add(this.labCamstarPortal);
            this.tabPMonitor.Controls.Add(this.checkBCIMPDA);
            this.tabPMonitor.Controls.Add(this.listVCIMPDA);
            this.tabPMonitor.Controls.Add(this.butCIMPDA);
            this.tabPMonitor.Controls.Add(this.textBCIMPDA);
            this.tabPMonitor.Controls.Add(this.labCIMPDA);
            this.tabPMonitor.Controls.Add(this.checkBPDA);
            this.tabPMonitor.Controls.Add(this.listVPDA);
            this.tabPMonitor.Controls.Add(this.butPDA);
            this.tabPMonitor.Controls.Add(this.textBPDA);
            this.tabPMonitor.Controls.Add(this.labPDA);
            this.tabPMonitor.Controls.Add(this.checkBWebApi);
            this.tabPMonitor.Controls.Add(this.listVWebApi);
            this.tabPMonitor.Controls.Add(this.butWebApi);
            this.tabPMonitor.Controls.Add(this.textBWebApi);
            this.tabPMonitor.Controls.Add(this.labelWebApi);
            this.tabPMonitor.Location = new System.Drawing.Point(4, 31);
            this.tabPMonitor.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPMonitor.Name = "tabPMonitor";
            this.tabPMonitor.Size = new System.Drawing.Size(1942, 818);
            this.tabPMonitor.TabIndex = 3;
            this.tabPMonitor.Text = "AP Version Monitor";
            this.tabPMonitor.UseVisualStyleBackColor = true;
            // 
            // butOpenMonitor
            // 
            this.butOpenMonitor.Location = new System.Drawing.Point(343, 721);
            this.butOpenMonitor.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butOpenMonitor.Name = "butOpenMonitor";
            this.butOpenMonitor.Size = new System.Drawing.Size(258, 37);
            this.butOpenMonitor.TabIndex = 40;
            this.butOpenMonitor.Text = "批量开启监控";
            this.butOpenMonitor.UseVisualStyleBackColor = true;
            this.butOpenMonitor.Click += new System.EventHandler(this.butOpenMonitor_Click);
            // 
            // butSaveFolderPath
            // 
            this.butSaveFolderPath.Location = new System.Drawing.Point(16, 721);
            this.butSaveFolderPath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butSaveFolderPath.Name = "butSaveFolderPath";
            this.butSaveFolderPath.Size = new System.Drawing.Size(271, 37);
            this.butSaveFolderPath.TabIndex = 38;
            this.butSaveFolderPath.Text = " Save FolderPath Config";
            this.butSaveFolderPath.UseVisualStyleBackColor = true;
            this.butSaveFolderPath.Click += new System.EventHandler(this.butSaveFolderPath_Click);
            // 
            // checkBCamstarPortal
            // 
            this.checkBCamstarPortal.AutoSize = true;
            this.checkBCamstarPortal.Checked = true;
            this.checkBCamstarPortal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBCamstarPortal.Location = new System.Drawing.Point(1733, 354);
            this.checkBCamstarPortal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBCamstarPortal.Name = "checkBCamstarPortal";
            this.checkBCamstarPortal.Size = new System.Drawing.Size(120, 25);
            this.checkBCamstarPortal.TabIndex = 37;
            this.checkBCamstarPortal.Text = "开启回收";
            this.checkBCamstarPortal.UseVisualStyleBackColor = true;
            // 
            // listVCamstarPortal
            // 
            this.listVCamstarPortal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listVCamstarPortal.GridLines = true;
            this.listVCamstarPortal.HideSelection = false;
            this.listVCamstarPortal.Location = new System.Drawing.Point(967, 394);
            this.listVCamstarPortal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listVCamstarPortal.Name = "listVCamstarPortal";
            this.listVCamstarPortal.Size = new System.Drawing.Size(920, 213);
            this.listVCamstarPortal.TabIndex = 36;
            this.listVCamstarPortal.UseCompatibleStateImageBehavior = false;
            this.listVCamstarPortal.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "时间";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "状态";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "消息";
            this.columnHeader6.Width = 600;
            // 
            // butCamstarPortal
            // 
            this.butCamstarPortal.Location = new System.Drawing.Point(1536, 348);
            this.butCamstarPortal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butCamstarPortal.Name = "butCamstarPortal";
            this.butCamstarPortal.Size = new System.Drawing.Size(174, 36);
            this.butCamstarPortal.TabIndex = 35;
            this.butCamstarPortal.Text = "选择目录";
            this.butCamstarPortal.UseVisualStyleBackColor = true;
            this.butCamstarPortal.Click += new System.EventHandler(this.butCamstarPortal_Click);
            // 
            // textBCamstarPortal
            // 
            this.textBCamstarPortal.Location = new System.Drawing.Point(1047, 351);
            this.textBCamstarPortal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBCamstarPortal.Name = "textBCamstarPortal";
            this.textBCamstarPortal.Size = new System.Drawing.Size(481, 31);
            this.textBCamstarPortal.TabIndex = 34;
            // 
            // labCamstarPortal
            // 
            this.labCamstarPortal.AutoSize = true;
            this.labCamstarPortal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCamstarPortal.Location = new System.Drawing.Point(970, 349);
            this.labCamstarPortal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labCamstarPortal.Name = "labCamstarPortal";
            this.labCamstarPortal.Size = new System.Drawing.Size(78, 48);
            this.labCamstarPortal.TabIndex = 33;
            this.labCamstarPortal.Text = "Camstar\r\nPortal";
            // 
            // checkBCIMPDA
            // 
            this.checkBCIMPDA.AutoSize = true;
            this.checkBCIMPDA.Checked = true;
            this.checkBCIMPDA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBCIMPDA.Location = new System.Drawing.Point(778, 355);
            this.checkBCIMPDA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBCIMPDA.Name = "checkBCIMPDA";
            this.checkBCIMPDA.Size = new System.Drawing.Size(120, 25);
            this.checkBCIMPDA.TabIndex = 32;
            this.checkBCIMPDA.Text = "开启回收";
            this.checkBCIMPDA.UseVisualStyleBackColor = true;
            // 
            // listVCIMPDA
            // 
            this.listVCIMPDA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listVCIMPDA.GridLines = true;
            this.listVCIMPDA.HideSelection = false;
            this.listVCIMPDA.Location = new System.Drawing.Point(16, 396);
            this.listVCIMPDA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listVCIMPDA.Name = "listVCIMPDA";
            this.listVCIMPDA.Size = new System.Drawing.Size(905, 211);
            this.listVCIMPDA.TabIndex = 31;
            this.listVCIMPDA.UseCompatibleStateImageBehavior = false;
            this.listVCIMPDA.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "时间";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "状态";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "消息";
            this.columnHeader9.Width = 600;
            // 
            // butCIMPDA
            // 
            this.butCIMPDA.Location = new System.Drawing.Point(592, 350);
            this.butCIMPDA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butCIMPDA.Name = "butCIMPDA";
            this.butCIMPDA.Size = new System.Drawing.Size(174, 37);
            this.butCIMPDA.TabIndex = 30;
            this.butCIMPDA.Text = "选择目录";
            this.butCIMPDA.UseVisualStyleBackColor = true;
            this.butCIMPDA.Click += new System.EventHandler(this.butCIMPDA_Click);
            // 
            // textBCIMPDA
            // 
            this.textBCIMPDA.Location = new System.Drawing.Point(99, 351);
            this.textBCIMPDA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBCIMPDA.Name = "textBCIMPDA";
            this.textBCIMPDA.Size = new System.Drawing.Size(481, 31);
            this.textBCIMPDA.TabIndex = 29;
            // 
            // labCIMPDA
            // 
            this.labCIMPDA.AutoSize = true;
            this.labCIMPDA.Location = new System.Drawing.Point(6, 357);
            this.labCIMPDA.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labCIMPDA.Name = "labCIMPDA";
            this.labCIMPDA.Size = new System.Drawing.Size(87, 21);
            this.labCIMPDA.TabIndex = 28;
            this.labCIMPDA.Text = "CIMPDA:";
            // 
            // checkBPDA
            // 
            this.checkBPDA.AutoSize = true;
            this.checkBPDA.Checked = true;
            this.checkBPDA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBPDA.Location = new System.Drawing.Point(1733, 32);
            this.checkBPDA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBPDA.Name = "checkBPDA";
            this.checkBPDA.Size = new System.Drawing.Size(120, 25);
            this.checkBPDA.TabIndex = 27;
            this.checkBPDA.Text = "开启回收";
            this.checkBPDA.UseVisualStyleBackColor = true;
            // 
            // listVPDA
            // 
            this.listVPDA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listVPDA.GridLines = true;
            this.listVPDA.HideSelection = false;
            this.listVPDA.Location = new System.Drawing.Point(967, 73);
            this.listVPDA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listVPDA.Name = "listVPDA";
            this.listVPDA.Size = new System.Drawing.Size(920, 210);
            this.listVPDA.TabIndex = 26;
            this.listVPDA.UseCompatibleStateImageBehavior = false;
            this.listVPDA.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "状态";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "消息";
            this.columnHeader3.Width = 600;
            // 
            // butPDA
            // 
            this.butPDA.Location = new System.Drawing.Point(1537, 27);
            this.butPDA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butPDA.Name = "butPDA";
            this.butPDA.Size = new System.Drawing.Size(174, 36);
            this.butPDA.TabIndex = 25;
            this.butPDA.Text = "选择目录";
            this.butPDA.UseVisualStyleBackColor = true;
            this.butPDA.Click += new System.EventHandler(this.butPDA_Click);
            // 
            // textBPDA
            // 
            this.textBPDA.Location = new System.Drawing.Point(1047, 29);
            this.textBPDA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBPDA.Name = "textBPDA";
            this.textBPDA.Size = new System.Drawing.Size(481, 31);
            this.textBPDA.TabIndex = 24;
            // 
            // labPDA
            // 
            this.labPDA.AutoSize = true;
            this.labPDA.Location = new System.Drawing.Point(970, 34);
            this.labPDA.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labPDA.Name = "labPDA";
            this.labPDA.Size = new System.Drawing.Size(54, 21);
            this.labPDA.TabIndex = 23;
            this.labPDA.Text = "PDA:";
            // 
            // checkBWebApi
            // 
            this.checkBWebApi.AutoSize = true;
            this.checkBWebApi.Checked = true;
            this.checkBWebApi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBWebApi.Location = new System.Drawing.Point(783, 34);
            this.checkBWebApi.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBWebApi.Name = "checkBWebApi";
            this.checkBWebApi.Size = new System.Drawing.Size(120, 25);
            this.checkBWebApi.TabIndex = 22;
            this.checkBWebApi.Text = "开启回收";
            this.checkBWebApi.UseVisualStyleBackColor = true;
            // 
            // listVWebApi
            // 
            this.listVWebApi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHTime,
            this.colHStatus,
            this.colHMsg});
            this.listVWebApi.GridLines = true;
            this.listVWebApi.HideSelection = false;
            this.listVWebApi.Location = new System.Drawing.Point(16, 74);
            this.listVWebApi.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listVWebApi.Name = "listVWebApi";
            this.listVWebApi.Size = new System.Drawing.Size(905, 209);
            this.listVWebApi.TabIndex = 19;
            this.listVWebApi.UseCompatibleStateImageBehavior = false;
            this.listVWebApi.View = System.Windows.Forms.View.Details;
            // 
            // colHTime
            // 
            this.colHTime.Text = "时间";
            this.colHTime.Width = 120;
            // 
            // colHStatus
            // 
            this.colHStatus.Text = "状态";
            // 
            // colHMsg
            // 
            this.colHMsg.Text = "消息";
            this.colHMsg.Width = 600;
            // 
            // butWebApi
            // 
            this.butWebApi.Location = new System.Drawing.Point(592, 28);
            this.butWebApi.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butWebApi.Name = "butWebApi";
            this.butWebApi.Size = new System.Drawing.Size(168, 37);
            this.butWebApi.TabIndex = 13;
            this.butWebApi.Text = "选择目录";
            this.butWebApi.UseVisualStyleBackColor = true;
            this.butWebApi.Click += new System.EventHandler(this.butWebApi_Click);
            // 
            // textBWebApi
            // 
            this.textBWebApi.Location = new System.Drawing.Point(99, 31);
            this.textBWebApi.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBWebApi.Name = "textBWebApi";
            this.textBWebApi.Size = new System.Drawing.Size(481, 31);
            this.textBWebApi.TabIndex = 7;
            // 
            // labelWebApi
            // 
            this.labelWebApi.AutoSize = true;
            this.labelWebApi.Location = new System.Drawing.Point(6, 36);
            this.labelWebApi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelWebApi.Name = "labelWebApi";
            this.labelWebApi.Size = new System.Drawing.Size(87, 21);
            this.labelWebApi.TabIndex = 0;
            this.labelWebApi.Text = "WebApi:";
            // 
            // labSchedule
            // 
            this.labSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSchedule.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labSchedule.Location = new System.Drawing.Point(1452, 855);
            this.labSchedule.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labSchedule.Name = "labSchedule";
            this.labSchedule.Size = new System.Drawing.Size(183, 21);
            this.labSchedule.TabIndex = 1;
            this.labSchedule.Text = "进度:";
            this.labSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(1642, 859);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(262, 16);
            this.progressBar.TabIndex = 2;
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNum.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labNum.Location = new System.Drawing.Point(1910, 856);
            this.labNum.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(33, 20);
            this.labNum.TabIndex = 3;
            this.labNum.Text = "0%";
            // 
            // labRole
            // 
            this.labRole.AutoSize = true;
            this.labRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRole.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labRole.Location = new System.Drawing.Point(37, 855);
            this.labRole.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labRole.Name = "labRole";
            this.labRole.Size = new System.Drawing.Size(48, 20);
            this.labRole.TabIndex = 4;
            this.labRole.Text = "工号:";
            // 
            // labWorkNumber
            // 
            this.labWorkNumber.AutoSize = true;
            this.labWorkNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWorkNumber.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labWorkNumber.Location = new System.Drawing.Point(152, 855);
            this.labWorkNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labWorkNumber.Name = "labWorkNumber";
            this.labWorkNumber.Size = new System.Drawing.Size(0, 20);
            this.labWorkNumber.TabIndex = 5;
            // 
            // labFactoryTag
            // 
            this.labFactoryTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFactoryTag.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labFactoryTag.Location = new System.Drawing.Point(297, 855);
            this.labFactoryTag.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labFactoryTag.Name = "labFactoryTag";
            this.labFactoryTag.Size = new System.Drawing.Size(128, 21);
            this.labFactoryTag.TabIndex = 6;
            this.labFactoryTag.Text = "Factory:";
            this.labFactoryTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labFactoryValue
            // 
            this.labFactoryValue.AutoSize = true;
            this.labFactoryValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFactoryValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labFactoryValue.Location = new System.Drawing.Point(433, 856);
            this.labFactoryValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labFactoryValue.Name = "labFactoryValue";
            this.labFactoryValue.Size = new System.Drawing.Size(0, 20);
            this.labFactoryValue.TabIndex = 7;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "更版监控";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1956, 892);
            this.Controls.Add(this.labFactoryValue);
            this.Controls.Add(this.labFactoryTag);
            this.Controls.Add(this.labWorkNumber);
            this.Controls.Add(this.labRole);
            this.Controls.Add(this.labNum);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labSchedule);
            this.Controls.Add(this.tabCMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.tabCMain.ResumeLayout(false);
            this.tabPAuthentication.ResumeLayout(false);
            this.groupBAuthen.ResumeLayout(false);
            this.groupBAuthen.PerformLayout();
            this.tabPAPConfig.ResumeLayout(false);
            this.gbConfig.ResumeLayout(false);
            this.cMSApConfig.ResumeLayout(false);
            this.tabPAPOperation.ResumeLayout(false);
            this.gBOperation.ResumeLayout(false);
            this.gBOperation.PerformLayout();
            this.gBSelectAP.ResumeLayout(false);
            this.gBSelectAP.PerformLayout();
            this.gbLocal.ResumeLayout(false);
            this.gbLocal.PerformLayout();
            this.tabPMonitor.ResumeLayout(false);
            this.tabPMonitor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCMain;
        private System.Windows.Forms.TabPage tabPAPConfig;
        private System.Windows.Forms.TabPage tabPAPOperation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chPath;
        private System.Windows.Forms.ColumnHeader chUserName;
        private System.Windows.Forms.ColumnHeader chRemarks;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.Button butAddConfig;
        private System.Windows.Forms.GroupBox gbLocal;
        private System.Windows.Forms.Button butSelectFolder;
        private System.Windows.Forms.TextBox tBFolderPath;
        private System.Windows.Forms.Label labSelectFolder;
        private System.Windows.Forms.TextBox tBMFilesPath;
        private System.Windows.Forms.Button butSelectFiles;
        private System.Windows.Forms.GroupBox gBSelectAP;
        private System.Windows.Forms.ComboBox cBUpdateType;
        private System.Windows.Forms.Label labSelectType;
        private System.Windows.Forms.CheckedListBox cLBAPS;
        private System.Windows.Forms.Label labSelectAP;
        private System.Windows.Forms.Button butUpdateTypeAP;
        private System.Windows.Forms.GroupBox gBOperation;
        private System.Windows.Forms.Button butDownload;
        private System.Windows.Forms.Button butUpload;
        private System.Windows.Forms.ColumnHeader cHPort;
        private System.Windows.Forms.ListView liVFTPRes;
        private System.Windows.Forms.ColumnHeader cHFTPResDate;
        private System.Windows.Forms.ColumnHeader cHFTPResIP;
        private System.Windows.Forms.ColumnHeader cHFTPResMsg;
        private System.Windows.Forms.TextBox teBUploadPath;
        private System.Windows.Forms.Label labRemote;
        private System.Windows.Forms.Button butBackup;
        private System.Windows.Forms.Label labBackup;
        private System.Windows.Forms.TextBox teBBackupDir;
        private System.Windows.Forms.Button butBackVersion;
        private System.Windows.Forms.ComboBox cbBBackVersion;
        private System.Windows.Forms.Label labBackVersion;
        private System.Windows.Forms.ContextMenuStrip cMSApConfig;
        private System.Windows.Forms.ToolStripMenuItem UpdateAPConfig;
        private System.Windows.Forms.ToolStripMenuItem DeleteAPConfig;
        private System.Windows.Forms.ToolStripMenuItem RefreshAPConfig;
        private System.Windows.Forms.CheckBox checkBIsFirst;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butCloseConfig;
        private System.Windows.Forms.TabPage tabPAuthentication;
        private System.Windows.Forms.GroupBox groupBAuthen;
        private System.Windows.Forms.TextBox textBUserName;
        private System.Windows.Forms.Button butCloseAuten;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.TextBox textBPWD;
        private System.Windows.Forms.CheckBox checkBoxUploadLock;
        private System.Windows.Forms.CheckBox checkBoxBackVersion;
        private System.Windows.Forms.CheckBox checkBBackupLock;
        private System.Windows.Forms.Label labSchedule;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.Label labRole;
        private System.Windows.Forms.Label labWorkNumber;
        private System.Windows.Forms.CheckBox checkBBackVersion;
        private System.Windows.Forms.Label labFactory;
        private System.Windows.Forms.ComboBox comboBFactory;
        private System.Windows.Forms.Label labFactoryTag;
        private System.Windows.Forms.Label labFactoryValue;
        private System.Windows.Forms.ColumnHeader chFactory;
        private System.Windows.Forms.ColumnHeader chProjectFolderPath;
        private System.Windows.Forms.CheckBox checkBoIsSetRemotePath;
        private System.Windows.Forms.TabPage tabPMonitor;
        private System.Windows.Forms.CheckBox checkBWebApi;
        private System.Windows.Forms.ListView listVWebApi;
        private System.Windows.Forms.Button butWebApi;
        private System.Windows.Forms.TextBox textBWebApi;
        private System.Windows.Forms.Label labelWebApi;
        private System.Windows.Forms.ColumnHeader colHTime;
        private System.Windows.Forms.ColumnHeader colHStatus;
        private System.Windows.Forms.ColumnHeader colHMsg;
        private System.Windows.Forms.CheckBox checkBCamstarPortal;
        private System.Windows.Forms.ListView listVCamstarPortal;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button butCamstarPortal;
        private System.Windows.Forms.TextBox textBCamstarPortal;
        private System.Windows.Forms.Label labCamstarPortal;
        private System.Windows.Forms.CheckBox checkBCIMPDA;
        private System.Windows.Forms.ListView listVCIMPDA;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button butCIMPDA;
        private System.Windows.Forms.TextBox textBCIMPDA;
        private System.Windows.Forms.Label labCIMPDA;
        private System.Windows.Forms.CheckBox checkBPDA;
        private System.Windows.Forms.ListView listVPDA;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button butPDA;
        private System.Windows.Forms.TextBox textBPDA;
        private System.Windows.Forms.Label labPDA;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button butPool;
        private System.Windows.Forms.Button butSaveFolderPath;
        private System.Windows.Forms.ToolStripMenuItem TestFTPConnector;
        private System.Windows.Forms.Button butOpenMonitor;
        private System.Windows.Forms.ComboBox comboBLanguage;
        private System.Windows.Forms.Label labLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBUpload;
    }
}

