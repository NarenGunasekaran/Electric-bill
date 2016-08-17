using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Myproject
{
    public partial class bill : Form
    {
        public bill()
        {
            InitializeComponent();
            label2.Text= Mainpage.sendText1;
            label4.Text = Mainpage.sendText6;
            label6.Text = Mainpage.sendText2;
            label8.Text = Mainpage.sendText3;
            label10.Text = Mainpage.sendText4;
            label12.Text = Mainpage.sendText5;
            DateTime d=DateTime.Now;
            label14.Text = d.ToString();
        }

        private void bill_Load(object sender, EventArgs e)
        {
            
        }
    }
}
