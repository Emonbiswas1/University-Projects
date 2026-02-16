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
    public partial class Hire_Employee : Form
    {
        public Hire_Employee()
        {
            InitializeComponent();
        }

        private void Hire_Employee_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select* from UserInfo";

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

        private void btnRf_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPass.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPno.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
                dtpDOB.Text = dgvData.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSal.Text = dgvData.Rows[e.RowIndex].Cells[8].Value.ToString();

                string gender = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();

                if (gender == "Male")
                {
                    rbtnM.Checked = true;
                }
                else if (gender == "Female")
                {
                    rbtnF.Checked = true;
                }

                string role = dgvData.Rows[e.RowIndex].Cells[7].Value.ToString();

                if (role == "Employee")
                {
                    rbtnEm.Checked = true;
                }
                else if (role == "Manager")
                {
                    rbtnMng.Checked = true;
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Close();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            txtID.Text = "Auto Generated";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPno.Text = "";
            dtpDOB.Text = "";
            txtSal.Text = "";
            rbtnM.Checked = false;
            rbtnF.Checked = false;
            rbtnEm.Checked = false;
            rbtnMng.Checked = false;
            dgvData.ClearSelection();

        }

        private void btnDlt_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "Auto Generated")
            {
                MessageBox.Show("Please select a row first");
                return;
            }
            var result = MessageBox.Show("Are you sure ?", "confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            { return; }

            try
            {

                SqlConnection con = new SqlConnection(ApplicationHelper.CS);
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from UserInfo where id={id}";

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfully Deleted !", "Confirmation");

                this.LoadData();
                this.NewData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnSv_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string ph = txtPno.Text;
            string dob = dtpDOB.Value.ToString("yyyy-MM-dd");
            string sal = txtSal.Text;

            string gender = "";
            if (rbtnM.Checked)
            {
                gender = "Male";
            }
            else if (rbtnF.Checked)
            {
                gender = "Female";
            }

            string role = "";
            if (rbtnEm.Checked)
            {
                role = "Employee";
            }
            else if (rbtnMng.Checked)
            {
                role = "Manager";

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

            string query = "";

            if (id == "Auto Generated")
            {
                query = query = $"insert into UserInfo (FullName, Email,Password, PhoneNumber, Salary, Gender, DOB, Role) " + $"values('{name}', '{email}','{pass}', '{ph}', '{sal}', '{gender}', '{dob}', '{role}')";


            }
            else
            {
                query = $"update UserInfo set " + $"FullName='{name}', " + $"PhoneNumber='{ph}', " + $"Salary='{sal}', " + $"DOB='{dob}', " + $"Gender='{gender}', " + $"Role='{role}' " + $"where ID='{id}'";

            }

            try
            {

                SqlConnection con = new SqlConnection(ApplicationHelper.CS);
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfully Added !", "Confirmation");

                this.LoadData();
                this.NewData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


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
                    cmd.CommandText = $"select * from UserInfo";

                }
                else
                {
                    cmd.CommandText = $"SELECT * FROM UserInfo WHERE FullName like '%{search}%' OR Role LIKE '%{search}%'";
                }
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                con.Close();
                DataTable dt = ds.Tables[0];
                dgvData.DataSource = dt;
                dgvData.Refresh();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

    }
}

