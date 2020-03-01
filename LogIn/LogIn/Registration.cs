using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LogIn
{
    public partial class Registration : Form
    {
        SqlConnection con = new SqlConnection();
        public Registration()
        {
   
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-KJ3BAKB\SQLEXPRESS;Initial Catalog=DEMO;Integrated Security=True";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-KJ3BAKB\SQLEXPRESS;Initial Catalog=DEMO;Integrated Security=True";
            con.Open();


            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("insert into Stuff (username, password, type) values (@u, @p, @t)", con);
                cmd.Parameters.Add("@u", getUserName.Text.ToString());
                string pass = Hashing.execution(getPassword.Text.ToString()).ToString();
                cmd.Parameters.Add("@p", pass);
                
                if (radioButton1.Checked)
                {
                    cmd.Parameters.Add("@t", "administrator");
                }
                else if (radioButton2.Checked)
                {
                    cmd.Parameters.Add("@t", "stuff");
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully");
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
            
            
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Visible = false;
        }
    }
}
