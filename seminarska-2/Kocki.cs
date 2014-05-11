using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using seminarska_2.Properties;

namespace seminarska_2
{
    public class Kocki
    {
        public int y { get; set; }
        private int x, sirina, visina;
        public Rectangle[] KockiRec;
        Image[] sliki = new Image[4];
        Bitmap bmp;
        public int brSliki = 0;


        public Rectangle[] kockiRec
        {
            get { return KockiRec; }
        }

        public Kocki(Random randomKocki)
        {
            
                KockiRec = new Rectangle[50];
                y = -20;
                visina = sirina = 30;
                for (int i = 0; i < KockiRec.Length; i++)
                {
                    x = randomKocki.Next(10, 360);
                    KockiRec[i] = new Rectangle(x, y, sirina, visina);
                    y -= 100;
                }
            
        }

        public void DrawFruit(Graphics g)
        {
            sliki[0] = new Bitmap(Resources.Apple);
            sliki[1] = new Bitmap(Resources.banana);
            sliki[2] = new Bitmap(Resources.orange);
            sliki[3] = new Bitmap(Resources.strawberry);
                 for (int i = 0; i < KockiRec.Length; i+=4)
                 {                     
                     g.DrawImage(sliki[0], KockiRec[i]);

                 }
                 for (int j = 1; j < KockiRec.Length; j += 4)
                 {
                     g.DrawImage(sliki[1], KockiRec[j]);

                 }
                 for (int m = 2; m < KockiRec.Length; m += 4)
                 {
                     g.DrawImage(sliki[2], KockiRec[m]);

                 }
                 for (int n = 3; n < KockiRec.Length; n += 4)
                 {
                     g.DrawImage(sliki[3], KockiRec[n]);

                 } 
        }
        public void DrawDrop(Graphics g)
        {
            bmp = new Bitmap(Resources.Drop1);

            for (int i = 0; i < KockiRec.Length; i++)
            {
                g.DrawImage(bmp, KockiRec[i]);

            }          
        }

        public void DrawCandy(Graphics g)
        {
            sliki[0] = new Bitmap(Resources.candy1);
            sliki[1] = new Bitmap(Resources.candy2);
            sliki[2] = new Bitmap(Resources.candy3);
            sliki[3] = new Bitmap(Resources.candy4);
            for (int i = 0; i < KockiRec.Length; i += 4)
            {
                g.DrawImage(sliki[0], KockiRec[i]);

            }
            for (int j = 1; j < KockiRec.Length; j += 4)
            {
                g.DrawImage(sliki[1], KockiRec[j]);

            }
            for (int m = 2; m < KockiRec.Length; m += 4)
            {
                g.DrawImage(sliki[2], KockiRec[m]);

            }
            for (int n = 3; n < KockiRec.Length; n += 4)
            {
                g.DrawImage(sliki[3], KockiRec[n]);

            }
        }

        public void moveDownlvl1()
        {
            Form1 forma1 = new Form1();
            for (int i = 0; i < KockiRec.Length; i++)
            {
                KockiRec[i].Y += 1;
            }
        }

        public void moveDownlvl2()
        {
            Form1 forma1 = new Form1();
            for (int i = 0; i < KockiRec.Length; i++)
            {
                KockiRec[i].Y += 2;
            }
        }

        public void moveDownlvl3()
        {
            Form1 forma1 = new Form1();
            for (int i = 0; i < KockiRec.Length; i++)
            {
                KockiRec[i].Y += 3;
            }
        }

        public void moveDownlvl4()
        {
            Form1 forma1 = new Form1();
            for (int i = 0; i < KockiRec.Length; i++)
            {
                KockiRec[i].Y += 4;
            }
        }

        public void moveDownlvl5()
        {
            Form1 forma1 = new Form1();
            for (int i = 0; i < KockiRec.Length; i++)
            {
                KockiRec[i].Y += 5;
            }
        }


    }
}
