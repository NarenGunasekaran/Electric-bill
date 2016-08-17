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
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mainpage m = new Mainpage();
            m.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                int cid = 0;
                if (int.TryParse(textBox1.Text, out cid) == true)
                {
                    DBOperation db = new DBOperation();
                    db.dbs();
                    String query = "Select * from bill where code='" + textBox1.Text + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(query, db.con);
                    waterbillDataSet1.Clear();
                    adp.Fill(waterbillDataSet1, "customer");
                    dataGridView1.DataSource = waterbillDataSet1;
                    dataGridView1.DataMember = "customer";
                    db.dbs_close();
                }
                else
                {
                    MessageBox.Show("Id should be an numeric value !!!");
                }
            }
            else
            {
                MessageBox.Show("Please input customer Id !!!");
            }
        }
    }
}
