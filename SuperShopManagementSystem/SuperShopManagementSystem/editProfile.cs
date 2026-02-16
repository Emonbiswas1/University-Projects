using SuperShopManagementSystem;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SuperShopManagementSystem
{
    public partial class editProfile : Form
    {
        public editProfile()
        {
            InitializeComponent();
        }

        private void editProfile_Load(object sender, EventArgs e)
        {
            this.LoadProfile();
        }

        private void LoadProfile()
        {
            try
            {
                int userId = Login.LoggedinUserId;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT ID, FullName, PhoneNumber, Email, Role, Gender, DOB FROM UserInfo WHERE ID = {userId}";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                con.Close();

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];

                    txtUserID.Text = row["ID"].ToString();
                    txtName.Text = row["FullName"].ToString();
                    txtPhoneNumber.Text = row["PhoneNumber"].ToString();
                    txtEmail.Text = row["Email"].ToString();

                    comboBoxRole.Text = row["Role"].ToString();
                    comboBoxGender.Text = row["Gender"].ToString();

                    if (row["DOB"] != DBNull.Value)
                    {
                        pickerDOB.Value = Convert.ToDateTime(row["DOB"]);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmail.Text;

            if (name == "")
            {
                MessageBox.Show("Name cannot be empty");
                txtName.Focus();
                return;
            }

            if (phone == "")
            {
                MessageBox.Show("Phone number cannot be empty");
                txtPhoneNumber.Focus();
                return;
            }

            if (phone.Length != 11)
            {
                MessageBox.Show("Phone number must be 11 digits");
                txtPhoneNumber.Focus();
                return;
            }

            for (int i = 0; i < phone.Length; i++)
            {
                if (!char.IsDigit(phone[i]))
                {
                    MessageBox.Show("Phone number must contain only digits");
                    txtPhoneNumber.Focus();
                    return;
                }
            }

            if (email == "")
            {
                MessageBox.Show("Email cannot be empty");
                txtEmail.Focus();
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Invalid Email address");
                txtEmail.Focus();
                return;
            }

            if (comboBoxGender.SelectedItem == null && comboBoxGender.Text == "")
            {
                MessageBox.Show("Please Select Your Gender");
                comboBoxGender.Focus();
                return;
            }

            try
            {
                DateTime dob = DateTime.Parse(pickerDOB.Text);
                double years = (DateTime.Now - dob).TotalDays / 365;

                if (years < 18)
                {
                    MessageBox.Show("Age must be 18 or above");
                    pickerDOB.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Date of Birth");
                pickerDOB.Focus();
                return;
            }

            try
            {
                int userId = Login.LoggedinUserId;
                string gender = comboBoxGender.Text;

                string dobStr = pickerDOB.Value.ToString("yyyy-MM-dd");

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText =
                    $"UPDATE UserInfo SET FullName='{txtName.Text}', PhoneNumber='{txtPhoneNumber.Text}', Email='{txtEmail.Text}', Gender='{gender}', DOB='{dobStr}' WHERE ID={userId}";

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Operation Successful");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myProfile mp = new myProfile();
            mp.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            myProfile mp = new myProfile();
            mp.Show();
            this.Close();
        }
    }
}
