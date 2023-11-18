using System;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;
using SystemUpdateVersion.Models;
using static System.Net.WebRequestMethods;

namespace SystemUpdateVersion.Hepler
{
    public class FTPHepler
    {
        private string ftpServerIP;
        private string ftpServerPort;
        private string ftpRemotePath;
        private string ftpUserID;
        private string ftpPassword;
        private string ftpURI;
        private string TimeOut = INIHelper.ReadINI("FTPConnetConfig","TIME_OUT","5000");

        /// <summary>
        /// 连接FTP
        /// </summary>
        /// <param name="FtpServerIP">FTP连接地址</param>
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
        /// <param name="FtpUserID">用户名</param>
        /// <param name="FtpPassword">密码</param>
        public FTPHepler(string ServerIP, string RemotePath, string UserID, string Password)
        {
            ftpServerIP = ServerIP;
            ftpRemotePath = RemotePath;
            ftpUserID = UserID;
            ftpPassword = Password;
            ftpURI = "ftp://" + ftpServerIP  + "/" + ftpRemotePath + "/";
        }

        /// <summary>
        /// 连接FTP
        /// </summary>
        /// <param name="FtpServerIP">FTP连接地址</param>
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
        /// <param name="FtpUserID">用户名</param>
        /// <param name="FtpPassword">密码</param>
        public FTPHepler(string ServerIP, string Port, string RemotePath, string UserID, string Password)
        {
            ftpServerIP = ServerIP;
            ftpServerPort = Port;
            ftpRemotePath = RemotePath;
            ftpUserID = UserID;
            ftpPassword = Password;
            ftpURI = $"ftp://" + ftpServerIP + ":"+ ftpServerPort + "/" + ftpRemotePath + "/";
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="filename">文件名</param>
        public void UploadFile(string FileName)
        {
            FileInfo fileInfo = new FileInfo(FileName);
            string uri = ftpURI + fileInfo.Name;
            FtpWebRequest reqFTP;
            LogHepler.WriterLog(INIHelper.ReadINI("AccountInformation", "UserName"), $"File:{FileName} FTPFileInfo:{uri}", CSL.Get(CSLE.A_FTP_UploadFile));

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.UsePassive = false;
            reqFTP.ContentLength = fileInfo.Length;
            int BufferSize = 2048;
            byte[] buff = new byte[BufferSize];
            int ContentLength;
            FileStream fs = fileInfo.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                ContentLength = fs.Read(buff, 0, BufferSize);
                while (ContentLength != 0)
                {
                    strm.Write(buff, 0, ContentLength);
                    ContentLength = fs.Read(buff, 0, BufferSize);
                }

                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Ftphelper Upload Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="filename">文件名</param>
        public void UploadFile(string FileName, string RemotePath)
        {
            FileInfo fileInfo = new FileInfo(FileName);
            string uri = ftpURI + RemotePath + "/" + fileInfo.Name;
            FtpWebRequest reqFTP;
            LogHepler.WriterLog(INIHelper.ReadINI("AccountInformation", "UserName"), $"File:{FileName} FTPFileInfo:{uri}", CSL.Get(CSLE.A_FTP_UploadFile));

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.UsePassive = false;
            reqFTP.ContentLength = fileInfo.Length;
            int BufferSize = 2048;
            byte[] buff = new byte[BufferSize];
            int ContentLength;
            FileStream fs = fileInfo.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                ContentLength = fs.Read(buff, 0, BufferSize);
                while (ContentLength != 0)
                {
                    strm.Write(buff, 0, ContentLength);
                    ContentLength = fs.Read(buff, 0, BufferSize);
                }

                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Ftphelper Upload Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名</param>
        public void DownloadFile(string FileName, string LocalSavePath)
        {
            FtpWebRequest reqFTP;
            try
            {
                //检查本地备份目录
                string[] _LocalBackupPaths = LocalSavePath.Split('/');
                string _LocalBackupPath = string.Empty;
                for (int i = 0; i < _LocalBackupPaths.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        _LocalBackupPath += _LocalBackupPaths[i];
                    }
                    else
                    {
                        _LocalBackupPath += "/";
                        _LocalBackupPath += _LocalBackupPaths[i];
                    }
                }
                if (!Directory.Exists(_LocalBackupPath)) {
                    Directory.CreateDirectory(_LocalBackupPath);
                }

                FileStream outputStream = new FileStream(LocalSavePath, FileMode.Create);

                string _downloadURL = @"ftp://" + ftpServerIP + ":" + ftpServerPort + "/" + ftpRemotePath + "/" + FileName;
                LogHepler.WriterLog(INIHelper.ReadINI("AccountInformation", "UserName"), $"File:{FileName}{LocalSavePath} FTPFileInfo:" + _downloadURL, CSL.Get(CSLE.A_FTP_DownloadFile));

                //reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpUserID + ":" + ftpPassword + "@" + ftpServerIP + "/" + FileName));
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(_downloadURL));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.UsePassive = false;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="folderName">文件夹名</param>
        public void RemoveDirectory(string folderName)
        {
            try
            {
                string uri = ftpURI + folderName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                reqFTP.UsePassive = false;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper Delete Error --> " + ex.Message + "  文件名:" + folderName);
            }
        }

        /// <summary>
        /// 获取当前目录下明细(包含文件和文件夹)
        /// </summary>
        /// <returns>名称数组</returns>
        public string[] GetFilesDetailList()
        {
            string[] downloadFiles;
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                ftp.UsePassive = false;
                ftp.Timeout = GetFTPSettingTimeOut();
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                //while (reader.Read() > 0)
                //{

                //}
                string line = reader.ReadLine();
                //line = reader.ReadLine();
                //line = reader.ReadLine();

                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                throw new Exception("FtpHelper  Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 获取当前目录下文件列表(仅文件)
        /// </summary>
        /// <returns></returns>
        public string[] GetFileList(string mask)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.UsePassive = false;
                reqFTP.Timeout = reqFTP.Timeout = GetFTPSettingTimeOut();
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {

                        string mask_ = mask.Substring(0, mask.IndexOf("*"));
                        if (line.Substring(0, mask_.Length) == mask_)
                        {
                            result.Append(line);
                            result.Append("\n");
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    throw new Exception("FtpHelper GetFileList Error --> " + ex.Message.ToString());
                }
                return downloadFiles;
            }
        }

        /// <summary>
        /// 获取当前目录下所有的文件夹列表(仅文件夹)
        /// </summary>
        /// <returns></returns>
        public string[] GetDirectoryList()
        {
            string[] drectory = GetFilesDetailList();
            string m = string.Empty;
            foreach (string str in drectory)
            {
                int dirPos = str.IndexOf("<DIR>");
                if (dirPos > 0)
                {
                    /*判断 Windows 风格*/
                    m += str.Substring(dirPos + 5).Trim() + "\n";
                }
                else if (str.Trim().Substring(0, 1).ToUpper() == "D")
                {
                    /*判断 Unix 风格*/
                    string dir = str.Substring(54).Trim();
                    if (dir != "." && dir != "..")
                    {
                        m += dir + "\n";
                    }
                }
            }

            char[] n = new char[] { '\n' };
            return m.Split(n);
        }

        /// <summary>
        /// 判断当前目录下指定的子目录是否存在
        /// </summary>
        /// <param name="RemoteDirectoryName">指定的目录名</param>
        public bool DirectoryExist(string RemoteDirectoryName)
        {
            string[] dirList = GetDirectoryList();
            foreach (string str in dirList)
            {
                if (str.Trim() == RemoteDirectoryName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断当前目录下指定的文件是否存在
        /// </summary>
        /// <param name="RemoteFileName">远程文件名</param>
        public bool FileExist(string RemoteFileName)
        {
            string[] fileList = GetFileList("*.*");
            foreach (string str in fileList)
            {
                if (str.Trim() == RemoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper MakeDir Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 获取指定文件大小
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper GetFileSize Error --> " + ex.Message);
            }
            return fileSize;
        }

        /// <summary>
        /// 改名
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper ReName Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void MovieFile(string currentFilename, string newDirectory)
        {
            ReName(currentFilename, newDirectory);
        }

        /// <summary>
        /// 切换当前目录
        /// </summary>
        /// <param name="DirectoryName"></param>
        /// <param name="IsRoot">true 绝对路径   false 相对路径</param>
        public void GotoDirectory(string DirectoryName, bool IsRoot)
        {
            if (IsRoot)
            {
                ftpRemotePath = DirectoryName;
            }
            else
            {
                ftpRemotePath += DirectoryName + "/";
            }
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }

        /// <summary>
        /// 获取FTP远程指定目录下最新的修改时间
        /// </summary>
        /// <param name="directory">目录</param>
        /// <returns>最新的修改时间</returns>
        /// <exception cref="Exception">FTP执行异常</exception>
        public string ChangeDateTime(string directory = "/")
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + directory));
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Timeout = GetFTPSettingTimeOut();
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(ftpStream);
                string latestFile = string.Empty;
                DateTime latestFileChangeDateTime = DateTime.MinValue;

                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string fileName = tokens[tokens.Length - 1];
                    DateTime modifiedTime = DateTime.Parse(tokens[0] + " " + tokens[1]);

                    if (fileName != "." && fileName != "..")
                    {
                        if (modifiedTime > latestFileChangeDateTime)
                        {
                            latestFileChangeDateTime = modifiedTime;
                            latestFile = fileName;
                        }
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                ftpStream.Close();
                response.Close();
                LogHepler.WriterLog(INIHelper.ReadINI("AccountInformation", "UserName"), $"GetChangeDateTime:{ftpURI + directory} time:{latestFileChangeDateTime.ToShortDateString()}", CSL.Get(CSLE.A_FTP_GetLatestModificationTime));
                return latestFileChangeDateTime.ToString();
            } catch (Exception ex)
            {
                LogHepler.WriterLog(INIHelper.ReadINI("AccountInformation", "UserName"), $"GetChangeDateTimeError:{ftpURI + directory} Msg:{ex.Message}", CSL.Get(CSLE.A_FTP_GetLatestModificationTime));
                throw new Exception("FtpHelper GetChangeDateTime Error --> " + ex.Message);
            } 
            finally
            {
            }
        }

        /// <summary>
        /// 获取FTP远程指定目录下最新的修改时间
        /// </summary>
        /// <param name="directory">目录</param>
        /// <returns>最新的修改时间</returns>
        /// <exception cref="Exception">FTP执行异常</exception>
        public string ChangeDateTimeNet(FtpWebRequest reqFTP)
        {
            try
            {
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Timeout = GetFTPSettingTimeOut();
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(ftpStream);
                string latestFile = string.Empty;
                DateTime latestFileChangeDateTime = DateTime.MinValue;

                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string fileName = tokens[tokens.Length - 1];
                    string rawtime = string.Join(" ", tokens, 4, 2);
                    DateTime modifiedTime = DateTime.ParseExact(rawtime, "MMM dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    //DateTime modifiedTime = DateTime.Parse(tokens[0] + " " + tokens[1]);

                    if (fileName == "." || fileName == "..")
                    {
                        if (modifiedTime > latestFileChangeDateTime)
                        {
                            latestFileChangeDateTime = modifiedTime;
                            latestFile = fileName;
                        }
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                ftpStream.Close();
                response.Close();
                LogHepler.WriterLog(INIHelper.ReadINI("AccountInformation", "UserName"), $"GetChangeDateTime:{ftpURI} time:{latestFileChangeDateTime.ToShortDateString()}", CSL.Get(CSLE.A_FTP_GetLatestModificationTime));
                return latestFileChangeDateTime.ToString();
            } catch (Exception ex)
            {
                LogHepler.WriterLog(INIHelper.ReadINI("AccountInformation", "UserName"), $"GetChangeDateTimeError:{ftpURI} Msg:{ex.Message}", CSL.Get(CSLE.A_FTP_GetLatestModificationTime));
                throw new Exception("FtpHelper GetChangeDateTime Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 返回默认设置FTP连接超时时间，未设置超时时间返回默认值5000ms
        /// </summary>
        /// <returns></returns>
        private int GetFTPSettingTimeOut()
        {
            if (string.IsNullOrWhiteSpace(TimeOut))
            {
                return 5000;
            }
            return Convert.ToInt32(TimeOut);
        }
    }
}
