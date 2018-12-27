using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Media;
namespace game2048
{
    public partial class Game2048 : Form
    {
       
        SoundPlayer sound = new SoundPlayer(Application.StartupPath+"/andiem.wav");
        SoundPlayer sound2 = new SoundPlayer(Application.StartupPath+"/blip.wav");
        SoundPlayer sound3 = new SoundPlayer(Application.StartupPath + "/gameover.wav");
        Random Rd = new Random();
        bool laplai = true;
        static ArrayList array1 = new ArrayList();//array1
        public Game2048()
        {
            
            InitializeComponent();
            
        }
      
        public void taoimage()
        {
            PictureBox[,] Game = { 
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if(Game[i,j].Text==""){
                        Game[i, j].Image = Properties.Resources._nen;
                    }
                    if (Game[i, j].Text == "2")
                    {
                        Game[i, j].Image = Properties.Resources._2;
                       

                    }
                    if (Game[i, j].Text == "4")
                    {
                        Game[i, j].Image = Properties.Resources._4_dribbble;
                    
                    }
                    if (Game[i, j].Text == "8")
                    {
                        Game[i, j].Image = Properties.Resources._8;
                       
                    }
                    if (Game[i, j].Text == "16")
                    {
                        Game[i, j].Image = Properties.Resources._16;
                        
                    }
                    if (Game[i, j].Text == "32")
                    {
                        Game[i, j].Image = Properties.Resources._32;
                
                    }
                    if (Game[i, j].Text == "64")
                    {
                        Game[i, j].Image = Properties.Resources._64;
                    
                    }
                    if (Game[i, j].Text == "128")
                    {
                        Game[i, j].Image = Properties.Resources._128;
                        
                    }
                    if (Game[i, j].Text == "256")
                    {
                        Game[i, j].Image=Properties.Resources._256;
                        
                    }
                    if (Game[i, j].Text == "512")
                    {
                        Game[i, j].Image = Properties.Resources._5e309116173271_562a65a9d1854;
                       
                    }
                    if (Game[i, j].Text == "1024")
                    {
                        Game[i, j].Image = Properties.Resources._1024;
                      
                    }
                    if (Game[i, j].Text == "2048")
                    {
                        Game[i, j].Image = Properties.Resources._2048;
                       
                    }
                    
                }
            }
            
        }
        void gameover()
        {
            PictureBox[,] Game = {
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            if(volume==true)
            sound3.Play();
            Game[0, 0].Image = Properties.Resources.g;
            Game[0, 1].Image = Properties.Resources.a;
            Game[0, 2].Image = Properties.Resources.m;
            Game[0, 3].Image = Properties.Resources.e;
            Game[1, 0].Image = Properties.Resources.o;

            Game[1, 1].Image = Properties.Resources.v;
            Game[1, 2].Image = Properties.Resources.e;
            Game[1, 3].Image = Properties.Resources.r;
            for (int i = 2; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                   
                        Game[i, j].Image = Properties.Resources._nen;
                    
                }
            }
        }
        public void taoso()
            {
            array1.Clear();

            PictureBox[,] Game = {
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++)
                {
                    if(Game[i,j].Text==""){
                        array1.Add(i*4+j+1);
                    }
                }
            }
            
