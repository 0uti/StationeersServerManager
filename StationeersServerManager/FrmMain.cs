/*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * Outi wrote this file. As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return Outi
 * ----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Timers;
using System.Windows.Forms;

namespace StationeersServerManager
{
    public partial class FrmMain : Form
    {
        private readonly IPAddress serverIP = IPAddress.Parse("1.1.1.1");
        private readonly int serverPort = 27500;
        private readonly string serverPassword = "password";

        private System.Timers.Timer _PlayerListTimer;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _PlayerListTimer.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _PlayerListTimer.Stop();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _PlayerListTimer = new System.Timers.Timer
            {
                Interval = 10000
            };
            _PlayerListTimer.Elapsed += PlayerListTimerTick;

        }

        private void PlayerListTimerTick(object sender, ElapsedEventArgs e)
        {
            RemoteConsole rcon = new RemoteConsole(serverIP, serverPort, serverPassword);
            ServerStatus status = rcon.GetStatus();
            BeginInvoke(new Action(() => UpdatePlayerList(status.PlayerList)));
        }

        private void UpdatePlayerList(List<Player> players)
        {
            LstPlayerList.Items.Clear();
            foreach (Player player in players)
            {
                ListViewItem item = new ListViewItem(player.Name);
                item.SubItems.Add(player.Score.ToString());
                item.SubItems.Add(player.PlayTime);
                item.SubItems.Add(player.Ping);
                LstPlayerList.Items.Add(item);
            }
        }

        private void BtnSendMessge_Click(object sender, EventArgs e)
        {
            if (TxtMessage.Text.Length != 0)
            {
                RemoteConsole rcon = new RemoteConsole(serverIP, serverPort, serverPassword);
                rcon.Notice(TxtMessage.Text);
            }
        }
    }
}
