using FSLib.App.SimpleUpdater;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemUpdateVersion.Hepler;
using SystemUpdateVersion.Models;

namespace SystemUpdateVersion
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appName = ConfigurationManager.AppSettings["AppName"];
            bool isCreateApp;
            using ( Mutex mutex = new Mutex(true, appName, out isCreateApp))
            {
                if (isCreateApp)
                {
                    //检查版本
                    FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple("http://127.0.0.1:8080/{0}", "update.xml");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                } 
                else
                {
                    MessageHelper.Warning(CSL.Get(CSLE.A_CreateNewApp));
                }
            }
                
        }
    }
}
