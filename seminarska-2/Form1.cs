using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using seminarska_2.Properties;

namespace seminarska_2
{
    public partial class Form1 : Form
    {
        Random randomKocki = new Random();
        Pozadina p = new Pozadina();
        Pad pad = new Pad();
        SoundPlayer player;
        Kocki kocki;
        Graphics g;

        public int brojac { get; set; }
        public string ime { get; set; }

        bool drop = true;
        bool fruit, candy = false;
        bool pause = true;
        bool lvl1, lvl2, lvl3, lvl4, lvl5 = false;
        bool sound;

        public Form1()
        {
            InitializeComponent();
            kocki = new Kocki(randomKocki);
            brojac = 0;
            lblPause.Visible = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            lvl1 = true;
            sound = true;
            player = new SoundPlayer(Resources.kapka1);
            soundToolStripMenuItem.Checked = true;
            dropToolStripMenuItem.Checked = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PoeniForma poeniforma = new PoeniForma();
            Dvizenje();
            for (int i = 0; i < kocki.KockiRec.Length; i++)
            {
                if (kocki.KockiRec[i].IntersectsWith(pad.PadRec))
                {
                    if (sound == true)
                        player.Play();
                    brojac++;
                    kocki.KockiRec[i].Y = 500;
                    label2.Text = Convert.ToString(brojac);
                }

                if (kocki.KockiRec[i].Y > 330 && kocki.KockiRec[i].Y < 370)
                {
                    timer1.Stop();
                    timer2.Stop();
                    lvl1 = true;
                    lvl2 = lvl3 = lvl4 = lvl5 = false;
                    if (MessageBox.Show("Do you want to save the points?", "Save points?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        poeniforma.poeni = brojac;
                        poeniforma.ShowDialog();
                        ime = poeniforma.ime;
                    }
                    kocki = new Kocki(randomKocki);
                }

                if (brojac == kocki.KockiRec.Length)
                {
                    timer1.Stop();
                    if (MessageBox.Show("Do you want to save the points?", "Save points?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        poeniforma.poeni = brojac;
                        poeniforma.ShowDialog();
                        ime = poeniforma.ime;
                    }
                }
            }
            this.Invalidate();
        }

        public void Dvizenje()
        {
            if (lvl1 == true)
            {
                kocki.moveDownlvl1();
            }
            if (lvl2 == true)
            {
                kocki.moveDownlvl2();
            }
            if (lvl3 == true)
            {
                kocki.moveDownlvl3();
            }
            if (lvl4 == true)
            {
                kocki.moveDownlvl4();
            }
            if (lvl5 == true)
            {
                kocki.moveDownlvl5();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            if (drop == true)
            {
                p.DrawWallpaperDrop(g);
                kocki.DrawDrop(g);
                pad.DrawDrop(g);

            }
            else if (fruit == true)
            {
                p.DrawWallpaperFruit(g);
                kocki.DrawFruit(g);
                pad.DrawFruit(g);
            }
            else if (candy == true)
            {
                p.DrawWallpaperCandy(g);
                kocki.DrawCandy(g);
                pad.DrawCandy(g);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled)
            {
                if (e.KeyData == Keys.Left)
                    if (pad.PadRec.X > 0)
                        pad.PadRec.X -= 20;
                if (pad.PadRec.X == 10)
                    pad.PadRec.X -= 10;
                if (e.KeyData == Keys.Right)
                    if (pad.PadRec.X < 300)
                        pad.PadRec.X += 20;
                if (pad.PadRec.X == 300)
                    pad.PadRec.X += 10;
            }
            else
                if (e.Control && e.KeyCode.ToString() == "N")
                {
                    Restart();
                }
            if (pause == true)
            {
                if (e.KeyData == Keys.P)
                {
                    if (timer2.Enabled == true)
                    {
                        timer1.Stop();
                        lblPause.Visible = true;
                        pause = false;
                    }
                }
            }
            else if (pause == false)
            {
                if (timer2.Enabled == true)
                {
                    if (e.KeyData == Keys.P)
                    {
                        timer1.Start();
                        lblPause.Visible = false;
                        pause = true;
                    }
                }
            }
            if (e.KeyData == Keys.Escape)
            {
                aboutUsToolStripMenuItem.Checked = false;
                HowToPlayToolStripMenuItem.Checked = false;
                txtHowToPlay.Visible = false;
            }
        }

        public void Restart()
        {
            kocki = new Kocki(randomKocki);
            brojac = 0;
            label2.Text = "0";
            timer1.Start();
            timer2.Start();
            lvl1 = true;
            HowToPlayToolStripMenuItem.Checked = false;
            helpToolStripMenuItem.Checked = false;
            txtHowToPlay.Visible = false;
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drop = true;
            fruit = false;
            candy = false;
            player = new SoundPlayer(Resources.kapka1);
            dropToolStripMenuItem.Checked = true;
            fruitToolStripMenuItem.Checked = false;
            candyToolStripMenuItem.Checked = false;
        }

        private void fruitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drop = false;
            fruit = true;
            candy = false;
            player = new SoundPlayer(Resources.applee);
            dropToolStripMenuItem.Checked = false;
            fruitToolStripMenuItem.Checked = true;
            candyToolStripMenuItem.Checked = false;
        }

        private void candyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drop = false;
            fruit = false;
            candy = true;
            player = new SoundPlayer(Resources.Candy);
            dropToolStripMenuItem.Checked = false;
            fruitToolStripMenuItem.Checked = false;
            candyToolStripMenuItem.Checked = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (File.Exists("highscore.txt"))
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader("highscore.txt");
                for (int i = 0; i < 5; i++)
                {
                    sb.Append(sr.ReadLine() + "\n");

                }
                MessageBox.Show(sb.ToString());
            }
            else
            {
                StreamWriter sw = new StreamWriter("highscore.txt");
                sw.WriteLine("Brown" + " -" + "5");
                sw.WriteLine("Brath" + " -" + "4");
                sw.WriteLine("Mate" + " -" + "3");
                sw.WriteLine("Axwel" + " -" + "2");
                sw.WriteLine("John" + " -" + "1");
                sw.Close();
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader("highscore.txt");
                for (int i = 0; i < 5; i++)
                {
                    sb.Append(sr.ReadLine() + "\n");

                }
                MessageBox.Show(sb.ToString());
            }
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HowToPlayToolStripMenuItem.Checked == true)
            {
                HowToPlayToolStripMenuItem.Checked = false;
            }
            aboutUsToolStripMenuItem.Checked = true;
            kocki = new Kocki(randomKocki);
            txtHowToPlay.Visible = true;
            timer1.Stop();
            timer2.Stop();
            txtHowToPlay.Text = "We hope you will enjoy playing our game. \n The developers of these aplications are:\n\n Bozijanov Hristijan\n Minova Gurgica \n Jovanovic Aleksandra \n \n E-mails for contacts: \n  hristijan_bozijanov@yahoo.com \n minova_bube@yahoo.com \n jovanovic_a@yahoo.com\n\n\nPress Escape to close this!";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lvl1 == true)
            {
                lblLevel.Text = "Level 1";
            }
            if (brojac == 10)
            {
                lvl1 = false;
                lvl2 = true;
                if (lvl2 == true)
                {
                    lblLevel.Text = "Level  2";
                }
            }
            else if (brojac == 20)
            {
                lvl2 = false;
                lvl3 = true;
                if (lvl3 == true)
                {
                    lblLevel.Text = "Level 3";
                }
            }
            else if (brojac == 30)
            {
                lvl3 = false;
                lvl4 = true;
                if (lvl4 == true)
                {
                    lblLevel.Text = "Level  4";
                }
            }
            else if (brojac == 40)
            {
                lvl4 = false;
                lvl5 = true;
                if (lvl5 == true)
                {
                    lblLevel.Text = "Level 5";
                }
            }
            if (brojac == kocki.kockiRec.Length)
            {
                lvl5 = false;
                timer1.Stop();
                timer2.Stop();
            }
        }

        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sound == true)
            {
                sound = false;
                soundToolStripMenuItem.Checked = false;
            }
            else
            {
                sound = true;
                soundToolStripMenuItem.Checked = true;
            }
        }

        private void HowToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutUsToolStripMenuItem.Checked == true)
            {
                aboutUsToolStripMenuItem.Checked = false;
            }
            HowToPlayToolStripMenuItem.Checked = true;
            kocki = new Kocki(randomKocki);
            txtHowToPlay.Visible = true;
            timer1.Stop();
            timer2.Stop();
            txtHowToPlay.Text = "For starter we have three menu options to choose: File,Skins and Help.\n To start a new game you either press ctrl+n, p or File->New Game.\n In the menu File there are also three more optons: High Score,Sound and Exit. If you want to close the game you should press exit,\n if you want to see who has the higher scores in the game you press high score and you get the top five high scores.\n If you want a sound effects you turn on the option Sound. \n You also have a posibility to pause the game by pressing the key p on the keyboard. \n In the second menu Skins ,you have the option to choose one of the three skins Drop,Fruit and Candy.\n And finaly in the last menu Help there are two possibilities: How to play(this text itself) and About us(info about the developers of this aplication)\n\n\nPress Escape to close this!";
        }
    }
}
