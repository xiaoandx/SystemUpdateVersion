using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemUpdateVersion.Hepler
{
    public class LicenseVerification
    {
        [DllImport("License.dll")]
        public static extern bool VLicense();

        public static bool Verification()
        {
            bool res = true;
            try
            {
                Assembly asm = Assembly.LoadFrom("License.dll");
                Type VerifyClass = asm.GetType("License.Verify");
                object o = Activator.CreateInstance(VerifyClass);
                MethodInfo _VLicense = VerifyClass.GetMethod("VLicense", new Type[] { typeof(string)});
                string _MAC = GetMac();
                object result = _VLicense.Invoke(o, new object[] { _MAC });
                res = result is bool;
            }
            catch (Exception ex)
            {
                res = false;
            }
            //res = VLicense();
            return res;
        }

        private static string GetMac()
        {
            string info = string.Empty;
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();
            foreach (var o in moc)
            {
                var mo = (ManagementObject)o;
                if (!(bool)mo["IPEnabled"])
                {
                    continue;
                }
                info = mo["MacAddress"].ToString();
                break;
            }
            return info;
        }

    }
}
