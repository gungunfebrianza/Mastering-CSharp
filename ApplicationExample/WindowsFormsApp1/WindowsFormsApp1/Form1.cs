using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;

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
            var html = @"https://kawalcovid19.id/";

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(html);
            System.Threading.Thread.Sleep(3000);
            // filter html elements on the basis of class name
            var nodes = doc.DocumentNode.Descendants().Where(n => n.HasClass("css-12jz6xg"));

            foreach (var item in nodes)
            {
                // displaying final output
                textBox1.Text += item.InnerText;
            }


        }
    }
}

/*            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//div/div/span");

            foreach (var node in htmlNodes)
            {
                textBox1.Text += node.InnerText;
            }
*/
