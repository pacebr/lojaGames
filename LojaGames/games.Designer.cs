namespace LojaGames
{
    partial class games
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBtn_Desconectar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBtn_Dashboard = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.panelBtn_Users = new System.Windows.Forms.Panel();
            this.lblUsers = new System.Windows.Forms.Label();
            this.panelBtn_Games = new System.Windows.Forms.Panel();
            this.lblGames = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelBtn_Dashboard.SuspendLayout();
            this.panelBtn_Users.SuspendLayout();
            this.panelBtn_Games.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBtn_Desconectar
            // 
            this.panelBtn_Desconectar.BackgroundImage = global::LojaGames.Properties.Resources.icons8_desligar_25;
            this.panelBtn_Desconectar.Location = new System.Drawing.Point(775, 426);
            this.panelBtn_Desconectar.Name = "panelBtn_Desconectar";
            this.panelBtn_Desconectar.Size = new System.Drawing.Size(25, 25);
            this.panelBtn_Desconectar.TabIndex = 5;
            this.panelBtn_Desconectar.Click += new System.EventHandler(this.panelBtn_Desconectar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panelBtn_Dashboard);
            this.panel1.Controls.Add(this.panelBtn_Users);
            this.panel1.Controls.Add(this.panelBtn_Games);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 451);
            this.panel1.TabIndex = 4;
            // 
            // panelBtn_Dashboard
            // 
            this.panelBtn_Dashboard.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelBtn_Dashboard.Controls.Add(this.lblDashboard);
            this.panelBtn_Dashboard.Location = new System.Drawing.Point(39, 253);
            this.panelBtn_Dashboard.Name = "panelBtn_Dashboard";
            this.panelBtn_Dashboard.Size = new System.Drawing.Size(110, 40);
            this.panelBtn_Dashboard.TabIndex = 2;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(27, 13);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(59, 13);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Dashboard";
            // 
            // panelBtn_Users
            // 
            this.panelBtn_Users.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelBtn_Users.Controls.Add(this.lblUsers);
            this.panelBtn_Users.Location = new System.Drawing.Point(39, 191);
            this.panelBtn_Users.Name = "panelBtn_Users";
            this.panelBtn_Users.Size = new System.Drawing.Size(110, 40);
            this.panelBtn_Users.TabIndex = 3;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.ForeColor = System.Drawing.Color.White;
            this.lblUsers.Location = new System.Drawing.Point(41, 13);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(34, 13);
            this.lblUsers.TabIndex = 2;
            this.lblUsers.Text = "Users";
            // 
            // panelBtn_Games
            // 
            this.panelBtn_Games.BackColor = System.Drawing.Color.Green;
            this.panelBtn_Games.Controls.Add(this.lblGames);
            this.panelBtn_Games.Location = new System.Drawing.Point(39, 129);
            this.panelBtn_Games.Name = "panelBtn_Games";
            this.panelBtn_Games.Size = new System.Drawing.Size(110, 40);
            this.panelBtn_Games.TabIndex = 2;
            // 
            // lblGames
            // 
            this.lblGames.AutoSize = true;
            this.lblGames.BackColor = System.Drawing.Color.Transparent;
            this.lblGames.ForeColor = System.Drawing.Color.White;
            this.lblGames.Location = new System.Drawing.Point(38, 13);
            this.lblGames.Name = "lblGames";
            this.lblGames.Size = new System.Drawing.Size(40, 13);
            this.lblGames.TabIndex = 0;
            this.lblGames.Text = "Games";
            // 
            // games
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelBtn_Desconectar);
            this.Controls.Add(this.panel1);
            this.Name = "games";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Games";
            this.panel1.ResumeLayout(false);
            this.panelBtn_Dashboard.ResumeLayout(false);
            this.panelBtn_Dashboard.PerformLayout();
            this.panelBtn_Users.ResumeLayout(false);
            this.panelBtn_Users.PerformLayout();
            this.panelBtn_Games.ResumeLayout(false);
            this.panelBtn_Games.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBtn_Desconectar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBtn_Dashboard;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Panel panelBtn_Users;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Panel panelBtn_Games;
        private System.Windows.Forms.Label lblGames;
    }
}