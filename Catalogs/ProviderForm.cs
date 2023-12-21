using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Catalogs
{
	public partial class ProviderForm : Form
	{
		private Dictionary<string, string> _digits;

		private string _connectionString;
		private string _queryString;
		private DataSet _dataSet;
		private Dictionary<string, string> _args;

		public ProviderForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];
			_queryString = "SELECT id, title, address, idBank, account, inn FROM Providers ORDER BY title";
			string queryBanks = "SELECT id, title FROM Banks ORDER BY title";
			_digits = new Dictionary<string, string>() { { "digitsOnly", @"[0-9]" } };

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();

				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryString, connection);
				_dataSet = new DataSet();
				dataAdapter.Fill(_dataSet, "Providers");
				OleDbDataAdapter adpBanks = new OleDbDataAdapter(queryBanks, connection);
				adpBanks.Fill(_dataSet, "Banks");


				dgvObject.AllowUserToAddRows = false;
				dgvObject.AllowUserToDeleteRows = false;
				dgvObject.ReadOnly = !bool.Parse(_args["E"]);
				dgvObject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				dgvObject.AutoGenerateColumns = false;
				dgvObject.DataSource = _dataSet.Tables["Providers"];
				dgvObject.Columns.AddRange(
					new DataGridViewColumn[]
					{
						new DataGridViewTextBoxColumn()
						{
							DataPropertyName = "id",
							Visible = false
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
							DataPropertyName = "address",
							HeaderText = "юрический адрес",
							Width = 200,
							MaxInputLength = 255
						},
						new DataGridViewTextBoxColumn()
						{
							DataPropertyName = "idBank",
							Visible = false
						},
						new DataGridViewComboBoxColumn()
						{
							DataSource = _dataSet.Tables["Banks"],
							DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
							FlatStyle = FlatStyle.Flat,
							ValueMember = "id",
							DisplayMember = "title",
							DataPropertyName = "idBank",
							HeaderText = "банк",
							Width = 100,
							DropDownWidth = 160,
						},
						new DataGridViewTextBoxColumn()
						{
							DataPropertyName = "account",
							HeaderText = "расчетный счёт",
							MaxInputLength = 30,
							Tag = _digits
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
			}

			btnAdd.Enabled = bool.Parse(_args["W"]) & bool.Parse(_args["E"]);
			btnDel.Enabled = bool.Parse(_args["D"]);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			DataRow dr = _dataSet.Tables[0].NewRow();
			_dataSet.Tables[0].Rows.Add(dr);
		}

		private void btnDel_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvObject.SelectedRows)
			{
				dgvObject.Rows.Remove(row);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryString, connection);
				OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
				dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
				dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
				dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();

				try
				{
					dataAdapter.Update(_dataSet, "Providers");
					_dataSet.Tables["Providers"].Clear();
					dataAdapter.Fill(_dataSet, "Providers");
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
	}
}
