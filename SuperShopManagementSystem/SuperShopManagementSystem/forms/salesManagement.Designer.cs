namespace SuperShopManagementUsers
{
    partial class salesManagement
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelRightBottom = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panelLeftBottom = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.listBoxProductName = new System.Windows.Forms.ListBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panelPaymentMethod = new System.Windows.Forms.Panel();
            this.comboboxPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.panelQuantity = new System.Windows.Forms.Panel();
            this.panelUnitPrice = new System.Windows.Forms.Panel();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.panelUnit = new System.Windows.Forms.Panel();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblAvailableStock = new System.Windows.Forms.Label();
            this.panelStock = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtSoldBy = new System.Windows.Forms.TextBox();
            this.panelProductName = new System.Windows.Forms.Panel();
            this.panelSoldBy = new System.Windows.Forms.Panel();
            this.lblSoldBy = new System.Windows.Forms.Label();
            this.txtSaleId = new System.Windows.Forms.TextBox();
            this.panelSaleId = new System.Windows.Forms.Panel();
            this.lblSaleId = new System.Windows.Forms.Label();
            this.panelRightTop = new System.Windows.Forms.Panel();
            this.btnDeleteSale = new System.Windows.Forms.Button();
            this.btnLoadDatabase = new System.Windows.Forms.Button();
            this.panelLeftTop = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.btnUpdateSale = new System.Windows.Forms.Button();
            this.btnReturntoDashboard = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelRightBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panelLeftBottom.SuspendLayout();
            this.panelPaymentMethod.SuspendLayout();
            this.panelRightTop.SuspendLayout();
            this.panelLeftTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.66898F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.33102F));
            this.tableLayoutPanel1.Controls.Add(this.panelRightBottom, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelLeftBottom, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelRightTop, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelLeftTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1009, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelRightBottom
            // 
            this.panelRightBottom.BackColor = System.Drawing.Color.Black;
            this.panelRightBottom.Controls.Add(this.dgvData);
            this.panelRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightBottom.Location = new System.Drawing.Point(261, 59);
            this.panelRightBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelRightBottom.Name = "panelRightBottom";
            this.panelRightBottom.Size = new System.Drawing.Size(746, 401);
            this.panelRightBottom.TabIndex = 3;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(746, 401);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.BackColor = System.Drawing.Color.Black;
            this.panelLeftBottom.Controls.Add(this.btnReturntoDashboard);
            this.panelLeftBottom.Controls.Add(this.btnUpdateSale);
            this.panelLeftBottom.Controls.Add(this.btnClear);
            this.panelLeftBottom.Controls.Add(this.btnBuy);
            this.panelLeftBottom.Controls.Add(this.listBoxProductName);
            this.panelLeftBottom.Controls.Add(this.lblPaymentMethod);
            this.panelLeftBottom.Controls.Add(this.lblTotal);
            this.panelLeftBottom.Controls.Add(this.panelPaymentMethod);
            this.panelLeftBottom.Controls.Add(this.lblQuantity);
            this.panelLeftBottom.Controls.Add(this.txtTotal);
            this.panelLeftBottom.Controls.Add(this.txtUnitPrice);
            this.panelLeftBottom.Controls.Add(this.panelTotal);
            this.panelLeftBottom.Controls.Add(this.txtQuantity);
            this.panelLeftBottom.Controls.Add(this.lblUnitPrice);
            this.panelLeftBottom.Controls.Add(this.panelQuantity);
            this.panelLeftBottom.Controls.Add(this.panelUnitPrice);
            this.panelLeftBottom.Controls.Add(this.lblUnit);
            this.panelLeftBottom.Controls.Add(this.txtUnit);
            this.panelLeftBottom.Controls.Add(this.panelUnit);
            this.panelLeftBottom.Controls.Add(this.txtStock);
            this.panelLeftBottom.Controls.Add(this.lblAvailableStock);
            this.panelLeftBottom.Controls.Add(this.panelStock);
            this.panelLeftBottom.Controls.Add(this.lblProductName);
            this.panelLeftBottom.Controls.Add(this.txtProductName);
            this.panelLeftBottom.Controls.Add(this.txtSoldBy);
            this.panelLeftBottom.Controls.Add(this.panelProductName);
            this.panelLeftBottom.Controls.Add(this.panelSoldBy);
            this.panelLeftBottom.Controls.Add(this.lblSoldBy);
            this.panelLeftBottom.Controls.Add(this.txtSaleId);
            this.panelLeftBottom.Controls.Add(this.panelSaleId);
            this.panelLeftBottom.Controls.Add(this.lblSaleId);
            this.panelLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftBottom.Location = new System.Drawing.Point(2, 59);
            this.panelLeftBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeftBottom.Name = "panelLeftBottom";
            this.panelLeftBottom.Size = new System.Drawing.Size(255, 401);
            this.panelLeftBottom.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(12, 294);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 28);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(84)))), ((int)(((byte)(143)))));
            this.btnBuy.FlatAppearance.BorderSize = 0;
            this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.ForeColor = System.Drawing.Color.White;
            this.btnBuy.Location = new System.Drawing.Point(124, 294);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(119, 28);
            this.btnBuy.TabIndex = 24;
            this.btnBuy.Text = "Add To Sale";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnAddToSale_Click);
            // 
            // listBoxProductName
            // 
            this.listBoxProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.listBoxProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxProductName.ForeColor = System.Drawing.Color.White;
            this.listBoxProductName.FormattingEnabled = true;
            this.listBoxProductName.IntegralHeight = false;
            this.listBoxProductName.ItemHeight = 15;
            this.listBoxProductName.Location = new System.Drawing.Point(11, 107);
            this.listBoxProductName.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxProductName.Name = "listBoxProductName";
            this.listBoxProductName.Size = new System.Drawing.Size(133, 18);
            this.listBoxProductName.TabIndex = 9;
            this.listBoxProductName.Visible = false;
            this.listBoxProductName.SelectedIndexChanged += new System.EventHandler(this.listBoxProductName_SelectedIndexChanged);
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.White;
            this.lblPaymentMethod.Location = new System.Drawing.Point(8, 229);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(88, 15);
            this.lblPaymentMethod.TabIndex = 17;
            this.lblPaymentMethod.Text = "Payment Meth.";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(117, 176);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(33, 15);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "Total";
            // 
            // panelPaymentMethod
            // 
            this.panelPaymentMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelPaymentMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPaymentMethod.Controls.Add(this.comboboxPaymentMethod);
            this.panelPaymentMethod.Location = new System.Drawing.Point(12, 249);
            this.panelPaymentMethod.Margin = new System.Windows.Forms.Padding(2);
            this.panelPaymentMethod.Name = "panelPaymentMethod";
            this.panelPaymentMethod.Size = new System.Drawing.Size(101, 26);
            this.panelPaymentMethod.TabIndex = 18;
            // 
            // comboboxPaymentMethod
            // 
            this.comboboxPaymentMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboboxPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboboxPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxPaymentMethod.ForeColor = System.Drawing.Color.White;
            this.comboboxPaymentMethod.FormattingEnabled = true;
            this.comboboxPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Card"});
            this.comboboxPaymentMethod.Location = new System.Drawing.Point(2, 1);
            this.comboboxPaymentMethod.Margin = new System.Windows.Forms.Padding(2);
            this.comboboxPaymentMethod.Name = "comboboxPaymentMethod";
            this.comboboxPaymentMethod.Size = new System.Drawing.Size(93, 23);
            this.comboboxPaymentMethod.TabIndex = 20;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.White;
            this.lblQuantity.Location = new System.Drawing.Point(8, 176);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 15);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "Quantity";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(123, 200);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(116, 16);
            this.txtTotal.TabIndex = 17;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnitPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitPrice.ForeColor = System.Drawing.Color.White;
            this.txtUnitPrice.Location = new System.Drawing.Point(122, 145);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(116, 16);
            this.txtUnitPrice.TabIndex = 13;
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotal.Location = new System.Drawing.Point(118, 195);
            this.panelTotal.Margin = new System.Windows.Forms.Padding(2);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(126, 26);
            this.panelTotal.TabIndex = 18;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.White;
            this.txtQuantity.Location = new System.Drawing.Point(15, 200);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(92, 16);
            this.txtQuantity.TabIndex = 14;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPrice.ForeColor = System.Drawing.Color.White;
            this.lblUnitPrice.Location = new System.Drawing.Point(116, 123);
            this.lblUnitPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(58, 15);
            this.lblUnitPrice.TabIndex = 14;
            this.lblUnitPrice.Text = "Unit Price";
            // 
            // panelQuantity
            // 
            this.panelQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuantity.Location = new System.Drawing.Point(12, 195);
            this.panelQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.panelQuantity.Name = "panelQuantity";
            this.panelQuantity.Size = new System.Drawing.Size(100, 26);
            this.panelQuantity.TabIndex = 15;
            // 
            // panelUnitPrice
            // 
            this.panelUnitPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnitPrice.Location = new System.Drawing.Point(118, 141);
            this.panelUnitPrice.Margin = new System.Windows.Forms.Padding(2);
            this.panelUnitPrice.Name = "panelUnitPrice";
            this.panelUnitPrice.Size = new System.Drawing.Size(126, 26);
            this.panelUnitPrice.TabIndex = 14;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.ForeColor = System.Drawing.Color.White;
            this.lblUnit.Location = new System.Drawing.Point(8, 123);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 15);
            this.lblUnit.TabIndex = 13;
            this.lblUnit.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.ForeColor = System.Drawing.Color.White;
            this.txtUnit.Location = new System.Drawing.Point(15, 146);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(92, 16);
            this.txtUnit.TabIndex = 11;
            // 
            // panelUnit
            // 
            this.panelUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnit.Location = new System.Drawing.Point(12, 141);
            this.panelUnit.Margin = new System.Windows.Forms.Padding(2);
            this.panelUnit.Name = "panelUnit";
            this.panelUnit.Size = new System.Drawing.Size(100, 26);
            this.panelUnit.TabIndex = 12;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.ForeColor = System.Drawing.Color.White;
            this.txtStock.Location = new System.Drawing.Point(156, 86);
            this.txtStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(82, 16);
            this.txtStock.TabIndex = 8;
            // 
            // lblAvailableStock
            // 
            this.lblAvailableStock.AutoSize = true;
            this.lblAvailableStock.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableStock.ForeColor = System.Drawing.Color.White;
            this.lblAvailableStock.Location = new System.Drawing.Point(150, 63);
            this.lblAvailableStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAvailableStock.Name = "lblAvailableStock";
            this.lblAvailableStock.Size = new System.Drawing.Size(37, 15);
            this.lblAvailableStock.TabIndex = 10;
            this.lblAvailableStock.Text = "Stock";
            // 
            // panelStock
            // 
            this.panelStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStock.Location = new System.Drawing.Point(152, 81);
            this.panelStock.Margin = new System.Windows.Forms.Padding(2);
            this.panelStock.Name = "panelStock";
            this.panelStock.Size = new System.Drawing.Size(91, 26);
            this.panelStock.TabIndex = 9;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.White;
            this.lblProductName.Location = new System.Drawing.Point(8, 63);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(84, 15);
            this.lblProductName.TabIndex = 8;
            this.lblProductName.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.ForeColor = System.Drawing.Color.White;
            this.txtProductName.Location = new System.Drawing.Point(14, 85);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(126, 16);
            this.txtProductName.TabIndex = 6;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // txtSoldBy
            // 
            this.txtSoldBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtSoldBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoldBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoldBy.ForeColor = System.Drawing.Color.White;
            this.txtSoldBy.Location = new System.Drawing.Point(105, 35);
            this.txtSoldBy.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoldBy.Name = "txtSoldBy";
            this.txtSoldBy.ReadOnly = true;
            this.txtSoldBy.Size = new System.Drawing.Size(133, 16);
            this.txtSoldBy.TabIndex = 4;
            // 
            // panelProductName
            // 
            this.panelProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProductName.Location = new System.Drawing.Point(12, 81);
            this.panelProductName.Margin = new System.Windows.Forms.Padding(2);
            this.panelProductName.Name = "panelProductName";
            this.panelProductName.Size = new System.Drawing.Size(132, 26);
            this.panelProductName.TabIndex = 7;
            // 
            // panelSoldBy
            // 
            this.panelSoldBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelSoldBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSoldBy.Location = new System.Drawing.Point(102, 30);
            this.panelSoldBy.Margin = new System.Windows.Forms.Padding(2);
            this.panelSoldBy.Name = "panelSoldBy";
            this.panelSoldBy.Size = new System.Drawing.Size(142, 26);
            this.panelSoldBy.TabIndex = 5;
            // 
            // lblSoldBy
            // 
            this.lblSoldBy.AutoSize = true;
            this.lblSoldBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldBy.ForeColor = System.Drawing.Color.White;
            this.lblSoldBy.Location = new System.Drawing.Point(98, 11);
            this.lblSoldBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoldBy.Name = "lblSoldBy";
            this.lblSoldBy.Size = new System.Drawing.Size(47, 15);
            this.lblSoldBy.TabIndex = 3;
            this.lblSoldBy.Text = "Sold By";
            // 
            // txtSaleId
            // 
            this.txtSaleId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtSaleId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSaleId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleId.ForeColor = System.Drawing.Color.White;
            this.txtSaleId.Location = new System.Drawing.Point(14, 35);
            this.txtSaleId.Margin = new System.Windows.Forms.Padding(2);
            this.txtSaleId.Name = "txtSaleId";
            this.txtSaleId.ReadOnly = true;
            this.txtSaleId.Size = new System.Drawing.Size(75, 16);
            this.txtSaleId.TabIndex = 0;
            // 
            // panelSaleId
            // 
            this.panelSaleId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelSaleId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSaleId.Location = new System.Drawing.Point(12, 30);
            this.panelSaleId.Margin = new System.Windows.Forms.Padding(2);
            this.panelSaleId.Name = "panelSaleId";
            this.panelSaleId.Size = new System.Drawing.Size(82, 26);
            this.panelSaleId.TabIndex = 2;
            // 
            // lblSaleId
            // 
            this.lblSaleId.AutoSize = true;
            this.lblSaleId.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleId.ForeColor = System.Drawing.Color.White;
            this.lblSaleId.Location = new System.Drawing.Point(8, 11);
            this.lblSaleId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaleId.Name = "lblSaleId";
            this.lblSaleId.Size = new System.Drawing.Size(45, 15);
            this.lblSaleId.TabIndex = 1;
            this.lblSaleId.Text = "Sale ID";
            // 
            // panelRightTop
            // 
            this.panelRightTop.BackColor = System.Drawing.Color.Black;
            this.panelRightTop.Controls.Add(this.btnDeleteSale);
            this.panelRightTop.Controls.Add(this.btnLoadDatabase);
            this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelRightTop.Location = new System.Drawing.Point(261, 2);
            this.panelRightTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelRightTop.Name = "panelRightTop";
            this.panelRightTop.Size = new System.Drawing.Size(746, 53);
            this.panelRightTop.TabIndex = 1;
            // 
            // btnDeleteSale
            // 
            this.btnDeleteSale.BackColor = System.Drawing.Color.Maroon;
            this.btnDeleteSale.FlatAppearance.BorderSize = 0;
            this.btnDeleteSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSale.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSale.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSale.Location = new System.Drawing.Point(509, 21);
            this.btnDeleteSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteSale.Name = "btnDeleteSale";
            this.btnDeleteSale.Size = new System.Drawing.Size(112, 28);
            this.btnDeleteSale.TabIndex = 24;
            this.btnDeleteSale.Text = "Delete Sale";
            this.btnDeleteSale.UseVisualStyleBackColor = false;
            this.btnDeleteSale.Click += new System.EventHandler(this.btnDeleteSale_Click);
            // 
            // btnLoadDatabase
            // 
            this.btnLoadDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(84)))), ((int)(((byte)(143)))));
            this.btnLoadDatabase.FlatAppearance.BorderSize = 0;
            this.btnLoadDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDatabase.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDatabase.ForeColor = System.Drawing.Color.White;
            this.btnLoadDatabase.Location = new System.Drawing.Point(627, 21);
            this.btnLoadDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadDatabase.Name = "btnLoadDatabase";
            this.btnLoadDatabase.Size = new System.Drawing.Size(112, 28);
            this.btnLoadDatabase.TabIndex = 23;
            this.btnLoadDatabase.Text = "Load/Refresh";
            this.btnLoadDatabase.UseVisualStyleBackColor = false;
            this.btnLoadDatabase.Click += new System.EventHandler(this.btnLoadDatabase_Click);
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.BackColor = System.Drawing.Color.Black;
            this.panelLeftTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftTop.Controls.Add(this.lblName);
            this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftTop.Location = new System.Drawing.Point(2, 2);
            this.panelLeftTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Size = new System.Drawing.Size(255, 53);
            this.panelLeftTop.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(84)))), ((int)(((byte)(143)))));
            this.lblName.Location = new System.Drawing.Point(8, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(234, 32);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Sales Management";
            // 
            // btnUpdateSale
            // 
            this.btnUpdateSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(84)))), ((int)(((byte)(143)))));
            this.btnUpdateSale.FlatAppearance.BorderSize = 0;
            this.btnUpdateSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSale.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSale.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSale.Location = new System.Drawing.Point(11, 330);
            this.btnUpdateSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateSale.Name = "btnUpdateSale";
            this.btnUpdateSale.Size = new System.Drawing.Size(233, 28);
            this.btnUpdateSale.TabIndex = 26;
            this.btnUpdateSale.Text = "Update Sale";
            this.btnUpdateSale.UseVisualStyleBackColor = false;
            this.btnUpdateSale.Click += new System.EventHandler(this.btnUpdateSale_Click);
            // 
            // btnReturntoDashboard
            // 
            this.btnReturntoDashboard.BackColor = System.Drawing.Color.Maroon;
            this.btnReturntoDashboard.FlatAppearance.BorderSize = 0;
            this.btnReturntoDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturntoDashboard.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturntoDashboard.ForeColor = System.Drawing.Color.White;
            this.btnReturntoDashboard.Location = new System.Drawing.Point(11, 365);
            this.btnReturntoDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturntoDashboard.Name = "btnReturntoDashboard";
            this.btnReturntoDashboard.Size = new System.Drawing.Size(233, 28);
            this.btnReturntoDashboard.TabIndex = 25;
            this.btnReturntoDashboard.Text = "Return to Dashboard";
            this.btnReturntoDashboard.UseVisualStyleBackColor = false;
            // 
            // salesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "salesManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Management";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelRightBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panelLeftBottom.ResumeLayout(false);
            this.panelLeftBottom.PerformLayout();
            this.panelPaymentMethod.ResumeLayout(false);
            this.panelRightTop.ResumeLayout(false);
            this.panelLeftTop.ResumeLayout(false);
            this.panelLeftTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelRightBottom;
        private System.Windows.Forms.Panel panelLeftBottom;
        private System.Windows.Forms.Panel panelRightTop;
        private System.Windows.Forms.Panel panelLeftTop;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblSaleId;
        private System.Windows.Forms.TextBox txtSaleId;
        private System.Windows.Forms.Panel panelSaleId;
        private System.Windows.Forms.Label lblSoldBy;
        private System.Windows.Forms.TextBox txtSoldBy;
        private System.Windows.Forms.Panel panelSoldBy;
        private System.Windows.Forms.ListBox listBoxProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Panel panelProductName;
        private System.Windows.Forms.Label lblAvailableStock;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Panel panelUnit;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Panel panelStock;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Panel panelUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Panel panelQuantity;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Panel panelPaymentMethod;
        private System.Windows.Forms.ComboBox comboboxPaymentMethod;
        private System.Windows.Forms.Button btnLoadDatabase;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnDeleteSale;
        private System.Windows.Forms.Button btnUpdateSale;
        private System.Windows.Forms.Button btnReturntoDashboard;
    }
}