using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using SystemUpdateVersion.Hepler;
using SystemUpdateVersion.Models;

namespace SystemUpdateVersion.FormModels
{
    public partial class AddAPConfig : Form
    {
        public Main ParForm = null;
        public string OperationUserName = string.Empty;
        public string Factory = string.Empty;
        public AddAPConfig()
        {
            InitializeComponent();
            InitLanguage();
        }

        public AddAPConfig(Main _ParForm)
        {
            InitializeComponent();
            this.ParForm = _ParForm;
            InitLanguage();
        }

        public AddAPConfig(Main _ParForm, string _OperationUserName)
        {
            InitializeComponent();
            this.ParForm = _ParForm;
            OperationUserName = _OperationUserName;
            InitLanguage();
        }

        public AddAPConfig(Main _ParForm, string _OperationUserName, string _Factory)
        {
            InitializeComponent();
            this.ParForm = _ParForm;
            OperationUserName = _OperationUserName;
            Factory = _Factory;
            InitLanguage();
        }

        private void AddAPConfig_Load(object sender, EventArgs e)
        {
            InitAPConfigType();
            comboBAddFactory.Items.Add(Factory);
            comboBAddFactory.SelectedIndex = 0;
            comboBType.SelectedIndex = 0;
            butCreate.Enabled = false;
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            bool verifi = Verification(out msg);
            if (!verifi) {
                MessageHelper.Error(msg);
                return;
            }
            //修改前判断数据是否存在
            string InsertSQL = string.Empty;
            try
            {
                string SelectSQL = $@"select * from APConfigDateils ap where ap.Factory = '{Factory}' and  ap.IP = '{textBIP.Text}' and ap.Port = {textBPort.Text} and ap.Type = '{comboBType.SelectedItem.ToString()}' and ap.Path = '{textBPath.Text}'";
                //and ap.Port = '{textBPort.Text}' and ap.Type = '{comboBType.SelectedItem.ToString()}' and ap.Path = '{textBPath.Text}'
                DataTable isData = MdbHepler.Query(SelectSQL);
                if (isData != null && isData.Rows.Count > 0)
                {
                    InsertSQL = $@"UPDATE APConfigDateils ap SET ap.FTPUserName = '{textUN.Text}', ap.FTPPassWord = '{textPW.Text}', ap.Remarks = '{textRe.Text}', ap.ProjectFolderPath = '{textBAddFolderPath.Text}' where ap.Factory = '{Factory}' and ap.IP = '{textBIP.Text}' and ap.Port = {textBPort.Text} and ap.Type = '{comboBType.SelectedItem.ToString()}' and ap.Path = '{textBPath.Text}'";
                }
                else
                {
                    InsertSQL = $@"INSERT INTO APConfigDateils (IP,Factory, Port,Type,Path,FTPUserName,FTPPassWord,Remarks,ProjectFolderPath)
                                VALUES ('{textBIP.Text}','{Factory}','{textBPort.Text}','{comboBType.SelectedItem.ToString()}','{textBPath.Text}','{textUN.Text}','{textPW.Text}','{textRe.Text}','{textBAddFolderPath.Text}');";
                }

                // CreateSQL

                int res = MdbHepler.Update(InsertSQL);
                if (res == 1)
                {
                    MessageHelper.Asterisk($@"{DateTime.Now.ToString("yyyymmdd hh:mm:ss")} {textBIP.Text}:{textBPort.Text}/{textBPath.Text}  Successfully!");
                    //LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.SelectedItem.ToString()}】", "添加APConfig成功！");
                    LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.SelectedItem.ToString()}】", CSL.Get(CSLE.R_Add_Form_Create));
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageHelper.Error($@"{DateTime.Now.ToString("yyyymmdd hh:mm:ss")} {textBIP.Text}:{textBPort.Text}/{textBPath.Text}  Failed!");
                    //LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.SelectedItem.ToString()}】", "添加APConfig失败！");
                    LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.SelectedItem.ToString()}】", CSL.Get(CSLE.R_Add_Form_Create_Fail));
                    return;
                }
            }
            catch (Exception ex)
            {
                //LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.SelectedItem.ToString()}】Msg:{ex.Message}", "添加APConfig出现异常！");
                LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.SelectedItem.ToString()}】Msg:{ex.Message}", CSL.Get(CSLE.R_Add_Form_Create_Error));
            }
        }

        private void textRe_TextChanged(object sender, EventArgs e)
        {
            butCreate.Enabled = true;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            textBIP.Text = "";
            textBPort.Text = "";
            comboBType.SelectedIndex = 0;
            textBPath.Text = "";
            textUN.Text = "";
            textUN.Text = "";
            textPW.Text = "";
            textRe.Text = "";
            butCreate.Enabled = false;
            ParForm.isCloerAdd = true;
            this.Close(); 
        }

        /////////////////////////////////////////////////////////////////// 事件与方法分割线//////////////////////////////////////////////////////////

        private void InitAPConfigType()
        {
            string TypeString = ConfigurationManager.AppSettings["APConfigType"];
            if (TypeString != null && !string.IsNullOrWhiteSpace(TypeString))
            {
                string[] Types = TypeString.Split(',');
                comboBType.Items.Clear();
                comboBType.Items.Add(CSL.Get(CSLE.A_SelectUpdateType));
                foreach (string item in Types)
                {
                    comboBType.Items.Add(item);
                }
            }

        }

        private bool Verification(out string msg)
        {
            if ("".Equals(textBIP.Text))
            {
                msg = "IP is empty!";
                return false;
            }
            if (CSL.Get(CSLE.A_SelectFactoryTitle).Equals(comboBAddFactory.SelectedItem.ToString()))
            {
                msg = "Factory is empty!";
                return false;
            }
            if ("".Equals(textBPort.Text))
            {
                msg = "Port is empty!";
                return false;
            }
            if ("".Equals(comboBType.SelectedItem.ToString()))
            {
                msg = "Type is empty!";
                return false;
            }
            if (CSL.Get(CSLE.A_SelectUpdateType).Equals(comboBType.SelectedItem.ToString()))
            {
                msg = "Type is empty!";
                return false;
            }
            if ("".Equals(textBPath.Text))
            {
                msg = "Path is empty!";
                return false;
            }
            if ("".Equals(textBAddFolderPath.Text))
            {
                msg = "FolderPath is empty!";
                return false;
            }
            if ("".Equals(textUN.Text))
            {
                msg = "FTPUserName is empty!";
                return false;
            }
            if ("".Equals(textPW.Text))
            {
                msg = "FTPPassWord is empty!";
                return false;
            }
            if ("".Equals(textRe.Text))
            {
                //msg = "备注 is empty!";
                msg = CSL.Get(CSLE.R_Add_Form_Remarks);
                return false;
            }
            msg = "success";
            return true;
        }

        private void InitLanguage()
        {
            labAddRemarks.Text = CSL.Get(CSLE.R_A_CreateForm_Remarks);
        }
    }
}
