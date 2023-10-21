using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUpdateVersion.Hepler
{
    public class LogHepler
    {
        public static void WriterLog(string log, string fun)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{fun} "+ log + "\r\n");

            string fileName = DateTime.Now.ToString("yyyyMMddHH") + ".txt";
            string configpath = ConfigurationManager.AppSettings["Log"];
            string currentPath = Environment.CurrentDirectory;
            string LogDir = currentPath + configpath;

            if (!Directory.Exists(LogDir))
            {
                Directory.CreateDirectory(LogDir);
            }
            string filename = LogDir + "\\" + fileName;
            FileInfo finfo = new FileInfo(filename);
            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(filename);
                fs.Close();
                finfo = new FileInfo(filename);
            }
            using (FileStream fs = finfo.OpenWrite())
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(strb);
                sw.Flush();
                sw.Close();
            }
        }

        public static void WriterLog(string user, string log, string fun)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append($"{user} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{fun} " + log + "\r\n");

            string fileName = DateTime.Now.ToString("yyyyMMddHH") + ".txt";
            string configpath = ConfigurationManager.AppSettings["Log"];
            string currentPath = Environment.CurrentDirectory;
            string LogDir = currentPath + configpath;

            if (!Directory.Exists(LogDir))
            {
                Directory.CreateDirectory(LogDir);
            }
            string filename = LogDir + "\\" + fileName;
            FileInfo finfo = new FileInfo(filename);
            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(filename);
                fs.Close();
                finfo = new FileInfo(filename);
            }
            using (FileStream fs = finfo.OpenWrite())
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(strb);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
