using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text.Json;
using System.Windows.Forms;

namespace Catalogs
{
	public partial class StreetForm : Form
	{
		private string _connectionString;
		private string _queryString;
		private DataSet _dataSet;
		private Dictionary<string, string> _args;

		public StreetForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];
			_queryString = "SELECT id, title FROM Streets ORDER BY title";

			dgvObject.AllowUserToAddRows = false;
			dgvObject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryString, connection);
				_dataSet = new DataSet();
				dataAdapter.Fill(_dataSet);

				dgvObject.AllowUserToAddRows = false;
				dgvObject.AllowUserToDeleteRows = false;
				dgvObject.ReadOnly = !bool.Parse(_args["E"]);
				dgvObject.DataSource = _dataSet.Tables[0];
				dgvObject.Columns["id"].Visible = false;
				dgvObject.Columns["title"].HeaderText = "наименование";
				dgvObject.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			}

			btnAdd.Enabled = bool.Parse(_args["W"]);
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
					dataAdapter.Update(_dataSet);
					_dataSet.Tables[0].Clear();
					dataAdapter.Fill(_dataSet);
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
	}
}
