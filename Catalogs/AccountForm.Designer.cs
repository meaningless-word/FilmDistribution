namespace Catalogs
{
	partial class AccountForm
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
			this.cbxBank = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.edtAccount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbxBank
			// 
			this.cbxBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxBank.FormattingEnabled = true;
			this.cbxBank.Location = new System.Drawing.Point(180, 25);
			this.cbxBank.Name = "cbxBank";
			this.cbxBank.Size = new System.Drawing.Size(194, 21);
			this.cbxBank.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(182, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "в банке";
			// 
			// edtAccount
			// 
			this.edtAccount.Location = new System.Drawing.Point(11, 25);
			this.edtAccount.Name = "edtAccount";
			this.edtAccount.Size = new System.Drawing.Size(163, 20);
			this.edtAccount.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "рассчетный счет";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(299, 52);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "добавить";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// AccountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(385, 85);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.edtAccount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbxBank);
			this.Name = "AccountForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Расчетный счет";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbxBank;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox edtAccount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOk;
	}
}