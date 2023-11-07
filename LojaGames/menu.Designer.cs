namespace LojaGames.Resources
{
    partial class menu
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panelBtn_Dashboard);
            this.panel1.Controls.Add(this.panelBtn_Users);
            this.panel1.Controls.Add(this.panelBtn_Games);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 451);
            this.panel1.TabIndex = 2;
            // 
            // panelBtn_Dashboard
            // 
            this.panelBtn_Dashboard.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelBtn_Dashboard.Controls.Add(this.lblDashboard);
            this.panelBtn_Dashboard.Location = new System.Drawing.Point(39, 253);
            this.panelBtn_Dashboard.Name = "panelBtn_Dashboard";
            this.panelBtn_Dashboard.Size = new System.Drawing.Size(110, 40);
            this.panelBtn_Dashboard.TabIndex = 2;
            this.panelBtn_Dashboard.MouseEnter += new System.EventHandler(this.panelBtn_Dashboard_MouseEnter);
            this.panelBtn_Dashboard.MouseLeave += new System.EventHandler(this.panelBtn_Dashboard_MouseLeave);
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
            this.lblDashboard.MouseEnter += new System.EventHandler(this.lblDashboard_MouseEnter);
            // 
            // panelBtn_Users
            // 
            this.panelBtn_Users.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelBtn_Users.Controls.Add(this.lblUsers);
            this.panelBtn_Users.Location = new System.Drawing.Point(39, 191);
            this.panelBtn_Users.Name = "panelBtn_Users";
            this.panelBtn_Users.Size = new System.Drawing.Size(110, 40);
            this.panelBtn_Users.TabIndex = 3;
            this.panelBtn_Users.MouseEnter += new System.EventHandler(this.panelBtn_Users_MouseEnter);
            this.panelBtn_Users.MouseLeave += new System.EventHandler(this.panelBtn_Users_MouseLeave);
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
            this.lblUsers.MouseEnter += new System.EventHandler(this.lblUsers_MouseEnter);
            // 
            // panelBtn_Games
            // 
            this.panelBtn_Games.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelBtn_Games.Controls.Add(this.lblGames);
            this.panelBtn_Games.Location = new System.Drawing.Point(39, 129);
            this.panelBtn_Games.Name = "panelBtn_Games";
            this.panelBtn_Games.Size = new System.Drawing.Size(110, 40);
            this.panelBtn_Games.TabIndex = 2;
            this.panelBtn_Games.MouseEnter += new System.EventHandler(this.panelBtn_Games_MouseEnter);
            this.panelBtn_Games.MouseLeave += new System.EventHandler(this.panelBtn_Games_MouseLeave);
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
            this.lblGames.MouseEnter += new System.EventHandler(this.lblGames_MouseEnter);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "menu";
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

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBtn_Dashboard;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Panel panelBtn_Users;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Panel panelBtn_Games;
        private System.Windows.Forms.Label lblGames;
    }
}