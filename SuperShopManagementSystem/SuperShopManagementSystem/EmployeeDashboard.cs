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
    public partial class EmployeeDashboard : Form
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        

        private void btnSl_Click(object sender, EventArgs e)
        {
            SalesBoard sb = new SalesBoard();
            sb.Show(this);
            this.Hide();
        }

        
        //Code Added by shanjida for my profile
        

        private void btnPf_Click_1(object sender, EventArgs e)
        {
            myProfile mp = new myProfile();
            mp.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
