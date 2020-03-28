using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackExchange.Redis;

namespace RedisApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379,allowAdmin=True,connectTimeout=60000");

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxSetKey.Clear();
            textBoxSetValue.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select a database (by default, DB = 0)
            IDatabase db = redis.GetDatabase();
            db.StringSet(textBoxSetKey.Text, textBoxSetValue.Text);
            int i = (int)db.StringGet(textBoxSetKey.Text);
            MessageBox.Show("Stored on Redis " + i.ToString(), "Redis Application Dekstop");
            buttonClearValue.PerformClick();
        }
    }
}
