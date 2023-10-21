namespace SystemUpdateVersion.FormModels
{
    partial class APEditRemotPath
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
            this.labAPLab = new System.Windows.Forms.Label();
            this.textBAPIP = new System.Windows.Forms.TextBox();
            this.textBLocalFilesPath = new System.Windows.Forms.TextBox();
            this.textBAPFilesPath = new System.Windows.Forms.TextBox();
            this.butCheckConfirm = new System.Windows.Forms.Button();
            this.labLoaclFilesPath = new System.Windows.Forms.Label();
            this.labAPFilesPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labAPLab
            // 
            this.labAPLab.AutoSize = true;
            this.labAPLab.Location = new System.Drawing.Point(12, 21);
            this.labAPLab.Name = "labAPLab";
            this.labAPLab.Size = new System.Drawing.Size(37, 13);
            this.labAPLab.TabIndex = 0;
            this.labAPLab.Text = "AP IP:";
            // 
            // textBAPIP
            // 
            this.textBAPIP.Location = new System.Drawing.Point(54, 19);
            this.textBAPIP.Name = "textBAPIP";
            this.textBAPIP.Size = new System.Drawing.Size(182, 20);
            this.textBAPIP.TabIndex = 1;
            // 
            // textBLocalFilesPath
            // 
            this.textBLocalFilesPath.Location = new System.Drawing.Point(15, 73);
            this.textBLocalFilesPath.Multiline = true;
            this.textBLocalFilesPath.Name = "textBLocalFilesPath";
            this.textBLocalFilesPath.Size = new System.Drawing.Size(450, 212);
            this.textBLocalFilesPath.TabIndex = 2;
            // 
            // textBAPFilesPath
            // 
            this.textBAPFilesPath.Location = new System.Drawing.Point(515, 73);
            this.textBAPFilesPath.Multiline = true;
            this.textBAPFilesPath.Name = "textBAPFilesPath";
            this.textBAPFilesPath.Size = new System.Drawing.Size(432, 212);
            this.textBAPFilesPath.TabIndex = 3;
            this.textBAPFilesPath.TextChanged += new System.EventHandler(this.textBAPFilesPath_TextChanged);
            // 
            // butCheckConfirm
            // 
            this.butCheckConfirm.Location = new System.Drawing.Point(809, 19);
            this.butCheckConfirm.Name = "butCheckConfirm";
            this.butCheckConfirm.Size = new System.Drawing.Size(138, 23);
            this.butCheckConfirm.TabIndex = 4;
            this.butCheckConfirm.Text = "已检查，确认无误";
            this.butCheckConfirm.UseVisualStyleBackColor = true;
            this.butCheckConfirm.Click += new System.EventHandler(this.butCheckConfirm_Click);
            // 
            // labLoaclFilesPath
            // 
            this.labLoaclFilesPath.AutoSize = true;
            this.labLoaclFilesPath.Location = new System.Drawing.Point(14, 57);
            this.labLoaclFilesPath.Name = "labLoaclFilesPath";
            this.labLoaclFilesPath.Size = new System.Drawing.Size(79, 13);
            this.labLoaclFilesPath.TabIndex = 5;
            this.labLoaclFilesPath.Text = "本地更版文件";
            // 
            // labAPFilesPath
            // 
            this.labAPFilesPath.AutoSize = true;
            this.labAPFilesPath.Location = new System.Drawing.Point(512, 57);
            this.labAPFilesPath.Name = "labAPFilesPath";
            this.labAPFilesPath.Size = new System.Drawing.Size(108, 13);
            this.labAPFilesPath.TabIndex = 6;
            this.labAPFilesPath.Text = "AP 更版上传子目录";
            // 
            // APEditRemotPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 297);
            this.Controls.Add(this.labAPFilesPath);
            this.Controls.Add(this.labLoaclFilesPath);
            this.Controls.Add(this.butCheckConfirm);
            this.Controls.Add(this.textBAPFilesPath);
            this.Controls.Add(this.textBLocalFilesPath);
            this.Controls.Add(this.textBAPIP);
            this.Controls.Add(this.labAPLab);
            this.Name = "APEditRemotPath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APEditRemotPath";
            this.Load += new System.EventHandler(this.APEditRemotPath_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labAPLab;
        private System.Windows.Forms.TextBox textBAPIP;
        private System.Windows.Forms.TextBox textBLocalFilesPath;
        private System.Windows.Forms.TextBox textBAPFilesPath;
        private System.Windows.Forms.Button butCheckConfirm;
        private System.Windows.Forms.Label labLoaclFilesPath;
        private System.Windows.Forms.Label labAPFilesPath;
    }
}