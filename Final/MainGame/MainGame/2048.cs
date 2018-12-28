using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using game2048;
using BirdHuntingGame;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BirdHuntingGame.Forms;

namespace MainGame
{
    public partial class _2048 : Form
    {
        public _2048()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        game2048.Game2048 game2048 = new Game2048();
        private void button1_Click(object sender, EventArgs e)
        {
            game2048.Show();
            timer2.Enabled = true;
            timer2.Start();
            game2048.Closed += (s, arg) => this.Close();
            this.Hide();
        }
        
        //PlayGameForm playGameForm = new PlayGameForm();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(game2048.CurrentScore>1000)
            {
                BirdHunting BirdHunting = new BirdHunting();
                BirdHunting.Show();
                timer2.Enabled = false;
                timer2.Stop();
                //playGameForm.Show();
                BirdHunting.Closed += (s, arg) => this.Close();
                game2048.Hide();
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void _2048_Load(object sender, EventArgs e)
        {
            
        }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    if(gameOptionsForm.isWon==true)
        //    {
        //        MarioBomb marioBomb = new MarioBomb();
        //        marioBomb.Show();
        //        marioBomb.Closed += (s, arg) => this.Close();
        //        gameOptionsForm.Hide();
        //        timer2.Stop();
        //        timer2.Enabled = false;
        //    }
        //}
    }
}
