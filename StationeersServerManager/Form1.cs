/*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * Outi wrote this file. As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return Outi
 * ----------------------------------------------------------------------------
 */

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
