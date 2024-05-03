using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Security.Principal;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Catalogs
{
	public partial class ProviderForm : Form
	{
		private Dictionary<string, string> _digits;

		private string _connectionString;
		private string _queryProviders;
		private string _queryProviderAccounts;
		private string _queryCities;
		private string _queryStreets;
		private string _queryElements;
		private DataSet _dataSet;
		private BindingSource _bsProviders;
		private BindingSource _bsProviderAccounts;
		private Dictionary<string, string> _args;

		public ProviderForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];

			_digits = new Dictionary<string, string>() { { "digitsOnly", @"[0-9]" } };

			_dataSet = new DataSet();
			_bsProviders = new BindingSource();
			_bsProviderAccounts = new BindingSource();

			GenerateScripts();
			ReloadData();

			dgvObject.AllowUserToAddRows = false;
			dgvObject.AllowUserToDeleteRows = false;
			dgvObject.ReadOnly = !bool.Parse(_args["E"]);
			dgvObject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvObject.AutoGenerateColumns = false;
			dgvObject.DataSource = _bsProviders;
			dgvObject.Columns.AddRange(
				new DataGridViewColumn[]
				{
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "id",
						Visible = false,
						Name = "id",
					},
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "title",
						HeaderText = "наименование",
						Width = 200,
						MaxInputLength = 100
					},
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "inn",
						HeaderText = "ИНН",
						MaxInputLength = 20,
						Tag = _digits
					}
				}
			);
			bnProviders.BindingSource = _bsProviders;

			lstAccounts.DataSource = _bsProviderAccounts;
			lstAccounts.ValueMember = "id";
			lstAccounts.DisplayMember = "public";

			cbxCity.DataSource = _dataSet.Tables["Cities"];
			cbxCity.ValueMember = "id";
			cbxCity.DisplayMember = "title";

			cbxElement.DataSource = _dataSet.Tables["Elements"];
			cbxElement.ValueMember = "id";
			cbxElement.DisplayMember = "title";

			cbxStreet.DataSource = _dataSet.Tables["Streets"];
			cbxStreet.ValueMember = "id";
			cbxStreet.DisplayMember = "title";

			cbxCity.DataBindings.Add(new Binding("SelectedValue", _bsProviders, "idCity", false, DataSourceUpdateMode.OnPropertyChanged));
			cbxElement.DataBindings.Add(new Binding("SelectedValue", _bsProviders, "idElement", false, DataSourceUpdateMode.OnPropertyChanged));
			cbxStreet.DataBindings.Add(new Binding("SelectedValue", _bsProviders, "idStreet", false, DataSourceUpdateMode.OnPropertyChanged));
			
			edtBuildingNo.DataBindings.Add(new Binding("Text", _bsProviders, "buildingNo", false, DataSourceUpdateMode.OnPropertyChanged));
			edtOfficeNo.DataBindings.Add(new Binding("Text", _bsProviders, "officeNo", false, DataSourceUpdateMode.OnPropertyChanged));

			bnProviders.AddNewItem.Enabled = bool.Parse(_args["W"]) & bool.Parse(_args["E"]); // без права на редактирование записи добавление бесмыссленно - пустую запись не заполнить данными
			bnProviders.DeleteItem.Enabled = bool.Parse(_args["D"]);
			pnlPropertyHolder.Enabled = bool.Parse(_args["E"]);
		}

		private void GenerateScripts()
		{
			_queryProviders = "SELECT id, title, inn, idCity, idElement, idStreet, buildingNo, officeNo FROM Providers ORDER BY title";
			_queryProviderAccounts = "SELECT ProviderAccounts.id, idOwner, idBank, account, Banks.title," +
				" 'р/сч №' + account + ' в банке ' + Banks.title AS [public]" +
				" FROM ProviderAccounts" +
				" INNER JOIN Banks ON Banks.id = ProviderAccounts.idBank";
			_queryCities = "SELECT id, title FROM Cities ORDER BY title";
			_queryStreets = "SELECT id, title FROM Streets ORDER BY title";
			_queryElements = "SELECT id, title FROM Elements ORDER BY title";
		}

		private void ReloadData()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				int iFirstRow = -1;
				if (dgvObject.Rows.Count > 0 && dgvObject.FirstDisplayedCell != null) { iFirstRow = dgvObject.CurrentRow.Index; }
				Point cell = dgvObject.CurrentCellAddress;

				if (_dataSet.Relations.Contains("acc")) { _dataSet.Relations.Remove("acc"); }
				if (_dataSet.Tables.Contains("Streets")) { _dataSet.Tables["Streets"].Clear(); }
				if (_dataSet.Tables.Contains("Elements")) { _dataSet.Tables["Elements"].Clear(); }
				if (_dataSet.Tables.Contains("Cities")) { _dataSet.Tables["Cities"].Clear(); }
				if (_dataSet.Tables.Contains("ProviderAccounts")) { _dataSet.Tables["ProviderAccounts"].Clear(); }
				if (_dataSet.Tables.Contains("Providers")) { _dataSet.Tables["Providers"].Clear(); }

				connection.Open();
				OleDbDataAdapter da = new OleDbDataAdapter();
				da.SelectCommand = new OleDbCommand(_queryProviders, connection);
				da.Fill(_dataSet, "Providers");
				da.SelectCommand = new OleDbCommand(_queryProviderAccounts, connection);
				da.Fill(_dataSet, "ProviderAccounts");
				da.SelectCommand = new OleDbCommand(_queryCities, connection);
				da.Fill(_dataSet, "Cities");
				da.SelectCommand = new OleDbCommand(_queryElements, connection);
				da.Fill(_dataSet, "Elements");
				da.SelectCommand = new OleDbCommand(_queryStreets, connection);
				da.Fill(_dataSet, "Streets");

				_dataSet.Relations.Add("acc", _dataSet.Tables["Providers"].Columns["id"], _dataSet.Tables["ProviderAccounts"].Columns["idOwner"]);

				_bsProviders.DataSource = _dataSet;
				_bsProviders.DataMember = "Providers";
				_bsProviderAccounts.DataSource = _bsProviders;
				_bsProviderAccounts.DataMember = "acc";

				if (iFirstRow > -1 && iFirstRow < dgvObject.Rows.Count) { dgvObject.FirstDisplayedScrollingRowIndex = iFirstRow; }
				dgvObject.MultiSelect = false;
				if (cell.X > -1) { dgvObject.Rows[cell.Y].Cells[cell.X].Selected = true; }
				dgvObject.MultiSelect = true;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryProviders, connection);
				OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
				dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
				dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
				dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();

				try
				{
					_bsProviders.EndEdit();
					dataAdapter.Update(_dataSet, "Providers");
					connection.Close();
					ReloadData();
				}
				catch (OleDbException exDb)
				{
					string msg;
					switch (exDb.Errors[0].SQLState)
					{
						case "3314":
							msg = "Не заполнено обязательное поле\n" + exDb.Errors[0].Message;
							break;
						case "3022":
							msg = "Введённые значения дублируют уже существующие\n" + exDb.Errors[0].Message;
							break;
						case "3316":
							msg = "Нарушено требование к данным\n" + exDb.Errors[0].Message;
							break;
						default:
							msg = exDb.Errors[0].Message;
							break;
					}
					MessageBox.Show(msg, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void dgvObject_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (sender is DataGridView)
			{
				DataGridView dgv = sender as DataGridView;
				DataGridViewColumn c = dgv.Columns[e.ColumnIndex];
				// суть проверки заключается в том, что из значения клетки удаляются все допустимые символы,
				// представленные шаблоном регулярного выражения и переданные в словаре через тег.
				// и если после обработки ничего не осталось, то и недопустимых символов нет
				if (c.Tag is Dictionary<string, string>)
				{
					Dictionary<string, string> tag = c.Tag as Dictionary<string, string>;
					string result = e.FormattedValue.ToString();
					foreach (string key in tag.Keys)
					{
						if (key.EndsWith("Only"))
						{
							result = Regex.Replace(result, tag[key], string.Empty);
						}
					}
					if (result.Length == 0) { return; }

					e.Cancel = true;
					string ErrorText = $"введены недопустимые символы: {result}";
					dgv.Rows[e.RowIndex].ErrorText = ErrorText;
				}
			}
		}

		private void dgvObject_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (sender is DataGridView)
			{
				DataGridView dgv = sender as DataGridView;
				dgv.Rows[e.RowIndex].ErrorText = string.Empty;
			}
		}

		private void btnAddAccount_Click(object sender, EventArgs e)
		{
			using (AccountForm f = new AccountForm(_connectionString))
			{
				if (f.ShowDialog(this) != DialogResult.OK) { return; }
				using (OleDbConnection connection = new OleDbConnection(_connectionString))
				{
					string query = "INSERT INTO ProviderAccounts (idOwner, idBank, account) VALUES (@idOwner, @idBank, @account)";
					OleDbCommand cmd = new OleDbCommand(query, connection);
					cmd.Parameters.Add("@idOwner", OleDbType.Integer).Value = dgvObject.CurrentRow.Cells[0].Value;
					cmd.Parameters.Add("@idBank", OleDbType.Integer).Value = f.idBank;
					cmd.Parameters.Add("@account", OleDbType.VarChar).Value = f.account;
					connection.Open();
					cmd.ExecuteNonQuery();
					connection.Close();
					ReloadData();
				}
			}
		}

		private void btnDelAccount_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				string queryDelete = "DELETE FROM ProviderAccounts WHERE [id] = @id";

				OleDbCommand cmd = new OleDbCommand(queryDelete, connection);
				if (lstAccounts.SelectedIndex > -1)
				{
					cmd.Parameters.Add("@id", OleDbType.Integer).Value = lstAccounts.SelectedValue;
					connection.Open();
					cmd.ExecuteNonQuery();
					connection.Close();
					ReloadData();
				}
			}
		}
	}
}
