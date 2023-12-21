using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text.Json;
using System.Windows.Forms;

namespace Office
{
	public partial class LeaseForm : Form
	{
		private string _connectionString;
		private string _queryString;
		private DataSet _dataSet;
		private BindingSource _bindingSource;
		private Dictionary<string, string> _args;

		public LeaseForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];
			_queryString = "SELECT Leasing.[id], Leasing.[idFilm], Leasing.[idCinema], Leasing.[documentNo]" +
				", Leasing.[startDate], Leasing.[stopDate], Leasing.[returnDate], Leasing.[rentPrice], Leasing.[delayPrice]" +
				", Cinemas.title AS cinemaTitle, Films.title AS filmTitle, Films.year_of_release" +
				", IIF(ISNULL(Leasing.[returnDate]), 1, 0) AS returned" +
				" FROM(Leasing" +
				" INNER JOIN Cinemas ON Cinemas.id = Leasing.idCinema)" +
				" INNER JOIN Films ON Films.id = Leasing.[idFilm]" +
				" WHERE Leasing.stopDate >= @beginPeriod" +
				" AND Leasing.startDate <= @endPeriod" +
				" AND IIF(ISNULL(Leasing.[returnDate]), 1, 0) >= @isClosed" +
				" ORDER BY Leasing.[stopDate]"
				;

			_dataSet = new DataSet();
			_bindingSource = new BindingSource();
			ReloadData();

