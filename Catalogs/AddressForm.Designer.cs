namespace Catalogs
{
	partial class AddressForm
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
			this.cbxElement = new System.Windows.Forms.ComboBox();
			this.cbxCity = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnOk = new System.Windows.Forms.Button();
			this.cbxStreet = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.edtBuildingNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.edtOfficeNo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.edtOfficeNo);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.edtBuildingNo);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cbxStreet);
			this.panel1.Controls.Add(this.cbxElement);
			this.panel1.Controls.Add(this.cbxCity);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(351, 126);
			this.panel1.TabIndex = 0;
			// 
			// cbxElement
			// 
			this.cbxElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxElement.FormattingEnabled = true;
			this.cbxElement.Location = new System.Drawing.Point(13, 40);
			this.cbxElement.Name = "cbxElement";
			this.cbxElement.Size = new System.Drawing.Size(85, 21);
			this.cbxElement.TabIndex = 3;
			// 
			// cbxCity
			// 
			this.cbxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCity.FormattingEnabled = true;
			this.cbxCity.Location = new System.Drawing.Point(115, 13);
			this.cbxCity.Name = "cbxCity";
			this.cbxCity.Size = new System.Drawing.Size(222, 21);
			this.cbxCity.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.btnOk);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 127);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(351, 38);
			this.panel2.TabIndex = 1;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(269, 8);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// cbxStreet
			// 
			this.cbxStreet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxStreet.FormattingEnabled = true;
			this.cbxStreet.Location = new System.Drawing.Point(104, 40);
			this.cbxStreet.Name = "cbxStreet";
			this.cbxStreet.Size = new System.Drawing.Size(233, 21);
			this.cbxStreet.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "дом/строение";
			// 
			// edtBuildingNo
			// 
			this.edtBuildingNo.Location = new System.Drawing.Point(104, 67);
			this.edtBuildingNo.Name = "edtBuildingNo";
			this.edtBuildingNo.Size = new System.Drawing.Size(57, 20);
			this.edtBuildingNo.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "№ офиса";
			// 
			// edtOfficeNo
			// 
			this.edtOfficeNo.Location = new System.Drawing.Point(104, 93);
			this.edtOfficeNo.Name = "edtOfficeNo";
			this.edtOfficeNo.Size = new System.Drawing.Size(57, 20);
			this.edtOfficeNo.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "населенный пункт";
			// 
			// AddressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 165);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddressForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Адрес";
			this.Load += new System.EventHandler(this.AddressForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox cbxCity;
		private System.Windows.Forms.ComboBox cbxElement;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox edtOfficeNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtBuildingNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbxStreet;
	}
}