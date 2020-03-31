using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace FormExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string changeCase = Form2.tb.Text;
            if (radioButton1.Checked == true)
            {
                changeCase = changeCase.ToUpper();
            }
            else if (radioButton2.Checked == true)
            {
                changeCase = changeCase.ToLower();
            }
            else if (radioButton3.Checked == true)
            {
                CultureInfo properCase = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfoObject = properCase.TextInfo;
                changeCase = textInfoObject.ToTitleCase(changeCase);
            }
            Form2.tb.Text = changeCase;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
