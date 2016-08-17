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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mainpage mp = new Mainpage();
            mp.Show();
            this.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            op_functions op = new op_functions();

            bool check = op.validate(textBox1.Text,textBox2.Text,textBox6.Text,textBox7.Text,textBox8.Text,textBox3.Text,textBox4.Text);
            
            if (check == true)
            {
                DBOperation db = new DBOperation();
                db.dbs();

                int num = op.rand_num();
                string qry = "insert into customer(cust_name,cust_cont,address1,address2,address3,pincode,city,cust_code,house) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + num + "','" + textBox8.Text + "')";
                SqlCommand cmd = new SqlCommand(qry, db.con);
                int res = cmd.ExecuteNonQuery();
                if (res >= 1)
                {
                    MessageBox.Show("Record has been inserted successfully...");
                    MessageBox.Show("Your ID : " + num);
                }
                else
                {
                    MessageBox.Show("Record has not been inserted successfully...");
                }
                db.dbs_close();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            cust_update mp = new cust_update();
            mp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_customer v = new view_customer();
            v.Show();
            this.Hide();
        }

       
    }
}
