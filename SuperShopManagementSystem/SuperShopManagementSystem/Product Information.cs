using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SuperShopManagementSystem
{
    public partial class Product_Information : Form
    {
        public Product_Information()
        {
            InitializeComponent();
        }

        private void Product_Information_Load(object sender, EventArgs e)
        {
            this.LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from Products; SELECT DISTINCT ProductCategory FROM Products; SELECT DISTINCT ProductUnit FROM Products";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                con.Close();

                DataTable dt = ds.Tables[0];
                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = dt;
                dgvProducts.Refresh();
                dgvProducts.ClearSelection();


                DataTable cat = ds.Tables[1];
                cmbCategory.DataSource = cat;
                cmbCategory.ValueMember = "ProductCategory";
                cmbCategory.DisplayMember = "ProductCategory";

                DataTable ut = ds.Tables[2];
                cmbUnit.DataSource = ut;
                cmbUnit.ValueMember = "ProductUnit";
                cmbUnit.DisplayMember = "ProductUnit";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadProducts();
            this.AddProducts();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbCategory.SelectedValue = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPName.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbUnit.SelectedValue = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAvailability.Text = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();


            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddProducts();
        }

        private void AddProducts()
        {
            txtID.Text = "ID will be Auto Generated";
            cmbCategory.SelectedValue = "";
            txtPName.Text = "";
            cmbUnit.SelectedValue = "";
            txtPrice.Text = "";
            txtAvailability.Text = "";
            dgvProducts.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "ID will be Auto Generated")
            {
                MessageBox.Show("Please Select a Row first");
                return;

            }
            var result = MessageBox.Show("Sir, are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.No)
                return;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from Products where id={id}";

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Operation Successful");
                this.LoadProducts();
                this.AddProducts();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string category = cmbCategory.SelectedValue.ToString();
            string name = txtPName.Text;
            string unit = cmbUnit.SelectedValue.ToString();
            string price = txtPrice.Text;
            string availability = txtAvailability.Text;

            string query = "";
            if (id == "ID will be Auto Generated")
            {
                query = $" INSERT INTO Products (ProductCategory, ProductName, ProductUnit, ProductPrice, ProductAvailability) VALUES ('{category}','{name}','{unit}',{price},{availability})";
            }
            else
            {
                query = $"update Products set ProductCategory='{category}',ProductName='{name}',ProductUnit='{unit}', ProductPrice='{price}', ProductAvailability={availability} where ProductID='{id}' ";
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Operation Successful");
                this.LoadProducts();
                this.AddProducts();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }




        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string search = txtSearch.Text;
                if (txtSearch.Text == "")
                {
                    cmd.CommandText = $"select * from Products";

                }
                else
                {
                    cmd.CommandText = $"SELECT * FROM Products WHERE ProductCategory like '%{search}%' OR ProductName LIKE '%{search}%'";
                }
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                con.Close();
                DataTable dt = ds.Tables[0];
                dgvProducts.DataSource = dt;
                dgvProducts.Refresh();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void Product_Information_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (type == "Admin")
            {
                AdminDashboard ad = new AdminDashboard();
                ad.Show();
                //this.Hide();
            }

            else if (type == "Manager")
            {
                ManagerDashboard md = new ManagerDashboard();
                md.Show();
                //this.Hide();
            }

            /*           if (this.Owner != null)
                       {

                           this.Owner.Show();
                           //this.Close();
                       }
           */

        }
        public string type = "";

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(this.Owner!=null)
                this.Owner.Show();
            this.Hide();


        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
