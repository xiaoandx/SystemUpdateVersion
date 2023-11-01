using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemUpdateVersion.FormModels;
using SystemUpdateVersion.Hepler;
using SystemUpdateVersion.Models;

namespace SystemUpdateVersion
{
    public partial class Main : Form
    {

        private static int LocalMaxFilesNmber = 200;

        public bool isCloerAdd = false;

        //private string OperationUserName = "C7000520";
        private string OperationUserName = string.Empty;

        //private string Factory = "SZ";
        private string Factory = string.Empty;

        private DataTable _APConfig = new DataTable();
        private DataTable _TypeAPConfig = new DataTable();
        List<APConfigModel> _TypeAPConfigList = new List<APConfigModel>();
        List<APConfigModel> SelectAPList = new List<APConfigModel>();
        List<string> UploadFiles = new List<string>();

        //上传本地文件集合
        List<string> LocalFilesPath = new List<string>();
        //远程AP上传目录集合(IP:Port/Path/..../FileName)
        List<string> RemoteFilesPath = new List<string>();

        //退版文件路径集合
        List<string> BackVersionLoaclFilePathBase = new List<string>();
        List<string> BackVersionLoaclFilePath = new List<string>();

        //AP独立设定远程路径
        int ActualLoaclFilesNumer = 0;
        string[] LocalFilesPathArray = new string[LocalMaxFilesNmber];
        int ActualBackVersionLoaclFileNumer = 0;
        string[] BackVersionLoaclFilePathArray = new string[LocalMaxFilesNmber];
        Dictionary<string, APConfigModel> APInfroDictionary = new Dictionary<string, APConfigModel>();
        Dictionary<string, string[]> APRemotePathsByIPDictionary = new Dictionary<string, string[]>();

        //监控相关变量
        string WebApiMonitorPath = string.Empty;
        string PDAMonitorPath = string.Empty;
        string CIMPDAMonitorPath = string.Empty;
        string CamPortalMonitorPath = string.Empty;

        //最小化
        Hidden hidden;

        public Main()
        {
            InitializeComponent();
            InitLanguage();
            //初始化双缓存
            InItListViewLogDouble();
            InitListViewAPConfigDoubleBuffer();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //验证Linces
            //bool InitLRes = InitAppLinces();
            bool InitLRes = true;
            if (InitLRes)
            {
                //判断是否为监控客户端
                bool _IsMonitorRes = IsMonitor();
                if (_IsMonitorRes)
                {
                    tabPAuthentication.Parent = null;
                    tabPAPConfig.Parent = null;
                    tabPAPOperation.Parent = null;
                }
                else
                {
                    tabPMonitor.Parent = null;
                }

                //操作认证
                InitFactory();
                butLogin.Enabled = false;
                tabPAPConfig.Parent = null;
                tabPAPOperation.Parent = null;

                //LogHepler.WriterLog($"==================================== {Factory} 更版开始 ======================================", "");
                LogHepler.WriterLog($"==================================== {CSL.Get(CSLE.R_Log_UpdateStart, Factory)} ======================================", "");
                //初始化APP信息
                InitApp(_IsMonitorRes);

                //初始化监控目录
                InitMonitorFolder();

                //SelectAllConfig();
                //InitType
                InitAPConfigType();
                //默认选择更版类型
                cBUpdateType.SelectedIndex = 0;
                EnabledComp();
            }
            else
            {
                DialogResult ress = MessageHelper.Error("Initialization of the SDK failed." + Environment.NewLine + Environment.NewLine + "Need license authorization,please contact the administrtor to obtain the license authorization");
                if (ress == DialogResult.OK)
                {
                    System.Environment.Exit(0);
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult res = MessageBox.Show("确定要关闭窗口吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult res = MessageBox.Show(CSL.Get(CSLE.A_M_CloseWindow), CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //LogHepler.WriterLog($"==================================== {Factory} 更版结束 ======================================", "");
            LogHepler.WriterLog($"==================================== {CSL.Get(CSLE.R_Log_UpdateEnd, Factory)} ======================================", "");
            if(hidden != null) hidden.Dispose();
            this.Dispose();
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SelectAllConfig();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GetAPConfigsSelectID();
        }

        private void CMSIUpdate_Click(object sender, EventArgs e)
        {
            int SelectID = GetAPConfigsSelectID();
            UpdateAPConfig updateAPConfig = new UpdateAPConfig(SelectID, OperationUserName, Factory);
            updateAPConfig.ShowDialog();
        }

        private void CMSIDelete_Click(object sender, EventArgs e)
        {
            int SelectID = GetAPConfigsSelectID();
            //DialogResult dialogResult = MessageHelper.Question("是否确认要删除所选数据项！");
            DialogResult dialogResult = MessageHelper.Question(CSL.Get(CSLE.R_M_DeleteConfig));
            if (dialogResult == DialogResult.Yes)
            {

                try
                {
                    string deleteSQL = $@"DELETE FROM APConfigDateils where ID = {SelectID}";
                    int DeleteRes = MdbHepler.Update(deleteSQL);
                    if (DeleteRes == 1)
                    {
                        //MessageHelper.Asterisk("删除成功！");
                        //LogHepler.WriterLog(OperationUserName, $"ID {SelectID}", "删除APConfig成功！");
                        MessageHelper.Asterisk(CSL.Get(CSLE.R_M_Delete_OK));
                        LogHepler.WriterLog(OperationUserName, $"ID {SelectID}", CSL.Get(CSLE.R_L_Delete_OK));
                    }
                    else
                    {
                        //MessageHelper.Error("删除失败！");
                        //LogHepler.WriterLog(OperationUserName, $"ID {SelectID}", "删除APConfig失败！");
                        MessageHelper.Error(CSL.Get(CSLE.R_M_Delect_Error));
                        LogHepler.WriterLog(OperationUserName, $"ID {SelectID}", CSL.Get(CSLE.R_L_Delect_Error));
                    }
                }
                catch (Exception ex)
                {
                    //MessageHelper.Error("删除数据异常！");
                    //LogHepler.WriterLog(OperationUserName, $"ID {SelectID} Msg:{ex.Message}", "删除APConfig出现异常！");
                    MessageHelper.Error(CSL.Get(CSLE.R_M_DeleteFile));
                    LogHepler.WriterLog(OperationUserName, $"ID {SelectID} Msg:{ex.Message}", CSL.Get(CSLE.R_L_DeleteFile));
                }
            }
        }

        private void CMSIF_Click(object sender, EventArgs e)
        {
            SelectAllConfig();
        }

        private void CMSTESTFTP_Click(object sender, EventArgs e)
        {
            int Index = 0;
            string IP = string.Empty;
            string Port = string.Empty;
            string Path = string.Empty;
            string UserName = string.Empty;
            string Password = string.Empty;
            int length = listView1.SelectedItems.Count;
            for (int i = 0; i < length; i++)
            {
                string v = (listView1.SelectedItems[i].Index + 1).ToString();
                int _Index = Convert.ToInt32(v);
                Index = Convert.ToInt32(_APConfig.Rows[_Index - 1]["ID"].ToString());
                IP = _APConfig.Rows[_Index - 1]["IP"].ToString();
                Port = _APConfig.Rows[_Index - 1]["Port"].ToString();
                Path = _APConfig.Rows[_Index - 1]["Path"].ToString();
                UserName = _APConfig.Rows[_Index - 1]["FTPUserName"].ToString();
                Password = _APConfig.Rows[_Index - 1]["FTPPassWord"].ToString();
            }
            try
            {
                FTPHepler ftp = new FTPHepler(IP, Port, Path, UserName, Password);
                string[] dirs = ftp.GetFilesDetailList();
                MessageHelper.Asterisk($"{IP}:{Port}/{Path} FTP Connect Successfully！");
                return;
            }
            catch (Exception ex)
            {
                //LogHepler.WriterLog(OperationUserName, $"{IP}:{Port}/{Path} FTP 测试连接异常！", "FTP 测试连接");
                //MessageHelper.Error($"{IP}:{Port}/{Path} FTP 测试连接异常！");
                LogHepler.WriterLog(OperationUserName, $"{IP}:{Port}/{Path} {CSL.Get(CSLE.R_L_TESTFTP_Error)}", CSL.Get(CSLE.R_L_TESTFTP));
                MessageHelper.Error($"{IP}:{Port}/{Path} {CSL.Get(CSLE.R_L_TESTFTP_Error)}");
            }
        }

        private void butSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.SelectedPath = ReadINI("DefalutConfig", "DefalutSelectPath");
            path.ShowDialog();
            tBFolderPath.Text = path.SelectedPath;
            WriteINI("DefalutConfig", "DefalutSelectPath", path.SelectedPath);
            butSelectFiles.Enabled = true;
        }

        private void butSelectFiles_Click(object sender, EventArgs e)
        {
            SelectDir();
        }

        private void butUpdateTypeAP_Click(object sender, EventArgs e)
        {
            string v = cBUpdateType.SelectedItem.ToString();
            if (CSL.Get(CSLE.A_SelectUpdateType).Equals(v) || string.IsNullOrEmpty(v))
            {
                //MessageHelper.Error("请选择更版类型!");
                MessageHelper.Error(CSL.Get(CSLE.R_M_SelectType));
                return;
            }
            //初始化APCheckLsitBox
            InitCheckListBox(v);

            //获取最新的本地上传文件及远程对应路径
            UpdateFilePath();

            //更新退版文件夹
            UpdateVersionFolder();

            //初始化TypeAP的远程目录
            InitAPRemotePathsByIPDictionaryByType();

            //开启备份按钮
            checkBIsFirst.Enabled = true;
            checkBBackVersion.Enabled = true;
            butBackup.Enabled = true;

            checkBBackupLock.Enabled = true;
            checkBoxUploadLock.Enabled = true;
            checkBoxBackVersion.Enabled = true;
            checkBoIsSetRemotePath.Enabled = true;
            checkBUpload.Enabled = true;
            butPool.Enabled = true;

        }

        private void InitAPRemotePathsByIPDictionaryByType()
        {
            APRemotePathsByIPDictionary.Clear();
            foreach (APConfigModel item in _TypeAPConfigList)
            {
                string[] RemoctPath = new string[ActualLoaclFilesNumer];
                for (int i = 0; i < ActualLoaclFilesNumer; i++)
                {
                    RemoctPath[i] = item.ProjectFolderPath;
                }
                if (APRemotePathsByIPDictionary.ContainsKey(item.IP))
                {
                    APRemotePathsByIPDictionary.Clear();
                    //MessageHelper.Error(CSL.Get(CSLE.R_O_SelectAPConfigE0001, item.IP));
                    return;
                }
                else
                {
                    APRemotePathsByIPDictionary.Add(item.IP, RemoctPath);
                }
            }
        }

        private void UpdateVersionFolder()
        {
            cbBBackVersion.Items.Clear();
            string _backVersionPathBase = GetVersionBackupPathBase();

            if (!Directory.Exists(_backVersionPathBase))
            {
                Directory.CreateDirectory(_backVersionPathBase);
            }
            DirectoryInfo dir = new DirectoryInfo(_backVersionPathBase);
            DirectoryInfo[] dis = dir.GetDirectories();
            //LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(dis), "可选退版备份目录");
            LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(dis), CSL.Get(CSLE.R_L_SelectBackupFolder));
            for (int i = 0; i <= dis.Length; i++) {
                if (i == 0)
                {
                    cbBBackVersion.Items.Insert(i, "**选择Version文件夹**");
                }
                else
                {
                    cbBBackVersion.Items.Insert(i, dis[i - 1]);
                }

            }
            cbBBackVersion.SelectedIndex = 0;
        }

        private void butUpload_Click(object sender, EventArgs e)
        {
            //清除进度条
            progressBar.Value = 0;

            //获取最新的本地上传文件及远程对应路径
            UpdateFilePath();

            //操作解锁
            if (!checkBoxUploadLock.Checked)
            {
                //MessageHelper.Warning("上传更版操作被禁止，请启用操作锁！");
                MessageHelper.Warning(CSL.Get(CSLE.R_M_UploadBack));
                return;
            }

            SelectAPList = GetSelectAP();
            UpdateFilePath();

            if (SelectAPList == null || SelectAPList.Count == 0) {
                //MessageHelper.Error("未选择上传AP！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_NotSelectAP));
                return;
            }



            //是否勾选AP单独设定上传文件子目录
            if (checkBoIsSetRemotePath.Checked)
            {
                #region 勾选

                progressBar.Maximum = ActualLoaclFilesNumer * SelectAPList.Count;
                for (int i = 0; i < SelectAPList.Count; i++)
                {
                    APConfigModel item = SelectAPList[i];
                    string _filepath = string.Empty;
                    string[] _RemoteFilesPathByAP = APRemotePathsByIPDictionary[item.IP];
                    try
                    {
                        //构建FTP连接对象
                        FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path, item.FTPUserName, item.FTPPassWord);
                        if (_RemoteFilesPathByAP.Length == 0)
                        {
                            foreach (string filePath in LocalFilesPath)
                            {
                                try
                                {
                                    _filepath = filePath.Replace("\\", "/");
                                    FileInfo fileInfo = new FileInfo(_filepath);
                                    ftp.UploadFile(filePath.Replace("\\", "/"));
                                    FTPResStatusPush(item.IP, fileInfo.Name, true, FTPType.Upload);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", "更版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", CSL.Get(CSLE.R_L_UpdateVersionStatus));
                                    ProgressBarPush();
                                }
                                catch (Exception ex)
                                {
                                    FTPResStatusPush(item.IP, new FileInfo(_filepath).Name, false, FTPType.Upload);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}", "更版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} {ex.Message}", CSL.Get(CSLE.R_L_UpdateVersionStatus));
                                }

                            }
                        }
                        else if (_RemoteFilesPathByAP.Length == ActualLoaclFilesNumer)
                        {
                            for (int index = 0; index < ActualLoaclFilesNumer; index++)
                            {
                                try
                                {
                                    _filepath = LocalFilesPathArray[index].Replace("\\", "/");
                                    FileInfo fileInfo = new FileInfo(_filepath);
                                    ftp.UploadFile(LocalFilesPathArray[index].Replace("\\", "/"), _RemoteFilesPathByAP[index].Replace("\\", "/"));
                                    FTPResStatusPush(item.IP, fileInfo.Name, true, FTPType.Upload);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", "更版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", CSL.Get(CSLE.R_L_UpdateVersionStatus));
                                    ProgressBarPush();
                                }
                                catch (Exception ex)
                                {
                                    FTPResStatusPush(item.IP, new FileInfo(_filepath).Name, false, FTPType.Upload);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}", "更版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}{ex.Message}", CSL.Get(CSLE.R_L_UpdateVersionStatus));
                                }
                            }
                        }
                        else
                        {
                            //MessageHelper.Error("请检查，本地待上传文件数理与对应文件远程目录不一致！");
                            //LogHepler.WriterLog(OperationUserName, $"请检查，本地待上传文件数理与对应文件远程目录不一致！", "更版错误");
                            MessageHelper.Error(CSL.Get(CSLE.R_M_E_FolderNumber));
                            LogHepler.WriterLog(OperationUserName, CSL.Get(CSLE.R_M_E_FolderNumber), CSL.Get(CSLE.R_L_UpdateVersionStatus_Error));
                            return;
                        }

