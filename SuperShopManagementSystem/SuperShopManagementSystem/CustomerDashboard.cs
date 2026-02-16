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
    public partial class CustomerDashboard : Form
    {
        public CustomerDashboard()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnVisit_Click(object sender, EventArgs e)
        {
            OfferProducts op = new OfferProducts();
            op.Show(this);
            this.Hide();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            myProfile mp = new myProfile();
            mp.Show();
            this.Hide();
        }
    }
}
