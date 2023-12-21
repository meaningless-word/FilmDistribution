using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Office
{
	public partial class PaymentForm : Form
	{
		private string _connectionString;
		private string _queryAccounts;
		private string _queryPayments;
		private DataSet _dataSet;
		private BindingSource _bsMaster;
		private BindingSource _bsDetail;
		private Dictionary<string, string> _args;

		public PaymentForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];
			_queryAccounts = "SELECT Leasing.id, Leasing.documentNo, Leasing.stopDate," +
				" Leasing.rentPrice - IIF(ISNULL(SUM(Payments.payment)), 0, SUM(Payments.payment)) AS balance," +
				" IIF(Leasing.stopDate < Now, CInt(Now - Leasing.stopDate), 0) AS delay," +
				" IIF(Leasing.stopDate < Now, CInt(Now - Leasing.stopDate), 0) * Leasing.delayPrice AS delayPayment," +
				" Leasing.rentPrice - IIF(ISNULL(SUM(Payments.payment)), 0, SUM(Payments.payment)) + IIF(Leasing.stopDate < Now, CInt(Now -  Leasing.stopDate), 0) * Leasing.delayPrice AS total" +
				" FROM Leasing" +
				" LEFT JOIN Payments ON Payments.idLeasing = Leasing.id" +
				" WHERE ISNULL(Leasing.returnDate)" +
				" GROUP BY Leasing.id, Leasing.documentNo, Leasing.stopDate, Leasing.rentPrice, Leasing.delayPrice" +
				" ORDER BY Leasing.stopDate"
				;
			_queryPayments = "SELECT Payments.id, Payments.idLeasing, Payments.paymentDate, Payments.payment " +
				" FROM Payments" +
				" INNER JOIN Leasing ON Leasing.id = Payments.idLeasing" +
				" WHERE ISNULL(Leasing.returnDate)" +
				" ORDER BY Payments.paymentDate"
				;

			_dataSet = new DataSet();
			_bsMaster = new BindingSource();
			_bsDetail = new BindingSource();

			ReloadData();

			dgvAccounts.AllowUserToAddRows = false;
			dgvAccounts.AllowUserToDeleteRows = false;
			dgvAccounts.ReadOnly = true;
			dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvAccounts.AutoGenerateColumns = false;
			dgvAccounts.DataSource = _bsMaster;
			dgvAccounts.Columns.AddRange(new DataGridViewColumn[]
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
					DataPropertyName="stopDate",
					HeaderText = "окончание проката",
					Width = 70
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="balance",
					HeaderText = "остаток платежа",
					Width = 60
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="delay",
					HeaderText = "дней просрочки",
					Width = 40
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="delayPayment",
					HeaderText = "пеня",
					Width = 60
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="total",
					HeaderText = "итого к погашению",
					Width = 60
				}
			});

			dgvPayments.AllowUserToAddRows = false;
			dgvPayments.AllowUserToDeleteRows = false;
			dgvPayments.ReadOnly = true;
			dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvPayments.AutoGenerateColumns = false;
			dgvPayments.DataSource = _bsDetail;
			dgvPayments.Columns.AddRange(new DataGridViewColumn[]
			{
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "id",
					Visible = false
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "idLeasing",
					Visible = false
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="paymentDate",
					HeaderText = "дата платежа",
					Width = 70
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="payment",
					HeaderText = "платеж",
					Width = 60
				}
			});

			edtPayment.Enabled = bool.Parse(_args["W"]) & bool.Parse(_args["E"]);
		}

		private void edtPayment_Validating(object sender, CancelEventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				if (tb.Text.Length == 0) { return; }
				decimal result;
				CultureInfo ci = CultureInfo.CurrentUICulture;

				tb.Text = Regex.Replace(tb.Text, @"[\.\,]", ci.NumberFormat.NumberDecimalSeparator);
				if (!decimal.TryParse(tb.Text, out result))
				{
					e.Cancel = true;
					tb.SelectAll();
					erpValidator.SetError(tb, "введено нечисловое значение");
				}
			}
		}

		private void edtPayment_Validated(object sender, EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				erpValidator.SetError(tb, string.Empty);
			}
		}

		private void btnPay_Click(object sender, EventArgs e)
		{
			pnlCreatePayment.Enabled = true;
			dtpPaymentDate.Value = DateTime.Now.Date;
			edtPayment.Text = string.Empty;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (edtPayment.Text.Trim() == string.Empty) { erpValidator.SetError(edtPayment, "необходимо ввести сумму платежа");  return; }
			if (decimal.Parse(edtPayment.Text) == 0) { erpValidator.SetError(edtPayment, "необходимо ввести сумму платежа"); return; }

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				string querySelect = "SELECT Leasing.rentPrice - IIF(ISNULL(SUM(Payments.payment)), 0, SUM(Payments.payment)) + IIF(Leasing.stopDate < Now, CInt(Now -  Leasing.stopDate), 0) * Leasing.delayPrice AS total" +
				" FROM Leasing" +
				" LEFT JOIN Payments ON Payments.idLeasing = Leasing.id" +
				" WHERE Leasing.id = @id" +
				" GROUP BY Leasing.id, Leasing.documentNo, Leasing.stopDate, Leasing.rentPrice, Leasing.delayPrice"
				;
				OleDbCommand cmd = new OleDbCommand(querySelect, connection);
				cmd.Parameters.Add("@id", OleDbType.Integer).Value = dgvAccounts.CurrentRow.Cells[0].Value;
				connection.Open();
				DataTable dt = new DataTable();
				OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
				adapter.Fill(dt);
				decimal d = dt.Rows[0].Field<decimal>("total");
				connection.Close();

				if (d < decimal.Parse(edtPayment.Text))
				{
					MessageBox.Show($"Вонсимая сумма превышает задолженность по договору в размере {d.ToString("# ##0.00")}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string queryInsert = "INSERT INTO Payments (idLeasing, paymentDate, payment)" +
					" VALUES (@idLeasing, @paymentDate, @payment)";
				cmd = new OleDbCommand(queryInsert, connection);
				cmd.Parameters.Add("@idLeasing", OleDbType.Integer).Value = dgvAccounts.CurrentRow.Cells[0].Value;
				cmd.Parameters.Add("@paymentDate", OleDbType.DBDate).Value = dtpPaymentDate.Value.Date;
				cmd.Parameters.Add("@payment", OleDbType.Currency).Value = decimal.Parse(edtPayment.Text);
				connection.Open();

				try
				{
					cmd.ExecuteNonQuery();
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

			pnlCreatePayment.Enabled = false;
		}

		private void ReloadData()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				int iRow = -1;

				if (dgvAccounts.Rows.Count > 0) { iRow = dgvAccounts.CurrentRow.Index; }
				if (_dataSet.Relations.Contains("relation")) { _dataSet.Relations.Remove("relation"); }
				if (_dataSet.Tables.Contains("Payments")) { _dataSet.Tables["Payments"].Clear(); }
				if (_dataSet.Tables.Contains("Accounts")) { _dataSet.Tables["Accounts"].Clear(); }

				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(_queryAccounts, connection);
				dataAdapter.Fill(_dataSet, "Accounts");
				dataAdapter = new OleDbDataAdapter(_queryPayments, connection);
				dataAdapter.Fill(_dataSet, "Payments");
				_dataSet.Relations.Add("relation", _dataSet.Tables["Accounts"].Columns["id"], _dataSet.Tables["Payments"].Columns["idLeasing"]);
				_bsMaster.DataSource = _dataSet;
				_bsMaster.DataMember = "Accounts";
				_bsDetail.DataSource = _bsMaster;
				_bsDetail.DataMember = "relation";
				if (dgvAccounts.Rows.Count > 0 && iRow > -1) { dgvAccounts.Rows[iRow].Selected = true; }
			}
		}

		private void dgvAccounts_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			if (e.StateChanged == DataGridViewElementStates.Selected)
			{
				var selectedRow = e.Row;
				dgvAccounts.CurrentCell = e.Row.Cells[1];
			}
		}
	}
}
