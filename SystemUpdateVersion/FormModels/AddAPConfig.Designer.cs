namespace SystemUpdateVersion.FormModels
{
    partial class AddAPConfig
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
            this.labAddIP = new System.Windows.Forms.Label();
            this.labAddPort = new System.Windows.Forms.Label();
            this.labAddType = new System.Windows.Forms.Label();
            this.labBasePath = new System.Windows.Forms.Label();
            this.labAddFTPUserName = new System.Windows.Forms.Label();
            this.labAddFTPPassWord = new System.Windows.Forms.Label();
            this.labAddRemarks = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butCreate = new System.Windows.Forms.Button();
            this.textRe = new System.Windows.Forms.TextBox();
            this.textPW = new System.Windows.Forms.TextBox();
            this.comboBType = new System.Windows.Forms.ComboBox();
            this.textBIP = new System.Windows.Forms.TextBox();
            this.textBPort = new System.Windows.Forms.TextBox();
            this.textBPath = new System.Windows.Forms.TextBox();
            this.textUN = new System.Windows.Forms.TextBox();
            this.comboBAddFactory = new System.Windows.Forms.ComboBox();
            this.labAddFactory = new System.Windows.Forms.Label();
            this.textBAddFolderPath = new System.Windows.Forms.TextBox();
            this.labAddFolderPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labAddIP
            // 
            this.labAddIP.AutoSize = true;
            this.labAddIP.Location = new System.Drawing.Point(50, 39);
            this.labAddIP.Name = "labAddIP";
            this.labAddIP.Size = new System.Drawing.Size(36, 13);
            this.labAddIP.TabIndex = 0;
            this.labAddIP.Text = "* IP：";
            // 
            // labAddPort
            // 
            this.labAddPort.AutoSize = true;
            this.labAddPort.Location = new System.Drawing.Point(41, 135);
            this.labAddPort.Name = "labAddPort";
            this.labAddPort.Size = new System.Drawing.Size(45, 13);
            this.labAddPort.TabIndex = 1;
            this.labAddPort.Text = "* Port：";
            // 
            // labAddType
            // 
            this.labAddType.AutoSize = true;
            this.labAddType.Location = new System.Drawing.Point(36, 183);
            this.labAddType.Name = "labAddType";
            this.labAddType.Size = new System.Drawing.Size(50, 13);
            this.labAddType.TabIndex = 2;
            this.labAddType.Text = "* Type：";
            // 
            // labBasePath
            // 
            this.labBasePath.AutoSize = true;
            this.labBasePath.Location = new System.Drawing.Point(14, 231);
            this.labBasePath.Name = "labBasePath";
            this.labBasePath.Size = new System.Drawing.Size(72, 13);
            this.labBasePath.TabIndex = 3;
            this.labBasePath.Text = "* BasePath：";
            // 
            // labAddFTPUserName
            // 
            this.labAddFTPUserName.AutoSize = true;
            this.labAddFTPUserName.Location = new System.Drawing.Point(10, 327);
            this.labAddFTPUserName.Name = "labAddFTPUserName";
            this.labAddFTPUserName.Size = new System.Drawing.Size(76, 13);
            this.labAddFTPUserName.TabIndex = 4;
            this.labAddFTPUserName.Text = "* UserName：";
            // 
            // labAddFTPPassWord
            // 
            this.labAddFTPPassWord.AutoSize = true;
            this.labAddFTPPassWord.Location = new System.Drawing.Point(11, 375);
            this.labAddFTPPassWord.Name = "labAddFTPPassWord";
            this.labAddFTPPassWord.Size = new System.Drawing.Size(75, 13);
            this.labAddFTPPassWord.TabIndex = 5;
            this.labAddFTPPassWord.Text = "* PassWord：";
            // 
            // labAddRemarks
            // 
            this.labAddRemarks.Location = new System.Drawing.Point(6, 423);
            this.labAddRemarks.Name = "labAddRemarks";
            this.labAddRemarks.Size = new System.Drawing.Size(80, 13);
            this.labAddRemarks.TabIndex = 6;
            this.labAddRemarks.Text = "* 备注：";
            this.labAddRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(204, 469);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 7;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(113, 469);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(75, 23);
            this.butCreate.TabIndex = 8;
            this.butCreate.Text = "Save";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // textRe
            // 
            this.textRe.Location = new System.Drawing.Point(88, 421);
            this.textRe.Name = "textRe";
            this.textRe.Size = new System.Drawing.Size(191, 20);
            this.textRe.TabIndex = 9;
            this.textRe.TextChanged += new System.EventHandler(this.textRe_TextChanged);
            // 
            // textPW
            // 
            this.textPW.Location = new System.Drawing.Point(88, 373);
            this.textPW.Name = "textPW";
            this.textPW.Size = new System.Drawing.Size(191, 20);
            this.textPW.TabIndex = 10;
            // 
            // comboBType
            // 
            this.comboBType.FormattingEnabled = true;
            this.comboBType.Items.AddRange(new object[] {
            "**请选择更版类型**",
            "WebApi",
            "PDA",
            "CIMPDA",
            "CamstarPortal"});
            this.comboBType.Location = new System.Drawing.Point(88, 180);
            this.comboBType.Name = "comboBType";
            this.comboBType.Size = new System.Drawing.Size(191, 21);
            this.comboBType.TabIndex = 11;
            // 
            // textBIP
            // 
            this.textBIP.Location = new System.Drawing.Point(88, 35);
            this.textBIP.Name = "textBIP";
            this.textBIP.Size = new System.Drawing.Size(191, 20);
            this.textBIP.TabIndex = 12;
            // 
            // textBPort
            // 
            this.textBPort.Location = new System.Drawing.Point(88, 132);
            this.textBPort.Name = "textBPort";
            this.textBPort.Size = new System.Drawing.Size(191, 20);
            this.textBPort.TabIndex = 13;
            // 
            // textBPath
            // 
            this.textBPath.Location = new System.Drawing.Point(88, 229);
            this.textBPath.Name = "textBPath";
            this.textBPath.Size = new System.Drawing.Size(191, 20);
            this.textBPath.TabIndex = 14;
            // 
            // textUN
            // 
            this.textUN.Location = new System.Drawing.Point(88, 325);
            this.textUN.Name = "textUN";
            this.textUN.Size = new System.Drawing.Size(191, 20);
            this.textUN.TabIndex = 15;
            // 
            // comboBAddFactory
            // 
            this.comboBAddFactory.FormattingEnabled = true;
            this.comboBAddFactory.Location = new System.Drawing.Point(88, 83);
            this.comboBAddFactory.Name = "comboBAddFactory";
            this.comboBAddFactory.Size = new System.Drawing.Size(191, 21);
            this.comboBAddFactory.TabIndex = 17;
            // 
            // labAddFactory
            // 
            this.labAddFactory.AutoSize = true;
            this.labAddFactory.Location = new System.Drawing.Point(25, 87);
            this.labAddFactory.Name = "labAddFactory";
            this.labAddFactory.Size = new System.Drawing.Size(61, 13);
            this.labAddFactory.TabIndex = 16;
            this.labAddFactory.Text = "* Factory：";
            // 
            // textBAddFolderPath
            // 
            this.textBAddFolderPath.Location = new System.Drawing.Point(88, 277);
            this.textBAddFolderPath.Name = "textBAddFolderPath";
            this.textBAddFolderPath.Size = new System.Drawing.Size(191, 20);
            this.textBAddFolderPath.TabIndex = 19;
            // 
            // labAddFolderPath
            // 
            this.labAddFolderPath.AutoSize = true;
            this.labAddFolderPath.Location = new System.Drawing.Point(9, 279);
            this.labAddFolderPath.Name = "labAddFolderPath";
            this.labAddFolderPath.Size = new System.Drawing.Size(77, 13);
            this.labAddFolderPath.TabIndex = 18;
            this.labAddFolderPath.Text = "* FolderPath：";
            // 
            // AddAPConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 511);
            this.Controls.Add(this.textBAddFolderPath);
            this.Controls.Add(this.labAddFolderPath);
            this.Controls.Add(this.comboBAddFactory);
            this.Controls.Add(this.labAddFactory);
            this.Controls.Add(this.textUN);
            this.Controls.Add(this.textBPath);
            this.Controls.Add(this.textBPort);
            this.Controls.Add(this.textBIP);
            this.Controls.Add(this.comboBType);
            this.Controls.Add(this.textPW);
            this.Controls.Add(this.textRe);
            this.Controls.Add(this.butCreate);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.labAddRemarks);
            this.Controls.Add(this.labAddFTPPassWord);
            this.Controls.Add(this.labAddFTPUserName);
            this.Controls.Add(this.labBasePath);
            this.Controls.Add(this.labAddType);
            this.Controls.Add(this.labAddPort);
            this.Controls.Add(this.labAddIP);
            this.MaximizeBox = false;
            this.Name = "AddAPConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create AP Config";
            this.Load += new System.EventHandler(this.AddAPConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labAddIP;
        private System.Windows.Forms.Label labAddPort;
        private System.Windows.Forms.Label labAddType;
        private System.Windows.Forms.Label labBasePath;
        private System.Windows.Forms.Label labAddFTPUserName;
        private System.Windows.Forms.Label labAddFTPPassWord;
        private System.Windows.Forms.Label labAddRemarks;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.TextBox textRe;
        private System.Windows.Forms.TextBox textPW;
        private System.Windows.Forms.ComboBox comboBType;
        private System.Windows.Forms.TextBox textBIP;
        private System.Windows.Forms.TextBox textBPort;
        private System.Windows.Forms.TextBox textBPath;
        private System.Windows.Forms.TextBox textUN;
        private System.Windows.Forms.ComboBox comboBAddFactory;
        private System.Windows.Forms.Label labAddFactory;
        private System.Windows.Forms.TextBox textBAddFolderPath;
        private System.Windows.Forms.Label labAddFolderPath;
    }
}