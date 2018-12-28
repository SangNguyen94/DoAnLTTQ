using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using WindowsFormsApp8;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGame
{
    public partial class DiabolosHunter : Form
    {
        public DiabolosHunter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer2.Enabled = true;
            //timer2.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public WindowsFormsApp8.Form1 form1 = new Form1();
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            form1.Closed += (s, arg) => this.Close();
            this.Hide();
            form1.Show();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (form1.isWon == true)
             {
                  Mario mario = new Mario();
                  mario.Show();
                //timer2.Enabled = false;
                //timer2.Stop();
                  mario.Closed += (s, arg) => this.Close();
                  form1.Hide();
                  timer1.Enabled = false;
                  timer1.Stop();
                
             }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(form1.isWon==false)
            {
                this.Close();
            }
        }
    }
}
