using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Office
{
	public partial class CategoryForm : Form
	{
		private string _connectionString;
		private string _queryString;
		private DataSet _dataSet;
		private BindingSource _bindingSource;
		public List<int> ids;

		public CategoryForm(string connectionString, string excluded)
		{
			InitializeComponent();
			ids = new List<int>();
			string s = "";
			_connectionString = connectionString;
			_queryString = $"SELECT id, title FROM Categories WHERE id NOT IN ({excluded}) ORDER BY title";
			_dataSet = new DataSet();
			_bindingSource = new BindingSource();

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryString, connection);
				dataAdapter.Fill(_dataSet, "Categories");

			}
			_bindingSource.DataSource = _dataSet.Tables["Categories"];
			clbCategories.DataSource = _bindingSource;
			clbCategories.DisplayMember = "title";
			clbCategories.ValueMember = "id";
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			foreach (DataRowView item in clbCategories.CheckedItems)
			{
				ids.Add((int)item.Row.ItemArray[0]);
			}
		}

		private void CategoryForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.DialogResult = ids.Count > 0 ? DialogResult.OK : DialogResult.Cancel;
		}
	}
}
