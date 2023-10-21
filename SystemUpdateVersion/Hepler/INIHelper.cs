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
    }
}
