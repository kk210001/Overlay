using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Overlay.addlayers;

namespace Overlay
{
    public partial class MainForm : Form
    {
        public void isChecked(bool check)
        {
            if (check)
            {
                this._overlayform_mococo = new overlayform_mococo();
               // _overlayform_mococo.webURL = textBox1.Text;
                //_overlayform_mococo.navigateBrowser();
                this._overlayform_mococo.Show();
            }
            else
            {
                this._overlayform_mococo.Close();
            }
        }
    }
}
