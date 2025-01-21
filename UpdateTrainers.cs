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
    public partial class UpdateTrainers : Form
    {
        public UpdateTrainers()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Rizad\Desktop\prev\N-Fit Gym Management System\N-Fit Gym Management System\GymDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from TrainerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            TrainerSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTrainers_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void TrainerSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.TrainerSDGV.Rows[e.RowIndex];
                key = Convert.ToInt32(row.Cells["TID"].Value?.ToString() ?? "0");
                TrainerTb.Text = row.Cells["TName"].Value?.ToString();
                TrPhoneTb.Text = row.Cells["TPhone"].Value?.ToString();
                TrAgeTb.Text = row.Cells["TAge"].Value?.ToString();
                TrGenderCb.Text = row.Cells["TGen"].Value?.ToString();
                TrAmountTb.Text = row.Cells["TAmount"].Value?.ToString();
                TrTimingCb.Text = row.Cells["TTiming"].Value?.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TrainerTb.Text = "";
            TrPhoneTb.Text = "";
            TrAgeTb.Text = "";
            TrGenderCb.Text = "";
            TrAmountTb.Text = "";
            TrTimingCb.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Trainer To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from TrainerTbl where TID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Trainer Deleted Successfully!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (key == 0 || TrainerTb.Text == "" || TrPhoneTb.Text == "" || TrAgeTb.Text == "" || TrAgeTb.Text == "" || TrAmountTb.Text == "" || TrTimingCb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update TrainerTbl set TName='" + TrainerTb.Text +
               "', TPhone='" + TrPhoneTb.Text +
               "', TAge='" + TrAgeTb.Text +
               "', TGen='" + TrGenderCb.Text +
               "', TAmount='" + TrAmountTb.Text +
               "', TTiming='" + TrTimingCb.Text +
               "' where TID=" + key + ";";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Trainer Updated Successfully!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dashboard = new Form1();
            dashboard.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
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
