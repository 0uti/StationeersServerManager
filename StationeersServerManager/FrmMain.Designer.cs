
namespace StationeersServerManager
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.LstPlayerList = new System.Windows.Forms.ListView();
            this.lPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lTme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.BtnSendMessge = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(16, 17);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(112, 35);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(16, 74);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(112, 35);
            this.BtnStop.TabIndex = 1;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // LstPlayerList
            // 
            this.LstPlayerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lPlayers,
            this.lScore,
            this.lTme,
            this.lPing});
            this.LstPlayerList.HideSelection = false;
            this.LstPlayerList.Location = new System.Drawing.Point(261, 12);
            this.LstPlayerList.Name = "LstPlayerList";
            this.LstPlayerList.Size = new System.Drawing.Size(790, 501);
            this.LstPlayerList.TabIndex = 2;
            this.LstPlayerList.UseCompatibleStateImageBehavior = false;
            this.LstPlayerList.View = System.Windows.Forms.View.Details;
            // 
            // lPlayers
            // 
            this.lPlayers.Text = "Player";
            this.lPlayers.Width = 200;
            // 
            // lScore
            // 
            this.lScore.Text = "Score";
            this.lScore.Width = 100;
            // 
            // lTme
            // 
            this.lTme.Text = "Time";
            this.lTme.Width = 120;
            // 
            // lPing
            // 
            this.lPing.Text = "Ping";
            this.lPing.Width = 100;
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(261, 523);
            this.TxtMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(790, 26);
            this.TxtMessage.TabIndex = 3;
            // 
            // BtnSendMessge
            // 
            this.BtnSendMessge.Location = new System.Drawing.Point(18, 520);
            this.BtnSendMessge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSendMessge.Name = "BtnSendMessge";
            this.BtnSendMessge.Size = new System.Drawing.Size(112, 35);
            this.BtnSendMessge.TabIndex = 4;
            this.BtnSendMessge.Text = "Send Text";
            this.BtnSendMessge.UseVisualStyleBackColor = true;
            this.BtnSendMessge.Click += new System.EventHandler(this.BtnSendMessge_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 572);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.StatusBar.Size = new System.Drawing.Size(1054, 22);
            this.StatusBar.TabIndex = 5;
            this.StatusBar.Text = "statusStrip1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 594);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.BtnSendMessge);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.LstPlayerList);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Stationeers Server Manager";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.ListView LstPlayerList;
        private System.Windows.Forms.ColumnHeader lPlayers;
        private System.Windows.Forms.ColumnHeader lScore;
        private System.Windows.Forms.ColumnHeader lTme;
        private System.Windows.Forms.ColumnHeader lPing;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnSendMessge;
        private System.Windows.Forms.StatusStrip StatusBar;
    }
}

