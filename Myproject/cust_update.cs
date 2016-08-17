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
    public partial class cust_update : Form
    {
        public cust_update()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Customer mp = new Customer();
            mp.Show();
            this.Hide();
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

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                String code = textBox1.Text.ToString();
                DBOperation db = new DBOperation();
                db.dbs();
                string query = "DELETE FROM customer WHERE cust_code='" + code + "'";

                SqlCommand cmd = new SqlCommand(query, db.con);
                int res = cmd.ExecuteNonQuery();
                if (res >= 1)
                {

                    MessageBox.Show("Customer information deleted sucessfuly !!!");
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    
                }
                else
                {
                    MessageBox.Show("Deletion failed");
                }
                db.dbs_close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DBOperation db = new DBOperation();
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                int cid = 0;
                if (int.TryParse(textBox1.Text, out cid) == true)
                {
                    db.dbs();
                    String qry = "select * from customer where cust_code='" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(qry, db.con);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox2.Text = reader[1].ToString();
                        textBox3.Text = reader[2].ToString();
                        textBox4.Text = reader[3].ToString();
                        textBox5.Text = reader[4].ToString();
                        textBox6.Text = reader[5].ToString();
                        textBox7.Text = reader[6].ToString();
                        textBox8.Text = reader[7].ToString();
                        textBox9.Text = reader[9].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Customer information found !!!");
                    }
                    db.dbs_close();
                }
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("Case No should be numeric!!!!!");
                }
            }
            else
            {
                MessageBox.Show("Please insert the customer number ! ! !");
                textBox1.Text = "";
                textBox1.Focus();
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                String code = textBox1.Text.ToString();
                DBOperation db = new DBOperation();
                db.dbs();
                String qry = "update customer set cust_name='" + textBox2.Text + "',cust_cont='" + textBox3.Text + "',address1='" + textBox4.Text + "',address2='" + textBox5.Text + "',address3='" + textBox6.Text + "',pincode='" + textBox7.Text + "',city='" + textBox8.Text + "',house='"+textBox9.Text+"' where cust_code='" + code + "'";
                SqlCommand cmd = new SqlCommand(qry, db.con);
                int res = cmd.ExecuteNonQuery();
                if (res >= 1)
                {
                    MessageBox.Show("updated sucessfully");
                }
                else
                {
                    MessageBox.Show("Ooops !!! Not updated!!");
                }
                String qry1 = "select * from customer where cust_code='" + code + "'";
                SqlCommand cmds = new SqlCommand(qry1, db.con);
                SqlDataReader reader;
                reader = cmds.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                    textBox4.Text = reader[3].ToString();
                    textBox5.Text = reader[4].ToString();
                    textBox6.Text = reader[5].ToString();
                    textBox7.Text = reader[6].ToString();
                    textBox8.Text = reader[7].ToString();
                    textBox9.Text = reader[9].ToString();
                }
                db.dbs_close();
            }
            else
            {
                MessageBox.Show("Field should not be empty");
            }
        }

       
    }
}
