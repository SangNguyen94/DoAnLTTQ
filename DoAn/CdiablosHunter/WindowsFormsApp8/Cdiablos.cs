using System;
using WindowsFormsApp8.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    class Cdiablos:CImageBase
    {
        private Rectangle HotSpot = new Rectangle(); 
        public Cdiablos()
            :base(Resources.diablos1)
        {
            HotSpot.X = left + 30;
            HotSpot.Y = top - 1;
            HotSpot.Width = 173;
            HotSpot.Height = 250;
        }
        public void Update(int X, int Y)
        {
            left = X;
            top = Y;
            HotSpot.X = left+20;
            HotSpot.Y = top - 1;
        }
        public bool Hit(int x,int y)
        {
            Rectangle C = new Rectangle(x, y, 1, 1);
            if(HotSpot.Contains(C))
            {
                return true;
            }
            return false;
        }
    }
}
