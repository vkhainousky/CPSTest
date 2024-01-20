using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPStest
{
    public partial class Form1 : Form
    {
        public bool started = false;
        public int clicks = 0;
        public int clicksr = 0;
        public float timerval = 0f;
        public float cps = 0f;
        public float timervalr = 0f;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (started)
            {
                clicks += 1;
                clicksr += 1;
                label4.Text = "Clicks total: " + clicks;
            } else
            {
                timer1.Start();
                started = true;
                clicks = 0;
                clicksr = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerval += 0.1f;
            timervalr += 0.1f;
            label2.Text = "Time elapsed: " + timerval.ToString();
            if (timerval > Int32.Parse(comboBox1.Text))
            {
                timer1.Stop();
                timerval = 0f;
                timervalr = 0f;
                clicks = 0;
                clicksr = 0;
                started = false;
                MessageBox.Show("Your total CPS is: " + cps, "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            if (timervalr > 1f)
            {
                label1.Text = "CPS: " + clicksr;
                cps = clicksr;
                clicksr = 0;
                
                timervalr = 0f;
            }
        }
    }
}
