using SuperShopManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login lf = new Login();
            lf.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product_Information pi = new Product_Information();
            pi.Show(this);
            this.Hide();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Hire_Employee hemp = new Hire_Employee();
            hemp.Show(this);
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnVisit_Click(object sender, EventArgs e)
        {
            SalesInformation si = new SalesInformation();
            si.Show(this);
            this.Hide();
        }

        

        
        private void btnView_Click(object sender, EventArgs e)
        {
            myProfile mp = new myProfile();
            mp.Show();
            this.Hide();
        }


        private void btnMngSales_Click(object sender, EventArgs e)
        {
            salesManagement sm = new salesManagement();
            sm.Show();
            this.Hide();

        }
    }
}
