namespace Office
{
	partial class PaymentForm
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgvAccounts = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgvPayments = new System.Windows.Forms.DataGridView();
			this.btnPay = new System.Windows.Forms.Button();
			this.pnlCreatePayment = new System.Windows.Forms.Panel();
			this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.edtPayment = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.erpValidator = new System.Windows.Forms.ErrorProvider(this.components);
			this.btnSave = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
			this.pnlCreatePayment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.erpValidator)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.pnlCreatePayment);
			this.panel1.Controls.Add(this.btnPay);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 430);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(640, 86);
			this.panel1.TabIndex = 0;
			// 
			// dgvAccounts
			// 
			this.dgvAccounts.AllowUserToAddRows = false;
			this.dgvAccounts.AllowUserToDeleteRows = false;
			this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAccounts.Location = new System.Drawing.Point(0, 0);
			this.dgvAccounts.MultiSelect = false;
			this.dgvAccounts.Name = "dgvAccounts";
			this.dgvAccounts.ReadOnly = true;
			this.dgvAccounts.Size = new System.Drawing.Size(433, 424);
			this.dgvAccounts.TabIndex = 1;
			this.dgvAccounts.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvAccounts_RowStateChanged);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.dgvAccounts);
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(437, 428);
			this.panel2.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.dgvPayments);
			this.panel3.Location = new System.Drawing.Point(437, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(202, 428);
			this.panel3.TabIndex = 3;
			// 
			// dgvPayments
			// 
			this.dgvPayments.AllowUserToAddRows = false;
			this.dgvPayments.AllowUserToDeleteRows = false;
			this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPayments.Location = new System.Drawing.Point(0, 0);
			this.dgvPayments.MultiSelect = false;
			this.dgvPayments.Name = "dgvPayments";
			this.dgvPayments.ReadOnly = true;
			this.dgvPayments.Size = new System.Drawing.Size(198, 424);
			this.dgvPayments.TabIndex = 0;
			// 
			// btnPay
			// 
			this.btnPay.Location = new System.Drawing.Point(10, 9);
			this.btnPay.Name = "btnPay";
			this.btnPay.Size = new System.Drawing.Size(121, 23);
			this.btnPay.TabIndex = 0;
			this.btnPay.Text = "Внести платёж";
			this.btnPay.UseVisualStyleBackColor = true;
			this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
			// 
			// pnlCreatePayment
			// 
			this.pnlCreatePayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCreatePayment.Controls.Add(this.btnSave);
			this.pnlCreatePayment.Controls.Add(this.label2);
			this.pnlCreatePayment.Controls.Add(this.edtPayment);
			this.pnlCreatePayment.Controls.Add(this.label1);
			this.pnlCreatePayment.Controls.Add(this.dtpPaymentDate);
			this.pnlCreatePayment.Enabled = false;
			this.pnlCreatePayment.Location = new System.Drawing.Point(138, 9);
			this.pnlCreatePayment.Name = "pnlCreatePayment";
			this.pnlCreatePayment.Size = new System.Drawing.Size(297, 63);
			this.pnlCreatePayment.TabIndex = 1;
			// 
			// dtpPaymentDate
			// 
			this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpPaymentDate.Location = new System.Drawing.Point(90, 3);
			this.dtpPaymentDate.Name = "dtpPaymentDate";
			this.dtpPaymentDate.Size = new System.Drawing.Size(96, 20);
			this.dtpPaymentDate.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "дата платежа";
			// 
			// edtPayment
			// 
			this.edtPayment.Location = new System.Drawing.Point(92, 30);
			this.edtPayment.Name = "edtPayment";
			this.edtPayment.Size = new System.Drawing.Size(94, 20);
			this.edtPayment.TabIndex = 2;
			this.edtPayment.Validating += new System.ComponentModel.CancelEventHandler(this.edtPayment_Validating);
			this.edtPayment.Validated += new System.EventHandler(this.edtPayment_Validated);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(44, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "сумма";
			// 
			// erpValidator
			// 
			this.erpValidator.ContainerControl = this;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(208, 30);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// PaymentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 516);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "PaymentForm";
			this.Text = "Реестр платежей";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
			this.pnlCreatePayment.ResumeLayout(false);
			this.pnlCreatePayment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.erpValidator)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dgvAccounts;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgvPayments;
		private System.Windows.Forms.Button btnPay;
		private System.Windows.Forms.Panel pnlCreatePayment;
		private System.Windows.Forms.DateTimePicker dtpPaymentDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtPayment;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ErrorProvider erpValidator;
		private System.Windows.Forms.Button btnSave;
	}
}