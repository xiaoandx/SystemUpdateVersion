﻿namespace SystemUpdateVersion.FormModels
{
    partial class UpdateAPConfig
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
            this.labUpdateIP = new System.Windows.Forms.Label();
            this.labUpdatePort = new System.Windows.Forms.Label();
            this.labUpdateType = new System.Windows.Forms.Label();
            this.labBasePath = new System.Windows.Forms.Label();
            this.labUpdateFTPUserName = new System.Windows.Forms.Label();
            this.labUpdateFTPPassWord = new System.Windows.Forms.Label();
            this.labUpdateRemarks = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butCreate = new System.Windows.Forms.Button();
            this.textRe = new System.Windows.Forms.TextBox();
            this.textPW = new System.Windows.Forms.TextBox();
            this.comboBType = new System.Windows.Forms.ComboBox();
            this.textBIP = new System.Windows.Forms.TextBox();
            this.textBPort = new System.Windows.Forms.TextBox();
            this.textBPath = new System.Windows.Forms.TextBox();
            this.textUN = new System.Windows.Forms.TextBox();
            this.comboBUpdateFactory = new System.Windows.Forms.ComboBox();
            this.labUpdateFactory = new System.Windows.Forms.Label();
            this.textBUpdateFolderPath = new System.Windows.Forms.TextBox();
            this.labUpdateFolderPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labUpdateIP
            // 
            this.labUpdateIP.AutoSize = true;
            this.labUpdateIP.Location = new System.Drawing.Point(92, 63);
            this.labUpdateIP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUpdateIP.Name = "labUpdateIP";
            this.labUpdateIP.Size = new System.Drawing.Size(75, 21);
            this.labUpdateIP.TabIndex = 0;
            this.labUpdateIP.Text = "* IP：";
            // 
            // labUpdatePort
            // 
            this.labUpdatePort.AutoSize = true;
            this.labUpdatePort.Location = new System.Drawing.Point(75, 221);
            this.labUpdatePort.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUpdatePort.Name = "labUpdatePort";
            this.labUpdatePort.Size = new System.Drawing.Size(97, 21);
            this.labUpdatePort.TabIndex = 1;
            this.labUpdatePort.Text = "* Port：";
            // 
            // labUpdateType
            // 
            this.labUpdateType.AutoSize = true;
            this.labUpdateType.Location = new System.Drawing.Point(66, 300);
            this.labUpdateType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUpdateType.Name = "labUpdateType";
            this.labUpdateType.Size = new System.Drawing.Size(97, 21);
            this.labUpdateType.TabIndex = 2;
            this.labUpdateType.Text = "* Type：";
            // 
            // labBasePath
            // 
            this.labBasePath.AutoSize = true;
            this.labBasePath.Location = new System.Drawing.Point(26, 380);
            this.labBasePath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labBasePath.Name = "labBasePath";
            this.labBasePath.Size = new System.Drawing.Size(141, 21);
            this.labBasePath.TabIndex = 3;
            this.labBasePath.Text = "* BasePath：";
            // 
            // labUpdateFTPUserName
            // 
            this.labUpdateFTPUserName.AutoSize = true;
            this.labUpdateFTPUserName.Location = new System.Drawing.Point(18, 538);
            this.labUpdateFTPUserName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUpdateFTPUserName.Name = "labUpdateFTPUserName";
            this.labUpdateFTPUserName.Size = new System.Drawing.Size(141, 21);
            this.labUpdateFTPUserName.TabIndex = 4;
            this.labUpdateFTPUserName.Text = "* UserName：";
            // 
            // labUpdateFTPPassWord
            // 
            this.labUpdateFTPPassWord.AutoSize = true;
            this.labUpdateFTPPassWord.Location = new System.Drawing.Point(20, 617);
            this.labUpdateFTPPassWord.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUpdateFTPPassWord.Name = "labUpdateFTPPassWord";
            this.labUpdateFTPPassWord.Size = new System.Drawing.Size(141, 21);
            this.labUpdateFTPPassWord.TabIndex = 5;
            this.labUpdateFTPPassWord.Text = "* PassWord：";
            // 
            // labUpdateRemarks
            // 
            this.labUpdateRemarks.AutoSize = true;
            this.labUpdateRemarks.Location = new System.Drawing.Point(66, 696);
            this.labUpdateRemarks.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUpdateRemarks.Name = "labUpdateRemarks";
            this.labUpdateRemarks.Size = new System.Drawing.Size(95, 21);
            this.labUpdateRemarks.TabIndex = 6;
            this.labUpdateRemarks.Text = "* 备注：";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(374, 761);
            this.butCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(138, 37);
            this.butCancel.TabIndex = 7;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(207, 761);
            this.butCreate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(138, 37);
            this.butCreate.TabIndex = 8;
            this.butCreate.Text = "Save";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click_1);
            // 
            // textRe
            // 
            this.textRe.Location = new System.Drawing.Point(161, 693);
            this.textRe.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textRe.Name = "textRe";
            this.textRe.Size = new System.Drawing.Size(347, 31);
            this.textRe.TabIndex = 9;
            this.textRe.TextChanged += new System.EventHandler(this.textRe_TextChanged);
            // 
            // textPW
            // 
            this.textPW.Location = new System.Drawing.Point(161, 614);
            this.textPW.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textPW.Name = "textPW";
            this.textPW.Size = new System.Drawing.Size(347, 31);
            this.textPW.TabIndex = 10;
            // 
            // comboBType
            // 
            this.comboBType.Enabled = false;
            this.comboBType.FormattingEnabled = true;
            this.comboBType.Items.AddRange(new object[] {
            "**请选择更版类型**",
            "WebApi",
            "PDA",
            "CIMPDA",
            "CamstarPortal"});
            this.comboBType.Location = new System.Drawing.Point(161, 296);
            this.comboBType.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBType.Name = "comboBType";
            this.comboBType.Size = new System.Drawing.Size(347, 29);
            this.comboBType.TabIndex = 11;
            // 
            // textBIP
            // 
            this.textBIP.Enabled = false;
            this.textBIP.Location = new System.Drawing.Point(161, 57);
            this.textBIP.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBIP.Name = "textBIP";
            this.textBIP.Size = new System.Drawing.Size(347, 31);
            this.textBIP.TabIndex = 12;
            // 
            // textBPort
            // 
            this.textBPort.Enabled = false;
            this.textBPort.Location = new System.Drawing.Point(161, 216);
            this.textBPort.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBPort.Name = "textBPort";
            this.textBPort.Size = new System.Drawing.Size(347, 31);
            this.textBPort.TabIndex = 13;
            // 
            // textBPath
            // 
            this.textBPath.Location = new System.Drawing.Point(161, 376);
            this.textBPath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBPath.Name = "textBPath";
            this.textBPath.Size = new System.Drawing.Size(347, 31);
            this.textBPath.TabIndex = 14;
            // 
            // textUN
            // 
            this.textUN.Location = new System.Drawing.Point(161, 535);
            this.textUN.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textUN.Name = "textUN";
            this.textUN.Size = new System.Drawing.Size(347, 31);
            this.textUN.TabIndex = 15;
            // 
            // comboBUpdateFactory
            // 
            this.comboBUpdateFactory.Enabled = false;
            this.comboBUpdateFactory.FormattingEnabled = true;
            this.comboBUpdateFactory.Location = new System.Drawing.Point(161, 136);
            this.comboBUpdateFactory.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBUpdateFactory.Name = "comboBUpdateFactory";
            this.comboBUpdateFactory.Size = new System.Drawing.Size(347, 29);
            this.comboBUpdateFactory.TabIndex = 17;
            // 
            // labUpdateFactory
            // 
            this.labUpdateFactory.AutoSize = true;
            this.labUpdateFactory.Location = new System.Drawing.Point(46, 142);
            this.labUpdateFactory.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUpdateFactory.Name = "labUpdateFactory";
            this.labUpdateFactory.Size = new System.Drawing.Size(130, 21);
            this.labUpdateFactory.TabIndex = 16;
            this.labUpdateFactory.Text = "* Factory：";
            // 
            // textBUpdateFolderPath
            // 
            this.textBUpdateFolderPath.Location = new System.Drawing.Point(161, 456);
            this.textBUpdateFolderPath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBUpdateFolderPath.Name = "textBUpdateFolderPath";
            this.textBUpdateFolderPath.Size = new System.Drawing.Size(347, 31);
            this.textBUpdateFolderPath.TabIndex = 19;
            // 
            // labUpdateFolderPath
            // 
            this.labUpdateFolderPath.AutoSize = true;
            this.labUpdateFolderPath.Location = new System.Drawing.Point(16, 459);
            this.labUpdateFolderPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labUpdateFolderPath.Name = "labUpdateFolderPath";
            this.labUpdateFolderPath.Size = new System.Drawing.Size(163, 21);
            this.labUpdateFolderPath.TabIndex = 18;
            this.labUpdateFolderPath.Text = "* FolderPath：";
            // 
            // UpdateAPConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 825);
            this.Controls.Add(this.textBUpdateFolderPath);
            this.Controls.Add(this.labUpdateFolderPath);
            this.Controls.Add(this.comboBUpdateFactory);
            this.Controls.Add(this.labUpdateFactory);
            this.Controls.Add(this.textUN);
            this.Controls.Add(this.textBPath);
            this.Controls.Add(this.textBPort);
            this.Controls.Add(this.textBIP);
            this.Controls.Add(this.comboBType);
            this.Controls.Add(this.textPW);
            this.Controls.Add(this.textRe);
            this.Controls.Add(this.butCreate);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.labUpdateRemarks);
            this.Controls.Add(this.labUpdateFTPPassWord);
            this.Controls.Add(this.labUpdateFTPUserName);
            this.Controls.Add(this.labBasePath);
            this.Controls.Add(this.labUpdateType);
            this.Controls.Add(this.labUpdatePort);
            this.Controls.Add(this.labUpdateIP);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "UpdateAPConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update AP Config";
            this.Load += new System.EventHandler(this.UpdateAPConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labUpdateIP;
        private System.Windows.Forms.Label labUpdatePort;
        private System.Windows.Forms.Label labUpdateType;
        private System.Windows.Forms.Label labBasePath;
        private System.Windows.Forms.Label labUpdateFTPUserName;
        private System.Windows.Forms.Label labUpdateFTPPassWord;
        private System.Windows.Forms.Label labUpdateRemarks;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.TextBox textRe;
        private System.Windows.Forms.TextBox textPW;
        private System.Windows.Forms.ComboBox comboBType;
        private System.Windows.Forms.TextBox textBIP;
        private System.Windows.Forms.TextBox textBPort;
        private System.Windows.Forms.TextBox textBPath;
        private System.Windows.Forms.TextBox textUN;
        private System.Windows.Forms.ComboBox comboBUpdateFactory;
        private System.Windows.Forms.Label labUpdateFactory;
        private System.Windows.Forms.TextBox textBUpdateFolderPath;
        private System.Windows.Forms.Label labUpdateFolderPath;
    }
}