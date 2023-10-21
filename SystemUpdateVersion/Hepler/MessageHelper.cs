using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemUpdateVersion.Models;

namespace SystemUpdateVersion.Hepler
{
    public class MessageHelper
    {
        public static DialogResult Question(string _Value)
        {
            return MessageBox.Show(_Value, CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static DialogResult Question(string _Value, string _Title)
        {
            return MessageBox.Show(_Value, _Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static DialogResult Asterisk(string _Value)
        {
            return MessageBox.Show(_Value, CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        public static DialogResult Asterisk(string _Value, string _Title)
        {
            return MessageBox.Show(_Value, _Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        public static DialogResult Information(string _Value)
        {
            return MessageBox.Show(_Value, CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        public static DialogResult Information(string _Value, string _Title)
        {
            return MessageBox.Show(_Value, _Title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        public static DialogResult Error(string _Value)
        {
            return MessageBox.Show(_Value, CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        public static DialogResult Error(string _Value, string _Title)
        {
            return MessageBox.Show(_Value, _Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        public static DialogResult Stop(string _Value)
        {
            return MessageBox.Show(_Value, CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static DialogResult Stop(string _Value, string _Title)
        {
            return MessageBox.Show(_Value, _Title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static DialogResult Hand(string _Value)
        {
            return MessageBox.Show(_Value, CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
        }

        public static DialogResult Hand(string _Value, string _Title)
        {
            return MessageBox.Show(_Value, _Title, MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
        }
        public static DialogResult Exclamation(string _Value)
        {
            return MessageBox.Show(_Value, CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
        }

        public static DialogResult Exclamation(string _Value, string _Title)
        {
            return MessageBox.Show(_Value, _Title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
        }
        public static DialogResult Warning(string _Value)
        {
            return MessageBox.Show(_Value, CSL.Get(CSLE.A_M_Clue), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        public static DialogResult Warning(string _Value, string _Title)
        {
            return MessageBox.Show(_Value, _Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}
