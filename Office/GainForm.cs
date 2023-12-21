using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace Office
{
	public partial class GainForm : Form
	{
		private string _connectionString;
		private string _queryString;
		private DataSet _dataSet;
		private BindingSource _bindingSource;
		private Dictionary<string, string> _args;

		public GainForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];
			_queryString = "SELECT l.id" +
				" , f.title AS filmTitle, f.year_of_release" +
				" , c.title AS cinemaTitle" +
				" , l.stopDate, l.returnDate" +
				" , l.rentPrice - IIF(IsNull(p.payment), 0, p.payment) + IIF(IsNull(delay.days), 0, delay.days) * l.delayPrice AS total" +
				" , delay.days * l.delayPrice AS delayCost" +
				" , pCur.payment AS current_payments" +
				" FROM ((((Leasing l" +
				" INNER JOIN Films f ON f.id = l.idFilm)" +
				" INNER JOIN Cinemas c ON c.id = l.idCinema)" +
				" LEFT JOIN (" +
				"   SELECT idLeasing, SUM(payment) AS payment" +
				"   FROM Payments" +
				"   GROUP BY idLeasing" +
				" ) p ON p.idLeasing = l.id)" +
				" LEFT JOIN (" +
				"   SELECT idLeasing, SUM(payment) AS payment" +
				"   FROM Payments" +
				"   WHERE Year(paymentDate) = Year(Now) AND Month(paymentDate) = Month(Now) " +
				"   GROUP BY idLeasing" +
				" ) pCur ON pCur.idLeasing = l.id)" +
				" LEFT JOIN (" +
				"   SELECT id, DateDiff('d', stopDate, IIF(IsNull(returnDate), Now, returnDate)) AS days" +
				"   FROM Leasing" +
				"   WHERE stopDate <= Now AND IIF(IsNull(returnDate), Now, returnDate) > stopDate" +
				" ) delay ON delay.id = l.id" +
				" WHERE l.stopDate < DateAdd('m', 1, DateSerial(Year(Now), Month(Now), 1))" +
				"";
			_dataSet = new DataSet();
			_bindingSource = new BindingSource();
			ReloadData();

			dgvGain.AllowUserToAddRows = false;
			dgvGain.AllowUserToDeleteRows = false;
			dgvGain.ReadOnly = true;
			dgvGain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvGain.AutoGenerateColumns = false;
			dgvGain.DataSource = _bindingSource;
			dgvGain.Columns.AddRange(new DataGridViewColumn[]
			{
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "id",
					Visible = false
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
					DataPropertyName="total",
					HeaderText = "оставшаяся задоженность",
					Width = 75,
					DefaultCellStyle = new DataGridViewCellStyle() { Format = "# ##0.00", Alignment = DataGridViewContentAlignment.MiddleRight }
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="delayCost",
					HeaderText = "пеня",
					Width = 75,
					DefaultCellStyle = new DataGridViewCellStyle() { Format = "# ##0.00", Alignment = DataGridViewContentAlignment.MiddleRight }
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName="current_payments",
					HeaderText = "выплат в текущем месяце",
					Width = 75,
					DefaultCellStyle = new DataGridViewCellStyle() { Format = "# ##0.00", Alignment = DataGridViewContentAlignment.MiddleRight }
				}
			});
		}

		private void ReloadData()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();

				OleDbDataAdapter adpGain = new OleDbDataAdapter(_queryString, connection);
				_dataSet = new DataSet();
				adpGain.Fill(_dataSet, "Gain");

				_bindingSource.DataSource = _dataSet.Tables["Gain"];

				decimal total = 0, payments = 0, fine = 0;
				foreach (DataRow row in _dataSet.Tables["Gain"].Rows)
				{
					decimal income;
					if (decimal.TryParse(row["total"].ToString(), out income)) { total += income; }
					if (decimal.TryParse(row["current_payments"].ToString(), out income)) { payments += income; }
					if (decimal.TryParse(row["delayCost"].ToString(), out income)) { fine += income; }
				}
				edtCurrentPayments.Text = payments.ToString("# ##0.00");
				edtTotal.Text = total.ToString("# ##0.00");
				edtFine.Text = fine.ToString("# ##0.00");
			}
		}

		private void btnExportXL_Click(object sender, EventArgs e)
		{
			var xlApp = new Excel.Application();
			xlApp.Interactive = false;
			xlApp.EnableEvents = false;

			Excel.Workbook xlWB = xlApp.Workbooks.Add();
			Excel.Worksheet xlWS = xlWB.Worksheets.Item[1];
			Excel.Range xlRange;

			xlWS.Name = "Расчет прибыли";
			int iR = 6, iC = 2;
			foreach (DataGridViewRow r in dgvGain.Rows)
			{
				foreach (DataGridViewCell c in r.Cells)
				{
					if (!c.Visible) { continue; }
					xlRange = xlWS.Cells[iR, iC++];
					xlRange.Value = c.FormattedValue.ToString();
				}
				iR++; iC = 2;
			}

			iR = 5; iC = 2;
			foreach (DataGridViewTextBoxColumn c in dgvGain.Columns)
			{
				if (!c.Visible) { continue; }
				xlRange = xlWS.Cells[iR, iC];
				xlRange.Value = c.HeaderText;
				xlRange.Font.Bold = true;
				xlRange = xlWS.Range[xlWS.Cells[iR + 1, iC], xlWS.Cells[iR + dgvGain.RowCount + 1, iC]];
				if (c.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
				{
					xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
					xlRange.ColumnWidth = c.Width;
				}
				xlRange.ColumnWidth = c.Width / 6;

				switch (c.DataPropertyName)
				{
					case "total":
						xlWS.Cells[iR + dgvGain.RowCount + 1, iC].Value = edtTotal.Text;
						break;
					case "delayCost":
						xlWS.Cells[iR + dgvGain.RowCount + 1, iC].Value = edtFine.Text;
						break;
					case "current_payments":
						xlWS.Cells[iR + dgvGain.RowCount + 1, iC].Value = edtCurrentPayments.Text;
						break;
				}

				iC++;
			}
			iC--;
			xlWS.Cells[iR + dgvGain.RowCount + 1, 2] = "Итого:";
			xlRange = xlWS.Range[xlWS.Cells[iR + dgvGain.RowCount + 1, 2], xlWS.Cells[iR + dgvGain.RowCount + 1, iC]];
			xlRange.Font.Bold = true;
			xlRange.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
			xlRange.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
			xlRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
			xlRange.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;

			xlRange = xlWS.Range[xlWS.Cells[iR, 2], xlWS.Cells[iR, iC]];
			xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			xlRange.WrapText = true;
			xlRange.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
			xlRange.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
			xlRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
			xlRange.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
			xlRange.Borders.Color = Color.Black;

			iR = 2;
			xlRange = xlWS.Range[xlWS.Cells[iR, 2], xlWS.Cells[iR, iC]];
			xlRange.Merge();
			xlRange.Value = "Предварительный расчет прибыли";
			xlRange.Font.Size = 14;
			xlRange.Font.Bold = true;
			xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			iR++;
			xlRange = xlWS.Range[xlWS.Cells[iR, 2], xlWS.Cells[iR, iC]];
			xlRange.Merge();
			xlRange.Value = $"на {DateTime.Now.ToString("dd.MM.yyyy")}";
			xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			xlApp.Visible = true;
			xlApp.Interactive = true;
			xlApp.ScreenUpdating = true;
			xlApp.UserControl = true;
		}
	}
}
