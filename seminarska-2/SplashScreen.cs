using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using seminarska_2.Properties;

namespace seminarska_2
{
    public partial class SplashScreen : Form
    {
        Timer t;
        
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            t = new Timer();
            t.Interval = 2000;
            t.Start();
            t.Tick += new EventHandler(t_tick);
        }

        private void t_tick(object sender, EventArgs e)
        {
            t.Stop();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }        
    }
}
