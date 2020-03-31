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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379,allowAdmin=True,connectTimeout=60000");

        private void Form2_Load(object sender, EventArgs e)
        {
            // grab an instance of an ISubscriber
            var subscriber = redis.GetSubscriber();

            // subscribe to a messages over the 'chat' channel
            subscriber.Subscribe("chat", (channel, message) => {
                //MessageBox.Show((string)message, "Redis App");
            });
        }
    }
}
