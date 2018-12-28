﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BirdHuntingGame.Forms;
using BirdHuntingGame;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGame
{
    public partial class BirdHunting : Form
    {
        public BirdHunting()
        {
            InitializeComponent();
        }
        PlayGameForm gameForm = new PlayGameForm();
        private void button1_Click(object sender, EventArgs e)
        {
            gameForm.Show();
            gameForm.Closed += (s, arg) => this.Close();
            this.Hide();
        }
        MarioBomb marioBomb = new MarioBomb();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(gameForm.iswon)
            {
                marioBomb.Show();
                marioBomb.Closed += (s, arg) => this.Close();
                gameForm.Hide();
                timer1.Enabled = false;
                timer1.Stop();
            }
        }
    }
}