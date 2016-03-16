using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inserttemp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = textBox1.Text;
            string path = textBox2.Text;
            string[] datas = System.IO.Directory.GetFiles(path);

            // list name
            List<string> list = new List<string>();
            foreach (var item in datas)
            {
                list.Add(item.Replace(path + "\\", ""));
            }

            int count =0 ;
            foreach (var item in list)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string connStr = @"insert into Temp1 (id) values(@id)";
                    SqlCommand cmd = new SqlCommand(connStr, conn);
                    SqlParameter pa = new SqlParameter("@id", SqlDbType.NVarChar) { Value = item };
                    cmd.Parameters.Add(pa);

                    conn.Open();
                    count += cmd.ExecuteNonQuery();

                    label3.Text = count.ToString();
                    Application.DoEvents();
                }
            }
            
           
        }
    }
}
