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
    public partial class Mainpage : Form
    {
        public Mainpage()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
                Customer mp = new Customer();
                mp.Show();
                this.Hide();
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DBOperation db = new DBOperation();
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                int cid = 0;
                if (int.TryParse(textBox1.Text, out cid) == true)
                {
                    db.dbs();
                    String qry = "select * from customer where cust_code='" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(qry,db.con);
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
                        textBox11.Text = reader[9].ToString();
                    }
                    else
                    {
                        MessageBox.Show("OOPS !!! Invalid Id !!!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                    }
                    db.dbs_close();
                    if (int.TryParse(textBox1.Text, out cid) == true)
                    {
                        db.dbs();
                        String query = "select * from bill where code='" + textBox1.Text + "'";
                        SqlCommand cmd1 = new SqlCommand(query, db.con);
                        SqlDataReader rea;
                        rea = cmd1.ExecuteReader();
                        while (rea.Read())
                        {
                            textBox10.Text = rea[7].ToString();
                            
                        }
                        
                        db.dbs_close();
                    }
                    
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    MessageBox.Show("Case No should be numeric!!!!!");
                }
            }
            else
            {
                MessageBox.Show("Please insert the customer number ! ! !");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox1.Focus();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                int cur = 0;
                int prev = 0;
                if (!string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    prev = int.Parse(textBox10.Text);
                }
                else
                {
                   prev = 0;
                }
                int val = 0;
                int tot = 0;
                int pen = 0;
                int sum = 0;
                int mtr = int.Parse(textBox11.Text);

                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (!string.IsNullOrWhiteSpace(textBox9.Text))
                    {
                        int cid = 0;
                        if (int.TryParse(textBox9.Text, out cid) == true)
                        {
                            
                                
                                string Ld="";
                                
                                    cur = int.Parse(textBox9.Text);
                                    if (textBox10.Text == "")
                                    {
                                        prev = 0;
                                    }
                                    else
                                    {
                                        prev = int.Parse(textBox10.Text);
                                    }
                                    DateTime ef;
                                    TimeSpan ts;
                                    DBOperation db = new DBOperation();
                                    db.dbs();
                                   
                                    String qry1 = "select code,MAX(date) AS mx from bill where code='" + textBox1.Text + "' group by code";
                                    SqlCommand cmds = new SqlCommand(qry1, db.con);
                                    SqlDataReader reader;
                                    reader = cmds.ExecuteReader();
                                    if (reader.Read())
                                    {
                                        Ld = reader[1].ToString();
                                         ef = Convert.ToDateTime(Ld);
                                         DateTime d = DateTime.Now;

                                          ts = d - ef;
                                    }
                                    else
                                    {
                                        DateTime d = DateTime.Now;
                                        ef = DateTime.Now;
                                        ts = d - ef;
                                    }
                                    
                                   
                                    var numofdays = Math.Round(ts.TotalDays);
                                  
                                   

                                    if (cur > prev)
                                    {
                                        val = cur - prev;
                                        if (mtr <= 200)
                                        {
                                            if(val <= 6000)
                                            {
                                                tot = 40;
                                            }
                                            else if(val >6000 & val <= 10000)
                                            {
                                                tot = 52;
                                            }
                                            else if(val > 10000 & val <= 20000)
                                            {
                                                tot = 82;
                                            }
                                            else if (val > 20000 & val <= 21000)
                                            {
                                                tot = 93;
                                            }
                                            else if(val > 21000 & val <= 31000)
                                            {
                                                tot = 202;
                                            }
                                            else if (val > 31000)
                                            {
                                                tot = 352;
                                            }
                                        }
                                        else if(mtr > 200)
                                        {
                                            if (val <= 6000)
                                            {
                                                tot = 120;
                                            }
                                            else if (val > 6000 & val <= 10000)
                                            {
                                                tot = 132;
                                            }
                                            else if (val > 10000 & val <= 20000)
                                            {
                                                tot = 162;
                                            }
                                            else if (val > 20000 & val <= 21000)
                                            {
                                                tot = 173;
                                            }
                                            else if (val > 21000 & val <= 31000)
                                            {
                                                tot = 282;
                                            }
                                            else if (val > 31000)
                                            {
                                                tot = 400;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Current reading should be greater than previous reading !!!");
                                    }

                                    if (numofdays > 60)
                                    {
                                        pen = 40;
                                        sum = tot + pen;
                                    }
                                    else
                                    {
                                        pen = 0;
                                        sum = tot + pen;
                                    }
                                    
                                    textBox12.Text = tot.ToString();
                                    textBox13.Text = pen.ToString();
                                    textBox14.Text = sum.ToString();
                                    textBox15.Text = val.ToString();
                               
                            
                           
                        }
                        else
                        {
                            MessageBox.Show("It should a numeric value !!!");
                            textBox9.Text = "";
                            textBox9.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Field should not be empty!!!");
                        textBox9.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("It seems like this Id is invalid !!! Insert a valid id");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Hey !!! You forgot to input customer Id");
                textBox1.Focus();
            }
        }
        public static string sendText1 = "";
        public static string sendText2 = "";
        public static string sendText3 = "";
        public static string sendText4 = "";
        public static string sendText5 = "";
        public static string sendText6 = "";

        private void button2_Click(object sender, EventArgs e)
        {
            
                DBOperation db = new DBOperation();
                
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    if (!string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(textBox9.Text))
                        {
                            int cid = 0;
                            if (int.TryParse(textBox9.Text, out cid) == true)
                            {
                                
                                        if (!string.IsNullOrWhiteSpace(textBox12.Text) & !string.IsNullOrWhiteSpace(textBox13.Text) & !string.IsNullOrWhiteSpace(textBox14.Text) & !string.IsNullOrWhiteSpace(textBox15.Text))
                                        {
                                            db.dbs();
                                            DateTime nw = DateTime.Now;
                                            string qry = "insert into bill(date,reading,penalty,amount,total,code,prev_reading) values('" + nw.ToString() + "','" + textBox15.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','" + textBox14.Text + "','" + textBox1.Text + "','"+textBox9.Text+"')";
                                            SqlCommand cmd = new SqlCommand(qry, db.con);
                                            int res = cmd.ExecuteNonQuery();
                                            if (res >= 1)
                                            {
                                                sendText1 = textBox1.Text;
                                                sendText2 = textBox15.Text;
                                                sendText3 = textBox12.Text;
                                                sendText4 = textBox13.Text;
                                                sendText5 = textBox14.Text;
                                                sendText6 = textBox2.Text;
                                                bill b = new bill();
                                                b.Show();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Record has not been inserted successfully...");
                                            }
                                            db.dbs_close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please generate the bill amount before adding !!!");
                                        }
                                   
                            }
                            else
                            {
                                MessageBox.Show("It should a numeric value !!!");
                                textBox9.Text = "";
                                textBox9.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show(" Field should not be empty!!!");
                            textBox9.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("It seems like this Id is invalid !!! Insert a valid id");
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Hey !!! You forgot to input customer Id");
                    textBox1.Focus();
                }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reports r = new reports();
            r.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mainpage_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
