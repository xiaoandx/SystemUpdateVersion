using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using SystemUpdateVersion.Hepler;
using SystemUpdateVersion.Models;

namespace SystemUpdateVersion.FormModels
{
    public partial class UpdateAPConfig : Form
    {
        public int ID = 0;
        public string OperationUserName = string.Empty;
        public string Factory = string.Empty;
        public UpdateAPConfig()
        {
            InitializeComponent();
            InitLanguage();
        }

        public UpdateAPConfig(int id)
        {
            InitializeComponent();
            this.ID = id;
            InitLanguage();
        }

        public UpdateAPConfig(int id, string _OperationUserName)
        {
            InitializeComponent();
            this.ID = id;
            OperationUserName = _OperationUserName;
            InitLanguage();
        }

        public UpdateAPConfig(int id, string _OperationUserName, string _Factory)
        {
            InitializeComponent();
            this.ID = id;
            OperationUserName = _OperationUserName;
            Factory = _Factory;
            InitLanguage();
        }

        private void textRe_TextChanged(object sender, EventArgs e)
        {
            InitAPConfigType();
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
            this.Close();
        }

        private void UpdateAPConfig_Load(object sender, EventArgs e)
        {
            comboBUpdateFactory.Items.Add(Factory);
            comboBUpdateFactory.SelectedIndex = 0;
            comboBType.SelectedIndex = 0;
            butCreate.Enabled = false;
            InitAPConfigByID(ID);
        }

        private void butCreate_Click_1(object sender, EventArgs e)
        {
            string msg = string.Empty;
            bool verifi = Verification(out msg);
            if (!verifi)
            {
                MessageHelper.Error(msg);
                return;
            }
            string InsertSQL = string.Empty;
            try
            {
                InsertSQL = $@"UPDATE APConfigDateils ap SET ap.FTPUserName = '{textUN.Text}', ap.FTPPassWord = '{textPW.Text}', ap.Remarks = '{textRe.Text}', ap.ProjectFolderPath = '{textBUpdateFolderPath.Text}', ap.Path = '{textBPath.Text}' where ap.Factory = '{Factory}' and ap.IP = '{textBIP.Text}' and ap.Port = {textBPort.Text} and ap.Type = '{comboBType.Text}'";
                int res = MdbHepler.Update(InsertSQL);
                if (res == 1)
                {
                    MessageHelper.Asterisk($@"{DateTime.Now.ToString("yyyymmdd hh:mm:ss")}{textBIP.Text}:{textBPort.Text}/{textBPath.Text}  Successfully!");
                    //LogHepler.WriterLog(OperationUserName, $" {textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.Text}】FTPUserName = '{textUN.Text}', FTPPassWord = '{textPW.Text}', Remarks = '{textRe.Text}'", "修改APConfig成功！");
                    LogHepler.WriterLog(OperationUserName, $" {textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.Text}】FTPUserName = '{textUN.Text}', FTPPassWord = '{textPW.Text}', Remarks = '{textRe.Text}'", CSL.Get(CSLE.R_Update_Form_Update_OK));
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageHelper.Error($@"{DateTime.Now.ToString("yyyymmdd hh:mm:ss")} {textBIP.Text}:{textBPort.Text}/{textBPath.Text}  Failed!");
                    //LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.Text}】FTPUserName = '{textUN.Text}', FTPPassWord = '{textPW.Text}', Remarks = '{textRe.Text}'", "修改APConfig失败！");
                    LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.Text}】FTPUserName = '{textUN.Text}', FTPPassWord = '{textPW.Text}', Remarks = '{textRe.Text}'", CSL.Get(CSLE.R_Update_Form_Update_Fail));
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.Error($"Update {textBIP.Text}:{textBPort.Text}/{textBPath.Text} Exception!");
                //LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.Text}】FTPUserName = '{textUN.Text}', FTPPassWord = '{textPW.Text}', Remarks = '{textRe.Text}' Msg:{ex.Message}", "修改APConfig出现异常！");
                LogHepler.WriterLog(OperationUserName, $"{textBIP.Text}:{textBPort.Text}/{textBPath.Text} 【{comboBType.Text}】FTPUserName = '{textUN.Text}', FTPPassWord = '{textPW.Text}', Remarks = '{textRe.Text}' Msg:{ex.Message}", CSL.Get(CSLE.R_Update_Form_Update_Error));
                return;
            }
        }

        /////////////////////////////////////////////////////////////////// 事件与方法分割线//////////////////////////////////////////////////////////

        private void InitAPConfigByID(int iD)
        {

            string SelectSQL = $@"select * from APConfigDateils ap where ap.ID = {iD} ";
            DataTable Data = MdbHepler.Query(SelectSQL);
            if (Data != null && Data.Rows.Count == 1) {
                DataRow dr = Data.Rows[0];
                textBIP.Text = dr["IP"].ToString();
                textBPort.Text = dr["Port"].ToString();
                TypeSelect(dr["Type"].ToString());
                textBPath.Text = dr["Path"].ToString();
                textUN.Text = dr["FTPUserName"].ToString();
                textPW.Text = dr["FTPPassWord"].ToString();
                textRe.Text = dr["Remarks"].ToString();
                textBUpdateFolderPath.Text = dr["ProjectFolderPath"].ToString();
            }
        }

        private void TypeSelect(string type)
        {
            if (type != null && !string.IsNullOrWhiteSpace(type))
            {
                int index = comboBType.Items.IndexOf(type);
                if (index != -1)
                {
                    comboBType.SelectedIndex = index;
                }
            }
            
        }

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
            if ("".Equals(textBPort.Text))
            {
                msg = "Port is empty!";
                return false;
            }
            if (CSL.Get(CSLE.A_SelectUpdateType).Equals(comboBType.Text))
            {
                msg = "Type is empty!";
                return false;
            }
            if ("".Equals(textBPath.Text))
            {
                msg = "Path is empty!";
                return false;
            }
            if ("".Equals(textBUpdateFolderPath.Text))
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
            msg = "success";
            return true;
        }

        private void InitLanguage()
        {
            labUpdateRemarks.Text = CSL.Get(CSLE.R_A_UpdateForm_Remarks);
        }
    }
}
