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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string ph = txtPno.Text;
            string dob = dtpDOB.Value.ToString("yyyy-MM-dd");
            

            string gender = " ";
            if (rbtnF.Checked == true)
            {
                gender = "Female";
            }
            else if (rbtnM.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                MessageBox.Show("Gender is not defined!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string role = "";
           
            if (rbtnCustomer.Checked == true)
            {
                role = "Customer";
            }
            else
            {
                MessageBox.Show("User Type is not defined!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (name == "")
            {
                MessageBox.Show("Username is empty");
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Email must contain @");
                return;
            }

            if (pass.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters");
                return;
            }

            if (ph == "" || ph.Length < 11)
            {
                MessageBox.Show("Phone number must be 11 digits");
                return;
            }





            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into UserInfo (FullName, Email,Password, PhoneNumber,  Gender, DOB, Role) values('{name}', '{email}','{pass}', '{ph}', '{gender}', '{dob}', '{role}')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registration Successfull :)");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            if (txtPass.UseSystemPasswordChar)
            {
                txtPass.UseSystemPasswordChar = false;
                btnPass.Text = "H";
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                btnPass.Text = "S";
            }
        }
    }
}
