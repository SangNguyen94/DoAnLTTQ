using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BombsAway;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGame
{
    public partial class MarioBomb : Form
    {
        public MarioBomb()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        BombsAway.Form1 bomb = new Form1();
        
        private void button1_Click(object sender, EventArgs e)
        {
            bomb.Show();
            timer1.Enabled = true;
            timer1.Start();
            timer2.Enabled = true;
            timer2.Start();
            bomb.Closed += (s, arg) => this.Close();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(bomb.isdead)
            {
                timer1.Enabled = false;
                timer1.Stop();
                MessageBox.Show("You Lose");
                
                bomb.Close();
                
            }
        }
        FinalForm FinalForm = new FinalForm();
        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("You completed all 5 games!!!");
            bomb.Hide();
            FinalForm.Show();
            FinalForm.Closed += (s, arg) => this.Close();
        }

        private void MarioBomb_Load(object sender, EventArgs e)
        {
            bomb.isdead = false;
        }
    }
}
