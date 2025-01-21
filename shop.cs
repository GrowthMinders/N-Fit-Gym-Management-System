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
    public partial class shop : Form
    {
        public shop()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Rizad\Desktop\prev\N-Fit Gym Management System\N-Fit Gym Management System\GymDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void populate_category()
        {
            Con.Open();
            string query = "SELECT * FROM CategoryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            CategorySDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void populate_customer()
        {
            Con.Open();
            string query = "SELECT * FROM CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            CustomersSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void populate_Items()
        {
            Con.Open();
            string query = "SELECT * FROM ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            ItemsSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            CatNameCb.ValueMember = "CatName";
            CatNameCb.DataSource = dt;
            Con.Close();
        }

        private void FillName_Billing()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Name from CustomerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Load(rdr);
            BCustomerCb.ValueMember = "Name";
            BCustomerCb.DataSource = dt;
            Con.Close();
        }

        private void populate_items_In_Billing()
        {
            Con.Open();
            string query = "SELECT * FROM ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            BillingItemsSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void populate_Bill_Records()
        {
            Con.Open();
            string query = "select * from BillingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            BillRecordsSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Bill_Records_Filter_By_ID()
        {
            Con.Open();
            string query = "select * from BillingTbl where BID = '" + SearchBillRecordTb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            BillRecordsSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        string PMethod = "";
        int n = 0;
        int GrdTotal = 0;


        private void button21_Click(object sender, EventArgs e)
        {
            if (BPrice.Text == "" || BCustomerCb.Text == "" || BQty.Text == "" || BPrice.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                int Qte = Convert.ToInt32(BQty.Text);
                int total = Convert.ToInt32(BPrice.Text)*Qte;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ClientBillSDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = BCustomerCb.Text;
                newRow.Cells[2].Value = BItemTb.Text;
                newRow.Cells[3].Value = BPrice.Text;
                newRow.Cells[4].Value = BQty.Text;
                newRow.Cells[5].Value = "Rs " + total;
                ClientBillSDGV.Rows.Add(newRow);
                n++;
                GrdTotal = GrdTotal + total;
                GrandTotallbl.Text = "Rs " + GrdTotal;
                
            }
        }

        

        private void button19_Click(object sender, EventArgs e)
        {
            BItemTb.Text = "";
            BCustomerCb.Text = "";
            BQty.Text = "";
            BPrice.Text = "";
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Load(object sender, EventArgs e)
        {
           
        }

        private void tabPage3_Load(object sender, EventArgs e)
        {
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || GenderCb.Text == "" || PhoneTb.Text == "" || EmailTb.Text == "" || AdrsTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Insert into CustomerTbl values('" + NameTb.Text + "','" + GenderCb.SelectedItem.ToString() + "','" + PhoneTb.Text + "','" + EmailTb.Text + "','" + AdrsTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");
                    Con.Close();
                    populate_customer();
                    NameTb.Text = "";
                    GenderCb.Text = "";
                    PhoneTb.Text = "";
                    EmailTb.Text = "";
                    AdrsTb.Text = "";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void CustomerSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.CustomersSDGV.Rows[e.RowIndex];
                key = Convert.ToInt32(row.Cells["CustId"].Value?.ToString() ?? "0");
                NameTb.Text = row.Cells["Name"].Value?.ToString();
                GenderCb.Text = row.Cells["Gender"].Value?.ToString();
                PhoneTb.Text = row.Cells["Phone"].Value?.ToString();
                EmailTb.Text = row.Cells["Email"].Value?.ToString();
                AdrsTb.Text = row.Cells["Address"].Value?.ToString();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (ItemTb.Text == "" || CatNameCb.Text == "" || PriceTb.Text == "" || StockTb.Text == "" || ManufacTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Insert into ItemTbl values('" + ItemTb.Text + "','" + CatNameCb.SelectedValue.ToString() + "','" + PriceTb.Text + "','" + StockTb.Text + "','" + ManufacTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Successfully Added");
                    Con.Close();
                    populate_Items();
                    ItemTb.Text = "";
                    CatNameCb.Text = "";
                    PriceTb.Text = "";
                    StockTb.Text = "";
                    ManufacTb.Text = "";
                    

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (CategoryTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Insert into CategoryTbl values('" + CategoryTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Chategory Successfully Added");
                    Con.Close();
                    populate_category();
                    CategoryTb.Text = "";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        
        private void button15_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == "" || GenderCb.Text == "" || PhoneTb.Text == "" || EmailTb.Text == "" || AdrsTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update CustomerTbl set Name='" + NameTb.Text +
               "', Gender='" + GenderCb.Text +
               "', Phone='" + PhoneTb.Text +
               "', Email='" + EmailTb.Text +
               "', Address='" + AdrsTb.Text +
               "' WHERE CustId='" + key + "';";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Information Updated Successfully!");
                    Con.Close();
                    populate_customer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int key = 0;
        private void button11_Click(object sender, EventArgs e)
        {
            if (key == 0 || ItemTb.Text == "" || CatNameCb.Text == "" || PriceTb.Text == "" || StockTb.Text == "" || ManufacTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update ItemTbl set Name='" + ItemTb.Text +
               "', Category='" + CatNameCb.Text +
               "', Price='" + PriceTb.Text +
               "', Stock='" + StockTb.Text +
               "', Manufacturer='" + ManufacTb.Text +
               "' WHERE ITEMid='" + key + "';";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Updated Successfully!");
                    Con.Close();
                    populate_Items();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ItemsSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ItemsSDGV.Rows[e.RowIndex];
                key = Convert.ToInt32(row.Cells["ITEMid"].Value?.ToString() ?? "0");
                ItemTb.Text = row.Cells["Name"].Value?.ToString();
                CatNameCb.Text = row.Cells["Category"].Value?.ToString();
                PriceTb.Text = row.Cells["Price"].Value?.ToString();
                StockTb.Text = row.Cells["Stock"].Value?.ToString();
                ManufacTb.Text = row.Cells["Manufacturer"].Value?.ToString();

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Item To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from ItemTbl where ITEMid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted Successfully!");
                    Con.Close();
                    populate_Items();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Load(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Load(object sender, EventArgs e)
        {
            
        }

        private void BillingItemsSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.BillingItemsSDGV.Rows[e.RowIndex];
                key = Convert.ToInt32(row.Cells["ITEMid"].Value?.ToString() ?? "0");
                BItemTb.Text = row.Cells["Name"].Value?.ToString();
                BPrice.Text = row.Cells["Price"].Value?.ToString();

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

        private void button9_Click(object sender, EventArgs e)
        {
            shop mart = new shop();
            mart.Show();
            this.Hide();
        }

        private void shop_Load(object sender, EventArgs e)
        {
            populate_Items();
            FillName();
            populate_category();
            populate_customer();
            populate_items_In_Billing();
            FillName_Billing();
            populate_Bill_Records();
        }



        private void tabPage5_Click(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Customer To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from CustomerTbl where CustId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully!");
                    Con.Close();
                    populate_customer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CategorySDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.CategorySDGV.Rows[e.RowIndex];
                key = Convert.ToInt32(row.Cells["CatCode"].Value?.ToString() ?? "0");
                CategoryTb.Text = row.Cells["CatName"].Value?.ToString();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (key == 0 || CategoryTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update CategoryTbl set CatName='" + CategoryTb.Text +
               "' WHERE CatCode='" + key + "';";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Updated Successfully!");
                    Con.Close();
                    populate_category();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Category To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from CategoryTbl where CatCode=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Successfully!");
                    Con.Close();
                    populate_category();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClientBillSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (BItemTb.Text == "" || BCustomerCb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    if (CardRadio.Checked == true)
                    {
                        PMethod = "Card";
                    }else if(CashRadio.Checked == true)
                    {
                        PMethod = "Cash";
                    }
                    else
                    {
                        PMethod = "Mobile";
                    }
                    Con.Open();
                    string query = "Insert into BillingTbl values('" + BCustomerCb.Text + "','" + BItemTb.Text + "','" + BPrice.Text + "','" + BQty.Text + "','" + GrdTotal + "','" + PMethod + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Successfully Added To The Database");
                    Con.Close();
                    

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItemTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            populate_Bill_Records();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Bill_Records_Filter_By_ID();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Bill_Records_Filter_By_ID();
        }

        private void GrandTotallbl_Click(object sender, EventArgs e)
        {

        }

        private void CatNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}