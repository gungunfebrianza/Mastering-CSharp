using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormExample
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Form1 secondform = new Form1();
        public static TextBox tb = new TextBox();

        private void button1_Click(object sender, EventArgs e)
        {
            //secondform.Show();
            /*        if (secondform.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("OK", "Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }*/
            secondform.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tb = textBox1;
        }
    }
}
