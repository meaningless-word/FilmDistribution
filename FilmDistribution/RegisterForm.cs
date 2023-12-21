using System;
using System.Data;
using System.Windows.Forms;

namespace FilmDistribution
{
	public partial class RegisterForm : Form
	{
		private string _connectionString;
		public DataTable tblUser;
		public RegisterForm(string connectionString)
		{
			InitializeComponent();
			_connectionString = connectionString;
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			if (edtLogin.Text.Length == 0)
			{
				MessageBox.Show("Необходимо ввести логин", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
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
			tblUser = user.GetByLogin(edtLogin.Text);
			if (tblUser.Rows.Count == 0)
			{
				tblUser = user.Add(edtLogin.Text, edtPassword.Text);
				MessageBox.Show("Регистрация завершена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			else
			{
				MessageBox.Show("Пользователь с таким логином уже зарегистрирован!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			tblUser = new DataTable();
			tblUser.Columns.Add(new DataColumn() { ColumnName = "id", DataType = Type.GetType("System.Int32") });
			tblUser.Columns.Add(new DataColumn() { ColumnName = "isAdmin", DataType = Type.GetType("System.Boolean") });
			tblUser.Rows.Add(new object[] { -1, false });
			this.Close();
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

		private void edtPasswordAgain_Enter(object sender, EventArgs e)
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
