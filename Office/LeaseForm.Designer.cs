namespace Office
{
	partial class LeaseForm
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
			this.label4 = new System.Windows.Forms.Label();
			this.rdbClosedOnly = new System.Windows.Forms.RadioButton();
			this.rdbPeriod = new System.Windows.Forms.RadioButton();
			this.pnlPeriod = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.dtpBeginPeriod = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpEndPeriod = new System.Windows.Forms.DateTimePicker();
			this.btnShow = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnCreate = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgvLeasing = new System.Windows.Forms.DataGridView();
			this.btnDelete = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.pnlPeriod.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLeasing)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.rdbClosedOnly);
			this.panel1.Controls.Add(this.rdbPeriod);
			this.panel1.Controls.Add(this.pnlPeriod);
			this.panel1.Controls.Add(this.btnShow);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(971, 35);
			this.panel1.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(406, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "либо";
			// 
			// rdbClosedOnly
			// 
			this.rdbClosedOnly.AutoSize = true;
			this.rdbClosedOnly.Location = new System.Drawing.Point(443, 7);
			this.rdbClosedOnly.Name = "rdbClosedOnly";
			this.rdbClosedOnly.Size = new System.Drawing.Size(126, 17);
			this.rdbClosedOnly.TabIndex = 7;
			this.rdbClosedOnly.TabStop = true;
			this.rdbClosedOnly.Text = "только незакрытые";
			this.rdbClosedOnly.UseVisualStyleBackColor = true;
			// 
			// rdbPeriod
			// 
			this.rdbPeriod.AutoSize = true;
			this.rdbPeriod.Checked = true;
			this.rdbPeriod.Location = new System.Drawing.Point(75, 7);
			this.rdbPeriod.Name = "rdbPeriod";
			this.rdbPeriod.Size = new System.Drawing.Size(76, 17);
			this.rdbPeriod.TabIndex = 6;
			this.rdbPeriod.TabStop = true;
			this.rdbPeriod.Text = "за период";
			this.rdbPeriod.UseVisualStyleBackColor = true;
			// 
			// pnlPeriod
			// 
			this.pnlPeriod.Controls.Add(this.label3);
			this.pnlPeriod.Controls.Add(this.dtpBeginPeriod);
			this.pnlPeriod.Controls.Add(this.label2);
			this.pnlPeriod.Controls.Add(this.dtpEndPeriod);
			this.pnlPeriod.Location = new System.Drawing.Point(157, 3);
			this.pnlPeriod.Name = "pnlPeriod";
			this.pnlPeriod.Size = new System.Drawing.Size(243, 26);
			this.pnlPeriod.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(13, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "с";
			// 
			// dtpBeginPeriod
			// 
			this.dtpBeginPeriod.CustomFormat = "dd.MM.yyyy";
			this.dtpBeginPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpBeginPeriod.Location = new System.Drawing.Point(22, 3);
			this.dtpBeginPeriod.Name = "dtpBeginPeriod";
			this.dtpBeginPeriod.Size = new System.Drawing.Size(92, 20);
			this.dtpBeginPeriod.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(120, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(19, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "по";
			// 
			// dtpEndPeriod
			// 
			this.dtpEndPeriod.CustomFormat = "dd.MM.yyyy";
			this.dtpEndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndPeriod.Location = new System.Drawing.Point(145, 3);
			this.dtpEndPeriod.Name = "dtpEndPeriod";
			this.dtpEndPeriod.Size = new System.Drawing.Size(92, 20);
			this.dtpEndPeriod.TabIndex = 1;
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(575, 3);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(75, 23);
			this.btnShow.TabIndex = 4;
			this.btnShow.Text = "показать";
			this.btnShow.UseVisualStyleBackColor = true;
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "документы";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.btnDelete);
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Controls.Add(this.btnCreate);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 410);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(971, 40);
			this.panel2.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(159, 6);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(140, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Закрыть договор";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(3, 6);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(148, 23);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "Новый договор аренды";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.dgvLeasing);
			this.panel3.Location = new System.Drawing.Point(0, 35);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(971, 373);
			this.panel3.TabIndex = 2;
			// 
			// dgvLeasing
			// 
			this.dgvLeasing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLeasing.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvLeasing.Location = new System.Drawing.Point(0, 0);
			this.dgvLeasing.Name = "dgvLeasing";
			this.dgvLeasing.Size = new System.Drawing.Size(971, 373);
			this.dgvLeasing.TabIndex = 0;
			this.dgvLeasing.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvLeasing_RowStateChanged);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(305, 6);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Удалить";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// LeaseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 450);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "LeaseForm";
			this.Text = "Отдел договоров";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlPeriod.ResumeLayout(false);
			this.pnlPeriod.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvLeasing)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DateTimePicker dtpBeginPeriod;
		private System.Windows.Forms.DateTimePicker dtpEndPeriod;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgvLeasing;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.RadioButton rdbPeriod;
		private System.Windows.Forms.Panel pnlPeriod;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton rdbClosedOnly;
		private System.Windows.Forms.Button btnDelete;
	}
}