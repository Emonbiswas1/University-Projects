namespace SuperShopManagementSystem
{
    partial class EmployeeDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPf = new System.Windows.Forms.Button();
            this.btnSl = new System.Windows.Forms.Button();
            this.lbEd = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnPf);
            this.panel1.Controls.Add(this.btnSl);
            this.panel1.Controls.Add(this.lbEd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 622);
            this.panel1.TabIndex = 0;
            // 
            // btnPf
            // 
            this.btnPf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPf.AutoSize = true;
            this.btnPf.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnPf.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPf.Location = new System.Drawing.Point(622, 290);
            this.btnPf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPf.Name = "btnPf";
            this.btnPf.Size = new System.Drawing.Size(257, 176);
            this.btnPf.TabIndex = 2;
            this.btnPf.Text = "PROFILE";
            this.btnPf.UseVisualStyleBackColor = false;
            this.btnPf.Click += new System.EventHandler(this.btnPf_Click_1);
            // 
            // btnSl
            // 
            this.btnSl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSl.AutoSize = true;
            this.btnSl.BackColor = System.Drawing.Color.Orchid;
            this.btnSl.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSl.Location = new System.Drawing.Point(81, 290);
            this.btnSl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSl.Name = "btnSl";
            this.btnSl.Size = new System.Drawing.Size(395, 176);
            this.btnSl.TabIndex = 1;
            this.btnSl.Text = "SELL PRODUCT";
            this.btnSl.UseVisualStyleBackColor = false;
            this.btnSl.Click += new System.EventHandler(this.btnSl_Click);
            // 
            // lbEd
            // 
            this.lbEd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbEd.AutoSize = true;
            this.lbEd.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEd.Location = new System.Drawing.Point(241, 91);
            this.lbEd.Name = "lbEd";
            this.lbEd.Size = new System.Drawing.Size(603, 53);
            this.lbEd.TabIndex = 0;
            this.lbEd.Text = "EMPLOYEE DASHBOARD";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(936, 535);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(117, 50);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // EmployeeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 622);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EmployeeDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSl;
        private System.Windows.Forms.Label lbEd;
        private System.Windows.Forms.Button btnPf;
        private System.Windows.Forms.Button btnBack;
    }
}