using seminarska_2.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace seminarska_2
{
    public class Pozadina
    {
        public int x, y, sirina, visina;   
        public Rectangle pozadinaRec;

        public Pozadina()
        {
            x =0;
            y =0;
            visina = 400;
            sirina = 400;
            pozadinaRec = new Rectangle(x, y, visina, sirina);
        }
        public void DrawWallpaperDrop(Graphics g)
        {
            Bitmap pozadina = new Bitmap(Resources.pozadina1);
            g.DrawImage(pozadina, pozadinaRec);
        }
        
        public void DrawWallpaperFruit(Graphics g)
        {
            Bitmap pozadina = new Bitmap(Resources.pozadina2);
            g.DrawImage(pozadina, pozadinaRec);
        }

        public void DrawWallpaperCandy(Graphics g)
        {
            Bitmap pozadina = new Bitmap(Resources.pozadina3);
            g.DrawImage(pozadina, pozadinaRec);
        }

    }
}
