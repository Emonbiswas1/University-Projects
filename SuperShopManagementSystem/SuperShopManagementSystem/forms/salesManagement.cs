using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SuperShopManagementSystem;

namespace SuperShopManagementUsers
{
    public partial class salesManagement : Form
    {
        private int userID;
        private string userRole;
        private int SelectedProductId = -1;
        //private string connectionString = ConfigurationManager.ConnectionStrings["ShopDb"].ConnectionString;
        
        public salesManagement(int userId, string roleName)
        {
            InitializeComponent();
            userID = userId;
            userRole = roleName;
            LoadSoldByName();
            GenerateNextSaleId();
        }

        private void salesManagement_Load(object sender, EventArgs e)
        {
            listBoxProductName.Visible = false;
            txtSaleId.ReadOnly = true;
            txtSoldBy.ReadOnly = true;
            txtStock.ReadOnly = true;
            txtUnit.ReadOnly = true;
            txtUnitPrice.ReadOnly = true;
            txtTotal.ReadOnly = true;   
        }

        private void LoadSoldByName()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT FullName FROM Users WHERE UserId = @uid";
                cmd.Parameters.AddWithValue("@uid", userID);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result == null || result == DBNull.Value)
                {
                    txtSoldBy.Text = "Unknown";
                }
                else
                {
                    txtSoldBy.Text = result.ToString();
                }        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateNextSaleId()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT ISNULL(MAX(SaleId), 0) FROM Sales";

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                int lastId = Convert.ToInt32(result);
                txtSaleId.Text = (lastId + 1).ToString("000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim().Length < 2)
            {
                listBoxProductName.Visible = false;
                listBoxProductName.Items.Clear();
                return;
            }

            listBoxProductName.Items.Clear();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT ProductName FROM Products WHERE ProductName LIKE @prname + '%'";

                cmd.Parameters.AddWithValue("@prname", txtProductName.Text.Trim());

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listBoxProductName.Items.Add(reader["ProductName"].ToString());
                }

                reader.Close();
                con.Close();

                if (listBoxProductName.Items.Count > 0)
                {
                    listBoxProductName.Visible = true;
                }
                else
                {
                    listBoxProductName.Visible = false;
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProductName.SelectedItem == null)
            {
                return;
            }
                

            string productName = listBoxProductName.SelectedItem.ToString();
            txtProductName.Text = productName;
            listBoxProductName.Visible = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT ProductId, ProductUnit, ProductPrice, ProductAvailability FROM Products WHERE ProductName = @prname";