                        UpdateVersionFolder();
                        butBackVersion.Enabled = true;
                        cbBBackVersion.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        //MessageHelper.Error(ex.Message);
                        FTPResStatusPush(item.IP, _filepath, false, FTPType.Upload);
                        //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} Msg:{ex.Message}", "更版异常");
                        LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} Msg:{ex.Message}", CSL.Get(CSLE.R_L_UpdateVersionStatus_Exception));
                    }
                }

                #endregion
            }
            else
            {
                #region 未勾选

                progressBar.Maximum = LocalFilesPath.Count() * SelectAPList.Count;
                for (int i = 0; i < SelectAPList.Count; i++)
                {
                    APConfigModel item = SelectAPList[i];
                    string _filepath = string.Empty;
                    try
                    {
                        //构建FTP连接对象
                        FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path, item.FTPUserName, item.FTPPassWord);
                        if (RemoteFilesPath.Count == 0)
                        {
                            foreach (string filePath in LocalFilesPath)
                            {
                                try
                                {
                                    _filepath = filePath.Replace("\\", "/");
                                    FileInfo fileInfo = new FileInfo(_filepath);
                                    ftp.UploadFile(filePath.Replace("\\", "/"), item.ProjectFolderPath.Replace("\\", "/"));
                                    FTPResStatusPush(item.IP, fileInfo.Name, true, FTPType.Upload);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", "更版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", CSL.Get(CSLE.R_L_UpdateVersionStatus));
                                    ProgressBarPush();
                                }
                                catch (Exception ex)
                                {
                                    FTPResStatusPush(item.IP, new FileInfo(_filepath).Name, false, FTPType.Upload);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}", "更版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} {ex.Message}", CSL.Get(CSLE.R_L_UpdateVersionStatus));
                                }

                            }
                        }
                        else if (RemoteFilesPath.Count == LocalFilesPath.Count)
                        {
                            for (int index = 0; index < LocalFilesPath.Count; index++)
                            {
                                try
                                {
                                    _filepath = LocalFilesPath[index].Replace("\\", "/");
                                    FileInfo fileInfo = new FileInfo(_filepath);
                                    ftp.UploadFile(LocalFilesPath[index].Replace("\\", "/"), RemoteFilesPath[index].Replace("\\", "/"));
                                    FTPResStatusPush(item.IP, fileInfo.Name, true, FTPType.Upload);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", "更版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", CSL.Get(CSLE.R_L_UpdateVersionStatus));
                                    ProgressBarPush();
                                }
                                catch (Exception ex)
                                {
                                    FTPResStatusPush(item.IP, new FileInfo(_filepath).Name, false, FTPType.Upload);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}", "更版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} {ex.Message}", CSL.Get(CSLE.R_L_UpdateVersionStatus));
                                }
                            }
                        }
                        else
                        {
                            //MessageHelper.Error("请检查，本地待上传文件数理与对应文件远程目录不一致！");
                            //LogHepler.WriterLog(OperationUserName, $"请检查，本地待上传文件数理与对应文件远程目录不一致！", "更版错误");
                            MessageHelper.Error(CSL.Get(CSLE.R_M_E_FolderNumber));
                            LogHepler.WriterLog(OperationUserName, CSL.Get(CSLE.R_M_E_FolderNumber), CSL.Get(CSLE.R_L_UpdateVersionStatus_Error));
                            return;
                        }

                        UpdateVersionFolder();
                        butBackVersion.Enabled = true;
                        cbBBackVersion.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        //MessageHelper.Error(ex.Message);
                        FTPResStatusPush(item.IP, _filepath, false, FTPType.Upload);
                        //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} Msg:{ex.Message}", "更版异常");
                        LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} Msg:{ex.Message}", CSL.Get(CSLE.R_L_UpdateVersionStatus_Exception));
                    }
                }

                #endregion
            }

        }

        private void butDownload_Click(object sender, EventArgs e)
        {
            SelectAPList = GetSelectAP();
            APConfigModel item = SelectAPList[0];
            string _filepath = string.Empty;
            string LocaFilepath = string.Empty;
            try
            {
                //构建FTP连接对象
                FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path, item.FTPUserName, item.FTPPassWord);
                foreach (string filePath in UploadFiles)
                {
                    _filepath = filePath;
                    string[] filepathSpit = filePath.Split('\\');
                    LocaFilepath = $@"E:\XIAOANDX\FTP\WebApi\Down\{filepathSpit[(filepathSpit.Count() - 1)]}";
                    ftp.DownloadFile(filepathSpit[(filepathSpit.Count() - 1)], LocaFilepath);
                    FTPResStatusPush(item.IP, LocaFilepath, true, FTPType.Download);
                }
            }
            catch (Exception ex)
            {
                //MessageHelper.Error(ex.Message);
                FTPResStatusPush(item.IP, LocaFilepath, false, FTPType.Download);
            }

        }

        private void butBackup_Click(object sender, EventArgs e)
        {
            //清除进度条
            progressBar.Value = 0;

            //获取最新的本地上传文件及远程对应路径
            UpdateFilePath();

            //操作解锁
            if (!checkBBackupLock.Checked)
            {
                //MessageHelper.Warning("备份操作被禁止，请启用操作锁！");
                MessageHelper.Warning(CSL.Get(CSLE.R_M_BackupBack));
                return;
            }

            SelectAPList = GetSelectAP();

            if (SelectAPList.Count == 0)
            {
                MessageHelper.Warning(CSL.Get(CSLE.R_M_SelectAPList));
                return;
            }

            //备份文件目录
            string VersionBackupPathBase = GetVersionBackupPathBase();
            string DataString = DateTime.Now.ToString("yyyyMMddHH");
            teBBackupDir.Text = DataString;
            SelectAPList = GetSelectAP();
            APConfigModel item = SelectAPList[0];
            string _filepath = string.Empty;
            string _LocaFilepath = string.Empty;
            //LogHepler.WriterLog(OperationUserName, $"{DataString} {VersionBackupPathBase} {JsonConvert.SerializeObject(item)}", "备份文件夹及AP");
            LogHepler.WriterLog(OperationUserName, $"{DataString} {VersionBackupPathBase} {JsonConvert.SerializeObject(item)}", CSL.Get(CSLE.R_BackupFolder));
            //是否开启了AP独立设置上传子目录
            if (checkBoIsSetRemotePath.Checked)
            {
                #region 勾选

                string[] _RemoteFilesPathByAP = APRemotePathsByIPDictionary[item.IP];
                try
                {
                    //构建FTP连接对象
                    FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path, item.FTPUserName, item.FTPPassWord);
                    if (_RemoteFilesPathByAP.Length == 0)
                    {
                        progressBar.Maximum = LocalFilesPath.Count();
                        foreach (string filePath in LocalFilesPath)
                        {
                            try
                            {
                                _filepath = filePath.Replace("\\", "/");
                                string[] filepathSpit = _filepath.Split('/');
                                _LocaFilepath = $@"{VersionBackupPathBase}/{DataString}/{filepathSpit[(filepathSpit.Count() - 1)]}";
                                ftp.DownloadFile(filepathSpit[(filepathSpit.Count() - 1)], _LocaFilepath);
                                FTPResStatusPush(item.IP, _LocaFilepath, true, FTPType.BackupVersion);
                                //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {true}", "备份状态");
                                LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {true}", CSL.Get(CSLE.R_L_BackupStatus));
                                ProgressBarPush();
                            }
                            catch (Exception ex)
                            {
                                //DeleteFile(_LocaFilepath); -去掉
                                FTPResStatusPush(item.IP, _LocaFilepath, false, FTPType.BackupVersion);
                                //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false}", "备份状态");
                                LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false} {ex.Message}", CSL.Get(CSLE.R_L_BackupStatus));
                            }
                        }
                    }
                    else if (_RemoteFilesPathByAP.Length == ActualLoaclFilesNumer)
                    {
                        progressBar.Maximum = ActualLoaclFilesNumer;
                        for (int index = 0; index < ActualLoaclFilesNumer; index++)
                        {
                            try
                            {
                                _filepath = LocalFilesPathArray[index].Replace("\\", "/");
                                string[] filepathSpit = _filepath.Split('/');
                                _LocaFilepath = $@"{VersionBackupPathBase}/{DataString}/{_RemoteFilesPathByAP[index].Replace("\\", "/")}{filepathSpit[(filepathSpit.Count() - 1)]}";
                                string _RemoctPath = _RemoteFilesPathByAP[index].Replace("\\", "/") + filepathSpit[(filepathSpit.Count() - 1)];
                                ftp.DownloadFile(_RemoctPath, _LocaFilepath);
                                FTPResStatusPush(item.IP, _LocaFilepath, true, FTPType.BackupVersion);
                                //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {true}", "备份状态");
                                LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {true}", CSL.Get(CSLE.R_L_BackupStatus));
                                ProgressBarPush();
                            }
                            catch (Exception ex)
                            {
                                FTPResStatusPush(item.IP, _LocaFilepath, false, FTPType.BackupVersion);
                                //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false}", "备份状态");
                                LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false} {ex.Message}", CSL.Get(CSLE.R_L_BackupStatus));
                            }
                        }
                    }
                    else
                    {
                        //MessageHelper.Error("请检查，本地待备份文件数理与对应文件远程目录不一致！");
                        //LogHepler.WriterLog(OperationUserName, $"请检查，本地待备份文件数理与对应文件远程目录不一致！", "备份错误");
                        MessageHelper.Error(CSL.Get(CSLE.R_M_E_BackupFolderNumber));
                        LogHepler.WriterLog(OperationUserName, CSL.Get(CSLE.R_M_E_BackupFolderNumber), CSL.Get(CSLE.R_L_BackupStatus_Error));
                        return;
                    }
                    butUpload.Enabled = true;
                }
                catch (Exception ex)
                {
                    //MessageHelper.Error(ex.Message);
                    FTPResStatusPush(item.IP, _LocaFilepath, false, FTPType.BackupVersion);
                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false} Msg:{ex.Message}", "备份异常");
                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false} Msg:{ex.Message}", CSL.Get(CSLE.R_L_BackupStatus_Exception));
                }

                #endregion
            }
            else
            {
                #region 未勾选

                //没有开启独立AP设置，采用统一设定
                try
                {
                    //构建FTP连接对象
                    FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path, item.FTPUserName, item.FTPPassWord);
                    if (RemoteFilesPath.Count == 0)
                    {
                        progressBar.Maximum = LocalFilesPath.Count();
                        foreach (string filePath in LocalFilesPath)
                        {
                            try
                            {
                                _filepath = filePath.Replace("\\", "/");
                                string[] filepathSpit = _filepath.Split('/');
                                _LocaFilepath = $@"{VersionBackupPathBase}/{DataString}/{item.ProjectFolderPath.Replace("\\", "/")}/{filepathSpit[(filepathSpit.Count() - 1)]}";
                                ftp.DownloadFile($"{item.ProjectFolderPath.Replace("\\", "/")}/{filepathSpit[(filepathSpit.Count() - 1)]}", _LocaFilepath);
                                FTPResStatusPush(item.IP, _LocaFilepath, true, FTPType.BackupVersion);
                                //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {true}", "备份状态");
                                LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {true}", CSL.Get(CSLE.R_L_BackupStatus));
                                ProgressBarPush();
                            }
                            catch (Exception ex)
                            {
                                //DeleteFile(_LocaFilepath);
                                FTPResStatusPush(item.IP, _LocaFilepath, false, FTPType.BackupVersion);
                                //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false}", "备份状态");
                                LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false} {ex.Message}", CSL.Get(CSLE.R_L_BackupStatus));
                            }
                        }
                    }
                    else if (RemoteFilesPath.Count == LocalFilesPath.Count)
                    {
                        progressBar.Maximum = LocalFilesPath.Count();
                        for (int index = 0; index < LocalFilesPath.Count; index++)
                        {
                            try
                            {
                                _filepath = LocalFilesPath[index].Replace("\\", "/");
                                string[] filepathSpit = _filepath.Split('/');
                                _LocaFilepath = $@"{VersionBackupPathBase}/{DataString}/{RemoteFilesPath[index].Replace("\\", "/")}{filepathSpit[(filepathSpit.Count() - 1)]}";
                                string _RemoctPath = RemoteFilesPath[index].Replace("\\", "/") + filepathSpit[(filepathSpit.Count() - 1)];
                                ftp.DownloadFile(_RemoctPath, _LocaFilepath);
                                FTPResStatusPush(item.IP, _LocaFilepath, true, FTPType.BackupVersion);
                                //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {true}", "备份状态");
                                LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {true}", CSL.Get(CSLE.R_L_BackupStatus));
                                ProgressBarPush();
                            }
                            catch (Exception ex)
                            {
                                FTPResStatusPush(item.IP, _LocaFilepath, false, FTPType.BackupVersion);
                                //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false}", "备份状态");
                                LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false} {ex.Message}", CSL.Get(CSLE.R_L_BackupStatus));
                            }
                        }
                    }
                    else
                    {
                        //MessageHelper.Error("请检查，本地待备份文件数理与对应文件远程目录不一致！");
                        //LogHepler.WriterLog(OperationUserName, $"请检查，本地待备份文件数理与对应文件远程目录不一致！", "备份错误");
                        MessageHelper.Error(CSL.Get(CSLE.R_M_E_BackupFolderNumber));
                        LogHepler.WriterLog(OperationUserName, CSL.Get(CSLE.R_M_E_BackupFolderNumber), CSL.Get(CSLE.R_L_BackupStatus_Error));
                        return;
                    }
                    butUpload.Enabled = true;
                }
                catch (Exception ex)
                {
                    //MessageHelper.Error(ex.Message);
                    FTPResStatusPush(item.IP, _LocaFilepath, false, FTPType.BackupVersion);
                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false} Msg:{ex.Message}", "备份异常");
                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {_LocaFilepath} {false} Msg:{ex.Message}", CSL.Get(CSLE.R_L_BackupStatus_Exception));
                }

                #endregion
            }
        }

        private void butBackVersion_Click(object sender, EventArgs e)
        {
            //清除进度条
            progressBar.Value = 0;

            //操作解锁
            if (!checkBoxBackVersion.Checked)
            {
                //MessageHelper.Warning("退版操作被禁止，请启用操作锁！");
                MessageHelper.Warning("退版操作被禁止，请启用操作锁！");
                return;
            }

            SelectAPList = GetSelectAP();

            UpdateFilePath();

            if (SelectAPList == null || SelectAPList.Count == 0)
            {
                //MessageHelper.Error("未选择上传AP！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_BackSelectAP));
                return;
            }

            //更新退版文件路径
            string _backVersionPathBase = GetVersionBackupPathBase();
            string _backVersionDirName = cbBBackVersion.SelectedItem.ToString();
            if ("**选择Version文件夹**".Equals(_backVersionDirName) || string.IsNullOrEmpty(_backVersionDirName))
            {
                //MessageHelper.Error("请选择退版文件夹！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_BackSelectDir));
                return;
            }
            _backVersionPathBase = _backVersionPathBase + '/' + _backVersionDirName;


            SelectDirBackVersion(_backVersionPathBase);

            //LogHepler.WriterLog(OperationUserName, $"{JsonConvert.SerializeObject(BackVersionLoaclFilePath)} ", "选择退版文件");
            LogHepler.WriterLog(OperationUserName, $"{JsonConvert.SerializeObject(BackVersionLoaclFilePath)} ", CSL.Get(CSLE.R_BackFolder));

            //是否开启了AP独立设置上传子目录
            if (checkBoIsSetRemotePath.Checked)
            {
                #region 勾选

                progressBar.Maximum = SelectAPList.Count * ActualBackVersionLoaclFileNumer;
                for (int i = 0; i < SelectAPList.Count; i++)
                {
                    APConfigModel item = SelectAPList[i];
                    string _filepath = string.Empty;
                    string[] _RemoteFilesPathByAP = APRemotePathsByIPDictionary[item.IP];
                    try
                    {
                        //构建FTP连接对象
                        FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path, item.FTPUserName, item.FTPPassWord);
                        if (_RemoteFilesPathByAP.Length == 0)
                        {
                            foreach (string filePath in BackVersionLoaclFilePathArray)
                            {
                                try
                                {
                                    _filepath = filePath.Replace("\\", "/");
                                    FileInfo fileInfo = new FileInfo(_filepath);
                                    ftp.UploadFile(filePath.Replace("\\", "/"));
                                    FTPResStatusPush(item.IP, fileInfo.Name, true, FTPType.BackVersion);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", "退版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", CSL.Get(CSLE.R_L_BackStatus));
                                    ProgressBarPush();
                                }
                                catch (Exception ex)
                                {
                                    FTPResStatusPush(item.IP, new FileInfo(_filepath).Name, false, FTPType.BackVersion);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}", "退版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} {ex.Message}", CSL.Get(CSLE.R_L_BackStatus));
                                }
                            }
                        }
                        else if (_RemoteFilesPathByAP.Length == ActualBackVersionLoaclFileNumer)
                        {
                            for (int index = 0; index < ActualBackVersionLoaclFileNumer; index++)
                            {
                                try
                                {
                                    _filepath = BackVersionLoaclFilePathArray[index].Replace("\\", "/");
                                    FileInfo fileInfo = new FileInfo(_filepath);
                                    ftp.UploadFile(BackVersionLoaclFilePathArray[index].Replace("\\", "/"), _RemoteFilesPathByAP[index].Replace("\\", "/"));
                                    FTPResStatusPush(item.IP, fileInfo.Name, true, FTPType.BackVersion);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", "退版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", CSL.Get(CSLE.R_L_BackStatus));
                                    ProgressBarPush();
                                }
                                catch (Exception ex)
                                {
                                    FTPResStatusPush(item.IP, new FileInfo(_filepath).Name, false, FTPType.BackVersion);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}", "退版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} {ex.Message}", CSL.Get(CSLE.R_L_BackStatus));
                                }
                            }
                        }
                        else
                        {
                            //MessageHelper.Error("请检查，本地待上传文件数理与对应文件远程目录不一致！");
                            //LogHepler.WriterLog(OperationUserName, $"请检查，本地待上传文件数理与对应文件远程目录不一致！", "退版失败");
                            MessageHelper.Error(CSL.Get(CSLE.R_M_E_BackFolderNumber));
                            LogHepler.WriterLog(OperationUserName, CSL.Get(CSLE.R_M_E_BackFolderNumber), CSL.Get(CSLE.R_L_BackStatus_Error));
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageHelper.Error(ex.Message);
                        FTPResStatusPush(item.IP, _filepath, false, FTPType.BackVersion);
                        //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} Msg:{ex.Message}", "退版异常");
                        LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} Msg:{ex.Message}", CSL.Get(CSLE.R_L_BackStatus_Exception));
                    }
                }

                #endregion
            }
            else
            {
                #region 未勾选

                progressBar.Maximum = SelectAPList.Count * BackVersionLoaclFilePath.Count;
                for (int i = 0; i < SelectAPList.Count; i++)
                {
                    APConfigModel item = SelectAPList[i];
                    string _filepath = string.Empty;
                    try
                    {
                        //构建FTP连接对象
                        FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path, item.FTPUserName, item.FTPPassWord);
                        if (RemoteFilesPath.Count == 0)
                        {
                            foreach (string filePath in BackVersionLoaclFilePath)
                            {
                                try
                                {
                                    _filepath = filePath.Replace("\\", "/");
                                    FileInfo fileInfo = new FileInfo(_filepath);
                                    ftp.UploadFile(filePath.Replace("\\", "/"), item.ProjectFolderPath.Replace("\\", "/"));
                                    FTPResStatusPush(item.IP, fileInfo.Name, true, FTPType.BackVersion);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", "退版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", CSL.Get(CSLE.R_L_BackStatus));
                                    ProgressBarPush();
                                }
                                catch (Exception ex)
                                {
                                    FTPResStatusPush(item.IP, new FileInfo(_filepath).Name, false, FTPType.BackVersion);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}", "退版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} {ex.Message}", CSL.Get(CSLE.R_L_BackStatus));
                                }
                            }
                        }
                        else if (RemoteFilesPath.Count == BackVersionLoaclFilePath.Count)
                        {
                            for (int index = 0; index < BackVersionLoaclFilePath.Count; index++)
                            {
                                try
                                {
                                    _filepath = BackVersionLoaclFilePath[index].Replace("\\", "/");
                                    FileInfo fileInfo = new FileInfo(_filepath);
                                    ftp.UploadFile(BackVersionLoaclFilePath[index].Replace("\\", "/"), RemoteFilesPath[index].Replace("\\", "/"));
                                    FTPResStatusPush(item.IP, fileInfo.Name, true, FTPType.BackVersion);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", "退版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {fileInfo.Name} {true}", CSL.Get(CSLE.R_L_BackStatus));
                                    ProgressBarPush();
                                }
                                catch (Exception ex)
                                {
                                    FTPResStatusPush(item.IP, new FileInfo(_filepath).Name, false, FTPType.BackVersion);
                                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false}", "退版状态");
                                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} {ex.Message}", CSL.Get(CSLE.R_L_BackStatus));
                                }
                            }
                        }
                        else
                        {
                            //MessageHelper.Error("请检查，本地待上传文件数理与对应文件远程目录不一致！");
                            //LogHepler.WriterLog(OperationUserName, $"请检查，本地待上传文件数理与对应文件远程目录不一致！", "退版失败");
                            MessageHelper.Error(CSL.Get(CSLE.R_M_E_BackFolderNumber));
                            LogHepler.WriterLog(OperationUserName, CSL.Get(CSLE.R_M_E_BackFolderNumber), CSL.Get(CSLE.R_L_BackStatus_Error));
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageHelper.Error(ex.Message);
                        FTPResStatusPush(item.IP, _filepath, false, FTPType.BackVersion);
                        //LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} Msg:{ex.Message}", "退版异常");
                        LogHepler.WriterLog(OperationUserName, $"{item.IP} {new FileInfo(_filepath).Name} {false} Msg:{ex.Message}", CSL.Get(CSLE.R_L_BackStatus_Exception));
                    }
                }

                #endregion
            }
        }

        private void butAddConfig_Click(object sender, EventArgs e)
        {
            AddAPConfig addConfig = new AddAPConfig(this, OperationUserName, Factory);
            addConfig.Show();
            if (isCloerAdd)
            {
                SelectAllConfig();
            }
        }

        private void checkBIsFirst_CheckedChanged(object sender, EventArgs e)
        {
            //checkBIsFirst.Checked = !checkBIsFirst.Checked;
            if (checkBIsFirst.Checked)
            {
                //LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(checkBIsFirst.Checked), "是否首次上传更版文件！");
                LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(checkBIsFirst.Checked), CSL.Get(CSLE.R_L_FistUploadFile));
                butBackup.Enabled = false;
                butUpload.Enabled = true;
            }
            else {
                butBackup.Enabled = true;
                butUpload.Enabled = false;
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butCloseConfig_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void comboBFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            butLogin.Enabled = true;
        }

        private void butCloseAuten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                Login();
            }
        }

        private void checkBBackVersion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBBackVersion.Checked)
            {
                //LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(checkBBackVersion.Checked), "单独进行退版操作！");
                LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(checkBBackVersion.Checked), CSL.Get(CSLE.R_L_Perform));
                butBackVersion.Enabled = true;
                cbBBackVersion.Enabled = true;
                checkBoxBackVersion.Enabled = true;

                cBUpdateType.Enabled = true;
                butUpdateTypeAP.Enabled = true;

                checkBoIsSetRemotePath.Checked = false;
            }
            else
            {
                butBackVersion.Enabled = false;
                cbBBackVersion.Enabled = false;

                cBUpdateType.Enabled = false;
                butUpdateTypeAP.Enabled = false;
            }
        }

        //单独设定远程路径
        private void checkBoIsSetRemotePath_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoIsSetRemotePath.Checked)
            {
                //LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(checkBIsFirst.Checked), "单独设定远程上传更版文件目录！");
                //LogHepler.WriterLog(OperationUserName, $@"{JsonConvert.SerializeObject(checkBIsFirst.Checked)}", "单独设定远程上传更版文件目录！");
                LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(checkBIsFirst.Checked), CSL.Get(CSLE.R_L_SetTheFileDirectoryForRemote));
                teBUploadPath.Enabled = false;
            }
            else
            {
                teBUploadPath.Enabled = true;
            }
        }
        private void cLBAPS_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            cLBAPS.ItemCheck -= cLBAPS_ItemCheck;
            bool isChecked = cLBAPS.GetItemChecked(e.Index);
            cLBAPS.SetItemChecked(e.Index, !isChecked);
            if (checkBoIsSetRemotePath.Checked)
            {
                try
                {
                    string _SelectIP = cLBAPS.SelectedItem.ToString();
                    APConfigModel _SelectAP = _TypeAPConfigList.Find(a => _SelectIP.Equals(a.IP));
                    if (APInfroDictionary.ContainsKey(_SelectIP))
                    {
                        APInfroDictionary[_SelectIP] = _SelectAP;
                    }
                    else
                    {
                        APInfroDictionary.Add(_SelectIP, _SelectAP);
                    }
                    APEditRemotPath aPEditRemotPath = new APEditRemotPath(ActualLoaclFilesNumer, LocalFilesPathArray, _SelectAP, ref APRemotePathsByIPDictionary);
                    aPEditRemotPath.ShowDialog();
                    //LogHepler.WriterLog($@"{_SelectIP} {JsonConvert.SerializeObject(_SelectAP)} {APRemotePathsByIPDictionary[_SelectIP]}", "AP单独配置上传路径(首次设定)");
                    LogHepler.WriterLog($@"{_SelectIP} {JsonConvert.SerializeObject(_SelectAP)} {APRemotePathsByIPDictionary[_SelectIP]}", CSL.Get(CSLE.R_L_FistSettingAPPath));
                }
                catch (Exception ex)
                {
                    //MessageHelper.Error("请勿重复勾选AP！");
                    //LogHepler.WriterLog($@"请勿重复勾选AP！", "AP单独配置上传异常");
                    MessageHelper.Error(CSL.Get(CSLE.R_M_DoNotGouXuanTheAPAgain));
                    LogHepler.WriterLog(CSL.Get(CSLE.R_M_DoNotGouXuanTheAPAgain), CSL.Get(CSLE.R_L_GouXuanTheAPAgainFiled));
                    cLBAPS.ItemCheck += cLBAPS_ItemCheck;
                    return;
                }
            }
            cLBAPS.ItemCheck += cLBAPS_ItemCheck;
        }

        //监控相关组件事件
        private void butWebApi_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            ShowLogOpenMoinWebApi(textBWebApi, path.SelectedPath, VersionType.WebApi, listVWebApi);
            //textBWebApi.Text = path.SelectedPath;
            WebApiMonitorPath = path.SelectedPath;
            //MonitorLog(listVWebApi,"初始化", "选择监控目录");
            //LogHepler.WriterLog($"WebApi初始化目录：{path.SelectedPath}","选择监控目录");
            //WebApiopenFolderMonitor(path.SelectedPath);
        }

        private void butPDA_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            ShowLogOpenMoinPDA(textBPDA, path.SelectedPath, VersionType.PDA, listVPDA);
            //textBPDA.Text = path.SelectedPath;
            PDAMonitorPath = path.SelectedPath;
            //MonitorLog(listVPDA, "初始化", "选择监控目录");
            //PDAopenFolderMonitor(path.SelectedPath);
        }

        private void butCIMPDA_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            ShowLogOpenMoinCIMPDA(textBCIMPDA, path.SelectedPath, VersionType.CIMPDA, listVCIMPDA);
            //textBCIMPDA.Text = path.SelectedPath;
            CIMPDAMonitorPath = path.SelectedPath;
            //MonitorLog(listVCIMPDA, "初始化", "选择监控目录");
            //CIMPDAopenFolderMonitor(path.SelectedPath);
        }

        private void butCamstarPortal_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            ShowLogOpenMoinCamstarPort(textBCamstarPortal, path.SelectedPath, VersionType.CamstarPortal, listVCamstarPortal);
            //textBCamstarPortal.Text = path.SelectedPath;
            CamPortalMonitorPath = path.SelectedPath;
            //MonitorLog(listVCamstarPortal, "初始化", "选择监控目录");
            //CamstarPortalopenFolderMonitor(path.SelectedPath);
        }

        private void butSaveFolderPath_Click(object sender, EventArgs e)
        {
            //DialogResult res = MessageHelper.Asterisk("是否保存本次监控目录！");
            DialogResult res = MessageHelper.Asterisk(CSL.Get(CSLE.R_M_ISSaveLoacMoitorFolder));
            if (res == DialogResult.OK) {
                INIHelper.WriteIni("Monitor", "WebApi", textBWebApi.Text, Environment.CurrentDirectory + @"/Config.ini");
                INIHelper.WriteIni("Monitor", "PDA", textBPDA.Text, Environment.CurrentDirectory + @"/Config.ini");
                INIHelper.WriteIni("Monitor", "CIMPDA", textBCIMPDA.Text, Environment.CurrentDirectory + @"/Config.ini");
                INIHelper.WriteIni("Monitor", "CamstarPortal", textBCamstarPortal.Text, Environment.CurrentDirectory + @"/Config.ini");
                //LogHepler.WriterLog($"Config.ini Update {textBWebApi.Text},{textBPDA.Text},{textBCIMPDA.Text},{textBCamstarPortal.Text}", "保存本次设定的监控目录");
                LogHepler.WriterLog($"Config.ini Update {textBWebApi.Text},{textBPDA.Text},{textBCIMPDA.Text},{textBCamstarPortal.Text}", CSL.Get(CSLE.R_L_SaveSettingPath));
            }
        }

        //最小化到任务栏
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            bool _IsMonitorRes = IsMonitor();
            if (_IsMonitorRes)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.ShowInTaskbar = false;
                    notifyIcon1.Visible = true;
                    hidden = new Hidden();
                    hidden.Show();
                    this.Hide();
                }
            }
            else
            {
                //this.WindowState = FormWindowState.Minimized;
            } 
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            if (hidden != null)
                hidden.Hide();
            notifyIcon1.Visible = false;
        }

        //IsRecyclePool
        private void butPool_Click(object sender, EventArgs e)
        {
            //清除进度条
            progressBar.Value = 0;

            //获取最新的本地上传文件及远程对应路径
            UpdateFilePath();

            SelectAPList = GetSelectAP();

            UpdateFilePath();

            if (SelectAPList == null || SelectAPList.Count == 0)
            {
                //MessageHelper.Error("未选择上传AP！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_BackSelectAP));
                return;
            }

            #region 未勾选

            progressBar.Maximum = LocalFilesPath.Count() * SelectAPList.Count;
            for (int i = 0; i < SelectAPList.Count; i++)
            {
                APConfigModel item = SelectAPList[i];
                string _filepath = string.Empty;
                try
                {
                    //构建FTP连接对象
                    FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path, item.FTPUserName, item.FTPPassWord);
                    string DataString = DateTime.Now.ToString("yyyyMMddHHmmss");
                    _filepath = $@"IsRecylcePool/" + DataString;
                    ftp.MakeDir(_filepath);
                    FTPResStatusPush(item.IP, _filepath, true, FTPType.RecyclePool);
                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {item.IP}:{item.Port}/{item.Path}/{_filepath} {true} Create Recycle Folder Successfully！", "回收Pool");
                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {item.IP}:{item.Port}/{item.Path}/{_filepath} {true} Create Recycle Folder Successfully！", CSL.Get(CSLE.R_L_RecyclePool));
                }
                catch (Exception ex)
                {
                    //MessageHelper.Error(ex.Message);
                    FTPResStatusPush(item.IP, _filepath, false, FTPType.Upload);
                    //LogHepler.WriterLog(OperationUserName, $"{item.IP} {_filepath} {false} Msg:{ex.Message}", "回收Pool异常");
                    LogHepler.WriterLog(OperationUserName, $"{item.IP} {_filepath} {false} Msg:{ex.Message}", CSL.Get(CSLE.R_L_RecyclePoolFiled));
                }
            }

            #endregion
        }

        private void butOpenMonitor_Click(object sender, EventArgs e)
        {
            string[] Msg = new string[4];
            StringBuilder sb = new StringBuilder();
            OpenMonitor(textBWebApi, listVWebApi, VersionType.WebApi, 0, ref Msg);
            OpenMonitor(textBPDA, listVPDA, VersionType.PDA, 1, ref Msg);
            OpenMonitor(textBCIMPDA, listVCIMPDA, VersionType.CIMPDA, 2, ref Msg);
            OpenMonitor(textBCamstarPortal, listVCamstarPortal, VersionType.CamstarPortal, 3, ref Msg);
            foreach (string item in Msg)
            {
                sb.Append(item);
                if (!string.IsNullOrEmpty(item))
                {
                    sb.Append(@" | ");
                }
            }
            //LogHepler.WriterLog(OperationUserName, sb.ToString(), "批量启用文件监控");
            LogHepler.WriterLog(OperationUserName, sb.ToString(), CSL.Get(CSLE.R_L_EnableBatchFileMonitoring));
            MessageHelper.Asterisk(sb.ToString());
        }

        //多语言
        private void comboBLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!CSL.Get(CSLE.A_SelectLanguageTitle).Equals(comboBLanguage.SelectedItem.ToString()))
            {
                INIHelper.WriteIni("AppLanguage", "Language", comboBLanguage.SelectedItem.ToString(), Environment.CurrentDirectory + @"/Config.ini");
                //DialogResult res = MessageHelper.Question("需要重启应用才可生效！点击OK重启");
                DialogResult res = MessageHelper.Question(CSL.Get(CSLE.R_AppLanguage));
                if (res == DialogResult.Yes)
                {
                    Application.Restart();
                }
            } 
        }

        //选择版本回退加载文件
        private void cbBBackVersion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 清楚上传选取的文件
            tBMFilesPath.Clear();

            string _backVersionPathBase = GetVersionBackupPathBase();
            string _backVersionDirName = cbBBackVersion.SelectedItem.ToString();
            _backVersionPathBase = _backVersionPathBase + '/' + _backVersionDirName;
            DirSelectFiles(_backVersionPathBase);
        }

        //不备份，单更版
        private void checkBUpload_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBUpload.Checked)
            {
                //LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(checkBIsFirst.Checked), "单独设定远程上传更版文件目录！");
                //LogHepler.WriterLog(OperationUserName, $@"{JsonConvert.SerializeObject(checkBIsFirst.Checked)}", "单独设定远程上传更版文件目录！");
                LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(checkBIsFirst.Checked), CSL.Get(CSLE.R_L_SetcheckBUpload));
                butBackup.Enabled = false;
                butUpload.Enabled = true;
                butBackVersion.Enabled = true;
                cbBBackVersion.Enabled = true;
                checkBoxUploadLock.Enabled = true;
                checkBoxBackVersion.Enabled = true;
            }
            else
            {
                butBackup.Enabled = true;
                butUpload.Enabled = false;
                butBackVersion.Enabled = false;
                cbBBackVersion.Enabled = false;
            }
        }

        /////////////////////////////////////////////////////////////////// 事件与方法分割线//////////////////////////////////////////////////////////

        public void SelectAllConfig()
        {
            listView1.Items.Clear();
            DataTable data = new DataTable();
            data = MdbHepler.Query($"select * from APConfigDateils ap where ap.Factory = '{Factory}' Order By ap.IP DESC, ap.Type ASC");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ListViewItem litem = new ListViewItem();
                litem.Text = (i + 1).ToString();
                litem.SubItems.Add(data.Rows[i][1].ToString());
                litem.SubItems.Add(data.Rows[i][2].ToString());
                litem.SubItems.Add(data.Rows[i][3].ToString());
                litem.SubItems.Add(data.Rows[i][4].ToString());
                litem.SubItems.Add(data.Rows[i][5].ToString());
                litem.SubItems.Add(data.Rows[i][6].ToString());
                litem.SubItems.Add(data.Rows[i][8].ToString());
                litem.SubItems.Add(data.Rows[i][7].ToString());
                listView1.BeginUpdate();
                listView1.Items.Add(litem);
                listView1.EndUpdate();
            }
            _APConfig = data;
            LogHepler.WriterLog(JsonConvert.SerializeObject(_APConfig), "FindAllAPConfig");
        }

        private void ShowDataInListView(DataTable dt, ListView lv)
        {
            lv.Clear();
            lv.AllowColumnReorder = true;
            lv.GridLines = true;
            int RowCount, ColCount, i, j;
            DataRow dr = null;

            if (dt == null) return;
            RowCount = dt.Rows.Count;
            ColCount = dt.Columns.Count;

            for (i = 0; i < ColCount; i++)
            {
                lv.Columns.Add(dt.Columns[i].Caption.Trim(), lv.Width / ColCount, HorizontalAlignment.Left);
            }

            if (RowCount == 0) return;

            for (i = 0; i < RowCount; i++)
            {
                dr = dt.Rows[i];
                lv.Items.Add(dr[0].ToString().Trim());
                for (j = 1; j < ColCount; j++)
                {
                    lv.Items[i].SubItems.Add((string)dr[j].ToString().Trim());
                }
            }
        }

        private void SelectDir()
        {
            string scanDirectoryPath = tBFolderPath.Text;
            if (String.IsNullOrEmpty(scanDirectoryPath))
            {
                //MessageHelper.Error("扫描文件夹不能为空！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_ScannedFile));
                return;
            }
            else
            {
                this.tBMFilesPath.Clear();
                DirSelectFiles(scanDirectoryPath);
                cBUpdateType.Enabled = true;
                butUpdateTypeAP.Enabled = true;
                teBUploadPath.Enabled = true;
                tBMFilesPath.Enabled = false;
            }
        }

        private void SelectDir(string FolerPath)
        {
            if (String.IsNullOrEmpty(FolerPath))
            {
                //MessageHelper.Error("扫描文件夹不能为空！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_ScannedFile));
                return;
            }
            else
            {
                BackVersionLoaclFilePath.Clear();
                DirSelectFilesList(FolerPath);
                ActualBackVersionLoaclFileNumer = BackVersionLoaclFilePath.Count;
            }
        }

        private void SelectDirBackVersion(string FolerPath)
        {
            if (String.IsNullOrEmpty(FolerPath))
            {
                //MessageHelper.Error("扫描文件不能为空！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_ScannedFile));
                return;
            }
            else
            {
                BackVersionLoaclFilePath.Clear();
                int LoacFileNumer = 0;
                DirSelectFilesList(FolerPath, ref LoacFileNumer);
                ActualBackVersionLoaclFileNumer = BackVersionLoaclFilePath.Count;
            }
        }

        private void DirSelectFiles(string DirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(DirPath);
            if (dir.Exists == false)
            {
                //MessageHelper.Error("文件夹路径不存在！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_FolderPathDoesNotExist));
                return;
            }

            DirectoryInfo[] dis = dir.GetDirectories();
            if (dis.Count() > 0)
            {
                foreach (DirectoryInfo d in dis)
                {
                    DirSelectFiles(d.FullName);
                }
            }

            //检索当前目录的文件与子目录
            FileSystemInfo[] fsinfos = dir.GetFiles();
            if (fsinfos.Count() <= 0)
            {
                return;
            }
            else
            {
                //遍历检索的文件和子目录
                foreach (FileSystemInfo item in fsinfos)
                {
                    tBMFilesPath.AppendText(item.FullName);
                    UploadFiles.Add(item.FullName);
                    tBMFilesPath.AppendText("\r\n");
                }
            }
        }

        private void DirSelectFilesList(string DirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(DirPath);
            if (dir.Exists == false)
            {
                //MessageHelper.Error("文件夹路径不存在！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_FolderPathDoesNotExist));
                return;
            }

            DirectoryInfo[] dis = dir.GetDirectories();
            if (dis.Count() > 0)
            {
                foreach (DirectoryInfo d in dis)
                {
                    DirSelectFilesList(d.FullName);
                }
            }

            //检索当前目录的文件与子目录
            FileSystemInfo[] fsinfos = dir.GetFiles();
            if (fsinfos.Count() <= 0)
            {
                return;
            }
            else
            {
                //遍历检索的文件和子目录
                //foreach (FileSystemInfo item in fsinfos)
                //{
                //    BackVersionLoaclFilePath.Add(item.FullName);
                //}
                for (int i = 0, num = 0; i < fsinfos.Length; i++)
                {
                    BackVersionLoaclFilePath.Add(fsinfos[i].FullName);
                    BackVersionLoaclFilePathArray[num] = fsinfos[i].FullName;
                    num++;
                }
            }
        }

        private void DirSelectFilesList(string DirPath, ref int num)
        {
            DirectoryInfo dir = new DirectoryInfo(DirPath);
            if (dir.Exists == false)
            {
                //MessageHelper.Error("文件夹路径不存在！");
                MessageHelper.Error(CSL.Get(CSLE.R_M_FolderPathDoesNotExist));
                return;
            }

            DirectoryInfo[] dis = dir.GetDirectories();
            if (dis.Count() > 0)
            {
                foreach (DirectoryInfo d in dis)
                {
                    DirSelectFilesList(d.FullName, ref num);
                }
            }

            //检索当前目录的文件与子目录
            FileSystemInfo[] fsinfos = dir.GetFiles();
            if (fsinfos.Count() <= 0)
            {
                return;
            }
            else
            {
                //遍历检索的文件和子目录
                //foreach (FileSystemInfo item in fsinfos)
                //{
                //    BackVersionLoaclFilePath.Add(item.FullName);
                //}
                for (int i = 0; i < fsinfos.Length; i++)
                {
                    BackVersionLoaclFilePath.Add(fsinfos[i].FullName);
                    BackVersionLoaclFilePathArray[num] = fsinfos[i].FullName;
                    num++;
                }
            }
        }

        private void InitCheckListBox(string selectedText)
        {
            cLBAPS.Items.Clear();
            string _SQL = $@"select * from APConfigDateils ap where ap.Type = '{selectedText}' and ap.Factory = '{Factory}';";
            DataTable dt = MdbHepler.Query(_SQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                _TypeAPConfig = dt;
                _TypeAPConfigList = DtToList(dt);
            }

            //修改时间清空
            textBChangeDateTime.Clear();

            //数据回显
            foreach (APConfigModel item in _TypeAPConfigList)
            {             
                if (cLBAPS.Items.Contains(item.IP))
                {
                    cLBAPS.Items.Clear();
                    MessageHelper.Error(CSL.Get(CSLE.R_O_SelectAPConfigE0001, item.IP));
                    return;
                }
                else
                {
                    cLBAPS.Items.Add(item.IP);
                    GetChangeDateTime(item);
                }
            }

        }

        private void GetChangeDateTime(APConfigModel item)
        {
            try
            {
                FTPHepler ftp = new FTPHepler(item.IP, item.Port, item.Path + item.ProjectFolderPath, item.FTPUserName, item.FTPPassWord);
                string ChangeDateTime = ftp.ChangeDateTime();
                if (!string.IsNullOrEmpty(ChangeDateTime))
                {
                    textBChangeDateTime.AppendText($"{item.IP}" + "\t" + ChangeDateTime + "\r\n");
                }
            } 
            catch (Exception ex)
            {
                textBChangeDateTime.AppendText($"{item.IP}" + "\t" + "N/A" + "\r\n");
                return;
            }
        }

        private List<APConfigModel> DtToList(DataTable dt)
        {
            List<APConfigModel> _APConfigs = new List<APConfigModel>();
            foreach (DataRow item in dt.Rows)
            {
                APConfigModel _APConfig = new APConfigModel();
                _APConfig.ID = item["ID"].ToString();
                _APConfig.Factory = item["Factory"].ToString();
                _APConfig.IP = item["IP"].ToString();
                _APConfig.Port = item["Port"].ToString();
                _APConfig.Type = item["Type"].ToString();
                _APConfig.Path = item["Path"].ToString() ?? null;
                _APConfig.ProjectFolderPath = item["ProjectFolderPath"].ToString() ?? null;
                _APConfig.FTPUserName = item["FTPUserName"].ToString();
                _APConfig.FTPPassWord = item["FTPPassWord"].ToString();
                _APConfig.Remarks = item["Remarks"].ToString() ?? null;
                _APConfigs.Add(_APConfig);
            }
            return _APConfigs;
        }

        private List<APConfigModel> GetSelectAP()
        {
            List<APConfigModel> selectAPList = new List<APConfigModel>();
            List<string> selectAPIP = new List<string>();
            //获取选择的AP
            for (int x = 0; x < this.cLBAPS.Items.Count; x++)
            {
                if (cLBAPS.GetItemChecked(x))
                {
                    selectAPIP.Add(cLBAPS.GetItemText(cLBAPS.Items[x]));
                }
            }

            foreach (string ip in selectAPIP)
            {
                APConfigModel _apConfig = _TypeAPConfigList.Where(i => ip.Equals(i.IP)).First();
                if (_apConfig != null)
                {
                    selectAPList.Add(_apConfig);
                }
            }
            return selectAPList;
        }

        private void FTPResStatusPush(string ip, string filesPath, bool status, FTPType type)
        {
            if (status)
            {
                AddLog(liVFTPRes, ip, $@"{type.ToString()} Seccussfully: {filesPath}", status);
            }
            else
            {
                AddLog(liVFTPRes, ip, $@"{type.ToString()} Error: {filesPath}", status);
            }
        }

        private void AddLog(ListView _listView, string ip, string info, bool status, int maxDisplayItems = 1000)
        {
            if (_listView.InvokeRequired)
            {
                _listView.Invoke(new Action(() =>
                {
                    if (_listView.Items.Count > maxDisplayItems)
                    {
                        _listView.Items.RemoveAt(maxDisplayItems);
                    }
                    ListViewItem litem = new ListViewItem();
                    litem.Text = ip;
                    litem.SubItems.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    litem.SubItems.Add(info);
                    if (!status)
                    {
                        litem.ForeColor = Color.Red;
                    }
                    _listView.Items.Insert(0, litem);
                }));
            }
            else
            {
                if (_listView.Items.Count > maxDisplayItems)
                {
                    _listView.Items.RemoveAt(maxDisplayItems);
                }
                ListViewItem litem = new ListViewItem();
                litem.Text = ip;
                litem.SubItems.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                litem.SubItems.Add(info);
                if (!status)
                {
                    litem.ForeColor = Color.Red;
                }
                _listView.Items.Insert(0, litem);
            }
        }

        private void EnabledComp()
        {
            butSelectFiles.Enabled = false;
            tBMFilesPath.Enabled = false;
            cBUpdateType.Enabled = false;
            teBUploadPath.Enabled = false;
            butUpdateTypeAP.Enabled = false;
            butUpload.Enabled = false;
            butDownload.Enabled = false;
            butBackup.Enabled = false;
            butBackVersion.Enabled = false;
            cbBBackVersion.Enabled = false;
            checkBIsFirst.Enabled = false;
            checkBBackVersion.Enabled = true;
            checkBBackupLock.Enabled = false;
            checkBoxUploadLock.Enabled = false;
            checkBoxBackVersion.Enabled = false;
            checkBoIsSetRemotePath.Enabled = false;
            checkBUpload.Enabled = false;
        }

        private void UpdateFilePath()
        {
            LocalFilesPath.Clear();
            RemoteFilesPath.Clear();
            //获取最新的本地上传文件及远程对应路径
            for (int i = 0, num = 0; i < tBMFilesPath.Lines.Length - 1; i++)
            {
                if (!"".Equals(tBMFilesPath.Lines[i].ToString()))
                {
                    LocalFilesPath.Add(tBMFilesPath.Lines[i].ToString());
                    LocalFilesPathArray[num] = tBMFilesPath.Lines[i].ToString();
                    num++;
                }
            }
            for (int j = 0; j < teBUploadPath.Lines.Length; j++)
            {
                if (!"".Equals(teBUploadPath.Lines[j].ToString()))
                {
                    if (!teBUploadPath.Lines[j].ToString().Contains("\\"))
                    {
                        //MessageHelper.Error(@"远程目录开头无 / 线，结尾必须是 /");
                        MessageHelper.Error(CSL.Get(CSLE.R_M_E0002));
                        return;
                    }
                    else
                    {
                        RemoteFilesPath.Add(teBUploadPath.Lines[j].ToString());
                    }
                }
            }
            ActualLoaclFilesNumer = LocalFilesPath.Count;
            LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(LocalFilesPath), "LocalFilesPath");
            LogHepler.WriterLog(OperationUserName, JsonConvert.SerializeObject(RemoteFilesPath), "RemoteFilesPath");
        }

        private string GetVersionBackupPathBase()
        {
            string _pathbase = string.Empty;
            string v = cBUpdateType.SelectedItem.ToString();
            if ("WebApi".Equals(v))
            {
                _pathbase = ConfigurationManager.AppSettings["LocalBackupByWebApi"];
            }
            if ("PDA".Equals(v))
            {
                _pathbase = ConfigurationManager.AppSettings["LocalBackupByPDA"];
            }
            if ("CIMPDA".Equals(v))
            {
                _pathbase = ConfigurationManager.AppSettings["LocalBackupByCIMPDA"];
            }
            if ("CamstarPortal".Equals(v))
            {
                _pathbase = ConfigurationManager.AppSettings["LocalBackupByCamstarPortal"];
            }
            return _pathbase;
        }

        private int GetAPConfigsSelectID()
        {
            int Index = 0;
            int length = listView1.SelectedItems.Count;
            for (int i = 0; i < length; i++)
            {
                string v = (listView1.SelectedItems[i].Index + 1).ToString();
                int _Index = Convert.ToInt32(v);
                Index = Convert.ToInt32(_APConfig.Rows[_Index - 1]["ID"].ToString());
                //MessageBox.Show(v);
            }
            return Index;
        }

        private void InitAPConfigType()
        {
            string TypeString = ConfigurationManager.AppSettings["APConfigType"];
            if (TypeString != null && !string.IsNullOrWhiteSpace(TypeString))
            {
                string[] Types = TypeString.Split(',');
                cBUpdateType.Items.Clear();
                cBUpdateType.Items.Add(CSL.Get(CSLE.A_SelectUpdateType));
                foreach (string item in Types)
                {
                    cBUpdateType.Items.Add(item);
                }
            }

        }

        private void InitApp()
        {
            string AppName = ConfigurationManager.AppSettings["AppName"];
            string AppVersion = ConfigurationManager.AppSettings["AppVersion"];
            this.Text = $"{AppName} {AppVersion}";
        }
        private void InitApp(bool IsMointor)
        {
            string AppName = string.Empty;
            if (IsMointor)
            {
                AppName = ConfigurationManager.AppSettings["ClientAppName"];
            }
            else
            {
                AppName = ConfigurationManager.AppSettings["AppName"];
            }
            
            string AppVersion = ConfigurationManager.AppSettings["AppVersion"];
            this.Text = $"{AppName} {AppVersion}";
        }

        private bool InitAppLinces()
        {
            bool InitVerificationLicense = LicenseVerification.Verification();
            return InitVerificationLicense;
        }

        private void DeleteFile(string _LocaFilepath)
        {
            try
            {
                File.Delete(_LocaFilepath);
            }
            catch (Exception ex)
            {

            }
        }

        private void Login()
        {
            if ("".Equals(textBUserName.Text))
            {
                MessageHelper.Error(CSL.Get(CSLE.A_M_Login_UserName));
                LogHepler.WriterLog(CSL.Get(CSLE.A_M_Login_UserName), CSL.Get(CSLE.A_M_Login_UserNameLogFun));
                return;
            }
            if ("".Equals(textBPWD.Text))
            {
                //MessageHelper.Error("授权失败！秘钥未输入");
                //LogHepler.WriterLog($"授权失败！秘钥未输入", CSL.Get(CSLE.A_M_Login_UserNameLogFun));
                MessageHelper.Error(CSL.Get(CSLE.A_M_Login_Password));
                LogHepler.WriterLog(CSL.Get(CSLE.A_M_Login_Password), CSL.Get(CSLE.A_M_Login_UserNameLogFun));
                return;
            }

            if ("".Equals(comboBFactory.SelectedItem.ToString()) || CSL.Get(CSLE.A_SelectFactoryTitle).Equals(comboBFactory.SelectedItem.ToString()))
            {
                //MessageHelper.Error("授权失败！厂区未选择");
                //LogHepler.WriterLog($"授权失败！厂区未选择", CSL.Get(CSLE.A_M_Login_UserNameLogFun));
                MessageHelper.Error(CSL.Get(CSLE.A_M_Login_Factory));
                LogHepler.WriterLog(CSL.Get(CSLE.A_M_Login_Factory), CSL.Get(CSLE.A_M_Login_UserNameLogFun));
                return;
            }

            bool LoginRes = OperationAuthentication(textBUserName.Text, textBPWD.Text, comboBFactory.SelectedItem.ToString());
            if (LoginRes)
            {
                tabPAPConfig.Parent = tabCMain;
                tabPAPOperation.Parent = tabCMain;
                OperationUserName = textBUserName.Text;
                labWorkNumber.Text = OperationUserName;
                Factory = comboBFactory.SelectedItem.ToString();
                labFactoryValue.Text = comboBFactory.SelectedItem.ToString();
                SelectAllConfig();
                //MessageHelper.Asterisk($"成功授权【{textBUserName.Text}】可进行更版操作！");
                //LogHepler.WriterLog($"成功授权【{textBUserName.Text}】可进行更版操作！", CSL.Get(CSLE.A_M_Login_UserNameLogFun));
                MessageHelper.Asterisk(CSL.Get(CSLE.A_M_Login_LoginOK, textBUserName.Text));
                LogHepler.WriterLog(CSL.Get(CSLE.A_M_Login_LoginOK, textBUserName.Text), CSL.Get(CSLE.A_M_Login_UserNameLogFun));
                tabCMain.SelectedIndex = 1;
                tabPAuthentication.Parent = null;
                //登录用户信息持久化
                WriteINI("AccountInformation","UserName", OperationUserName);
                WriteINI("AccountInformation", "Factory", Factory);
                return;
            }
            else
            {
                MessageHelper.Error(CSL.Get(CSLE.A_M_Login_LoginError, textBUserName.Text));
                LogHepler.WriterLog(CSL.Get(CSLE.A_M_Login_LoginError, textBUserName.Text), CSL.Get(CSLE.A_M_Login_UserNameLogFun));
                return;
            }
        }

        private bool OperationAuthentication(string un, string pwd, string Factory)
        {
            bool LoginRes = false;
            try
            {
                string LoginSQL = $@"SELECT * FROM SystemAdmin sy WHERE sy.ahUserName = '{un}' AND sy.ahPassWord = '{pwd}' AND sy.ahFactory = '{Factory}' AND sy.ahType = '1';";
                DataTable dt = MdbHepler.Query(LoginSQL);
                if (dt != null && dt.Rows.Count == 0)
                {
                    LoginRes = false;
                }
                else
                {
                    LoginRes = true;
                }
            }
            catch (Exception ex)
            {
                LoginRes = false;
            }
            return LoginRes;
        }

        private void ProgressBarPush()
        {
            progressBar.Value += 1;
            decimal progressBarValue = progressBar.Value;
            decimal progressBarMaximum = progressBar.Maximum;
            decimal Percentage = decimal.Divide(progressBarValue, progressBarMaximum) * 100;
            labNum.Text = $"{Math.Round(Percentage, 2)}%";
        }

        private void InitFactory()
        {
            string FactoryString = ConfigurationManager.AppSettings["Factory"];
            if (FactoryString != null && !string.IsNullOrWhiteSpace(FactoryString))
            {
                string[] Factory = FactoryString.Split(',');
                comboBFactory.Items.Clear();
                comboBFactory.Items.Add(CSL.Get(CSLE.A_SelectFactoryTitle));
                foreach (string item in Factory)
                {
                    comboBFactory.Items.Add(item);
                }
                comboBFactory.SelectedIndex = 0;
            }

            string region = INIHelper.ReadIni("AppLanguage", "Language", "", 255, Environment.CurrentDirectory + @"/Config.ini");
            if ("".Equals(region))
            {
                string AppLanguageString = ConfigurationManager.AppSettings["AppLanguage"];
                if (AppLanguageString != null && !string.IsNullOrWhiteSpace(AppLanguageString))
                {
                    string[] AppLanguage = AppLanguageString.Split(',');
                    comboBLanguage.Items.Clear();
                    comboBLanguage.Items.Add(CSL.Get(CSLE.A_SelectLanguageTitle));
                    foreach (string item in AppLanguage)
                    {
                        comboBLanguage.Items.Add(item);
                    }
                    comboBLanguage.SelectedIndex = 0;
                }
            }
            else
            {
                string AppLanguageString = ConfigurationManager.AppSettings["AppLanguage"];
                int index = 0;
                if (AppLanguageString != null && !string.IsNullOrWhiteSpace(AppLanguageString))
                {
                    string[] AppLanguage = AppLanguageString.Split(',');
                    comboBLanguage.Items.Clear();
                    comboBLanguage.Items.Add(CSL.Get(CSLE.A_SelectLanguageTitle));
                    foreach (string item in AppLanguage)
                    {
                        comboBLanguage.Items.Add(item);
                    }
                    for (int i = 0; i < AppLanguage.Length; i++)
                    {
                        if (region.Equals(AppLanguage[i]))
                        {
                            index = i;
                            break;
                        }
                    }
                    comboBLanguage.SelectedIndex = index + 1;
                }
            }
        }

        //监控相关自定义方法
        private bool IsMonitor()
        {
            string MonitorString = ConfigurationManager.AppSettings["Monitor"];
            if ("0".Equals(MonitorString))
            {
                return false;
            }
            if ("2".Equals(MonitorString))
            {
                return true;
            }
            return false;
        }

        private void MonitorLog(ListView _listView, string status, string msg, int maxDisplayItems = 1000)
        {
            if (_listView.InvokeRequired)
            {
                _listView.Invoke(new Action(() =>
                {
                    if (_listView.Items.Count > maxDisplayItems)
                    {
                        _listView.Items.RemoveAt(maxDisplayItems);
                    }
                    ListViewItem litem = new ListViewItem();
                    litem.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    litem.SubItems.Add(status);
                    litem.SubItems.Add(msg);
                    _listView.Items.Insert(0, litem);
                }));
            }
            else
            {
                if (_listView.Items.Count > maxDisplayItems)
                {
                    _listView.Items.RemoveAt(maxDisplayItems);
                }
                ListViewItem litem = new ListViewItem();
                litem.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                litem.SubItems.Add(status);
                litem.SubItems.Add(msg);
                _listView.Items.Insert(0, litem);
            }
        }

        private void ExecuteCMD(string SiteName, ListView _ListView)
        {
            string appCmdPath = @"C:\Windows\System32\inetsrv\appcmd.exe";
            //string code = ExecuteCommandV2($@"{appCmdPath} recycle apppool /apppool.name:{ model.SiteName}");
            string code = CMDHelper.ExecuteCommandV2($@"{appCmdPath} recycle apppool /apppool.name:{ SiteName}");
            //LogHepler.WriterLog($"{SiteName} recycle msg:{code}", "回收站点pool");
            LogHepler.WriterLog($"{SiteName} recycle msg:{code}", CSL.Get(CSLE.R_L_RecycleSitePool));
            MonitorLog(_ListView, "recycle", code);
        }

        private void ShowLogOpenMoinWebApi(TextBox textB, string selectedPath, VersionType Type, ListView _ListView)
        {
            textB.Text = selectedPath;
            //MonitorLog(_ListView, "初始化", $"选择监控目录:{selectedPath}");
            //LogHepler.WriterLog($"{Type.ToString()}初始化目录：{selectedPath}", "选择监控目录");
            MonitorLog(_ListView, CSL.Get(CSLE.R_Init), CSL.Get(CSLE.R_M_SelectMoitorFolderPar, selectedPath));
            LogHepler.WriterLog($"{Type.ToString()}{CSL.Get(CSLE.R_M_InitPath)}：{selectedPath}", CSL.Get(CSLE.R_M_SelectMoitorFolder));
            WebApiopenFolderMonitor(selectedPath);
        }
        private void ShowLogOpenMoinPDA(TextBox textB, string selectedPath, VersionType Type, ListView _ListView)
        {
            textB.Text = selectedPath;
            //MonitorLog(_ListView, "初始化", $"选择监控目录:{selectedPath}");
            //LogHepler.WriterLog($"{Type.ToString()}初始化目录：{selectedPath}", "选择监控目录");
            MonitorLog(_ListView, CSL.Get(CSLE.R_Init), CSL.Get(CSLE.R_M_SelectMoitorFolderPar, selectedPath));
            LogHepler.WriterLog($"{Type.ToString()}{CSL.Get(CSLE.R_M_InitPath)}：{selectedPath}", CSL.Get(CSLE.R_M_SelectMoitorFolder));
            PDAopenFolderMonitor(selectedPath);
        }
        private void ShowLogOpenMoinCIMPDA(TextBox textB, string selectedPath, VersionType Type, ListView _ListView)
        {
            textB.Text = selectedPath;
            //MonitorLog(_ListView, "初始化", $"选择监控目录:{selectedPath}");
            //LogHepler.WriterLog($"{Type.ToString()}初始化目录：{selectedPath}", "选择监控目录");
            MonitorLog(_ListView, CSL.Get(CSLE.R_Init), CSL.Get(CSLE.R_M_SelectMoitorFolderPar, selectedPath));
            LogHepler.WriterLog($"{Type.ToString()}{CSL.Get(CSLE.R_M_InitPath)}：{selectedPath}", CSL.Get(CSLE.R_M_SelectMoitorFolder));
            CIMPDAopenFolderMonitor(selectedPath);
        }
        private void ShowLogOpenMoinCamstarPort(TextBox textB, string selectedPath, VersionType Type, ListView _ListView)
        {
            textB.Text = selectedPath;
            //MonitorLog(_ListView, "初始化", $"选择监控目录:{selectedPath}");
            //LogHepler.WriterLog($"{Type.ToString()}初始化目录：{selectedPath}", "选择监控目录");
            MonitorLog(_ListView, CSL.Get(CSLE.R_Init), CSL.Get(CSLE.R_M_SelectMoitorFolderPar, selectedPath));
            LogHepler.WriterLog($"{Type.ToString()}{CSL.Get(CSLE.R_M_InitPath)}：{selectedPath}", CSL.Get(CSLE.R_M_SelectMoitorFolder));
            CamstarPortalopenFolderMonitor(selectedPath);
        }

        private void InitMonitorFolder()
        {
            //"Monitor", "WebApi", WebApiMonitorPath, Environment.CurrentDirectory + @"/Config.ini"
            textBWebApi.Text = INIHelper.ReadIni("Monitor", "WebApi", "", 255, Environment.CurrentDirectory + @"/Config.ini");
            textBPDA.Text = INIHelper.ReadIni("Monitor", "PDA", "", 255, Environment.CurrentDirectory + @"/Config.ini");
            textBCIMPDA.Text = INIHelper.ReadIni("Monitor", "CIMPDA", "", 255, Environment.CurrentDirectory + @"/Config.ini");
            textBCamstarPortal.Text = INIHelper.ReadIni("Monitor", "CamstarPortal", "", 255, Environment.CurrentDirectory + @"/Config.ini");
        }

        private void OpenMonitor(TextBox textB, ListView listV, VersionType Type, int index, ref string[] msg)
        {
            if (!"".Equals(textB.Text) && !string.IsNullOrEmpty(textB.Text))
            {
                //ShowLogOpenMoin(textB, textB.Text, Type, listV);
                switch (Type)
                {
                    case VersionType.WebApi:
                        ShowLogOpenMoinWebApi(textB, textB.Text, Type, listV);
                        WebApiMonitorPath = textB.Text;
                        break;
                    case VersionType.PDA:
                        ShowLogOpenMoinPDA(textB, textB.Text, Type, listV);
                        PDAMonitorPath = textB.Text;
                        break;
                    case VersionType.CIMPDA:
                        ShowLogOpenMoinCIMPDA(textB, textB.Text, Type, listV);
                        CIMPDAMonitorPath = textB.Text;
                        break;
                    case VersionType.CamstarPortal:
                        CamPortalMonitorPath = textB.Text;
                        ShowLogOpenMoinCamstarPort(textB, textB.Text, Type, listV);
                        break;
                }
                
                msg[index] = $"{Type.ToString()} {textB.Text} OpenMonitor Successfully!";
            }
        }

        // 1.1 WebAPi
        private void WebApiopenFolderMonitor(string selectedPath)
        {
            if (!"".Equals(selectedPath) && !string.IsNullOrEmpty(selectedPath))
            {
                FileSystemWatcher watcher = new FileSystemWatcher(selectedPath);
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
                watcher.Changed += new FileSystemEventHandler(WebApiFileSystemWatcher_Handler);
                watcher.Created += new FileSystemEventHandler(WebApiFileSystemWatcher_Handler);
                watcher.Deleted += new FileSystemEventHandler(WebApiFileSystemWatcher_Handler);
                watcher.Renamed += new RenamedEventHandler(WebApiFileSystemWatcher_Renamed);
                watcher.Error += new ErrorEventHandler(WebApiFileSystemWatcher_Error);
            }

        }

        private void WebApiFileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            MonitorLog(listVWebApi, "Error", e.ToString());
        }

        private void WebApiFileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Invoke(new Action(() => {
                MonitorLog(listVWebApi, e.Name, e.FullPath);
            }));
        }

        private void WebApiFileSystemWatcher_Handler(object sender, FileSystemEventArgs e)
        {
            Invoke(new Action(() => {
                MonitorLog(listVWebApi, "UPDATE", e.FullPath);
                //LogHepler.WriterLog($"WebApi UPDATE {e.FullPath}", "监控目录");
                LogHepler.WriterLog($"WebApi UPDATE {e.FullPath}", CSL.Get(CSLE.R_M_MoitorFolder));
                if (checkBWebApi.Checked)
                {
                    ExecuteCMD(ConfigurationManager.AppSettings["WebApiSiteName"], listVWebApi);
                }
            }));
        }

        // 1.2 PDA
        private void PDAopenFolderMonitor(string selectedPath)
        {
            if (!"".Equals(selectedPath) && !string.IsNullOrEmpty(selectedPath))
            {
                FileSystemWatcher watcher = new FileSystemWatcher(selectedPath);
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
                watcher.Changed += new FileSystemEventHandler(PDAFileSystemWatcher_Handler);
                watcher.Created += new FileSystemEventHandler(PDAFileSystemWatcher_Handler);
                watcher.Deleted += new FileSystemEventHandler(PDAFileSystemWatcher_Handler);
                watcher.Renamed += new RenamedEventHandler(PDAFileSystemWatcher_Renamed);
                watcher.Error += new ErrorEventHandler(PDAFileSystemWatcher_Error);
            }

        }

        private void PDAFileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            MonitorLog(listVPDA, "Error", e.ToString());
        }

        private void PDAFileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Invoke(new Action(() => {
                MonitorLog(listVPDA, e.Name, e.FullPath);
            }));
        }

        private void PDAFileSystemWatcher_Handler(object sender, FileSystemEventArgs e)
        {
            Invoke(new Action(() => {
                MonitorLog(listVPDA, "UPDATE", e.FullPath);
                if (checkBPDA.Checked)
                {
                    ExecuteCMD(ConfigurationManager.AppSettings["PDASiteName"], listVPDA);
                }
            }));
        }

        // 1.2 CIMPDA
        private void CIMPDAopenFolderMonitor(string selectedPath)
        {
            if (!"".Equals(selectedPath) && !string.IsNullOrEmpty(selectedPath))
            {
                FileSystemWatcher watcher = new FileSystemWatcher(selectedPath);
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
                watcher.Changed += new FileSystemEventHandler(CIMPDAFileSystemWatcher_Handler);
                watcher.Created += new FileSystemEventHandler(CIMPDAFileSystemWatcher_Handler);
                watcher.Deleted += new FileSystemEventHandler(CIMPDAFileSystemWatcher_Handler);
                watcher.Renamed += new RenamedEventHandler(CIMPDAFileSystemWatcher_Renamed);
                watcher.Error += new ErrorEventHandler(CIMPDAFileSystemWatcher_Error);
            }

        }

        private void CIMPDAFileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            MonitorLog(listVCIMPDA, "Error", e.ToString());
        }

        private void CIMPDAFileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Invoke(new Action(() => {
                MonitorLog(listVCIMPDA, e.Name, e.FullPath);
            }));
        }

        private void CIMPDAFileSystemWatcher_Handler(object sender, FileSystemEventArgs e)
        {
            Invoke(new Action(() => {
                MonitorLog(listVCIMPDA, "UPDATE", e.FullPath);
                if (checkBCIMPDA.Checked)
                {
                    ExecuteCMD(ConfigurationManager.AppSettings["CIMPDASiteName"], listVCIMPDA);
                }
            }));
        }

        // 1.2 CamstarPortal
        private void CamstarPortalopenFolderMonitor(string selectedPath)
        {
            if (!"".Equals(selectedPath) && !string.IsNullOrEmpty(selectedPath))
            {
                FileSystemWatcher watcher = new FileSystemWatcher(selectedPath);
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
                watcher.Changed += new FileSystemEventHandler(CamstarPortalFileSystemWatcher_Handler);
                watcher.Created += new FileSystemEventHandler(CamstarPortalFileSystemWatcher_Handler);
                watcher.Deleted += new FileSystemEventHandler(CamstarPortalFileSystemWatcher_Handler);
                watcher.Renamed += new RenamedEventHandler(CamstarPortalFileSystemWatcher_Renamed);
                watcher.Error += new ErrorEventHandler(CamstarPortalFileSystemWatcher_Error);
            }

        }

        private void CamstarPortalFileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            MonitorLog(listVCamstarPortal, "Error", e.ToString());
        }

        private void CamstarPortalFileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Invoke(new Action(() => {
                MonitorLog(listVCamstarPortal, e.Name, e.FullPath);
            }));
        }

        private void CamstarPortalFileSystemWatcher_Handler(object sender, FileSystemEventArgs e)
        {
            Invoke(new Action(() => {
                MonitorLog(listVCamstarPortal, "UPDATE", e.FullPath);
                if (checkBCamstarPortal.Checked)
                {
                    ExecuteCMD(ConfigurationManager.AppSettings["CamstarPortalSiteName"], listVCamstarPortal);
                }
            }));
        }

        //多语言界面
        private void InitLanguage()
        {
            //Login Windows
            groupBAuthen.Text = CSL.Get(CSLE.R_Login_LA_OperationAuthorization);
            labUserName.Text = CSL.Get(CSLE.R_Login_labUserName);
            labPassword.Text = CSL.Get(CSLE.R_Login_labPassword);
            labFactory.Text = CSL.Get(CSLE.R_Login_labFactory);
            labLanguage.Text = CSL.Get(CSLE.R_Login_labLanguage);
            label2.Text = CSL.Get(CSLE.R_Login_labDeveloping);
            label2.ForeColor = Color.White;
            butLogin.Text = CSL.Get(CSLE.R_Login_btLogin);
            butCloseAuten.Text = CSL.Get(CSLE.R_Login_btOut);

            //状态栏
            labRole.Text = CSL.Get(CSLE.R_Status_WorkNo);
            labFactoryTag.Text = CSL.Get(CSLE.R_Status_Factory);
            labSchedule.Text = CSL.Get(CSLE.R_Status_SpeedOfProgress);

            //ApConfig
            button1.Text = CSL.Get(CSLE.R_A_SelectAPConfig);
            butAddConfig.Text = CSL.Get(CSLE.R_A_AddAPConfig);
            butCloseConfig.Text = CSL.Get(CSLE.R_A_Exit);
            chRemarks.Text = CSL.Get(CSLE.R_A_D_Remarks);
            //AP 右键
            UpdateAPConfig.Text = CSL.Get(CSLE.R_A_R_UpdateConfig);
            DeleteAPConfig.Text = CSL.Get(CSLE.R_A_R_DeleteConfig);
            RefreshAPConfig.Text = CSL.Get(CSLE.R_A_R_RefreshConfig);
            TestFTPConnector.Text = CSL.Get(CSLE.R_A_R_TestFTPConnector);

            //APOperation
            //Local
            gbLocal.Text = CSL.Get(CSLE.R_O_L_Lab_LocalFile);
            labSelectFolder.Text = CSL.Get(CSLE.R_O_L_Lab_SelectLoaclFile);
            butSelectFolder.Text = CSL.Get(CSLE.R_O_L_But_SelectFolder);
            butSelectFiles.Text = CSL.Get(CSLE.R_O_L_But_FindAllFiles);
            //AP
            gBSelectAP.Text = CSL.Get(CSLE.R_O_A_Lab_SelectAP);
            labSelectType.Text = CSL.Get(CSLE.R_O_A_Lab_SelectType);
            butUpdateTypeAP.Text = CSL.Get(CSLE.R_O_B_SelectAPByType);
            labSelectAP.Text = CSL.Get(CSLE.R_O_A_Lab_SelectTypeAP);
            checkBIsFirst.Text = CSL.Get(CSLE.R_O_A_C_First);
            checkBBackVersion.Text = CSL.Get(CSLE.R_O_A_C_BackVersion);
            checkBoIsSetRemotePath.Text = CSL.Get(CSLE.R_O_A_C_SettingPath);
            checkBUpload.Text = CSL.Get(CSLE.R_O_A_C_UploadVersion);
            //Operation
            gBOperation.Text = CSL.Get(CSLE.R_O_O_Lab_Backup);
            butBackup.Text = CSL.Get(CSLE.R_O_O_But_Backup);
            butUpload.Text = CSL.Get(CSLE.R_O_O_But_Upload);
            butBackVersion.Text = CSL.Get(CSLE.R_O_O_But_BackVersion);
            labBackup.Text = CSL.Get(CSLE.R_O_O_Lab_SelectBackupFolder);
            labBackVersion.Text = CSL.Get(CSLE.R_O_O_Lab_BackFolder);
            butPool.Text = CSL.Get(CSLE.R_O_O_But_RecyclePool);
            butClose.Text = CSL.Get(CSLE.R_O_O_But_AppExit);
            cHFTPResMsg.Text = CSL.Get(CSLE.R_O_O_ListView_Msg);
            labRemote.Text = CSL.Get(CSLE.R_O_O_Rem_Lab);

            //Monitor
            butWebApi.Text = CSL.Get(CSLE.R_M_But_WebApi);
            butPDA.Text = CSL.Get(CSLE.R_M_But_PDA);
            butCIMPDA.Text = CSL.Get(CSLE.R_M_But_CIMPDA);
            butCamstarPortal.Text = CSL.Get(CSLE.R_M_But_CamstarPortal);
            checkBWebApi.Text = CSL.Get(CSLE.R_M_CheckWebApi);
            checkBPDA.Text = CSL.Get(CSLE.R_M_CheckPDA);
            checkBCIMPDA.Text = CSL.Get(CSLE.R_M_CheckCIMPDA);
            checkBCamstarPortal.Text = CSL.Get(CSLE.R_M_CheckCamstarPortal);
            butSaveFolderPath.Text = CSL.Get(CSLE.R_M_ButSavePath);
            butOpenMonitor.Text = CSL.Get(CSLE.R_M_OpenMonitor);
            colHTime.Text = CSL.Get(CSLE.R_M_LV_WebAPI_Time);
            colHStatus.Text = CSL.Get(CSLE.R_M_LV_WebAPI_Status);
            colHMsg.Text = CSL.Get(CSLE.R_M_LV_WebAPI_Msg);
            columnHeader1.Text = CSL.Get(CSLE.R_M_LV_PDA_Time);
            columnHeader2.Text = CSL.Get(CSLE.R_M_LV_PDA_Status);
            columnHeader3.Text = CSL.Get(CSLE.R_M_LV_PDA_Msg);
            columnHeader4.Text = CSL.Get(CSLE.R_M_LV_CIMPDA_Time);
            columnHeader5.Text = CSL.Get(CSLE.R_M_LV_CIMPDA_Status);
            columnHeader6.Text = CSL.Get(CSLE.R_M_LV_CIMPDA_Msg);
            columnHeader7.Text = CSL.Get(CSLE.R_M_LV_CP_Time);
            columnHeader8.Text = CSL.Get(CSLE.R_M_LV_CP_Status);
            columnHeader9.Text = CSL.Get(CSLE.R_M_LV_CP_Msg);
        }

        private void InitListViewAPConfigDoubleBuffer()
        {
            Type listViewLog = listView1.GetType();
            PropertyInfo pi = listViewLog.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(listView1, true);
        }

        private void InItListViewLogDouble()
        {
            Type listViewLog = liVFTPRes.GetType();
            PropertyInfo pi = listViewLog.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(liVFTPRes, true);
        }

        //默认记录上次选的更版目录

        /// <summary>
        /// 读取Ini配置
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="key">key</param>
        /// <returns>Value</returns>
        private string ReadINI(string section, string key)
        {
            return INIHelper.ReadIni(section, key, "", 255, Environment.CurrentDirectory + @"/Config.ini");
        }

        /// <summary>
        /// 保存Ini配置
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        private void WriteINI(string section, string key, string value)
        {
            INIHelper.WriteIni(section, key, value, Environment.CurrentDirectory + @"/Config.ini");
        }
    }
}