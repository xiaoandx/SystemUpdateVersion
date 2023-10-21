using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUpdateVersion.Hepler
{
    public class CMDHelper
    {
        public static string ExecuteCommandV2(string commandString)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Verb = "runas";
            string strOutput = null;
            try
            {
                process.Start();
                process.StandardInput.WriteLine(commandString);
                process.StandardInput.WriteLine("exit");
                strOutput = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();

                var lines = strOutput.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

                lines = lines.Skip(4).Take(lines.Count - 4 - 3).ToList();
                return string.Join("\r\n", lines);
            }
            catch (Exception ex)
            {
                strOutput = ex.Message;
            }

            return strOutput;
        }
    }
}
