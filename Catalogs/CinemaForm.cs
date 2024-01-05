using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Catalogs
{
	public partial class CinemaForm : Form
	{
		private Dictionary<string, string> _digits, _phoneSeparators;

		private string _connectionString;
		private string _queryString;
		private string _queryBanks;
		private string _queryAddresses;
		private DataSet _dataSet;
		private Dictionary<string, string> _args;

		public CinemaForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];
			_queryString = "SELECT [id], [title], [idAddress], [phone], [seats], [director], [owner], [idBank], [account], [inn] FROM Cinemas ORDER BY title";
			_queryBanks = "SELECT id, title FROM Banks ORDER BY title";
			_queryAddresses = "SELECT Addresses.id" +
				", Cities.title" +
				" + ', '" +
				" + Elements.title + ' '" +
				" + Streets.title" +
				" + IIF(LEN(Addresses.buildingNo) > 0, ', д./стр. ' + Addresses.buildingNo, '')" +
				" + IIF(LEN(Addresses.officeNo) > 0, ', № офиса ' + officeNo, '') AS address" +
				" FROM (((Addresses" +
				" INNER JOIN Cities ON Cities.id = Addresses.idCity)" +
				" INNER JOIN Streets ON Streets.id = Addresses.idStreet)" +
				" INNER JOIN Elements ON Elements.id = Addresses.idElement)";

			_digits = new Dictionary<string, string>() { { "digitsOnly", @"[0-9]" } };
			_phoneSeparators = new Dictionary<string, string>() { { "separatorsOnly", @"[\s()+\-]" } };
			_dataSet = new DataSet();

			ReloadData();

			var phoneValidator = _digits.Union(_phoneSeparators).ToDictionary(x => x.Key, x => x.Value);
			dgvObject.AllowUserToAddRows = false;
			dgvObject.AllowUserToDeleteRows = false;
			dgvObject.ReadOnly = !bool.Parse(_args["E"]);
			dgvObject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvObject.AutoGenerateColumns = false;
			dgvObject.DataSource = _dataSet.Tables["Cinemas"];
			dgvObject.Columns.AddRange(
				new DataGridViewColumn[]
				{
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "id",
						Visible = false,
						Name = "id"
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
						DataPropertyName = "idAddress",
						Name = "idAddress",
						Visible = false
					},
					new DataGridViewComboBoxColumn()
					{
						DataSource = _dataSet.Tables["Addresses"],
						DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
						ReadOnly = true,
						FlatStyle = FlatStyle.Flat,
						ValueMember = "id",
						DisplayMember = "address",
						DataPropertyName = "idAddress",
						HeaderText = "юрический адрес",
						Width = 200,
						Name = "AddressValue"
					},
					new DataGridViewButtonColumn()
					{
						FlatStyle = FlatStyle.Popup,
						HeaderText = "",
						Text = "...",
						Name = "A",
						UseColumnTextForButtonValue = true,
						Width = 20
					},
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "phone",
						HeaderText = "телефон",
						Width = 100,
						MaxInputLength = 20,
						Tag = phoneValidator
					},
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "seats",
						HeaderText = "число посадочных мест",
						Width = 60,
						MaxInputLength = 4,
						Tag = _digits
					},
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "director",
						HeaderText = "директор",
						Width = 150,
						MaxInputLength = 100
					},
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "owner",
						HeaderText = "собственник",
						Width = 150,
						MaxInputLength = 100
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
						Width = 130,
						Tag = _digits
					},
					new DataGridViewTextBoxColumn()
					{
						DataPropertyName = "inn",
						HeaderText = "ИНН",
						MaxInputLength = 20,
						Width = 130,
						Tag = _digits
					}
				}
			);

			btnAdd.Enabled = bool.Parse(_args["W"]) & bool.Parse(_args["E"]);
			btnDel.Enabled = bool.Parse(_args["D"]);
		}

		private void ReloadData()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				int iFirstRow = -1;
				if (dgvObject.Rows.Count > 0 && dgvObject.FirstDisplayedCell != null) { iFirstRow = dgvObject.FirstDisplayedCell.RowIndex; }
				Point cell = dgvObject.CurrentCellAddress;

				if (_dataSet.Tables.Contains("Cinemas")) { _dataSet.Tables["Cinemas"].Clear(); }
				if (_dataSet.Tables.Contains("Banks")) { _dataSet.Tables["Banks"].Clear(); }
				if (_dataSet.Tables.Contains("Addresses")) { _dataSet.Tables["Addresses"].Clear(); }

				connection.Open();
				OleDbDataAdapter da = new OleDbDataAdapter();
				da.SelectCommand = new OleDbCommand(_queryString, connection);
				da.Fill(_dataSet, "Cinemas");
				da.SelectCommand = new OleDbCommand(_queryBanks, connection);
				da.Fill(_dataSet, "Banks");
				da.SelectCommand = new OleDbCommand(_queryAddresses, connection);
				da.Fill(_dataSet, "Addresses");

				if (iFirstRow > -1 && iFirstRow < dgvObject.Rows.Count) { dgvObject.FirstDisplayedScrollingRowIndex = iFirstRow; }
				dgvObject.MultiSelect = false;
				if (cell.X > -1) { dgvObject.Rows[cell.Y].Cells[cell.X].Selected = true; }
				dgvObject.MultiSelect = true;
			}
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
					dataAdapter.Update(_dataSet, "Cinemas");
					_dataSet.Tables["Cinemas"].Clear();
					dataAdapter.Fill(_dataSet, "Cinemas");
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

		private void dgvObject_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (sender is DataGridView)
			{
				DataGridView dgv = sender as DataGridView;
				dgv.Rows[e.RowIndex].ErrorText = string.Empty;
			}
		}

		private void dgvObject_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (sender is DataGridView)
			{
				DataGridView dgv = sender as DataGridView;
				if (dgv.Columns[e.ColumnIndex].Name == "A")
				{
					btnSave_Click(sender, e);
					using (AddressForm f = new AddressForm(_connectionString))
					{
						f.id = dgv.Rows[e.RowIndex].Cells["idAddress"];
						if (f.ShowDialog() == DialogResult.OK)
						{
							using (OleDbConnection connection = new OleDbConnection(_connectionString))
							{
								string queryUpdate = "UPDATE Cinemas SET idAddress = @idAddress WHERE id = @id";
								OleDbCommand cmd = new OleDbCommand(queryUpdate, connection);
								cmd.Parameters.Add("@idAddress", OleDbType.Integer).Value = f.id.Value;
								cmd.Parameters.Add("@id", OleDbType.Integer).Value = dgv.Rows[e.RowIndex].Cells["id"].Value;
								connection.Open();
								cmd.ExecuteNonQuery();
								connection.Close();
								ReloadData();
							}
						}
					}
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
	}
}
