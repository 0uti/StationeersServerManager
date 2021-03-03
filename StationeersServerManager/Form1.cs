using System;
using System.Net;
using System.Windows.Forms;

namespace StationeersServerManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Just for testing
            RemoteConsole rcon = new RemoteConsole(IPAddress.Parse("1.1.1.1"),27500,"password");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // just for testing
            RemoteConsole rcon = new RemoteConsole(IPAddress.Parse("1.1.1.1"), 27500, "password");
            rcon.GetStatus();
        }
    }
}
