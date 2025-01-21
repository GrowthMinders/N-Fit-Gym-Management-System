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

namespace N_Fit_Gym_Management_System
{
    public partial class AddTrainers : Form
    {
        public AddTrainers()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Rizad\Desktop\prev\N-Fit Gym Management System\N-Fit Gym Management System\GymDB.mdf"";Integrated Security=True;Connect Timeout=30");

        private void AddTrainers_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (TrainerTb.Text == "" || TrPhoneTb.Text == "" || TrAmountTb.Text == "" || TrAgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Insert into TrainerTbl values('" + TrainerTb.Text + "','" + TrPhoneTb.Text + "','" + TrAgeTb.Text + "','" + TrGenderCb.SelectedItem.ToString() + "','" + TrAmountTb.Text + "','" + TrTimingCb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Trainer Successfully Added");
                    Con.Close();
                    TrAmountTb.Text = "";
                    TrAgeTb.Text = "";
                    TrainerTb.Text = "";
                    TrGenderCb.Text = "";
                    TrPhoneTb.Text = "";
                    TrTimingCb.Text = "";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TrAmountTb.Text = "";
            TrAgeTb.Text = "";
            TrainerTb.Text = "";
            TrGenderCb.Text = "";
            TrPhoneTb.Text = "";
            TrTimingCb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dashboard = new Form1();
            dashboard.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 dashboard = new Form1();
            dashboard.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMember addmember = new AddMember();
            addmember.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTrainers addtrainers = new AddTrainers();
            addtrainers.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewMembers viewMembers = new ViewMembers();
            viewMembers.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewtrainers viewtrainers = new viewtrainers();
            viewtrainers.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateMembers updatemembers = new UpdateMembers();
            updatemembers.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UpdateTrainers updatetrainers = new UpdateTrainers();
            updatetrainers.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Payments payments = new Payments();
            payments.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shop mart = new shop();
            mart.Show();
            this.Hide();
        }
    }
}
