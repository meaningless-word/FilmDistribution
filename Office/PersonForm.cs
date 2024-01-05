using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text.Json;
using System.Windows.Forms;

namespace Office
{
	public partial class PersonForm : Form
	{
		private string _connectionString;
		private string _queryString;
		private DataSet _dataSet;
		private BindingSource _bindingSource;
		public int id = -1;

		public PersonForm(string connectionString)
		{
			InitializeComponent();
			_connectionString = connectionString;
			_queryString = "SELECT id, fullName FROM Persons ORDER BY fullName";
			_dataSet = new DataSet();
			_bindingSource = new BindingSource();

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryString, connection);
				dataAdapter.Fill(_dataSet, "Persons");

			}
			_bindingSource.DataSource = _dataSet.Tables["Persons"];
			lstPersons.DataSource = _bindingSource;
			lstPersons.DisplayMember = "fullName";
			lstPersons.ValueMember = "id";

			btnOk.Enabled = _dataSet.Tables["Persons"].Rows.Count <= 1;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (lstPersons.Items.Count == 1)
			{
				id = (int)lstPersons.SelectedValue;
				return;
			}

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				string queryInsert = "INSERT INTO Persons (fullName) VALUES (@text)";
				string querySelect = "SELECT id FROM Persons WHERE fullName = @text";

				OleDbCommand cmd = new OleDbCommand(queryInsert, connection);
				cmd.Parameters.Add("@payment", OleDbType.VarChar).Value = edtPersonName.Text;
				connection.Open();
				try
				{
					cmd.ExecuteNonQuery();
					connection.Close();
					cmd.CommandText = querySelect;
					DataTable dt = new DataTable();
					OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
					adapter.Fill(dt);
					id = dt.Rows[0].Field<int>("id");
					connection.Close();
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

		private void PersonForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.Cancel)
			{
				e.Cancel = false;
				return;
			}

			if (id == -1 && lstPersons.Items.Count > 1) 
			{
				MessageBox.Show("По введенному значению невозможно сделать однозначный выбор.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true; 
			}
			
		}

		private void edtPersonName_TextChanged(object sender, EventArgs e)
		{
			DataTable _dt = _dataSet.Tables["Persons"];

			EnumerableRowCollection<DataRow> query = from persons in _dt.AsEnumerable()
													 where persons.Field<string>("fullName").ToUpper().Contains(edtPersonName.Text.ToUpper())
													 orderby persons.Field<string>("fullName")
													 select persons;
			DataView _dv = query.AsDataView();
			_bindingSource.DataSource = _dv;

			btnOk.Enabled = _dv.Count <= 1;
		}

		private void lstPersons_DoubleClick(object sender, EventArgs e)
		{
			id = (int)lstPersons.SelectedValue;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
