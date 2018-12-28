using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using game2048;
using System.Text;
using BombsAway;
using BirdHuntingGame.Forms;
using BirdHuntingGame;
using MarioObjects;
using WindowsFormsApp8;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGame
{
    public partial class FinalForm : Form
    {
        public FinalForm()
        {
            InitializeComponent();

        }
        WindowsFormsApp8.Form1 Form1 = new WindowsFormsApp8.Form1();

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.isWon = false;
            timer1.Enabled = true;
            timer1.Start();
            Form1.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Form1.isWon==true)
            {
                this.Show();
                timer1.Enabled = false;
                timer1.Stop();
                this.Close();
            }
            if(Form1.IsDisposed)
            {
                
                timer1.Enabled = false;
                timer1.Stop();
                this.Close();
            }
        }
        game2048.Game2048 game2048 = new Game2048();
        private void button2_Click(object sender, EventArgs e)
        {
            game2048.Show();
            this.Hide();
            timer3.Enabled = true;
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(game2048.isdead==true)
            {
                timer3.Enabled = false;
                timer3.Stop();
                MessageBox.Show("GameOver");
                this.Close();
                
            }
        }
        MarioObjects.frmMain frmMain = new frmMain();
        private void button3_Click(object sender, EventArgs e)
        {
            frmMain.Show();
            this.Hide();
            timer5.Start();
            timer5.Enabled = true;
            timer6.Enabled = true;
            timer6.Start();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if(frmMain.isWON)
            {
                
                timer5.Enabled = false;
                timer5.Stop();
                MessageBox.Show("You WON");
                this.Close();

            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("You LOSE");
            this.Close();
        }
        BombsAway.Form1 form = new BombsAway.Form1();
        private void button4_Click(object sender, EventArgs e)
        {
            form.Show();
            form.isdead = false;
            this.Hide();
            timer7.Enabled = true;
            timer7.Start();
            timer8.Enabled = true;
            timer8.Start();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if(form.isdead==true)
            {
                timer7.Enabled = false;
                timer7.Stop();
                MessageBox.Show("You DIED");
                this.Close();
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("You SURVIVED");
            this.Close();
        }
        BirdHuntingGame.Forms.PlayGameForm gameForm = new PlayGameForm(); 
        private void button5_Click(object sender, EventArgs e)
        {
            gameForm.Show();
            this.Hide();
        }

        private void timer9_Tick(object sender, EventArgs e)
        {

        }

        private void timer10_Tick(object sender, EventArgs e)
        {

        }
    }
}
