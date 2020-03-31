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

namespace RedisSubscriber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379,allowAdmin=True,connectTimeout=60000");


        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // grab an instance of an ISubscriber
            var subscriber = redis.GetSubscriber();

            // subscribe to a messages over the 'chat' channel
            subscriber.Subscribe("chat", (channel, message) => {
                MessageBox.Show((string)message, "Redis App");
                var data = (string)message;
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // grab an instance of an ISubscriber
            var subscriber = redis.GetSubscriber();

            // subscribe to a messages over the 'chat' channel
            subscriber.Subscribe(textBox1.Text, (channel, message) => {
                MessageBox.Show((string)message, "Redis App");
                var data = (string)message;
                SetText(message.ToString());
            });
        }
    }
}
