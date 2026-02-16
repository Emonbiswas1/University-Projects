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
    public partial class SalesInformation : Form
    {
        public SalesInformation()
        {
            InitializeComponent();
        }

        private void SalesInformation_Load(object sender, EventArgs e)
        {
            this.LoadProducts();
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
                cmd.CommandText = $"select * from Sales";
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                con.Close();
                DataTable dt = ds.Tables[0];
                dgvSales.DataSource = dt;
                dgvSales.Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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
