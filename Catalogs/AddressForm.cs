using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Catalogs
{
	public partial class AddressForm : Form
	{
		private string _connectionString;
		private string _queryAddress;
		private string _queryCity;
		private string _queryStreets;
		private string _queryElements;
		private DataSet _dataSet;
		private BindingSource _bindingSource;
		public DataGridViewCell id;
		public AddressForm(string connectionString)
		{
			InitializeComponent();
			_connectionString = connectionString;
			_queryAddress = "SELECT id, idCity, idElement, idStreet, buildingNo, officeNo FROM Addresses WHERE id = @id";
			_queryCity = "SELECT id, title FROM Cities ORDER BY title";
			_queryStreets = "SELECT id, title FROM Streets ORDER BY title";
			_queryElements = "SELECT id, title FROM Elements ORDER BY title";
			_dataSet = new DataSet();
			_bindingSource = new BindingSource();
		}

		private void AddressForm_Load(object sender, EventArgs e)
		{
			ReloadData();
		}

		private void ReloadData()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter da = new OleDbDataAdapter();
				da.SelectCommand = new OleDbCommand(_queryAddress, connection);
				da.SelectCommand.Parameters.AddWithValue("@id", id.Value ?? 0);
				da.Fill(_dataSet, "Address");
				if (_dataSet.Tables["Address"].Rows.Count == 0)
				{
					DataRow dr = _dataSet.Tables[0].NewRow();
					_dataSet.Tables[0].Rows.Add(dr);
				}
				_bindingSource.DataSource = _dataSet;
				_bindingSource.DataMember = "Address";

				da.SelectCommand = new OleDbCommand(_queryCity, connection);
				da.Fill(_dataSet, "Cities");
				da.SelectCommand = new OleDbCommand(_queryStreets, connection);
				da.Fill(_dataSet, "Streets");
				da.SelectCommand = new OleDbCommand(_queryElements, connection);
				da.Fill(_dataSet, "Elements");
			}

			cbxCity.DataSource = _dataSet.Tables["Cities"];
			cbxCity.ValueMember = "id";
			cbxCity.DisplayMember = "title";
			cbxCity.DataBindings.Add(new Binding("SelectedValue", _bindingSource, "idCity", false, DataSourceUpdateMode.OnPropertyChanged));

			cbxElement.DataSource = _dataSet.Tables["Elements"];
			cbxElement.ValueMember = "id";
			cbxElement.DisplayMember = "title";
			cbxElement.DataBindings.Add(new Binding("SelectedValue", _bindingSource, "idElement", false, DataSourceUpdateMode.OnPropertyChanged));

			cbxStreet.DataSource = _dataSet.Tables["Streets"];
			cbxStreet.ValueMember = "id";
			cbxStreet.DisplayMember = "title";
			cbxStreet.DataBindings.Add(new Binding("SelectedValue", _bindingSource, "idStreet", false, DataSourceUpdateMode.OnPropertyChanged));

			edtBuildingNo.DataBindings.Add(new Binding("Text", _bindingSource, "buildingNo", false, DataSourceUpdateMode.OnPropertyChanged));
			edtOfficeNo.DataBindings.Add(new Binding("Text", _bindingSource, "officeNo", false, DataSourceUpdateMode.OnPropertyChanged));
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter da = new OleDbDataAdapter(_queryAddress, connection);
				OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(da);
				da.InsertCommand = commandBuilder.GetInsertCommand();
				da.UpdateCommand = commandBuilder.GetUpdateCommand();
				da.DeleteCommand = commandBuilder.GetDeleteCommand();
				da.SelectCommand.CommandText = "SELECT TOP 1 id, buildingNo, officeNo" +
					" FROM Addresses" +
					" WHERE idCity = @idCity" +
					" AND idElement = @idElement" +
					" AND idStreet = @idStreet" +
					" ORDER BY id DESC";
				da.SelectCommand.Parameters.AddWithValue("@idCity", cbxCity.SelectedValue);
				da.SelectCommand.Parameters.AddWithValue("@idElement", cbxElement.SelectedValue);
				da.SelectCommand.Parameters.AddWithValue("@idStreet", cbxStreet.SelectedValue);

				try
				{
					this.Validate();
					_bindingSource.EndEdit();

					da.Update(_dataSet, "Address");
					string value = id.Value as string;
					if (value == null)
					{
						if (_dataSet.Tables.Contains("Address")) { _dataSet.Tables["Address"].Clear(); }
						da.Fill(_dataSet, "Address");
						if (_dataSet.Tables["Address"].Rows.Count == 0)
						{
							MessageBox.Show("Странно, потерялась...", "A-a-a-a", MessageBoxButtons.OK, MessageBoxIcon.Error);
							this.DialogResult = DialogResult.Cancel;
						}
						else
						{
							this.id.Value = _dataSet.Tables["Address"].Rows[0].Field<int>("id");
							this.DialogResult = DialogResult.OK;
						}
					}
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
			this.Close();
		}
	}
}
