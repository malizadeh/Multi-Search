using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multi_Search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] targets = new string[]
            {
                $"https://www.google.de/search?q={textBox1.Text}&tbm=isch&hl=de&tbs=isz:m&sa=X&ved=0CAMQpwVqFwoTCPiXlKyCz_MCFQAAAAAdAAAAABAC&biw=1903&bih=969",
                $"https://de-thefreedictionary-com.translate.goog/{textBox1.Text}?_x_tr_sl=de&_x_tr_tl=en&_x_tr_hl=en-US&_x_tr_pto=nui",
                $"https://de.thefreedictionary.com/{textBox1.Text}",
                $"https://www.dict.cc/?s={textBox1.Text}",
                $"https://forvo.com/word/{textBox1.Text}/#de"
            };

            try
            {
                foreach (var target in targets)
                {
                    System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "\"" + target + "\" -inprivate");
                    Thread.Sleep(50);
                }
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}
