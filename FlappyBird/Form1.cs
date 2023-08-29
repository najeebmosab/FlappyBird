using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        int gravite = 20;
        int speed = 15;
        Random rnd = new Random();
        int score = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top += gravite;
            pictureBox3.Left -= speed;
            pictureBox4.Left -= speed;
            if (pictureBox3.Left <= 0)
            {
                int X = rnd.Next(440, 928);
                pictureBox3.Left = X;
                score += 1;
                label1.Text = "Your Score Is: " + score;
            }

            if (pictureBox4.Left <= 0)
            {
                int X = rnd.Next(440, 928);
                pictureBox4.Left = X;
                score += 1;
                label1.Text = "Your Score Is: " + score;
            }
            
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) || pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds) || pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                timer1.Stop();
                label1.Text = "Your Score Is" + score;
            }

            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled == false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    timer1.Start();
                    int X = rnd.Next(440, 928);
                    pictureBox3.Left = X;
                    X = rnd.Next(440, 928);
                    pictureBox4.Left = X;
                    score = 0;
                    pictureBox1.Top = 10;
                }
            }
            
            if (e.KeyCode == Keys.Space)
            {
                gravite = -15;
            }
            if (pictureBox1.Top < 2)
            {
                pictureBox1.Top = 15;
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravite = 15;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Your Score Is: " + score;
        }
    }
}
