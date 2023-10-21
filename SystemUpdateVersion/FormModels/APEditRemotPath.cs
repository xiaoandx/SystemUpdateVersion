using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemUpdateVersion.Hepler;
using SystemUpdateVersion.Models;

namespace SystemUpdateVersion.FormModels
{
    public partial class APEditRemotPath : Form
    {
        private static int LocalMaxFilesNmber = 200;

        int ActualLoaclFilesNumer = 0;
        string[] LocalFilesPathArray = null;
        APConfigModel APInfro = null;
        Dictionary<string, string[]> APRemotePathsByIPDictionary = null;

        public APEditRemotPath()
        {
            InitializeComponent();
            InitLanguage();
        }

        public APEditRemotPath(int _ActualLoaclFilesNumer, string[] _LocalFilesPathArray, APConfigModel _APInfro, ref Dictionary<string, string[]> _APRemotePathsByIPDictionary)
        {
            InitializeComponent();
            ActualLoaclFilesNumer = _ActualLoaclFilesNumer;
            LocalFilesPathArray = _LocalFilesPathArray;
            APInfro = _APInfro;
            APRemotePathsByIPDictionary = _APRemotePathsByIPDictionary;
            InitLanguage();
        }

        private void APEditRemotPath_Load(object sender, EventArgs e)
        {
            if (APInfro != null)
            {
                textBAPIP.Text = APInfro.IP;

                //初始化本地文件路径
                for (int i = 0; i < ActualLoaclFilesNumer; i++)
                {
                    textBLocalFilesPath.AppendText(LocalFilesPathArray[i]);
                    textBLocalFilesPath.AppendText("\r\n");
                }

                //初始化AP对应子目录
                //0.1 先判断是否已经设置了远程的
                if (!APRemotePathsByIPDictionary.ContainsKey(APInfro.IP))
                {
                    //初次设定
                    for (int i = 0; i < ActualLoaclFilesNumer; i++)
                    {
                        textBAPFilesPath.AppendText(APInfro.ProjectFolderPath);
                        textBAPFilesPath.AppendText("\r\n");
                    }
                }
                else
                {
                    //多次设定
                    string[] LastSettingPath = APRemotePathsByIPDictionary[APInfro.IP];
                    for (int i = 0; i < ActualLoaclFilesNumer; i++)
                    {
                        textBAPFilesPath.AppendText(LastSettingPath[i]);
                        textBAPFilesPath.AppendText("\r\n");
                    }
                }

                //初始化组件是否可见
                textBAPIP.Enabled = false;
                textBLocalFilesPath.Enabled = false;
                butCheckConfirm.Enabled = false;
            }
            else
            {
                MessageHelper.Error("选择AP为空，重新选择！");
                this.Close();
            }
        }

        private void butCheckConfirm_Click(object sender, EventArgs e)
        {
            string[] RemoctPath = new string[ActualLoaclFilesNumer];
            for (int j = 0, num = 0; j < textBAPFilesPath.Lines.Length; j++)
            {
                if (!"".Equals(textBAPFilesPath.Lines[j].ToString()))
                {
                    if (!textBAPFilesPath.Lines[j].ToString().Contains("\\"))
                    {
                        //MessageHelper.Error(@"远程目录开头无 / 线，结尾必须是 /");
                        MessageHelper.Error(CSL.Get(CSLE.R_M_E0002));
                        return;
                    }
                    else
                    {
                        RemoctPath[num] = textBAPFilesPath.Lines[j].ToString();
                        num++;
                    }
                }
            }
            if (APRemotePathsByIPDictionary.ContainsKey(APInfro.IP))
            {
                APRemotePathsByIPDictionary[APInfro.IP] = RemoctPath;
            }
            else
            {
                APRemotePathsByIPDictionary.Add(APInfro.IP,RemoctPath);
            }
            
            this.Close();
        }

        private void textBAPFilesPath_TextChanged(object sender, EventArgs e)
        {
            butCheckConfirm.Enabled = true;
        }

        private void InitLanguage()
        {
            labLoaclFilesPath.Text = CSL.Get(CSLE.R_A_APEditForm_lab_Local);
            labAPFilesPath.Text = CSL.Get(CSLE.R_A_APEditForm_lab_Remack);
            butCheckConfirm.Text = CSL.Get(CSLE.R_A_APEditForm_But_OK);
        }
    }
}