            if(array1.Count>0){
               
                int sayidoldur = int.Parse(array1[Rd.Next(0,array1.Count-1)].ToString());
                int i0 = (sayidoldur - 1) / 4;
                int j0 = (sayidoldur - 1) - i0 *4;
                int array2 = Rd.Next(1,10);
                if (array2 == 1 || array2 == 2 || array2 == 3 || array2 == 4 || array2 == 5||array2==6 )
                {
                    Game[i0, j0].Text = "2";
                }
                else { 
                    Game[i0,j0].Text="4";
                }

            }
            taoimage();
        } 
        public void DCUp()
        {
            //di chuyển lên
            bool ksup = true;
            bool compare = false;
            bool Danhso = false;
            PictureBox[,] Game = { 
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                int toplam = 0;
                for (int j = 0; j < 4;j++ )
                {
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[k,i].Text!=""){
                            if(Game[k,i].Text==Game[j,i].Text){
                                compare = true;
                            }
                            break;
                        }
                    }
                    if (Game[j, i].Text == "")
                    {
                        toplam++;// thu thập chúng nếu cúng số
                    }
                    else {
                        for (int m = j; m >= 0;m-- )
                        {
                            if(Game[m,i].Text==""){
                                Danhso = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool extrasayi = true;
                            
                            for (int k = j + 1; k < 4; k++)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                        ksup = false;
                                        
                                      
                                        Danhso = true;
                                        extrasayi = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if(toplam!=0){
                                            Game[j - toplam, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                       
                                        break;
                                        
                                    }
                                    break;
                                }
                            }
                            if(extrasayi==true && toplam!=0){
                                ksup = false;
                                Game[j - toplam, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else {
                            if(toplam!=0){
                                ksup = false;
                                Game[j - toplam, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        
                       
                    }
                }
            }
            new System.Threading.Thread(() =>
            {if (ksup==false && compare==true && volume == true)
            {
                sound.Play();
            }
            if (ksup == false && compare == false && volume == true)
            {
                sound2.Play();
            }

            }).Start();
            
            if(Danhso==true){
                taoso();
            }
            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            taoanh2048();
        }
        public void DCDown()
        {//di chuyển xuống
            bool ksdown = true;
            bool compare = false;
            bool Danhso = false;
            PictureBox[,] Game = { 
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int toplam = 0;
                for (int j = 3; j >=0; j--)
                {
                    for (int k = j - 1; k >= 0;k-- )
                    {
                        if(Game[k,i].Text!=""){
                            if(Game[k,i].Text==Game[j,i].Text){
                                compare = true;
                            }
                            break;
                        }
                    }
                    if (Game[j, i].Text == "")
                    {
                        toplam++;
                    }
                    else
                    {
                        for (int m = j+1; m <= 3; m++)
                        {
                            if (Game[m, i].Text == "")
                            {
                                Danhso = true;
                                break;
                            }
                        }
                        if (j-1>=0)
                        {
                            bool extrasayi = true;
                            
                            for (int k = j -1 ; k >= 0; k--)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                        ksdown = false;
                                        lbscore.Text = (int.Parse(lbscore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();
                                       
                                        Danhso = true;
                                        extrasayi = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if (toplam != 0)
                                        {
                                            Game[j + toplam, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extrasayi == true && toplam != 0)
                            {
                                ksdown = false;
                                Game[j + toplam, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (toplam != 0)
                            {
                                ksdown = false;
                                Game[j + toplam, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }


                    }
                }
            }
            new System.Threading.Thread(() =>
            {if (ksdown == false && compare == true && volume == true)
            {
                sound.Play();
            }
            if (ksdown == false && compare == false && volume == true)
            {
                sound2.Play();
            }

            }).Start();
            
            if (Danhso == true)
            {
                taoso();
            }
        }//
        public void DCleft()
        {
            bool ksleft=true;
            bool compare = false;
            bool Danhso = false;
            PictureBox[,] Game = { 
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int toplam = 0;
                for (int j =0; j <4; j++)
                {

                    for (int k = j + 1; k < 4;k++ )
                    {
                        if(Game[i,k].Text!=""){
                            if(Game[i,j].Text==Game[i,k].Text){
                                compare = true;
                            }
                            break;
                        }
                    }
                    if (Game[i,j].Text == "")
                    {
                        toplam++;
                    }
                    else
                    {
                        for (int m = j-1; m >= 0; m--)
                        {
                            if (Game[i, m].Text == "")
                            {
                                Danhso = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool extrasayi = true;
                            
                            for (int k = j + 1; k <4; k++)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        ksleft = false;
                                        lbscore.Text = (int.Parse(lbscore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();
                                       
                                        Danhso = true;
                                        extrasayi = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (toplam != 0)
                                        {
                                            Game[i,j - toplam].Text = Game[i,j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extrasayi == true && toplam != 0)
                            {
                                ksleft = false;
                                Game[i,j - toplam].Text = Game[i,j].Text;
                                Game[i,j].Text = "";
                               
                            }
                        }
                        else
                        {
                            if (toplam != 0)
                            {
                                ksleft = false;
                                Game[i,j - toplam].Text = Game[i, j].Text;
                                Game[i,j].Text = "";
                                
                            }
                        }


                    }
                }
            }
            new System.Threading.Thread(() =>
            { if (ksleft == false && compare == true && volume == true)
            {
                sound.Play();
            }
            if (ksleft == false && compare == false && volume == true)
            {
                sound2.Play();
            }

            }).Start();
           
            if (Danhso == true)
            {
                taoso();
            }
        }
        public void DCright()
        { //điều khiển sang phải.
            bool ksright = true;
            bool compare=false;
            bool Danhso = false;
            PictureBox[,] Game = { 
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int toplam = 0;
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0;k-- )
                    {
                        if(Game[i,k].Text!=""){
                            if(Game[i,k].Text==Game[i,j].Text){
                                compare = true;
                            }
                            break;
                        }
                    }
                    if (Game[i,j].Text == "")
                    {
                        toplam++;
                    }
                    else
                    {
                        for (int m = j + 1; m < 4; m++)
                        {
                            if (Game[i,m].Text == "")
                            {
                                Danhso = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool extrasayi = true;
                            
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)//nếu bằng nhau thì sẽ gộp

                                    {
                                        ksright = false;
                                       lbscore.Text = (int.Parse(lbscore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();
                                       
                                        Danhso = true;
                                        extrasayi = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (toplam != 0)
                                        {
                                            Game[i, j+toplam].Text = Game[ i,j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extrasayi == true && toplam != 0)
                            {
                                ksright = false;
                                Game[i,j+ toplam].Text = Game[i,j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (toplam != 0)
                            {
                                ksright = false;
                                Game[ i,j + toplam].Text = Game[ i,j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                    }
                }
            }
            new System.Threading.Thread(() =>
            {  if (ksright == false && compare == true&&volume==true)
            {
                sound.Play();
            }
            if (ksright == false && compare == false && volume == true)
            {
                sound2.Play();
            }

            }).Start();
          
            if (Danhso == true)
            {
                taoso();
            }
        }
        public bool Vietso() {
            PictureBox[,] Game = { 
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    if(Game[i,j].Text==""){
                        return false;
                    }
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[i,j].Text!=""){
                            if(Game[i,j].Text==Game[i,k].Text){
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game[j, i].Text == "")
                    {
                        return false;
                    }
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (Game[k,i].Text != "")
                        {
                            if (Game[j,i].Text == Game[k,i].Text)
                            {
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Vietso() == false)//giá trị tạo số mới 0 phải quay lại để sử dụng các phím
                
            {
                if (e.KeyCode == Keys.Up|| e.KeyCode == Keys.Packet)
                {
                    DCUp();//hoạt động gom nhóm lên khi  nhấn

                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    DCDown();//gom nhóm xuống
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    DCleft();//gom nhóm trái
                }
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    DCright();//gom nhóm phải
                }
               

            }
            else {

                laplai = false;
                gameover();
                button1.Text = "NewGame";
                button1.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
           
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        { //chức năng này được sử dụng để khởi động lại sau khi trò chơi kết thúc
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            lbscore.Text = "0";//điểm bằng 0

            PictureBox[,] Game = {  //đưa 16 picturebox vao mang
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
           
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    Game[i, j].Text = "";
                }
            }
            taoso();
            taoso();
            taoso();//tạo 3 số
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();//thoát
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
           

            if(laplai==false){
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
            laplai = true;
            
            PictureBox[,] Game = { 
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
           
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Game[i, j].Visible = true;
                    Game[i, j].Text = "";
                }
            }
            taoso();
            taoso();
            taoso();//
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            if (label2.Left <= -1800)
                label2.Left+=2540;
            else label2.Left -= 1;

            ;
            
           
        }

        private void ptbkeyup_Click(object sender, EventArgs e)
        {if(Vietso()==false)
            DCUp();
            else
            {

                laplai = false;
                gameover();
                button1.Text = "NewGame";
                button1.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
        }

        private void ptbkeydown_Click(object sender, EventArgs e)
        {
            if (Vietso()==false)
            DCDown();
            else
            {

                laplai = false;
                gameover();
                button1.Text = "NewGame";
                button1.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
        }

        private void ptbkeyleft_Click(object sender, EventArgs e)
        {if(Vietso()==false)
            DCleft();
            else
            {

                laplai = false;
                gameover();
                button1.Text = "NewGame";
                button1.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
        }

        private void ptbkeyright_Click(object sender, EventArgs e)
        {if(Vietso()==false)
            DCright();
            else
            {

                laplai = false;
                gameover();
                button1.Text = "NewGame";
                button1.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
        }
        void taoanh2048()
        {
            PictureBox[,] Game = {
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
            Game[0, 0].Image = Properties.Resources._20481;
            Game[0, 1].Image = Properties.Resources._20482;
            Game[0, 2].Image = Properties.Resources._20483_;
            Game[0, 3].Image = Properties.Resources._20484_;
            Game[1, 0].Image = Properties.Resources._20485_;

            Game[1, 1].Image = Properties.Resources._20486_;
            Game[1, 2].Image = Properties.Resources._2048__7;
            Game[1, 3].Image = Properties.Resources._2048_8;

            Game[2, 0].Image = Properties.Resources._2048_9;

            Game[2, 1].Image = Properties.Resources._204810;
            Game[2, 2].Image = Properties.Resources._204811;
            Game[2, 3].Image = Properties.Resources._204812;

            Game[3, 3].Image = Properties.Resources._20481;
            Game[3, 2].Image = Properties.Resources._20482;
            Game[3, 1].Image = Properties.Resources._20483_;
            Game[3, 0].Image = Properties.Resources._20484_;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            taoso(); taoso(); taoso();

        }
        int dem = 0;bool volume = true;
        private void pictureBox1_Click(object sender, EventArgs e)//cập nhật image volume
        { dem++;
            if (dem % 2 == 0)
            {
                ptbvolume.Image = Properties.Resources.volume; volume = true;
            }
            else
            {
                ptbvolume.Image = Properties.Resources.mutevolume; volume = false;
            }
        }
        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        { count++;button1.Enabled = false;
            if (count == 1)
            { taoso(); taoso(); taoso(); }
            else
            {
                //chức năng này được sử dụng để khởi động lại sau khi trò chơi kết thúc
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
                lbscore.Text = "0";//điểm bằng 0

                PictureBox[,] Game = {  //đưa 16 picturebox vao mang
                                {ptb1,ptb2,ptb3,ptb4},
                                {ptb5,ptb6,ptb7,ptb8},
                                {ptb9,ptb10,ptb11,ptb12},
                                {ptb13,ptb14,ptb15,ptb16}
                              };
                laplai = true;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Game[i, j].Text = "";
                    }
                }
                taoso();
                taoso();
                taoso();//tạo 3 số
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
