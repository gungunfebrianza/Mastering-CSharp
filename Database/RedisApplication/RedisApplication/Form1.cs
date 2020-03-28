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

        private void button3_Click(object sender, EventArgs e)
        {
            // grab an instance of an ISubscriber
            var subscriber = redis.GetSubscriber();

            // publish a message to the 'chat' channel
            subscriber.Publish(textBoxPubTopic.Text, textBoxPubMessage.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxPubTopic.Clear();
            textBoxPubMessage.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.Show();
        }
    }
}
