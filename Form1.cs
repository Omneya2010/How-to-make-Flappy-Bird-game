using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int pipespeed = 8;
        int gravity = 5;
        int score = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            pictureBox3.Left -= pipespeed;
            pictureBox1.Left -= pipespeed;
            ScoreText.Text = "Score : " + score;

            
            if ( pictureBox1.Left < -80)
            {
                pictureBox1.Left = 350;
                score++;
            }
            
            if (pictureBox3.Left < -100)
            {
                pictureBox3.Left = 500;
                score++;
            }

            if(Bird.Bounds.IntersectsWith(pictureBox1.Bounds) ||
                    Bird.Bounds.IntersectsWith(pictureBox3.Bounds) ||
                    Bird.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                endgame();
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Space)
                gravity = 5;
        }

        private void GameKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = -5;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void endgame()
        {
            GameTimer.Stop();
            ScoreText.Text = "Game Over !!!!";
        }
    }
}
