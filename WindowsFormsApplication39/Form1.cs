using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace WindowsFormsApplication39
{
    public partial class Form1 : Form
    {
        SoundPlayer spl = new SoundPlayer("Hitman.WAV");
        public Form1()
        {
            spl.Play();
            InitializeComponent();
        }
        

        private void bubble()
        {
            Random r = new Random();
            int i;
           foreach( Control j in this.Controls)
            {
                if ( j is PictureBox && j.Tag == "bubble")
                {
                    j.Top -= 5;
                    if(j.Top < 0)
                    {
                        i = r.Next(10, 900);
                        j.Location = new Point(i,900);
                    }
                }

            }
        }
        int score =0;
        private void fishmove()
        {
            
            Random r = new Random();
            int i;
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "fish")
                {
                    j.Left -= 2;
                    if (j.Left < 0)
                    {
                        i = r.Next(48, 303);
                        j.Location = new Point(1250, i);
                    }
                    if (play.Bounds.IntersectsWith(j.Bounds))
                    {
                        i = r.Next(48, 303);
                        j.Location = new Point(1200, i);
                        score++;
                        label1.Text = score.ToString();
                        play.Size += new Size(2,2);
                        progressBar1.Value += 2;
                        if (progressBar1.Value > 99)
                        {
                            label2.Visible = true;
                            timer1.Stop();
                            label2.Text = "لقد فزت";
                            play.Hide();
                            spl.Stop();
                        }
                    }

                }

            }
        }

        private void enemymove()
        {
            Random r = new Random();
            int i;
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "enemy")
                {
                    j.Left -= 2;
                    if (j.Left < 0)
                    {
                        i = r.Next(48, 303);
                        j.Location = new Point(1800, i);
                    }
                    if (play.Bounds.IntersectsWith(j.Bounds))
                    {
                        if(play.Size == new Size(60, 40))
                        {
                            label2.Visible = true;
                            timer1.Stop();
                            label2.Text = "لقد خسرت انتهت اللعبة";
                            play.Hide();
                            spl.Stop();
                        }
                        else { play.Size = new Size(60, 40); j.Left = 700; }

                        //i = r.Next(48, 303);
                        //j.Location = new Point(700, i);
                        //score++;
                        //label1.Text = score.ToString();
                        //play.Size += new Size(2, 2);
                        //progressBar1.Value += 5;
                        //if (progressBar1.Value > 99)
                        {

                        }
                    }

                }

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if(play.Top > 50) { play.Top -= 10; }
                    break;

                case Keys.Down:
                    if (play.Top < 330) { play.Top += 10; }
                    break;

                case Keys.Right:
                    if (play.Right < 1660) { play.Left += 10; }
                    play.Image = Properties.Resources.batman_r;
                    break;

                case Keys.Left:
                    if (play.Left > 0) { play.Left -= 10; }
                    play.Image = Properties.Resources.batman_l;
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            play.Top += 1;
            bubble();
            fishmove();
            enemymove();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void play_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
