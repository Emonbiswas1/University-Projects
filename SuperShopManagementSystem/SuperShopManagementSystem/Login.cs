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

namespace SuperShopManagementSystem
{
    public partial class Login : Form
    {

        //code added by shanjida to store logged in user info
        public static int LoggedinUserId;
        public static string LoggedinUserRole;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPass.Text;

            try
            {
                var connection = new SqlConnection();
                connection.ConnectionString = ApplicationHelper.CS;
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $"select * from UserInfo where Email='{email}'and Password='{password}'";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                connection.Close();

                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Invalid Data");
                    return;
                }

                string name = dt.Rows[0]["FullName"].ToString();
                string type = dt.Rows[0]["Role"].ToString();

                //Code added by Shanjida to get UserId and store in LoggedinUserId
                int userId = Convert.ToInt32(dt.Rows[0]["ID"]);
                Login.LoggedinUserId = userId;
                Login.LoggedinUserRole = type;

                MessageBox.Show("Welcome, " + name);

                if (type == "Admin")
                {
                    AdminDashboard ad = new AdminDashboard();
                    ad.Show();
                    this.Hide();
                }

                else if (type == "Manager")
                {
                    ManagerDashboard md = new ManagerDashboard();
                    md.Show();
                    this.Hide();
                }
                // (type == "Employee")
                else if (type == "Employee")
                {
                    EmployeeDashboard ep = new EmployeeDashboard();
                    ep.Show();
                    this.Hide();
                }

                else
                {
                    CustomerDashboard cd = new CustomerDashboard();
                    cd.Show();
                    this.Hide();
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_MouseHover(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void btnShow_MouseLeave(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnSU_Click(object sender, EventArgs e)
        {
            Registration rs = new Registration();
            rs.Show();
            this.Hide();

        }
    }

}
    

