using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGameTestProject
{
    public partial class Form1 : Form
    {
        int speed;
        int score;
        PictureBox[] road = new PictureBox[8];
        int num;

        public Form1()
        {
            InitializeComponent();
            speed = 3;
            road[0] = RoadDivider1;
            road[1] = RoadDivider2;
            road[2] = RoadDivider3;
            road[3] = RoadDivider4;
            road[4] = RoadDivider5;
            road[5] = RoadDivider6;
            road[6] = RoadDivider7;
            road[7] = RoadDivider8;
        }


        private void RoadAnimationTimer_Tick(object sender, EventArgs e)
        {

            PictureBox display = new PictureBox();
            display.Height = ClientRectangle.Height;
            num = ClientRectangle.Height;

            for (int i = 0; i <= 7; i++)
            {
                road[i].Top += 2;
                if (road[i].Top >= num)
                {
                    road[i].Top = -road[i].Height;
                }
                if (Car.Bounds.IntersectsWith(EnemyCar1.Bounds))
                {
                    GameOver();
                }
                if (Car.Bounds.IntersectsWith(EnemyCar2.Bounds))
                {
                    GameOver();
                }
                if (Car.Bounds.IntersectsWith(EnemyCar3.Bounds))
                {
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            GameOverLabel.Visible = true;
            ReplayButton.Visible = true;
            RoadAnimationTimer.Stop();
            Enemy1_timer.Stop();
            Enemy2_timer.Stop();
            Enemy3_timer.Stop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Left_mover.Start();
            }
            if (e.KeyCode == Keys.Right)
            {
                Right_mover.Start();
            }
        }

        private void Left_mover_Tick(object sender, EventArgs e)
        {
            if (Car.Location.X > 0)
            {
                Car.Left -= 5;
            }
            
        }

        private void Right_mover_Tick(object sender, EventArgs e)
        {
            if (Car.Location.X < 310)
            {
                Car.Left += 5;
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Right_mover.Stop();
            Left_mover.Stop();
        }

        private void Enemy1_timer_Tick(object sender, EventArgs e)
        {
            EnemyCar1.Top += 2;
            if (EnemyCar1.Top >= num)
            {
                score += 1;
                ScoreLabel.Text = "Score " + score;
                Random random2 = new Random();
                Double rdoub2 = random2.Next(0, 100);
                EnemyCar1.Top = -EnemyCar1.Height;
                EnemyCar1.Left = Convert.ToInt32(Math.Ceiling(rdoub2)) + 0;
            }
        }

        private void Enemy2_timer_Tick(object sender, EventArgs e)
        {
            EnemyCar2.Top += 2;
            if (EnemyCar2.Top >= num)
            {
                score += 1;
                ScoreLabel.Text = "Score " + score;
                Random random2 = new Random();
                Double rdoub2 = random2.Next(0, 100);
                EnemyCar2.Top = -EnemyCar2.Height;
                EnemyCar2.Left = Convert.ToInt32(Math.Ceiling(rdoub2)) + 100;
            }
        }

        private void Enemy3_timer_Tick(object sender, EventArgs e)
        {
            EnemyCar3.Top += 2;
            if (EnemyCar3.Top >= num)
            {
                score += 1;
                ScoreLabel.Text = "Score " + score;
                Random random2 = new Random();
                Double rdoub2 = random2.Next(0, 100);
                EnemyCar3.Top = -EnemyCar3.Height;
                EnemyCar3.Left = Convert.ToInt32(Math.Ceiling(rdoub2)) + 250;
            }
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            score = 0;
            GameOverLabel.Visible = false;
            ReplayButton.Visible = false;
            RoadAnimationTimer.Start();

        }
    }
}
