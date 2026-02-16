using SuperShopManagementSystem;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace SuperShopManagementUsers
{
    public partial class editProfile : Form
    {
        private int userID;
        private string userRole;
        //string connectionString = ConfigurationManager.ConnectionStrings["ShopDb"].ConnectionString;

        public editProfile(int userId, string roleName)
        {
            InitializeComponent();
            this.userID = userId;
            this.userRole = roleName;
        }

        private void editProfile_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT UserId, FullName, Phone, Email, Address, RoleName, Gender, DateOfBirth 
                FROM Users WHERE UserId = @UserId";

                cmd.Parameters.AddWithValue("@UserId", userID);

                con.Open();
                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtUserID.Text = row["UserId"].ToString();
                    txtName.Text = row["FullName"].ToString();
                    txtPhoneNumber.Text = row["Phone"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                    comboBoxRole.Text = row["RoleName"].ToString();
                    comboBoxGender.Text = row["Gender"].ToString();

                    if (row["DateOfBirth"] != DBNull.Value)
                    {
                        pickerDOB.Value = Convert.ToDateTime(row["DateOfBirth"]);
                    }
                }
                else
                {
                    MessageBox.Show("Admin user not found in database.");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            
            if (name == "") 
            {
                MessageBox.Show("Name cannot be empty.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (phone == "")
            {
                MessageBox.Show("Phone number cannot be empty.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                return;
            }
            else
            {
                if (phone.Length != 11)
                {
                    MessageBox.Show("Phone number is not 11 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNumber.Focus();
                    return;
                }

                for (int i = 0; i < phone.Length; i++)
                {
                    if (!char.IsDigit(phone[i]))
                    {
                        MessageBox.Show("Phone number must contain only digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPhoneNumber.Focus();
                        return;
                    }
                }
            }

            if (email == "")
            {
                MessageBox.Show("Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            else
            {
                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Invalid Email address.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
            }

            if (comboBoxGender.SelectedItem == null)
            {
                MessageBox.Show("Please Select Your Gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxGender.Focus();
                return;
            }

            try
            {
                DateTime dob = DateTime.Parse(pickerDOB.Text);

                double years = (DateTime.Now - dob).TotalDays / 365;

                if (years < 18)
                {
                    MessageBox.Show("Age must be 18 or above.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pickerDOB.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Date of Birth.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                pickerDOB.Focus();
                return;
            }

            if (address == "")
            {
                MessageBox.Show("Please Provide a Valid Address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }



            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"UPDATE Users SET FullName = @FullName, Phone = @Phone, Email = @Email, 
                Address = @Address, Gender = @Gender, DateOfBirth = @DateOfBirth WHERE UserId = @UserId";

                cmd.Parameters.AddWithValue("@FullName", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", comboBoxGender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@DateOfBirth", pickerDOB.Value);
                cmd.Parameters.AddWithValue("@UserId", userID);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows > 0)
                {
                    MessageBox.Show("Profile updated successfully.");
                }
                else
                {
                    MessageBox.Show("No changes were made.");
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
