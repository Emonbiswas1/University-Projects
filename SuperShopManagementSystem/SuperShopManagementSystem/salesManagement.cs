using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SuperShopManagementSystem
{
    public partial class salesManagement : Form
    {
        public salesManagement()
        {
            InitializeComponent();
        }

        private void ClearInputs()
        {
            txtSaleId.Text = "";
            txtProductName.Text = "";
            txtUnit.Text = "";
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtTotal.Text = "";
            txtStock.Text = "";
            comboboxPaymentMethod.Text = "";
            dgvData.ClearSelection();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                txtTotal.Text = "";
                return;
            }

            decimal qty;
            decimal price;

            if (!decimal.TryParse(txtQuantity.Text, out qty))
            {
                txtTotal.Text = "";
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, out price))
            {
                txtTotal.Text = "";
                return;
            }

            txtTotal.Text = (qty * price).ToString("0.00");
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            this.LoadSales();
        }

        private void LoadSales()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT SalesId, ProductName, Price, Quantity, Unit, TotalPrice, [Date], PaymentMethod FROM Sales ORDER BY [Date] DESC";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                con.Close();

                DataTable dt = ds.Tables[0];
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = dt;
                dgvData.Refresh();
                dgvData.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int LoadProductStockAndGetId(string productName)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT ProductID, ProductAvailability FROM Products WHERE ProductName = '{productName}'";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                con.Close();

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count == 1)
                {
                    txtStock.Text = dt.Rows[0]["ProductAvailability"].ToString();
                    return Convert.ToInt32(dt.Rows[0]["ProductID"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtStock.Text = "";
            return -1;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Please select a valid row.");
                return;
            }

            txtSaleId.Text = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUnitPrice.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtQuantity.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUnit.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtTotal.Text = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboboxPaymentMethod.Text = dgvData.Rows[e.RowIndex].Cells[7].Value.ToString();

            if (txtProductName.Text != "")
            {
                LoadProductStockAndGetId(txtProductName.Text);
            }
            else
            {
                txtStock.Text = "";
            }
        }

        private void btnDeleteSale_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }

            string role = Login.LoggedinUserRole;

            int salesId = Convert.ToInt32(dgvData.CurrentRow.Cells[0].Value);
            string productName = dgvData.CurrentRow.Cells[1].Value.ToString();
            int qty = Convert.ToInt32(dgvData.CurrentRow.Cells[3].Value);
            DateTime saleDate = Convert.ToDateTime(dgvData.CurrentRow.Cells[6].Value);

            if (role != "Admin" && saleDate < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("Can't delete after 1 day");
                return;
            }

            var result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.No)
                return;

            int pid = LoadProductStockAndGetId(productName);
            if (pid == -1)
            {
                MessageBox.Show("Product not found");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandText = $"UPDATE Products SET ProductAvailability = ProductAvailability + {qty} WHERE ProductID = {pid}";
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = $"DELETE FROM Sales WHERE SalesId = {salesId}";
                cmd2.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Operation Successful");
                this.ClearInputs();
                this.LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateSale_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }

            string role = Login.LoggedinUserRole;

            DateTime saleDate = Convert.ToDateTime(dgvData.CurrentRow.Cells[6].Value);
            if (role != "Admin" && saleDate < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("Can't update after 1 day");
                return;
            }

            int salesId = Convert.ToInt32(txtSaleId.Text);

            decimal oldQty;
            if (!decimal.TryParse(dgvData.CurrentRow.Cells[3].Value.ToString(), out oldQty))
            {
                MessageBox.Show("Invalid old quantity");
                return;
            }

            string oldProductName = dgvData.CurrentRow.Cells[1].Value.ToString();
            string newProductName = txtProductName.Text;

            decimal newQty;
            if (!decimal.TryParse(txtQuantity.Text, out newQty))
            {
                MessageBox.Show("Invalid qty");
                return;
            }

            if (newQty <= 0)
            {
                MessageBox.Show("Invalid qty");
                return;
            }

            int oldPid = LoadProductStockAndGetId(oldProductName);
            int newPid = LoadProductStockAndGetId(newProductName);

            if (oldPid == -1 || newPid == -1)
            {
                MessageBox.Show("Product not found");
                return;
            }
            decimal availableStock = 0;
            try
            {
                SqlConnection conCheck = new SqlConnection();
                conCheck.ConnectionString = ApplicationHelper.CS;
                conCheck.Open();

                SqlCommand cmdCheck = new SqlCommand();
                cmdCheck.Connection = conCheck;
                cmdCheck.CommandText = $"SELECT ProductAvailability FROM Products WHERE ProductID = {newPid}";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmdCheck);
                adp.Fill(ds);

                conCheck.Close();

                DataTable dt = ds.Tables[0];
                availableStock = Convert.ToDecimal(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (oldPid == newPid)
            {
                availableStock = availableStock + oldQty;
            }

            if (newQty > availableStock)
            {
                MessageBox.Show("Not enough stock. Available: " + availableStock);
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtUnitPrice.Text, out price))
            {
                MessageBox.Show("Invalid unit price");
                return;
            }

            decimal total;
            if (!decimal.TryParse(txtTotal.Text, out total))
            {
                MessageBox.Show("Invalid total");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandText = $"UPDATE Products SET ProductAvailability = ProductAvailability + {oldQty} WHERE ProductID = {oldPid}";
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = $"UPDATE Products SET ProductAvailability = ProductAvailability - {newQty} WHERE ProductID = {newPid}";
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandText =
                    $"UPDATE Sales SET ProductName='{txtProductName.Text}', Price={price}, Quantity={newQty}, Unit='{txtUnit.Text}', TotalPrice={total}, PaymentMethod='{comboboxPaymentMethod.Text}' WHERE SalesId={salesId}";
                cmd3.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Operation Successful");
                this.ClearInputs();
                this.LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearInputs();
        }

        private void btnReturntoDashboard_Click(object sender, EventArgs e)
        {
            string role = Login.LoggedinUserRole;

            if (role == "Admin")
            {
                AdminDashboard ad = new AdminDashboard();
                ad.Show();
                this.Hide();
            }
            else if (role == "Manager")
            {
                ManagerDashboard md = new ManagerDashboard();
                md.Show();
                this.Hide();
            }
            else
            {
                EmployeeDashboard ep = new EmployeeDashboard();
                ep.Show();
                this.Hide();
            }
        }
    }
}
