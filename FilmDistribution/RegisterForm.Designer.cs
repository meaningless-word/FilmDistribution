namespace FilmDistribution
{
	partial class RegisterForm
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
			this.edtPasswordAgain = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.edtLogin = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRegister = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.edtPasswordAgain);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.edtPassword);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.edtLogin);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(296, 90);
			this.panel1.TabIndex = 3;
			// 
			// edtPasswordAgain
			// 
			this.edtPasswordAgain.Location = new System.Drawing.Point(145, 58);
			this.edtPasswordAgain.MaxLength = 32;
			this.edtPasswordAgain.Name = "edtPasswordAgain";
			this.edtPasswordAgain.Size = new System.Drawing.Size(134, 20);
			this.edtPasswordAgain.TabIndex = 5;
			this.edtPasswordAgain.UseSystemPasswordChar = true;
			this.edtPasswordAgain.Enter += new System.EventHandler(this.edtPasswordAgain_Enter);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "подтверждение пароля";
			// 
			// edtPassword
			// 
			this.edtPassword.Location = new System.Drawing.Point(145, 32);
			this.edtPassword.MaxLength = 32;
			this.edtPassword.Name = "edtPassword";
			this.edtPassword.Size = new System.Drawing.Size(134, 20);
			this.edtPassword.TabIndex = 3;
			this.edtPassword.UseSystemPasswordChar = true;
			this.edtPassword.Enter += new System.EventHandler(this.edtPassword_Enter);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(93, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "пароль";
			// 
			// edtLogin
			// 
			this.edtLogin.Location = new System.Drawing.Point(145, 7);
			this.edtLogin.MaxLength = 50;
			this.edtLogin.Name = "edtLogin";
			this.edtLogin.Size = new System.Drawing.Size(134, 20);
			this.edtLogin.TabIndex = 1;
			this.edtLogin.Enter += new System.EventHandler(this.edtLogin_Enter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(100, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "логин";
			// 
			// btnRegister
			// 
			this.btnRegister.Location = new System.Drawing.Point(82, 96);
			this.btnRegister.Name = "btnRegister";
			this.btnRegister.Size = new System.Drawing.Size(95, 23);
			this.btnRegister.TabIndex = 5;
			this.btnRegister.Text = "Регистрация";
			this.btnRegister.UseVisualStyleBackColor = true;
			this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(188, 97);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// RegisterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 128);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnRegister);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RegisterForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Регистрация";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox edtPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtLogin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRegister;
		private System.Windows.Forms.TextBox edtPasswordAgain;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
	}
}