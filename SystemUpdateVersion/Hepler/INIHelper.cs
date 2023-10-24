using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemUpdateVersion.Hepler
{
    public class INIHelper
    {
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filepath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        public static String ReadIni(string section, string key, string def, int size, string filepath) {
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(section, key, def, sb, size, filepath);
            return sb.ToString();
        }

        public static long WriteIni(string section, string key, string val, string filepath) {
            return WritePrivateProfileString(section, key, val, filepath);
        }

        public void ClearAllSection(string filepath) {
            WriteIni(null, null, null, filepath);
        }

        public void ClearSection(string Section, string filepath) {
            WriteIni(Section, null, null, filepath);
        }

        /// <summary>
        /// 读取Ini配置
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="key">key</param>
        /// <returns>Value</returns>
        public static string ReadINI(string section, string key)
        {
            return INIHelper.ReadIni(section, key, "", 255, Environment.CurrentDirectory + @"/Config.ini");
        }

        /// <summary>
        /// 保存Ini配置
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public static void WriteINI(string section, string key, string value)
        {
            INIHelper.WriteIni(section, key, value, Environment.CurrentDirectory + @"/Config.ini");
        }
    }
}
