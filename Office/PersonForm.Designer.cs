namespace Office
{
	partial class PersonForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnOk = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.edtPersonName = new System.Windows.Forms.TextBox();
			this.lstPersons = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btnOk);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 415);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(295, 34);
			this.panel1.TabIndex = 5;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(206, 5);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 22);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.lstPersons);
			this.panel2.Controls.Add(this.edtPersonName);
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(295, 415);
			this.panel2.TabIndex = 6;
			// 
			// edtPersonName
			// 
			this.edtPersonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.edtPersonName.Location = new System.Drawing.Point(12, 150);
			this.edtPersonName.Name = "edtPersonName";
			this.edtPersonName.Size = new System.Drawing.Size(271, 20);
			this.edtPersonName.TabIndex = 0;
			this.edtPersonName.TextChanged += new System.EventHandler(this.edtPersonName_TextChanged);
			// 
			// lstPersons
			// 
			this.lstPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstPersons.FormattingEnabled = true;
			this.lstPersons.Location = new System.Drawing.Point(12, 176);
			this.lstPersons.Name = "lstPersons";
			this.lstPersons.Size = new System.Drawing.Size(271, 225);
			this.lstPersons.TabIndex = 1;
			this.lstPersons.DoubleClick += new System.EventHandler(this.lstPersons_DoubleClick);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(274, 138);
			this.label1.TabIndex = 2;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// PersonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(295, 449);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "PersonForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Персоны";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonForm_FormClosing);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox edtPersonName;
		private System.Windows.Forms.ListBox lstPersons;
		private System.Windows.Forms.Label label1;
	}
}