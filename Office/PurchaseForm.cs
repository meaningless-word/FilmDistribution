using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Office
{
	public partial class PurchaseForm : Form
	{
		private Dictionary<string, string> _filteredFields;

		private string _connectionString;
		private string _queryFilms;
		private string _queryCategories;
		private string _queryProviders;
		private string _queryFilmCompanies;
		private string _queryScreenwriters;
		private string _queryDirectors;
		private DataSet _dataSet;
		private BindingSource _bsFilms;
		private BindingSource _bsScreenwriters;
		private BindingSource _bsDirectors;
		private Dictionary<string, string> _args;

		public PurchaseForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];

			_filteredFields = new Dictionary<string, string>()
			{
				{ "title", "название" },
				{ "year_of_release", "год выхода на экран" },
				{ "idCategory", "категория" },
				{ "Screenwriters", "автор сценария" },
				{ "Directors", "режиссёр" },
				{ "idFilmCompany", "компания производитель" },
				{ "idProvider", "поставщик" }
			};

			cbxField.DataSource = new BindingSource(_filteredFields, null);
			cbxField.ValueMember = "Key";
			cbxField.DisplayMember = "Value";
			cbxField.SelectedIndex = 0;

			_dataSet = new DataSet();
			_bsFilms = new BindingSource();
			_bsScreenwriters = new BindingSource();
			_bsDirectors = new BindingSource();

			GenerateScripts();
			ReloadData();

			cbxCategory.DataSource = _dataSet.Tables["Category"];
			cbxCategory.ValueMember = "id";
			cbxCategory.DisplayMember = "title";

			cbxProvider.DataSource = _dataSet.Tables["Provider"];
			cbxProvider.ValueMember = "id";
			cbxProvider.DisplayMember = "title";

			cbxFilmCompany.DataSource = _dataSet.Tables["FilmCompany"];
			cbxFilmCompany.ValueMember = "id";
			cbxFilmCompany.DisplayMember = "title";

			lstScreenwriters.DataSource = _bsScreenwriters;
			lstScreenwriters.DisplayMember = "fullName";
			lstScreenwriters.ValueMember = "id";

			lstDirectors.DataSource = _bsDirectors;
			lstDirectors.DisplayMember = "fullName";
			lstDirectors.ValueMember = "id";

			dgvFilms.AllowUserToAddRows = false;
			dgvFilms.AllowUserToDeleteRows = false;
			dgvFilms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvFilms.AutoGenerateColumns = false;
			dgvFilms.DataSource = _bsFilms;
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

			bnFilms.BindingSource = _bsFilms;
			bnFilms.AddNewItem.Enabled = bool.Parse(_args["W"]) & bool.Parse(_args["E"]); // без права на редактирование записи добавление бесмыссленно - пустую запись не заполнить данными
			bnFilms.DeleteItem.Enabled = bool.Parse(_args["D"]);
			pnlPropertyHolder.Enabled = bool.Parse(_args["E"]);

			edtTitle.DataBindings.Add(new Binding("Text", _bsFilms, "title", false, DataSourceUpdateMode.OnPropertyChanged));
			edtYearOfRelease.DataBindings.Add(new Binding("Text", _bsFilms, "year_of_release", false, DataSourceUpdateMode.OnPropertyChanged));
			cbxCategory.DataBindings.Add(new Binding("SelectedValue", _bsFilms, "idCategory", false, DataSourceUpdateMode.OnPropertyChanged));
			cbxFilmCompany.DataBindings.Add(new Binding("SelectedValue", _bsFilms, "idFilmCompany", false, DataSourceUpdateMode.OnPropertyChanged));
			cbxProvider.DataBindings.Add(new Binding("SelectedValue", _bsFilms, "idProvider", false, DataSourceUpdateMode.OnPropertyChanged));
			edtCost.DataBindings.Add(new Binding("Text", _bsFilms, "cost", false, DataSourceUpdateMode.OnPropertyChanged));
		}

		private void GenerateScripts(string queryFilmsWhere = "")
		{
			_queryFilms = $"SELECT Films.id, Films.title, Films.idCategory, Films.idFilmCompany, Films.year_of_release, Films.idProvider, Films.cost" +
				" FROM Films " +
				" WHERE 1 = 1" +
				$" {queryFilmsWhere}" +
				" ORDER BY Films.title";
			_queryCategories = "SELECT id, title FROM Categories ORDER BY title";
			_queryProviders = "SELECT id, title FROM Providers ORDER BY title";
			_queryFilmCompanies = "SELECT id, title FROM FilmCompanies ORDER BY title";
			_queryScreenwriters = "SELECT Screenwriters.id, idFilm, idPerson, Persons.fullName " +
				" FROM Screenwriters " +
				" INNER JOIN Persons ON Persons.id = Screenwriters.idPerson" +
				$" WHERE idFilm IN (SELECT id FROM Films WHERE 1 = 1 {queryFilmsWhere})" +
				" ORDER BY Persons.fullName";
			_queryDirectors = "SELECT Directors.id, idFilm, idPerson, Persons.fullName " +
				" FROM Directors " +
				" INNER JOIN Persons ON Persons.id = Directors.idPerson" +
				$" WHERE idFilm IN (SELECT id FROM Films WHERE 1 = 1 {queryFilmsWhere})" +
				" ORDER BY Persons.fullName";
		}
		private void ReloadData()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				int iFirstRow = -1;
				if (dgvFilms.Rows.Count > 0 && dgvFilms.FirstDisplayedCell != null) { iFirstRow = dgvFilms.FirstDisplayedCell.RowIndex; }
				Point cell = dgvFilms.CurrentCellAddress;

				if (_dataSet.Relations.Contains("d")) { _dataSet.Relations.Remove("d"); }
				if (_dataSet.Relations.Contains("sw")) { _dataSet.Relations.Remove("sw"); }
				if (_dataSet.Tables.Contains("Directors")) { _dataSet.Tables["Directors"].Clear(); }
				if (_dataSet.Tables.Contains("Screenwriters")) { _dataSet.Tables["Screenwriters"].Clear(); }
				if (_dataSet.Tables.Contains("FilmCompany")) { _dataSet.Tables["FilmCompany"].Clear(); }
				if (_dataSet.Tables.Contains("Provider")) { _dataSet.Tables["Provider"].Clear(); }
				if (_dataSet.Tables.Contains("Category")) { _dataSet.Tables["Category"].Clear(); }
				if (_dataSet.Tables.Contains("Films")) { _dataSet.Tables["Films"].Clear(); }

				connection.Open();
				OleDbDataAdapter da = new OleDbDataAdapter();
				da.SelectCommand = new OleDbCommand(_queryFilms, connection);
				da.Fill(_dataSet, "Films");
				da.SelectCommand = new OleDbCommand(_queryCategories, connection);
				da.Fill(_dataSet, "Category");
				da.SelectCommand = new OleDbCommand(_queryProviders, connection);
				da.Fill(_dataSet, "Provider");
				da.SelectCommand = new OleDbCommand(_queryFilmCompanies, connection);
				da.Fill(_dataSet, "FilmCompany");
				da.SelectCommand = new OleDbCommand(_queryScreenwriters, connection);
				da.Fill(_dataSet, "Screenwriters");
				da.SelectCommand = new OleDbCommand(_queryDirectors, connection);
				da.Fill(_dataSet, "Directors");

				_dataSet.Relations.Add("sw", _dataSet.Tables["Films"].Columns["id"], _dataSet.Tables["Screenwriters"].Columns["idFilm"]);
				_dataSet.Relations.Add("d", _dataSet.Tables["Films"].Columns["id"], _dataSet.Tables["Directors"].Columns["idFilm"]);

				_bsFilms.DataSource = _dataSet;
				_bsFilms.DataMember = "Films";
				_bsScreenwriters.DataSource = _bsFilms;
				_bsScreenwriters.DataMember = "sw";
				_bsDirectors.DataSource = _bsFilms;
				_bsDirectors.DataMember = "d";

				if (iFirstRow > -1 && iFirstRow < dgvFilms.Rows.Count) { dgvFilms.FirstDisplayedScrollingRowIndex = iFirstRow; }
				dgvFilms.MultiSelect = false;
				if (cell.X > -1) { dgvFilms.Rows[cell.Y].Cells[cell.X].Selected = true; }
				dgvFilms.MultiSelect = true;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter adpFilms = new OleDbDataAdapter(_queryFilms, connection);
				OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adpFilms);
				adpFilms.InsertCommand = commandBuilder.GetInsertCommand();
				adpFilms.UpdateCommand = commandBuilder.GetUpdateCommand();
				adpFilms.DeleteCommand = commandBuilder.GetDeleteCommand();

				try
				{
					this.Validate();
					_bsFilms.EndEdit();
					adpFilms.Update(_dataSet, "Films");
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
			if (_dataSet.Tables["Films"].Columns.Contains(cbxField.SelectedValue.ToString()))
			{
				if (_dataSet.Tables["Films"].Columns[cbxField.SelectedValue.ToString()].DataType == typeof(string))
				{
					GenerateScripts($" AND Films.{cbxField.SelectedValue} LIKE '%{edtWord.Text}%'");
				}
				else
				{
					if (cbxField.SelectedValue.ToString().StartsWith("id"))
					{
						string f = cbxField.SelectedValue.ToString();
						string t = f.Substring(2);

						List<string> q = (
							from c in _dataSet.Tables[t].AsEnumerable()
							where c.Field<string>("title").ToLower().Contains(edtWord.Text.ToLower())
							select c.Field<int>("id").ToString()
							).ToList();
						string lst = String.Join(",", q);
						GenerateScripts($"AND Films.{f} IN ({lst})");
					}
					else
					{
						GenerateScripts($" AND Films.{cbxField.SelectedValue} = {edtWord.Text}");
					}
				}
			}
			else
			{
				List<string> q = (
					from c in _dataSet.Tables[cbxField.SelectedValue.ToString()].AsEnumerable()
					where c.Field<string>("fullName").ToLower().Contains(edtWord.Text.ToLower())
					select c.Field<int>("idFilm").ToString()
					).ToList();
				string lst = String.Join(",", q);
				GenerateScripts($"AND Films.id IN ({lst})");
			}
			ReloadData();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			edtWord.Clear();
			cbxField.SelectedIndex = 0;
			btnSet_Click(sender, e);
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

		private void btnRefreshFilmCompany_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter _dataAdapter = new OleDbDataAdapter(_queryFilmCompanies, connection);

				int selectedIndex = cbxFilmCompany.SelectedIndex;
				var selectedValue = cbxFilmCompany.SelectedValue;
				_dataSet.Tables["FilmCompany"].Clear();
				_dataAdapter.Fill(_dataSet, "FilmCompany");
				if (selectedIndex != -1)
				{
					cbxFilmCompany.SelectedValue = selectedValue;
				}
				else
				{
					cbxFilmCompany.SelectedIndex = -1;
				}
			}
		}

		private void btnDelScreenwriter_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				string queryDelete = "DELETE FROM Screenwriters WHERE [id] = @id";

				OleDbCommand cmd = new OleDbCommand(queryDelete, connection);
				if (lstScreenwriters.SelectedIndex > -1)
				{
					cmd.Parameters.Add("@id", OleDbType.Integer).Value = lstScreenwriters.SelectedValue;
					connection.Open();
					cmd.ExecuteNonQuery();
					connection.Close();
					ReloadData();
				}
			}
		}

		private void btnDelDirector_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				string queryDelete = "DELETE FROM Directors WHERE [id] = @id";

				OleDbCommand cmd = new OleDbCommand(queryDelete, connection);
				if (lstDirectors.SelectedIndex > -1)
				{
					cmd.Parameters.Add("@id", OleDbType.Integer).Value = lstDirectors.SelectedValue;
					connection.Open();
					cmd.ExecuteNonQuery();
					connection.Close();
					ReloadData();
				}
			}
		}

		private void btnAddScreeneriter_Click(object sender, EventArgs e)
		{
			using (PersonForm f = new PersonForm(_connectionString))
			{
				if (f.ShowDialog(this) != DialogResult.OK) { return; }
				using (OleDbConnection connection = new OleDbConnection(_connectionString))
				{
					string queryDelete = "INSERT INTO Screenwriters (idPerson, idFilm) VALUES (@idPerson, @idFilm)";
					OleDbCommand cmd = new OleDbCommand(queryDelete, connection);
					cmd.Parameters.Add("@idPerson", OleDbType.Integer).Value = f.id;
					cmd.Parameters.Add("@idFilm", OleDbType.Integer).Value = dgvFilms.CurrentRow.Cells[0].Value;
					connection.Open();
					cmd.ExecuteNonQuery();
					connection.Close();
					ReloadData();
				}
			}
		}

		private void btnAddDirector_Click(object sender, EventArgs e)
		{
			using (PersonForm f = new PersonForm(_connectionString))
			{
				if (f.ShowDialog(this) != DialogResult.OK) { return; }
				using (OleDbConnection connection = new OleDbConnection(_connectionString))
				{
					string queryDelete = "INSERT INTO Directors (idPerson, idFilm) VALUES (@idPerson, @idFilm)";
					OleDbCommand cmd = new OleDbCommand(queryDelete, connection);
					cmd.Parameters.Add("@idPerson", OleDbType.Integer).Value = f.id;
					cmd.Parameters.Add("@idFilm", OleDbType.Integer).Value = dgvFilms.CurrentRow.Cells[0].Value;
					connection.Open();
					cmd.ExecuteNonQuery();
					connection.Close();
					ReloadData();
				}
			}
		}
	}
}
