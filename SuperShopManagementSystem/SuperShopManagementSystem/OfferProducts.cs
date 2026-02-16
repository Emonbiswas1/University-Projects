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
    public partial class OfferProducts : Form
    {
        public OfferProducts()
        {
            InitializeComponent();
        }

        private void OfferProducts_Load(object sender, EventArgs e)
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
                cmd.CommandText = $"select * from Products";
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                con.Close();
                DataTable dt = ds.Tables[0];
                dgvProducts.DataSource = dt;
                dgvProducts.Refresh();


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
