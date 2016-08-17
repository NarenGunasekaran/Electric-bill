using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Myproject
{
    class DBOperation
    {
        public SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Naren\\documents\\visual studio 2010\\Projects\\Myproject\\Myproject\\waterbill.mdf\";Integrated Security=True;User Instance=True");

         public void dbs()
        {
            con.Open();
        }

         public void dbs_close()
         {
             con.Close();
         }

         public bool Delete(int cno)
         {
             try
             {
                 
                 string query = "DELETE FROM customer WHERE id='"+cno+"'";
                 
                    SqlCommand cmd = new SqlCommand(query, con);
                     int res = cmd.ExecuteNonQuery();
                     if (res >= 1)
                         return true;
                     else
                         return false;
                 }
                
             
             catch { return false; }
             finally
             {
                 this.dbs_close();
             }
         }
    }
}
