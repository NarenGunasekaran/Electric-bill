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
    public partial class view_customer : Form
    {
        public view_customer()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void view_customer_Load(object sender, EventArgs e)
        {
            DBOperation db = new DBOperation();
            db.dbs();
            String query = "Select * from customer";
            SqlDataAdapter adp = new SqlDataAdapter(query, db.con);
            waterbillDataSet1.Clear();
            adp.Fill(waterbillDataSet1, "customer");
            dataGridView1.DataSource = waterbillDataSet1;
            dataGridView1.DataMember = "customer";
            db.dbs_close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBOperation db = new DBOperation();
            db.dbs();
            int row = dataGridView1.CurrentRow.Index;
            int cno = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            string query = "DELETE FROM customer WHERE id='" + cno + "'";

            SqlCommand cmd = new SqlCommand(query, db.con);
            int res = cmd.ExecuteNonQuery();
            if (res >= 1)
            {

                MessageBox.Show("Customer information deleted sucessfuly !!!");
                String quer = "Select * from customer";
                SqlDataAdapter adp = new SqlDataAdapter(quer, db.con);
                waterbillDataSet1.Clear();
                adp.Fill(waterbillDataSet1, "customer");
                dataGridView1.DataSource = waterbillDataSet1;
                dataGridView1.DataMember = "customer";
            }
            else
            {
                MessageBox.Show("Deletion failed");
            }
            db.dbs_close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
