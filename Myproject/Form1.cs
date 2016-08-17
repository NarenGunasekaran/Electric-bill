using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Myproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "Naren") && (textBox2.Text != "naren"))
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
                System.Windows.Forms.MessageBox.Show("User name or password is an incorrect!!!!");
            }
            else
            {
                Mainpage mp = new Mainpage();
                mp.Show();
                this.Hide();
            }
        }
    }
}
