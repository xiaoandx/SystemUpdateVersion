using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUpdateVersion.Models
{
    public class APConfigModel
    {
        public string ID { get; set; }

        public string Factory { get; set; }

        public string IP { get; set; }

        public string Port { get; set; }

        public string Type { get; set; }

        public string Path { get; set; }

        public string ProjectFolderPath { get; set; }

        public string FTPUserName { get; set; }

        public string FTPPassWord { get; set; }

        public string Remarks { get; set; }
    }
}
