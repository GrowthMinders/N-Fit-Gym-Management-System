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

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace N_Fit_Gym_Management_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Rizad\Desktop\prev\N-Fit Gym Management System\N-Fit Gym Management System\GymDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            pass.UseSystemPasswordChar = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pass != null && user != null)
            {
                string password = pass.Text;
                string use = user.Text;
                string query = $"SELECT uname,pass,role FROM admin WHERE uname = '{use}'";



                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader row = cmd.ExecuteReader();




                    if (row.Read())
                    {
                        string passbase = row["pass"].ToString();
                        string unamebase = row["uname"].ToString();
                        string rolebase = row["role"].ToString();

                        if (use != unamebase)
                        {
                            dsplog.Text = "Incorrect UserName";
                        }
                        else if (password != passbase)
                        {
                            dsplog.Text = "Incorrect Password";
                            pass.Text = "";
                        }
                        else if (use == unamebase && password == passbase)
                        {
                            if (rolebase == "Administrator")
                            {
                                Form1 form4 = new Form1();
                                form4.Show();
                                this.Hide();
                            }
                            else if (rolebase == "Reception")
                            {
                                Form1 form5 = new Form1();
                                form5.Show();
                                this.Hide();
                            }
                            else if (rolebase == "Manager")
                            {
                                Form1 form6 = new Form1();
                                form6.Show();
                                this.Hide();
                            }

                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
            else
            {
                MessageBox.Show("Please fill all the data");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            user.Text = "";
            pass.Text = "";
        }

        private void see1_CheckedChanged(object sender, EventArgs e)
        {
            if (see.Checked)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration registerform = new Registration();
            registerform.Show();
            this.Hide();
        }
    }
}
