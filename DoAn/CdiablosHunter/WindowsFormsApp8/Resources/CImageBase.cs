using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    class CImageBase:IDisposable
    {
        bool disposed = false;
        Bitmap bitmap;
        private int X;
        private int Y;
        public int left { get { return X; } set { X = value; } }
        public int top { get { return Y; } set { Y = value; } }
        public CImageBase(Bitmap _resource)
        {
            bitmap = new Bitmap(_resource);
        }
        public void DrawImage(Graphics gfx)
        {
            gfx.DrawImage(bitmap, X, Y);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void  Dispose(bool disposing)
        {
            if (disposed)
                return;
            if(disposing)
            {
                bitmap.Dispose();
            }
            disposed=true;
        }
    }
}
