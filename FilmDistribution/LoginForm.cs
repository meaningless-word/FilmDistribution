using System;
using System.Data;
using System.Windows.Forms;

namespace FilmDistribution
{
	public partial class LoginForm : Form
	{
		private string _connectionString;
		public int userId;
		public bool isAdmin;
		public LoginForm(string connectionString)
		{
			InitializeComponent();
			_connectionString = connectionString;
			userId = -1;
			isAdmin = false;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			User user = new User(_connectionString);
			DataTable tblUser = user.GetByLogin(edtLogin.Text);

			if (tblUser.Rows.Count == 0)
			{
				MessageBox.Show("Такой пользователь не зарегистрирован", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				if ((bool)tblUser.Rows[0]["isReset"])
				{
					if (tblUser.Rows[0]["Password"].ToString() == edtPassword.Text)
					{
						using (ChangePasswordForm f = new ChangePasswordForm(_connectionString, tblUser.Rows[0]["Login"].ToString()))
						{
							if (f.ShowDialog() != DialogResult.OK)
							{
								MessageBox.Show("Необходимо сменить временный пароль!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}
					}
					else
					{
						MessageBox.Show("Пароль указан неверно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else
				{
					if (!Logic.Encrypter.VerifyHashedPassword(tblUser.Rows[0]["Password"].ToString(), edtPassword.Text))
					{
						MessageBox.Show("Имя пользователя или пароль указаны неверно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				userId = (int)tblUser.Rows[0]["id"];
				isAdmin = (bool)tblUser.Rows[0]["isAdmin"];
				this.Close();
			}
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			using (RegisterForm frm = new RegisterForm(_connectionString))
			{
				frm.ShowDialog();
				userId = (int)frm.tblUser.Rows[0]["id"];
				isAdmin = (bool)frm.tblUser.Rows[0]["isAdmin"];
			}
			if (userId != -1) this.Close();
		}

		private void edtLogin_Enter(object sender, EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				tb.SelectionStart = 0;
				tb.SelectionLength = tb.Text.Length;
			}
		}

		private void edtPassword_Enter(object sender, EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				tb.SelectionStart = 0;
				tb.SelectionLength = tb.Text.Length;
			}
		}
	}
}
