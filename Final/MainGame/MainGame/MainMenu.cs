using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGame
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiabolosHunter diabolosHunter = new DiabolosHunter();
            diabolosHunter.Show();
            diabolosHunter.Closed += (s, arg) => this.Close();
            this.Hide();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="hocmemnhungcung")
            {
                FinalForm final = new FinalForm();
                final.Show();
                final.Closed += (s, arg) => this.Close();
                this.Hide();
            }
            else { MessageBox.Show("Wrong passcode"); }
        }
    }
}
