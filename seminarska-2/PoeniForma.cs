using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace seminarska_2
{
    public partial class PoeniForma : Form
    {
        Form1 forma1 = new Form1();
        public int poeni;
        public string ime { get; set; }
        


        public PoeniForma()
        {
            InitializeComponent();
           
        }

        private void btnVnesi_Click(object sender, EventArgs e)
        {
            ime = txtIme.Text; 

            if (File.Exists("highscore.txt"))
            {
                saveHighScores(); 
                this.Close();
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
                saveHighScores(); 
                this.Close();
            }
                 
            

        }

        private void PoeniForma_Load(object sender, EventArgs e)
        {          
            label2.Text = "Points: " + Convert.ToString(poeni);
        }

        
        public struct HighScoreData
        {
            public string PlayerName;
            public int Score;

            public HighScoreData(string PlayerName, int Score)
            {
                this.PlayerName = PlayerName;
                this.Score = Score;
            }

        }

        List<HighScoreData> highScores = new List<HighScoreData>();

        public void saveHighScores()
        {
            string line;
            int i = 0;

            StreamReader sr = new StreamReader("highscore.txt");
            while ((line = sr.ReadLine()) != null)
            {
                HighScoreData dataskornya = new HighScoreData();
                string[] parts = line.Split('-');
                dataskornya.PlayerName = parts[0].Trim();
                dataskornya.Score = Int32.Parse(parts[1].Trim());
                highScores.Add(dataskornya);
                i++;
            }
            sr.Close();

            HighScoreData dataskornya2 = new HighScoreData();
            dataskornya2.PlayerName = ime;
            dataskornya2.Score = poeni;
            highScores.Add(dataskornya2);

            highScores.Sort(CompareByPlayerScore);

            StreamWriter sw = new StreamWriter("highscore.txt");
            for (i = 0; i < 5; i++)
            {
                line = highScores[i].PlayerName + " - " + highScores[i].Score;
                String stringToSave = ime.Replace("_", " ");
                sw.WriteLine(line);
            }
            sw.Close();
        }

        private static int CompareByPlayerScore(HighScoreData x, HighScoreData y)
        {
            if (x.Equals(null))
            {
                if (y.Equals(null))
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y.Equals(null))
                {
                    return 1;
                }
                else
                {

                    int retval = y.Score.CompareTo(x.Score);

                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return y.Score.CompareTo(x.Score);
                    }
                }
            }


        }
    }
}
