namespace Office
{
	partial class GainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgvGain = new System.Windows.Forms.DataGridView();
			this.edtCurrentPayments = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.edtTotal = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtFine = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnExportXL = new System.Windows.Forms.ToolStripButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGain)).BeginInit();
			this.panel2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.dgvGain);
			this.panel1.Location = new System.Drawing.Point(1, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(879, 310);
			this.panel1.TabIndex = 0;
			// 
			// dgvGain
			// 
			this.dgvGain.AllowUserToAddRows = false;
			this.dgvGain.AllowUserToDeleteRows = false;
			this.dgvGain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvGain.Location = new System.Drawing.Point(0, 0);
			this.dgvGain.Name = "dgvGain";
			this.dgvGain.ReadOnly = true;
			this.dgvGain.Size = new System.Drawing.Size(879, 310);
			this.dgvGain.TabIndex = 0;
			// 
			// edtCurrentPayments
			// 
			this.edtCurrentPayments.Location = new System.Drawing.Point(191, 8);
			this.edtCurrentPayments.Name = "edtCurrentPayments";
			this.edtCurrentPayments.Size = new System.Drawing.Size(118, 20);
			this.edtCurrentPayments.TabIndex = 1;
			this.edtCurrentPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "выплачено в текущем месяце";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.edtFine);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.edtTotal);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.edtCurrentPayments);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 347);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(881, 95);
			this.panel2.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(73, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "ожидаемая прибыль";
			// 
			// edtTotal
			// 
			this.edtTotal.Location = new System.Drawing.Point(191, 34);
			this.edtTotal.Name = "edtTotal";
			this.edtTotal.Size = new System.Drawing.Size(118, 20);
			this.edtTotal.TabIndex = 4;
			this.edtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(88, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "в частности, пеня";
			// 
			// edtFine
			// 
			this.edtFine.Location = new System.Drawing.Point(191, 60);
			this.edtFine.Name = "edtFine";
			this.edtFine.Size = new System.Drawing.Size(118, 20);
			this.edtFine.TabIndex = 6;
			this.edtFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportXL});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(881, 39);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnExportXL
			// 
			this.btnExportXL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnExportXL.Image = ((System.Drawing.Image)(resources.GetObject("btnExportXL.Image")));
			this.btnExportXL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExportXL.Name = "btnExportXL";
			this.btnExportXL.Size = new System.Drawing.Size(36, 36);
			this.btnExportXL.Text = "toolStripButton1";
			this.btnExportXL.Click += new System.EventHandler(this.btnExportXL_Click);
			// 
			// GainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(881, 442);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "GainForm";
			this.Text = "Расчёт прибыли";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGain)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dgvGain;
		private System.Windows.Forms.TextBox edtCurrentPayments;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox edtFine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox edtTotal;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnExportXL;
	}
}