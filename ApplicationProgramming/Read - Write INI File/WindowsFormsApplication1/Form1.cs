using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IniFilesClass;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        //AppDomain.CurrentDomain.BaseDirectory + "abc.ini"
        //string
        private void button1_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile( IniFile.AppIniName );
            ini.WriteString("Settings", "Name", textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile( IniFile.AppIniName );
            textBox1.Text = ini.ReadString("Settings", "Name", "没有文字");
        }




        //Integer
        private void button3_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(IniFile.AppIniName);
            ini.WriteInteger("Settings", "Age", 26);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(IniFile.AppIniName);
            int nAge = ini.ReadInteger("Settings", "Age", 0);
            textBox1.Text = nAge.ToString(); 
        }

        //bool
        private void button5_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(IniFile.AppIniName);
            ini.WriteBool("Settings", "Man", checkBox1.Checked);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(IniFile.AppIniName);
            checkBox1.Checked =  ini.ReadBool("Settings", "Man", true);
        }




    }
}