			dgvLeasing.AllowUserToAddRows = false;
			dgvLeasing.AllowUserToDeleteRows = false;
			dgvLeasing.ReadOnly = !bool.Parse(_args["E"]);
			dgvLeasing.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvLeasing.AutoGenerateColumns = false;
			dgvLeasing.DataSource = _bindingSource;
			dgvLeasing.Columns.AddRange(new DataGridViewColumn[]
			{
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "id",
					Visible = false
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "documentNo",
					HeaderText = "№ договора",
					Width = 100
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "cinemaTitle",
					HeaderText = "кинотеатр",
					Width = 200
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "filmTitle",
					HeaderText = "фильм",
					Width = 200
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="year_of_release",
					HeaderText = "год выхода на экран",
					Width = 70
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="startDate",
					HeaderText = "начало проката",
					Width = 70
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="stopDate",
					HeaderText = "окончание проката",
					Width = 70
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="returnDate",
					HeaderText = "возврат",
					Width = 70
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="rentPrice",
					HeaderText = "стоимость аренды",
					Width = 65
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="delayPrice",
					HeaderText = "стоимость дня просрочки",
					Width = 65
				}
			});

			dtpBeginPeriod.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			dtpEndPeriod.Value = DateTime.Now.Date;

			pnlPeriod.DataBindings.Add("Enabled", rdbPeriod, "Checked");

			btnCreate.Enabled = bool.Parse(_args["W"]);
			btnClose.Enabled = bool.Parse(_args["D"]);
			btnDelete.Enabled = bool.Parse(_args["D"]);
		}

		private void ReloadData()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				int iRow = -1;

				if (dgvLeasing.Rows.Count > 0) { iRow = dgvLeasing.CurrentRow.Index; }
				if (_dataSet.Tables.Contains("Leasing")) { _dataSet.Tables["Leasing"].Clear(); }
				btnClose.DataBindings.Clear();

				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryString, connection);
				if (rdbPeriod.Checked)
				{
					dataAdapter.SelectCommand.Parameters.Add("@beginPeriod", OleDbType.Date).Value = dtpBeginPeriod.Value.Date;
					dataAdapter.SelectCommand.Parameters.Add("@endPeriod", OleDbType.Date).Value = dtpEndPeriod.Value.Date;
					dataAdapter.SelectCommand.Parameters.Add("@isClosed", OleDbType.Integer).Value = 0;
				}
				else
				{
					dataAdapter.SelectCommand.Parameters.Add("@beginPeriod", OleDbType.Date).Value = new DateTime(1900, 1, 1);
					dataAdapter.SelectCommand.Parameters.Add("@endPeriod", OleDbType.Date).Value = new DateTime(DateTime.Now.Year + 1, 12, 31);
					dataAdapter.SelectCommand.Parameters.Add("@isClosed", OleDbType.Integer).Value = 1;
				}
				dataAdapter.Fill(_dataSet, "Leasing");
				_bindingSource.DataSource = _dataSet.Tables["Leasing"];
				btnClose.DataBindings.Add("Enabled", _bindingSource, "returned", false, DataSourceUpdateMode.Never);

				if (dgvLeasing.Rows.Count > 0 && iRow > -1) { dgvLeasing.Rows[iRow].Selected = true; }
			}
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
			ReloadData();
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			using (CreateLeasingForm f = new CreateLeasingForm(_connectionString))
			{
				if (f.ShowDialog(this) == DialogResult.OK)
				{
					using (OleDbConnection connection = new OleDbConnection(_connectionString))
					{
						string queryInsert = "INSERT INTO Leasing (documentNo, idFilm, idCinema, startDate, stopDate, rentPrice, delayPrice)" +
							" VALUES (@documentNo, @idFilm, @idCinema, @startDate, @stopDate, @rentPrice, @delayPrice)";
						OleDbCommand cmd = new OleDbCommand(queryInsert, connection);
						cmd.Parameters.Add("@documentNo", OleDbType.VarChar, 30).Value = f.documentNo;
						cmd.Parameters.Add("@idFilm", OleDbType.Integer).Value = f.idFilm;
						cmd.Parameters.Add("@idCinema", OleDbType.Integer).Value = f.idCinema;
						cmd.Parameters.Add("@startDate", OleDbType.DBDate).Value = f.dtStart;
						cmd.Parameters.Add("@stopDate", OleDbType.DBDate).Value = f.dtStop;
						cmd.Parameters.Add("@rentPrice", OleDbType.Currency).Value = f.rentPrice;
						cmd.Parameters.Add("@delayPrice", OleDbType.Currency).Value = f.delayPrice;
						connection.Open();

						try
						{
							cmd.ExecuteNonQuery();
							connection.Close();
							ReloadData();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
		}

		private void dgvLeasing_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			if (e.StateChanged == DataGridViewElementStates.Selected)
			{
				var selectedRow = e.Row;
				dgvLeasing.CurrentCell = e.Row.Cells[1];
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				string querySelect = "SELECT Leasing.rentPrice - IIF(ISNULL(SUM(Payments.payment)), 0, SUM(Payments.payment)) + IIF(Leasing.stopDate < Now, CInt(Now -  Leasing.stopDate), 0) * Leasing.delayPrice AS total" +
				" FROM Leasing" +
				" LEFT JOIN Payments ON Payments.idLeasing = Leasing.id" +
				" WHERE Leasing.id = @id" +
				" GROUP BY Leasing.id, Leasing.documentNo, Leasing.stopDate, Leasing.rentPrice, Leasing.delayPrice"
				;
				string queryUpdate = "UPDATE Leasing SET returnDate = @d WHERE [id] = @id";

				OleDbCommand cmd = new OleDbCommand(querySelect, connection);
				cmd.Parameters.Add("@id", OleDbType.Integer).Value = dgvLeasing.CurrentRow.Cells[0].Value;

				connection.Open();
				DataTable dt = new DataTable();
				OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
				adapter.Fill(dt);
				decimal d = dt.Rows[0].Field<decimal>("total");

				if (d == 0)
				{
					using (GetDateForm f = new GetDateForm("дата закрытия договора"))
					{
						if (f.ShowDialog(this) == DialogResult.OK)
						{
							cmd.CommandText = queryUpdate;
							cmd.Parameters.Clear();
							cmd.Parameters.Add("@d", OleDbType.DBDate).Value = f.SelectedDate;
							cmd.Parameters.Add("@id", OleDbType.Integer).Value = dgvLeasing.CurrentRow.Cells[0].Value;
							cmd.ExecuteNonQuery();
							connection.Close();
							ReloadData();
						}
					}
				}
				else
				{
					MessageBox.Show($"Сначала необходимо погаcить задолженность в размере {d.ToString("# ##0.00")}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				string querySelect = "SELECT IIF(ISNULL(SUM(payment)), 0, SUM(payment)) AS total" +
				" FROM Payments" +
				" WHERE idLeasing = @id" +
				" GROUP BY idLeasing"
				;
				string queryDelete = "DELETE FROM Leasing WHERE [id] = @id";

				OleDbCommand cmd = new OleDbCommand(querySelect, connection);
				cmd.Parameters.Add("@id", OleDbType.Integer).Value = dgvLeasing.CurrentRow.Cells[0].Value;

				connection.Open();
				DataTable dt = new DataTable();
				OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
				adapter.Fill(dt);
				decimal d = dt.Rows[0].Field<decimal>("total");

				if (d == 0)
				{
					cmd.CommandText = queryDelete;
					cmd.Parameters.Clear();
					cmd.Parameters.Add("@id", OleDbType.Integer).Value = dgvLeasing.CurrentRow.Cells[0].Value;
					cmd.ExecuteNonQuery();
					connection.Close();
					ReloadData();
				}
				else
				{
					MessageBox.Show($"По договору проведены выплаты в размере {d.ToString("# ##0.00")}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}
	}
}
