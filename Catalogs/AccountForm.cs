using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Catalogs
{
	public partial class AccountForm : Form
	{
		private string _connectionString;
		private string _queryString;
		private DataSet _dataSet;
		private BindingSource _bindingSource;
		public int idBank = -1;
		public string account = "";

		public AccountForm(string connectionString)
		{
			InitializeComponent();
			_connectionString = connectionString;
			_queryString = "SELECT id, title FROM Banks ORDER BY title";
			_dataSet = new DataSet();
			_bindingSource = new BindingSource();

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryString, connection);
				dataAdapter.Fill(_dataSet, "Banks");

			}
			_bindingSource.DataSource = _dataSet.Tables["Banks"];
			cbxBank.DataSource = _bindingSource;
			cbxBank.DisplayMember = "title";
			cbxBank.ValueMember = "id";
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if ((cbxBank.SelectedIndex == -1) || (edtAccount.Text.Length == 0))
			{
				this.DialogResult = DialogResult.Cancel;
				return;
			}

			this.account = edtAccount.Text;
			this.idBank = (int)cbxBank.SelectedValue;
		}
	}
}
