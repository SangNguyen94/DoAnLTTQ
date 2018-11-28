#define My_debug
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using WindowsFormsApp8.Properties;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
       
        const int splat_num = 3;
        public int splat_time = 0;
        public bool splat = false;
        public int _cursx = 0;
        public int _cursy = 0;
        Random rnd = new Random();
        Cdiablos Cdiablos;
        CScoreFrame CScoreFrame;
        CSignExit cSignExit;
        CSignStart CSignStart;
        CSignReset CSignReset;
        CSignStop CSignStop;
        CSplat CSplat;
        int hits = 0;
        int miss = 0;
        int totalshot = 0;
        int points = 0;
        public Form1()
        {
            InitializeComponent();
            Bitmap b = new Bitmap(Resources.whitemagic);
            this.Cursor = CustomCursor.CreateCursor(b, b.Height/2, b.Width/2);
            CScoreFrame = new CScoreFrame() { left = 0, top = 0 };
            CSignStart = new CSignStart() { left = 850, top = 0 };
            CSignStop = new CSignStop() { left = 850, top = 29 };
            CSignReset = new CSignReset() { left = 850, top = 65 };
            cSignExit = new CSignExit() { left = 850, top = 100 };
            Cdiablos = new Cdiablos() ;
            CSplat = new CSplat();


        }

        private void UpdateDiablos()
        {
            Cdiablos.Update(
                rnd.Next(0, 700),
                rnd.Next(128,400 )

                );

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            if (splat== true)
            {
                CSplat.DrawImage(dc);
            }
            else
            {
                Cdiablos.DrawImage(dc);
            }

#if My_debug
            CScoreFrame.DrawImage(dc);
            CSignStart.DrawImage(dc);
            CSignStop.DrawImage(dc);
            CSignReset.DrawImage(dc);
            cSignExit.DrawImage(dc);
           
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font Font1 = new Font("Stencil", 11, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursx.ToString() + ";" + "Y=" + _cursy.ToString(), Font1, new Rectangle(10, 10, 130, 30), SystemColors.ControlDarkDark, flags);
            TextRenderer.DrawText(dc, "Shots:" + totalshot.ToString(), Font1, new Rectangle(10, 22, 130, 30), SystemColors.ControlDarkDark, flags);
            TextRenderer.DrawText(dc, "Hits:" + hits.ToString(), Font1, new Rectangle(10, 34, 130, 30), SystemColors.ControlDarkDark, flags);
            TextRenderer.DrawText(dc, "Misses:" + miss.ToString(), Font1, new Rectangle(10, 46, 130, 30), SystemColors.ControlDarkDark, flags);
            TextRenderer.DrawText(dc, "Points:" + points.ToString(), Font1, new Rectangle(10, 58, 130, 30), SystemColors.ControlDarkDark, flags);
#endif
            base.OnPaint(e);
        }

        private void Timegameloop_Tick_1(object sender, EventArgs e)
        {
            UpdateDiablos();
            if(splat)
            {
                if(splat_time>=1)
                {
                    splat = false;
                    splat_time = 0;
                    UpdateDiablos();
                }
                splat_time++;

            }
            this.Refresh();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            _cursx = e.X;
            _cursy = e.Y;
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timegameloop.Stop();
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 850 && e.X < 945 && e.Y > 0 && e.Y < 32)
            {
                
                Timegameloop.Start();
                timer1.Enabled = true;
                miss--;
            }
            if (e.X > 850 && e.X < 945 && e.Y > 39 && e.Y < 69)
            {
                Timegameloop.Stop();
            }
            if (e.X > 850 && e.X < 945 && e.Y > 77 && e.Y < 103)
            {
                
                Timegameloop.Stop();
            }
            if (e.X > 850 && e.X < 945 && e.Y > 114 && e.Y < 135)
            {
                
                this.Close();
            }
           
            if(Cdiablos.Hit(e.X,e.Y))
            {
                splat = true;
                CSplat.left = Cdiablos.left +90;
                CSplat.top = Cdiablos.top + 40;
                hits++;
            }
            else { miss++; }
            points = hits - miss;
            totalshot = hits + miss;
            
        }
        private void Banish()
        {
            SoundPlayer simplesound = new SoundPlayer(Resources.Shock);
            simplesound.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timegameloop.Stop();
            if(points>=10)
            {
                MessageBox.Show("You WON!");
                this.Close();
            }
            else
            {
                MessageBox.Show("You LOST!");
                this.Close();
            }
            
        }
    }
}
