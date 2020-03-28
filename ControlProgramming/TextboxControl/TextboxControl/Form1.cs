using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextboxControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Hello";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += " Gun Gun Febrianza!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string x = textBox1.Text;
            MessageBox.Show(x, "TextBox Value");
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("You Press Enter");
            }
            if (e.KeyCode == Keys.Z)
            {
                MessageBox.Show("You Press Z/z");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox4.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox6.Text);
            MessageBox.Show(i.ToString());
        }
    }
}
