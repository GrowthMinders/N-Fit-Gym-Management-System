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
using System.Security.Cryptography;

namespace N_Fit_Gym_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Rizad\Desktop\prev\N-Fit Gym Management System\N-Fit Gym Management System\GymDB.mdf"";Integrated Security=True;Connect Timeout=30");
        
        private void populate_Customer_Count()
        {


            string QueryCust = "Select Count(*) from CustomerTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(QueryCust, Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            CustomerCountLbl.Text = dt2.Rows[0][0].ToString();


        }
        private void populate_Member_Count()
        {

            string QueryMem = "Select Count(*) from MemberTbl";
            SqlDataAdapter sda = new SqlDataAdapter(QueryMem, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MemCountLbl.Text = dt.Rows[0][0].ToString();


        }

        private void populate_Trainer_Count()
        {

            string QueryTrainer = "Select Count(*) from TrainerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(QueryTrainer, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TrainerCountLbl.Text = dt1.Rows[0][0].ToString();
        }

        private void populate_Shop_Income()
        {
            string QueryTrainer = "SELECT SUM(Total) FROM BillingTbl;";
            SqlDataAdapter sda1 = new SqlDataAdapter(QueryTrainer, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            ShpIncomeLbl.Text = "Rs." + dt1.Rows[0][0].ToString() + ".00";
        }

        private void populate_Membership_Income()
        {
            string QueryTrainer = "SELECT SUM(PAmount) FROM PaymentTbl;";
            SqlDataAdapter sda1 = new SqlDataAdapter(QueryTrainer, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            int total_membership_income = Convert.ToInt32(dt1.Rows[0][0]);
            MemIncomeLbl.Text = "Rs." + total_membership_income + ".00";
        }

        private void populate_Shop_Items_Cost()
        {

            string QueryTrainer = "SELECT SUM(Price) FROM ItemTbl;";
            SqlDataAdapter sda1 = new SqlDataAdapter(QueryTrainer, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            ShpItemsCostLbl.Text = "Rs." + dt1.Rows[0][0].ToString() + ".00";
        }

        private void populate_Trainers_Salary_Cost()
        {

            string QueryTrainer = "SELECT SUM(TAmount) FROM TrainerTbl;";
            SqlDataAdapter sda1 = new SqlDataAdapter(QueryTrainer, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TtlTrainersSalLbl.Text = "Rs." + dt1.Rows[0][0].ToString() + ".00";
        }
        private void populate_Total_Income()
        {
            int MembershipIncome = Convert.ToInt32(MemIncomeLbl.Text.Replace("Rs.", "").Replace(".00", ""));
            int ShopIncome = Convert.ToInt32(ShpIncomeLbl.Text.Replace("Rs.", "").Replace(".00", ""));
            int TotalIncome = MembershipIncome + ShopIncome;
            Ttllncomelbl.Text = "Rs." + TotalIncome + ".00";
        }

        private void populate_Net_Profit()
        {
            int shopItemCost = Convert.ToInt32(ShpItemsCostLbl.Text.Replace("Rs.", "").Replace(".00", ""));
            int TrainerSalCost = Convert.ToInt32(TtlTrainersSalLbl.Text.Replace("Rs.", "").Replace(".00", ""));
            int TotalCost = shopItemCost + TrainerSalCost;
            int NetProfit = Convert.ToInt32(Ttllncomelbl.Text.Replace("Rs.", "").Replace(".00", "")) - TotalCost;
            netProfitLbl.Text = "Rs." + NetProfit + ".00";

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

        private void button9_Click(object sender, EventArgs e)
        {
            shop mart = new shop();
            mart.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populate_Customer_Count();
            populate_Member_Count();
            populate_Trainer_Count();
            populate_Shop_Income();
            populate_Membership_Income();
            populate_Shop_Items_Cost();
            populate_Trainers_Salary_Cost();
            populate_Total_Income();
            populate_Net_Profit();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
