using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MarioObjects;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGame
{
    public partial class Mario : Form
    {
        public Mario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        MarioObjects.frmMain marioObjects = new frmMain();
        private void button1_Click(object sender, EventArgs e)
        {
             
            marioObjects.Show();
            timer2.Enabled = true;
            timer2.Start();
            this.Hide();
            marioObjects.Closed += (s, arg) => this.Close();
        }

        private void Mario_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(marioObjects.isWON==true)
            {
                MarioObjects.LevelManager.Instance.CurrentLevelIndex = 0;
                MarioObjects.LevelManager.Instance.MarioLives = 5;
                MarioObjects.LevelManager.Instance.SaveLevelManager("LevelManager.xml");
                _2048 _2048 = new _2048();
                _2048.Show();
                timer2.Enabled = false;
                timer2.Stop();
                _2048.Closed += (s, arg) => this.Close();
                marioObjects.Hide();
                timer1.Stop();
                timer1.Enabled = false;
                
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(marioObjects.isWON==false)
            {
                marioObjects.Close();
                this.Close();
            }
        }
    }
}
