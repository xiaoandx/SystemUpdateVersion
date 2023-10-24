using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemUpdateVersion.FormModels
{
    public partial class Hidden : Form
    {
        public Hidden()
        {
            this.Width = 0;
            this.Height = 0;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(-1000, -1000);
            this.ShowInTaskbar = false;
        }
    }
}
