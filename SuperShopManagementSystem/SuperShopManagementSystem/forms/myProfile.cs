using SuperShopManagementSystem;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SuperShopManagementUsers
{
    public partial class myProfile : Form
    {
        private int userID;
        private string userRole;
        //string connectionString = ConfigurationManager.ConnectionStrings["ShopDb"].ConnectionString;

        public myProfile(int userId, string userRole)
        {
            InitializeComponent();
            this.userID = userId;
            this.userRole = userRole;
        }

        private void myProfile_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT FullName, RoleName, Phone, Email, Address, Gender, DateOfBirth FROM Users WHERE UserId = @UserId";

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

                    lblUserName.Text = row["FullName"].ToString();
                    lblUserRole.Text = row["RoleName"].ToString();

                    lblNameValue.Text = row["FullName"].ToString();
                    lblPhoneNumberValue.Text = row["Phone"].ToString();
                    lblEmailValue.Text = row["Email"].ToString();
                    lblGenderValue.Text = row["Gender"].ToString();
                    lblRoleNameValue.Text = row["RoleName"].ToString();

                    if (row["DateOfBirth"] != DBNull.Value)
                    {
                        lblDateOfBirthValue.Text =
                            Convert.ToDateTime(row["DateOfBirth"]).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        lblDateOfBirthValue.Text = "";
                    }

                    lblAddressValue.Text = row["Address"].ToString();
                }


                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            editProfile ep = new editProfile(userID, userRole);
            ep.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

        }

    }
}
