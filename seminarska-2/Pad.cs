using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using seminarska_2.Properties;

namespace seminarska_2
{
    public class Pad
    {
        public int x, y, sirina, visina;        
        public Rectangle PadRec;

        public Pad()
        {
            x = 160;
            y = 330;
            visina = 30;
            sirina = 70;
            PadRec = new Rectangle(x, y, sirina, visina);
        }

        public void DrawDrop(Graphics g)
        {
            Bitmap bmp = new Bitmap(Resources.kosnicka1);
            g.DrawImage(bmp, PadRec);
        }
        public void DrawCandy(Graphics g)
        {
            Bitmap bmp = new Bitmap(Resources.pad3);
            g.DrawImage(bmp, PadRec);
        }
        public void DrawFruit(Graphics g)
        {
            Bitmap bmp = new Bitmap(Resources.pad2);
            g.DrawImage(bmp, PadRec);
        }
    }
}
