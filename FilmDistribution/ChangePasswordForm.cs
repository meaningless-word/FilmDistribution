using System;
using System.Windows.Forms;

namespace FilmDistribution
{
	public partial class ChangePasswordForm : Form
	{
		private string _connectionString;
		public ChangePasswordForm(string connectionString, string login)
		{
			InitializeComponent();
			_connectionString = connectionString;
			edtLogin.Text = login;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
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

		private void edtPasswordAgain_Enter(object sender, EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				tb.SelectionStart = 0;
				tb.SelectionLength = tb.Text.Length;
			}
		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			if (edtPassword.Text.Length == 0)
			{
				MessageBox.Show("Пароль не может быть пустым", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (edtPassword.Text != edtPasswordAgain.Text)
			{
				MessageBox.Show("Пароли не совпадают", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			User user = new User(_connectionString);
			user.Change(edtLogin.Text, edtPassword.Text);
			this.Close();
		}
	}
}
