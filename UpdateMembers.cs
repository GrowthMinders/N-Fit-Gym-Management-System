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

namespace N_Fit_Gym_Management_System
{
    public partial class UpdateMembers : Form
    {
        public UpdateMembers()
        {
            InitializeComponent();
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Rizad\Desktop\prev\N-Fit Gym Management System\N-Fit Gym Management System\GymDB.mdf"";Integrated Security=True;Connect Timeout=30");

        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TName from TrainerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TName", typeof(string));
            dt.Load(rdr);
            MATrainerCb.ValueMember = "TName";
            MATrainerCb.DataSource = dt;
            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from MemberTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UpdateMembers_Load(object sender, EventArgs e)
        {
            populate();
            FillName();
        }
        int key = 0;
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.MemberSDGV.Rows[e.RowIndex];
                key = Convert.ToInt32(row.Cells["MID"].Value?.ToString() ?? "0");
                MemTb.Text = row.Cells["MName"].Value?.ToString();
                PhoneTb.Text = row.Cells["MPhone"].Value?.ToString();
                AgeTb.Text = row.Cells["MAge"].Value?.ToString();
                GenderCb.Text = row.Cells["MGen"].Value?.ToString();
                AmountTb.Text = row.Cells["MAmount"].Value?.ToString();
                TimingCb.Text = row.Cells["MTiming"].Value?.ToString();
                MATrainerCb.Text = row.Cells["MATrainer"].Value?.ToString();

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MemTb.Text = "";
            PhoneTb.Text = "";
            AgeTb.Text = "";
            GenderCb.Text = "";
            AmountTb.Text = "";
            TimingCb.Text = "";
            MATrainerCb.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form1 dashboard = new Form1();
            dashboard.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Select The Member To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from MemberTbl where MID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Deleted Successfully!");
                    Con.Close();
                    populate();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (key == 0 || MemTb.Text == "" || PhoneTb.Text == "" || AgeTb.Text == "" || GenderCb.Text == "" || AmountTb.Text == "" || TimingCb.Text =="" || MATrainerCb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update MemberTbl set MName='" + MemTb.Text +
               "', MPhone='" + PhoneTb.Text +
               "', MAge='" + AgeTb.Text +
               "', MGen='" + GenderCb.Text +
               "', MAmount='" + AmountTb.Text +
               "', MTiming='" + TimingCb.Text +
               "', MATrainer='" + MATrainerCb.Text +
               "' where MID=" + key + ";";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Updated Successfully!");
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

        private void GenderCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            shop mart = new shop();
            mart.Show();
            this.Hide();
        }
    }
}
