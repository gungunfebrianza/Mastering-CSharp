using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process ipconfigProcess = new Process();
            // Indicate that we want to execute ipconfig
            ipconfigProcess.StartInfo.FileName = "ipconfig";
            ipconfigProcess.StartInfo.Arguments = "/all";
            // Indicate that we want to read the command line output
            ipconfigProcess.StartInfo.RedirectStandardOutput = true;
            ipconfigProcess.StartInfo.UseShellExecute = false;
            // Start the process to execute ipconfig
            ipconfigProcess.Start();
            // Get a StreamReader to read from the standard output of
            // the ipconfig process
            StreamReader reader = ipconfigProcess.StandardOutput;
            // Perform reading and writing of standard output to Console
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                MessageBox.Show(line);
            } // end while
        }
    }
}
