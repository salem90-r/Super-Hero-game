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
    public partial class splach_screen : Form
    {
        public splach_screen()
        {
            sply.Play();
            InitializeComponent();
        }

        SoundPlayer sply = new SoundPlayer("alex.WAV");
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            progressBar1.Increment(2);
            if(progressBar1.Value==100)
            {
                timer2.Enabled = false;
                Form1 form = new Form1();
                //this.sply.Stop();
                form.Show();
                this.Hide();
                
            }
        }

    }

}
