using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text.Json;
using System.Windows.Forms;

namespace Office
{
	public partial class PurchaseForm : Form
	{
		private Dictionary<string, string> _filteredFields;

		private string _connectionString;
		private string _queryString;
		private string _queryCategories;
		private string _queryProviders;
		private DataSet _dataSet;
		private BindingSource _bindingSource;
		private Dictionary<string, string> _args;

		public PurchaseForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];
			_queryString = "SELECT [id], [title], [idCategory], [screenwriter], [director], [product], [year_of_release], [idProvider], [cost] FROM Films ORDER BY title";
			_queryCategories = "SELECT id, title FROM Categories ORDER BY title";
			_queryProviders = "SELECT id, title FROM Providers ORDER BY title";

			_filteredFields = new Dictionary<string, string>() 
			{
				{ "title", "название" },
				{ "year_of_release", "год выхода на экран" },
				{ "idCategory", "категория" },
				{ "screenwriter", "автор сценария" },
				{ "director", "режиссёр-постановщик" },
				{ "product", "компания производитель" },
				{ "idProvider", "поставщик" }
			};
			cbxField.DataSource = new BindingSource(_filteredFields, null);
			cbxField.ValueMember = "Key";
			cbxField.DisplayMember = "Value";
			cbxField.SelectedIndex = 0;

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();

				OleDbDataAdapter adpFilms = new OleDbDataAdapter(_queryString, connection);
				_dataSet = new DataSet();
				adpFilms.Fill(_dataSet, "Films");
				OleDbDataAdapter adpCategories = new OleDbDataAdapter(_queryCategories, connection);
				adpCategories.Fill(_dataSet, "Category");
				OleDbDataAdapter adpProviders = new OleDbDataAdapter(_queryProviders, connection);
				adpProviders.Fill(_dataSet, "Provider");

				_bindingSource = new BindingSource();
				_bindingSource.DataSource = _dataSet.Tables["Films"];

				cbxCategory.DataSource = _dataSet.Tables["Category"];
				cbxCategory.ValueMember = "id";
				cbxCategory.DisplayMember = "title";

				cbxProvider.DataSource = _dataSet.Tables["Provider"];
				cbxProvider.ValueMember = "id";
				cbxProvider.DisplayMember = "title";

				dgvFilms.AllowUserToAddRows = false;
				dgvFilms.AllowUserToDeleteRows = false;
				dgvFilms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				dgvFilms.AutoGenerateColumns = false;
				dgvFilms.DataSource = _bindingSource;
				dgvFilms.Columns.AddRange(
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
							Width = 250,
							MaxInputLength = 100
						},
						new DataGridViewTextBoxColumn()
						{
							DataPropertyName="year_of_release",
							HeaderText = "год выхода на экран",
							Width = 50
						}
					}
				);
			}

			bnFilms.BindingSource = _bindingSource;
			bnFilms.AddNewItem.Enabled = bool.Parse(_args["W"]) & bool.Parse(_args["E"]); // без права на редактирование записи добавление бесмыссленно - пустую запись не заполнить данными
			bnFilms.DeleteItem.Enabled = bool.Parse(_args["D"]);
			pnlPropertyHolder.Enabled = bool.Parse(_args["E"]);

			edtTitle.DataBindings.Add(new Binding("Text", _bindingSource, "title", false, DataSourceUpdateMode.OnPropertyChanged));
			edtYearOfRelease.DataBindings.Add(new Binding("Text", _bindingSource, "year_of_release", false, DataSourceUpdateMode.OnPropertyChanged));
			cbxCategory.DataBindings.Add(new Binding("SelectedValue", _bindingSource, "idCategory", false, DataSourceUpdateMode.OnPropertyChanged));
			edtScreenwriter.DataBindings.Add(new Binding("Text", _bindingSource, "screenwriter", false, DataSourceUpdateMode.OnPropertyChanged));
			edtDirector.DataBindings.Add(new Binding("Text", _bindingSource, "director", false, DataSourceUpdateMode.OnPropertyChanged));
			edtProduct.DataBindings.Add(new Binding("Text", _bindingSource, "product", false, DataSourceUpdateMode.OnPropertyChanged));
			cbxProvider.DataBindings.Add(new Binding("SelectedValue", _bindingSource, "idProvider", false, DataSourceUpdateMode.OnPropertyChanged));
			edtCost.DataBindings.Add(new Binding("Text", _bindingSource, "cost", false, DataSourceUpdateMode.OnPropertyChanged));
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter adpFilms = new OleDbDataAdapter(_queryString, connection);
				OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adpFilms);
				adpFilms.InsertCommand = commandBuilder.GetInsertCommand();
				adpFilms.UpdateCommand = commandBuilder.GetUpdateCommand();
				adpFilms.DeleteCommand = commandBuilder.GetDeleteCommand();

				try
				{
					this.Validate();
					_bindingSource.EndEdit();

					adpFilms.Update(_dataSet, "Films");
					if (_dataSet.Tables.Contains("Films"))
						_dataSet.Tables["Films"].Clear();
					adpFilms.Fill(_dataSet, "Films");
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

		private void btnRefreshCategory_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter _dataAdapter = new OleDbDataAdapter(_queryCategories, connection);

				int selectedIndex = cbxCategory.SelectedIndex;
				var selectedValue = cbxCategory.SelectedValue;
				_dataSet.Tables["Category"].Clear();
				_dataAdapter.Fill(_dataSet, "Category");
				if (selectedIndex != -1) 
				{
					cbxCategory.SelectedValue = selectedValue;
				}
				else
				{
					cbxCategory.SelectedIndex = -1;
				}
			}
		}

		private void btnSet_Click(object sender, EventArgs e)
		{
			if (_dataSet.Tables["Films"].Columns[cbxField.SelectedValue.ToString()].DataType == typeof(string))
			{
				_dataSet.Tables["Films"].DefaultView.RowFilter = $"{cbxField.SelectedValue} LIKE '%{edtWord.Text}%'";
			}
			else
			{
				if (cbxField.SelectedValue.ToString().StartsWith("id"))
				{
					string expression = $"title like '%{edtWord.Text}%'";
					string order = "title";
					string tableName = cbxField.SelectedValue.ToString().Substring(2);
					DataRow[] foundRows = _dataSet.Tables[tableName].Select(expression, order);
					if (foundRows.Length > 0)
					{
						_dataSet.Tables["Films"].DefaultView.RowFilter = $"{cbxField.SelectedValue} = {foundRows[0]["id"]}";
					}
				}
				else
				{
					_dataSet.Tables["Films"].DefaultView.RowFilter = $"{cbxField.SelectedValue} = {edtWord.Text}";
				}
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			_dataSet.Tables["Films"].DefaultView.RowFilter = "";
			edtWord.Clear();
			cbxField.SelectedIndex = 0;
		}

		private void btnRefreshProvider_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter adpFilms = new OleDbDataAdapter(_queryProviders, connection);

				int selectedIndex = cbxProvider.SelectedIndex;
				var selectedValue = cbxProvider.SelectedValue;
				_dataSet.Tables["Provider"].Clear();
				adpFilms.Fill(_dataSet, "Provider");
				if (selectedIndex != -1)
				{
					cbxProvider.SelectedValue = selectedValue;
				}
				else
				{
					cbxProvider.SelectedIndex = -1;
				}
			}
		}
	}
}
