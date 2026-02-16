using SuperShopManagementSystem;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SuperShopManagementSystem
{
    public partial class myProfile : Form
    {
        public myProfile()
        {
            InitializeComponent();
        }

        private void myProfile_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            try
            {
                int userId = Login.LoggedinUserId;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT FullName, Role, PhoneNumber, Email, Gender, DOB FROM UserInfo WHERE ID = {userId}";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                con.Close();

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];

                    lblUserName.Text = row["FullName"].ToString();
                    lblUserRole.Text = row["Role"].ToString();

                    lblNameValue.Text = row["FullName"].ToString();
                    lblPhoneNumberValue.Text = row["PhoneNumber"].ToString();
                    lblEmailValue.Text = row["Email"].ToString();
                    lblGenderValue.Text = row["Gender"].ToString();
                    lblRoleNameValue.Text = row["Role"].ToString();

                    if (row["DOB"] != DBNull.Value)
                    {
                        lblDateOfBirthValue.Text = Convert.ToDateTime(row["DOB"]).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        lblDateOfBirthValue.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
           
            editProfile ep = new editProfile();
            ep.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {

        }
    }
}
