using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaGames
{
    public partial class splash : Form
    {
        private string text;
        private int len = 0;
        public splash()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuProgressBar1.Value = bunifuProgressBar1.Value + 4;
            label2.Text = bunifuProgressBar1.Value.ToString() + "%";

            if (bunifuProgressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                new explore().Show();
                Visible = false;
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            text = label1.Text;
            label1.Text = "";
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(len < text.Length)
            {
                label1.Text = label1.Text + text.ElementAt(len);
                len++;
            }
            else
                timer2.Stop();
        }
    }
}