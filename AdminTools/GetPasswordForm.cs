using System;
using System.Windows.Forms;

namespace AdminTools
{
	public partial class GetPasswordForm : Form
	{
		public string Password;
		public GetPasswordForm()
		{
			InitializeComponent();
			Password = "";
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Password = edtPassword.Text;
			this.Close();
		}
	}
}