                cmd.Parameters.AddWithValue("@prname", productName);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    SelectedProductId = Convert.ToInt32(reader["ProductId"]);
                    txtUnit.Text = reader["ProductUnit"].ToString();
                    txtUnitPrice.Text = reader["ProductPrice"].ToString();
                    txtStock.Text = reader["ProductAvailability"].ToString();
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                txtTotal.Text = "";
                return;
            }

            int qty;
            int stock;
            decimal price;

            try
            {
                qty = Convert.ToInt32(txtQuantity.Text);
                stock = Convert.ToInt32(txtStock.Text);
                price = Convert.ToDecimal(txtUnitPrice.Text);
            }
            catch
            {
                MessageBox.Show("Invalid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Text = "";
                txtTotal.Text = "";
                return;
            }

            

            if (qty > stock)
            {
                MessageBox.Show("Quantity exceeds available stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Text = stock.ToString();
                return;
            }

            decimal total = qty * price;
            txtTotal.Text = total.ToString("0.00");
        }


        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            dgvData.DataSource = null;
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();

            int isSalesman = 0;
            if (userRole == "Salesman" || userRole == "Employee")
            {
                isSalesman = 1;
            }
                

            string sql = @"SELECT s.SaleId, s.SoldByUserId, u.FullName AS SoldByUserName, s.ProductId, p.ProductName, p.ProductCategory,
                   s.UnitPrice AS PriceAtSale, s.Quantity, p.ProductUnit AS Unit, s.TotalPrice, s.SaleDateTime AS SaleDate, s.PaymentMethod
                   FROM Sales s INNER JOIN Users u ON s.SoldByUserId = u.UserId INNER JOIN Products p ON s.ProductId = p.ProductId
                   WHERE (@isSalesman = 0) OR (s.SoldByUserId = @userid) ORDER BY s.SaleDateTime DESC;";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@userid", userID);
                cmd.Parameters.AddWithValue("@isSalesman", isSalesman);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dgvData.DataSource = dt;

                dgvData.Columns["SaleId"].HeaderText = "Sale ID";
                dgvData.Columns["SoldByUserName"].HeaderText = "Sold By";
                dgvData.Columns["ProductName"].HeaderText = "Product";
                dgvData.Columns["ProductCategory"].HeaderText = "Product Category";
                dgvData.Columns["Quantity"].HeaderText = "Qty";
                dgvData.Columns["Unit"].HeaderText = "Unit";
                dgvData.Columns["PriceAtSale"].HeaderText = "Unit Price";
                dgvData.Columns["TotalPrice"].HeaderText = "Total";
                dgvData.Columns["SaleDate"].HeaderText = "Sale Date";
                dgvData.Columns["PaymentMethod"].HeaderText = "Payment";

                dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddToSale_Click(object sender, EventArgs e)
        {
            if (SelectedProductId == -1)
            {
                MessageBox.Show("Please select a product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Quantity cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            if (comboboxPaymentMethod.Text == "")
            {
                MessageBox.Show("Select payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboboxPaymentMethod.Focus();
                return;
            }

            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            decimal totalPrice = Convert.ToDecimal(txtTotal.Text);
            int stock = Convert.ToInt32(txtStock.Text);

            if (quantity <= 0)
            {
                MessageBox.Show("Invalid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            if (quantity > stock)
            {
                MessageBox.Show("Quantity exceeds available stock.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ApplicationHelper.CS;

            try
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.Transaction = tran;
                    cmd1.CommandText = @"INSERT INTO Sales (ProductId, SoldByUserId, Quantity, UnitPrice, TotalPrice, SaleDateTime, 
                                        PaymentMethod) VALUES (@productid, @userid, @quantity, @price, @total, GETDATE(), @payMethod)";

                    cmd1.Parameters.AddWithValue("@productid", SelectedProductId);
                    cmd1.Parameters.AddWithValue("@userid", userID);
                    cmd1.Parameters.AddWithValue("@quantity", quantity);
                    cmd1.Parameters.AddWithValue("@price", unitPrice);
                    cmd1.Parameters.AddWithValue("@total", totalPrice);
                    cmd1.Parameters.AddWithValue("@payMethod", comboboxPaymentMethod.Text);

                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.Transaction = tran;
                    cmd2.CommandText = @"UPDATE Products SET ProductAvailability = ProductAvailability - @quantity WHERE ProductId = @productid";

                    cmd2.Parameters.AddWithValue("@quantity", quantity);
                    cmd2.Parameters.AddWithValue("@productid", SelectedProductId);

                    cmd2.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("Sale completed successfully.");

                    GenerateNextSaleId();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Sale failed.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnLoadDatabase_Click(null, null);
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            txtUnit.Text = "";
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtTotal.Text = "";
            txtStock.Text = "";
            SelectedProductId = -1;
            listBoxProductName.Items.Clear();
            listBoxProductName.Visible = false;
            txtProductName.Focus();
        }


        private void btnDeleteSale_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null) 
            {  
                return; 
            }
            int saleId = Convert.ToInt32(dgvData.CurrentRow.Cells["SaleId"].Value);
            int productId = Convert.ToInt32(dgvData.CurrentRow.Cells["ProductId"].Value);
            int qty = Convert.ToInt32(dgvData.CurrentRow.Cells["Quantity"].Value);
            DateTime saleDate = Convert.ToDateTime(dgvData.CurrentRow.Cells["SaleDate"].Value);

            if (userRole != "Admin") 
            {
                if (saleDate < DateTime.Now.AddDays(-1))
                {
                    MessageBox.Show("Only administrators can delete sales older than 1 day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (userRole == "Salesman")
            {

                MessageBox.Show("Permission Denied! You are not allowed to delete sales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ApplicationHelper.CS;

            try
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.Transaction = tran;
                    cmd1.CommandText =
                        "UPDATE Products SET ProductAvailability = ProductAvailability + @quantity WHERE ProductId = @productid";

                    cmd1.Parameters.AddWithValue("@quantity", qty);
                    cmd1.Parameters.AddWithValue("@productid", productId);

                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.Transaction = tran;
                    cmd2.CommandText = "DELETE FROM Sales WHERE SaleId = @salesid";

                    cmd2.Parameters.AddWithValue("@salesid", saleId);

                    cmd2.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Delete failed.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnLoadDatabase_Click(null, null);
        }

        private void LoadCurrentStock(int productId)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT ProductAvailability FROM Products WHERE ProductId = @productid";
                cmd.Parameters.AddWithValue("@productid", productId);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != null)
                    txtStock.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) 
            {
                return;
            } 
            try
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];

                SelectedProductId = Convert.ToInt32(row.Cells["ProductId"].Value);
                txtUnit.Text = row.Cells["Unit"].Value.ToString();
                txtUnitPrice.Text = row.Cells["PriceAtSale"].Value.ToString();
                LoadCurrentStock(SelectedProductId);

                txtSaleId.Text = row.Cells["SaleId"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                comboboxPaymentMethod.Text = row.Cells["PaymentMethod"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                txtTotal.Text = row.Cells["TotalPrice"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSale_Click(object sender, EventArgs e)
        {
            DateTime saleDate = Convert.ToDateTime(dgvData.CurrentRow.Cells["SaleDate"].Value);

            if (userRole != "Admin")
            {
                if (saleDate < DateTime.Now.AddDays(-1))
                {
                    MessageBox.Show("Only administrators can edit sales older than 1 day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (userRole == "Salesman")
            {

                if (saleDate < DateTime.Now.AddHours(-1))
                {
                    MessageBox.Show("Permission Denied! You can't change sale details after 1 hour.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            


            if (txtSaleId.Text == "")
            {
                MessageBox.Show("Please select a sale to update.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SelectedProductId == -1)
            {
                MessageBox.Show("Please select a product.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Quantity cannot be empty.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboboxPaymentMethod.Text == "")
            {
                MessageBox.Show("Select payment method.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Please select a sale row.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int saleId = Convert.ToInt32(txtSaleId.Text);
            int oldProductId = Convert.ToInt32(dgvData.CurrentRow.Cells["ProductId"].Value);
            int oldQuantity = Convert.ToInt32(dgvData.CurrentRow.Cells["Quantity"].Value);
            int newProductId = SelectedProductId;
            int newQuantity = Convert.ToInt32(txtQuantity.Text);
            decimal newUnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            decimal newTotalPrice = Convert.ToDecimal(txtTotal.Text);
            string newPaymentMethod = comboboxPaymentMethod.Text;

            if (newQuantity <= 0)
            {
                MessageBox.Show("Invalid quantity.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string queryRestore = "UPDATE Products SET ProductAvailability = ProductAvailability + @oldquantity WHERE ProductId = @oldproductid";

            string queryCheck = "SELECT ProductAvailability FROM Products WHERE ProductId = @newproductid";

            string queryDeduct = "UPDATE Products SET ProductAvailability = ProductAvailability - @newquantity WHERE ProductId = @newproductid";

            string queryUpdate = @"UPDATE Sales SET ProductId = @productid, Quantity = @quantity, UnitPrice = @unitprice,
          TotalPrice = @totalprice, PaymentMethod = @paymethod WHERE SaleId = @saleid";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();
                SqlCommand cmdRestore = new SqlCommand();
                cmdRestore.Connection = con;
                cmdRestore.CommandText = queryRestore;
                cmdRestore.Parameters.AddWithValue("@oldquantity", oldQuantity);
                cmdRestore.Parameters.AddWithValue("@oldproductid", oldProductId);
                cmdRestore.ExecuteNonQuery();

                SqlCommand cmdCheck = new SqlCommand();
                cmdCheck.Connection = con;
                cmdCheck.CommandText = queryCheck;
                cmdCheck.Parameters.AddWithValue("@newproductid", newProductId);

                int availableStock = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (newQuantity > availableStock)
                {
                    MessageBox.Show("Insufficient stock. Available: " + availableStock, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;
                }

                SqlCommand cmdDeduct = new SqlCommand();
                cmdDeduct.Connection = con;
                cmdDeduct.CommandText = queryDeduct;
                cmdDeduct.Parameters.AddWithValue("@newquantity", newQuantity);
                cmdDeduct.Parameters.AddWithValue("@newproductid", newProductId);
                cmdDeduct.ExecuteNonQuery();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = con;
                cmdUpdate.CommandText = queryUpdate;

                cmdUpdate.Parameters.AddWithValue("@productid", newProductId);
                cmdUpdate.Parameters.AddWithValue("@quantity", newQuantity);
                cmdUpdate.Parameters.AddWithValue("@unitprice", newUnitPrice);
                cmdUpdate.Parameters.AddWithValue("@totalprice", newTotalPrice);
                cmdUpdate.Parameters.AddWithValue("@paymethod", newPaymentMethod);
                cmdUpdate.Parameters.AddWithValue("@saleid", saleId);

                cmdUpdate.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Sale updated successfully.", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(null, null);
                btnLoadDatabase_Click(null, null);
                GenerateNextSaleId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
