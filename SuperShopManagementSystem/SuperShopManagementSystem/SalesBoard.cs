using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace SuperShopManagementSystem
{
    public partial class SalesBoard : Form
    {
        public SalesBoard()
        {
            InitializeComponent();
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



        private void New_Product()

        {

            txtSID.Text = "ID WILL BE AUTO GENERATED";
            txtPName.Clear();
            cmbCategory.SelectedValue = " ";
            cmbUnit.SelectedValue = " ";
            txtPrice.Clear();
            txtQuan.Clear();
            txtTprice.Clear();
            txtAvailability.Clear();
            dgvProducts.ClearSelection();
            dgvCart.ClearSelection();

        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)

            {

             

               txtPName.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbUnit.SelectedValue = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbCategory.SelectedValue = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAvailability.Text = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();

            }

        }
        private void txtQuan_TextChanged(object sender, EventArgs e)
        {
            this.CalculateTotalPrice();
        }

        private void txtTprice_TextChanged(object sender, EventArgs e)
        {
            this.CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price) &&
                int.TryParse(txtQuan.Text, out int quantity))
            {
                decimal total = price * quantity;
                txtTprice.Text = total.ToString("0.00");
            }
            else
            {
                txtTprice.Text = ""; 
            }
        }





        private void btnATC_Click(object sender, EventArgs e)
        {
            
            if (txtSID.Text == "" || txtPName.Text == "" ||txtQuan.Text == "")
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }
                        int rowIndex = dgvCart.Rows.Add(
                txtSID.Text,
                txtPName.Text,
                cmbCategory.SelectedValue,
                cmbUnit.SelectedValue,
                txtQuan.Text,
                txtPrice.Text,
                dtpSdate.Value.ToString("yyyy-MM-dd"),
                txtTprice.Text
            );

            this.New_Product();
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSID.Text = dgvCart.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPName.Text = dgvCart.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbCategory.SelectedValue = dgvCart.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbUnit.SelectedValue = dgvCart.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtQuan.Text = dgvCart.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPrice.Text = dgvCart.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtpSdate.Text = dgvCart.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtTprice.Text = dgvCart.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private void SalesBoard_Load(object sender, EventArgs e)
        {
            this.LoadProducts();
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

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            string paymentMethod = "";
            if (rbtnCash.Checked) paymentMethod = "Cash";
            else if (rdbtnCard.Checked) paymentMethod = "Card";
            else if (rdbtnOnline.Checked) paymentMethod = "Online";

            if (string.IsNullOrWhiteSpace(paymentMethod))
            {
                MessageBox.Show("Please select a payment method", "Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add products first", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                {
                    con.Open();

                    for (int i = 0; i < dgvCart.Rows.Count; i++)
                    {
                        if (dgvCart.Rows[i].IsNewRow) continue;

                        string salesId = dgvCart.Rows[i].Cells[0].Value.ToString();
                        string productName = dgvCart.Rows[i].Cells[1].Value.ToString();
                        string category = dgvCart.Rows[i].Cells[2].Value.ToString();
                        string unit = dgvCart.Rows[i].Cells[3].Value.ToString();
                        int quantity = Convert.ToInt32(dgvCart.Rows[i].Cells[4].Value);
                        double price = Convert.ToDouble(dgvCart.Rows[i].Cells[5].Value);
                        string date = dgvCart.Rows[i].Cells[6].Value.ToString();
                        double total = Convert.ToDouble(dgvCart.Rows[i].Cells[7].Value);




                        // Check current stock
                        int currentStock = 0;
                        SqlCommand cmdCheck = new SqlCommand("SELECT ProductAvailability FROM Products WHERE ProductName = @ProductName", con);
                        cmdCheck.Parameters.AddWithValue("@ProductName", productName);
                        object stockObj = cmdCheck.ExecuteScalar();

                        if (stockObj == null || stockObj == DBNull.Value)
                        {
                            MessageBox.Show("Product not found: " + productName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        currentStock = Convert.ToInt32(stockObj);

                        if (currentStock < quantity)
                        {
                            MessageBox.Show($"Not enough stock for '{productName}'. Available: {currentStock}", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        
                        // Insert into Sales Table 
                        SqlCommand cmdInsert = new SqlCommand();
                        cmdInsert.Connection = con;
                        cmdInsert.CommandText = $"INSERT INTO Sales (ProductName, Price, Quantity, Unit, TotalPrice, Date, PaymentMethod) VALUES ('{productName}', {price}, {quantity}, '{unit}', {total}, '{date}', '{paymentMethod}')";

                        cmdInsert.ExecuteNonQuery();

                        // Update Stock
                        int newStock = currentStock - quantity;
                        SqlCommand cmdUpdate = new SqlCommand();
                        cmdUpdate.Connection = con;
                        cmdUpdate.CommandText = $"UPDATE Products SET ProductAvailability = {newStock} WHERE ProductName = '{productName}'";
                        cmdUpdate.ExecuteNonQuery();
                    }

                    con.Close();
                }

                MessageBox.Show("Checkout successful! Inventory updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvCart.Rows.Clear();
               

                LoadProducts();
                New_Product();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadProducts();
            this.New_Product();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCart.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvCart.Rows.Remove(row);
                    }
                }

               
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
            this.Hide();
        }

        
    }
}


