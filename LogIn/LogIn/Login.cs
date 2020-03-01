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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection();
        public Login()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-KJ3BAKB\SQLEXPRESS;Initial Catalog=DEMO;Integrated Security=True";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-KJ3BAKB\SQLEXPRESS;Initial Catalog=DEMO;Integrated Security=True";
            con.Open();

            string pass = Hashing.execution(getPassword.Text.ToString()).ToString();
            SqlCommand cmd = new SqlCommand("select username,password, type from  Stuff where username='"+ getUserName.Text.ToString() + "' and password = '"+ pass +"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string type = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    type = dr.GetString(2);
                }
                MessageBox.Show("Login Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (type.Equals("administrator"))
                {
                    Addministrator ad = new Addministrator();
                    ad.Show();
                    Visible = false;
                }
                else if (type.Equals("stuff"))
                {
                    Stuff s = new Stuff();
                    s.Show();
                    Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
            
            dr.Close();
            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Visible = false;
        }
    }
}
