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
using System.Text.RegularExpressions;
namespace N_Fit_Gym_Management_System
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Rizad\Desktop\prev\N-Fit Gym Management System\N-Fit Gym Management System\GymDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Registration_Load(object sender, EventArgs e)
        {
            pass.UseSystemPasswordChar = true;
            cpass.UseSystemPasswordChar = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dspsign.Text = "";
            fname.Text = "";
            uname.Text = "";
            gen.Text = "";
            pass.Text = "";
            cpass.Text = "";
            role.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dspsign.Text = "";
            if (fname.Text == null)
            {
                dspsign.Text = "Please enter your name";
                return;
            }
            else if (uname.Text == null)
            {
                dspsign.Text = "Please enter your username";
                return;
            }
            else if (pass.Text == null)
            {
                dspsign.Text = "Please enter a password";
                return;
            }
            else if (cpass.Text == null)
            {
                dspsign.Text = "Please enter repeat the same password";
                return;
            }
            else if (pass.Text != cpass.Text)
            {
                dspsign.Text = "Passwords do not match";
                return;
            }
            else if (role.Text == null)
            {
                dspsign.Text = "Please enter your role";
                return;
            }


            string val1 = @"^[A-Za-z\s]{3,100}$";
            string val2 = @"^[A-Za-z0-9_-]{10,100}$";
            string val3 = @"^([A-Za-z0-9@~`!#$%^&*+=':;<>,.|/]){8,32}$";


            if (!Regex.IsMatch(fname.Text, val1))
            {
                dspsign.Text = "Invalid Name";
                return;
            }

            if (!Regex.IsMatch(uname.Text, val2))
            {
                dspsign.Text = "Invalid UserName";
                return;
            }

            if (!Regex.IsMatch(pass.Text, val3))
            {
                dspsign.Text = "Passwords should contain capital letters,simple letters, digits, special characters, in range of 8-32";
                return;
            }




            string fullname = fname.Text;
            string username = uname.Text;
            string gender = gen.Text;
            string roler = role.Text;
            string password = pass.Text;

            string query = $"SELECT uname FROM admin WHERE uname = '{username}'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader row = cmd.ExecuteReader();

                if (row.Read())
                {
                    string unamebase = row["uname"].ToString();


                    if (username == unamebase)
                    {
                        dspsign.Text = "UserName already taken";
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }



            string query1 = $"INSERT INTO admin (flname,uname,gen,role,pass) VALUES ('{fullname}','{username}','{gender}','{roler}','{password}')";

            try
            {

                SqlCommand cmd1 = new SqlCommand(query1, conn);
                conn.Open();
                cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm form3 = new LoginForm();
            form3.Show();
            this.Close();
        }

        private void see1_CheckedChanged(object sender, EventArgs e)
        {
            if (see1.Checked)
            {
                pass.UseSystemPasswordChar = false;
                cpass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;
                cpass.UseSystemPasswordChar = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 dashboard = new Form1();
            dashboard.Show();
            this.Close();
        }
    }
}
