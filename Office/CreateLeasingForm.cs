using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Office
{
	public partial class CreateLeasingForm : Form
	{
		private string _connectionString;
		private string _queryFilms;
		private string _queryCinemas;
		private DataSet _dataSet;

		public string documentNo;
		public int idFilm;
		public int idCinema;
		public DateTime dtStart;
		public DateTime dtStop;
		public decimal rentPrice;
		public decimal delayPrice;

		public CreateLeasingForm(string connectionString)
		{
			InitializeComponent();
			_connectionString = connectionString;
			_queryCinemas = "SELECT id, title FROM Cinemas ORDER BY title";
			_queryFilms = "SELECT id, title + ' (' + CSTR(year_of_release) + ')' AS title " +
				"FROM Films " +
				"WHERE title LIKE @title AND year_of_release BETWEEN @b AND @e " +
				"ORDER BY title";
			_dataSet = new DataSet();

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();

				OleDbDataAdapter adpCinemas = new OleDbDataAdapter(_queryCinemas, connection);
				adpCinemas.Fill(_dataSet, "Cinemas");

				cbxCinema.DataSource = _dataSet.Tables["Cinemas"];
				cbxCinema.ValueMember = "id";
				cbxCinema.DisplayMember = "title";

				OleDbDataAdapter adpFilms = new OleDbDataAdapter(_queryFilms, connection);
				adpFilms.SelectCommand.Parameters.AddWithValue("@title", $"%{edtTitlePart.Text}%");
				adpFilms.SelectCommand.Parameters.AddWithValue("@b", DateTime.Now.Year - 10);
				adpFilms.SelectCommand.Parameters.AddWithValue("@e", DateTime.Now.Year);
				adpFilms.Fill(_dataSet, "Films");

				cbxFilms.DataSource = _dataSet.Tables["Films"];
				cbxFilms.ValueMember = "id";
				cbxFilms.DisplayMember = "title";
			}

			ttpYearRange.SetToolTip(this.edtYearRange, "можно указать закрытый диапазон: 2010-2020, либо открытые: -2020, 2010-");

			dtpStart.Value = DateTime.Now.Date;
			dtpStop.Value = dtpStart.Value.AddMonths(1);
		}

		private void edtTitlePart_Enter(object sender, EventArgs e)
		{
			Control_Enter(sender);
		}

		private void edtTitlePart_Leave(object sender, EventArgs e)
		{
			edtYearRange.Enabled = edtTitlePart.Text.Trim().Length == 0;
		}

		private void edtYearRange_Enter(object sender, EventArgs e)
		{
			Control_Enter(sender);
		}

		private void edtYearRange_Leave(object sender, EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				tb.Text = Regex.Replace(tb.Text, @"[\s]", string.Empty);
			}
		}

		private void Control_Enter(object sender)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				tb.SelectAll();
			}
		}

		private void btnRefreshFilms_Click(object sender, EventArgs e)
		{
			if (edtTitlePart.Text.Trim().Length == 0 && edtYearRange.Text.Trim().Length == 0) { return; }

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter adpFilms = new OleDbDataAdapter(_queryFilms, connection);
				adpFilms.SelectCommand.Parameters.AddWithValue("@title", $"%{edtTitlePart.Text.Trim()}%");

				int bY = 0, eY = DateTime.Now.Year + 1;
				if (edtYearRange.Enabled)
				{
					if (Regex.Replace(edtYearRange.Text, @"[0-9\-]", string.Empty).Length == 0)
					{
						if (edtYearRange.Text.Contains("-"))
						{
							string[] strY = edtYearRange.Text.Split('-');
							bY = strY[0].Length > 0 ? int.Parse(strY[0]) : bY;
							eY = strY[1].Length > 0 ? int.Parse(strY[1]) : eY;
						}
						else
						{
							bY = int.Parse(edtYearRange.Text);
							eY = bY;
						}
					}
				}

				adpFilms.SelectCommand.Parameters.AddWithValue("@b", bY);
				adpFilms.SelectCommand.Parameters.AddWithValue("@e", eY);
				_dataSet.Tables["Films"].Clear();
				adpFilms.Fill(_dataSet, "Films");
			}
		}

		private void edtRentPrice_Validating(object sender, CancelEventArgs e)
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

		private void edtRentPrice_Validated(object sender, EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				erpValidator.SetError(tb, string.Empty);
			}
		}

		private void edtDelayPrice_Validating(object sender, CancelEventArgs e)
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

		private void edtDelayPrice_Validated(object sender, EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox tb = sender as TextBox;
				erpValidator.SetError(tb, string.Empty);
			}
		}

		private void CreateLeasingForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;

			documentNo = edtDocumentNo.Text;
			dtStart = dtpStart.Value.Date;
			dtStop = dtpStop.Value.Date;

			if (sender is Form)
			{
				Form f = sender as Form;
				if (f.ActiveControl.Text == "Отмена") { return; }
			}

			if (cbxFilms.SelectedIndex == -1)
			{
				e.Cancel |= true;
				erpValidator.SetError(cbxFilms, "ничего не выбрано");
			}
			else { idFilm = (int)cbxFilms.SelectedValue; }

			if (cbxCinema.SelectedIndex == -1)
			{
				e.Cancel |= true;
				erpValidator.SetError(cbxCinema, "ничего не выбрано");
			}
			else { idCinema = (int) cbxCinema.SelectedValue; }

			if (!decimal.TryParse(edtRentPrice.Text, out rentPrice))
			{
				e.Cancel |= true;
				erpValidator.SetError(edtRentPrice, "нечисловое значение");
			}

			if(edtRentPrice.Text.Length == 0)
			{
				e.Cancel |= true;
				erpValidator.SetError(edtRentPrice, "обязательное значение");
			}

			if (!decimal.TryParse(edtDelayPrice.Text, out delayPrice))
			{
				e.Cancel |= true;
				erpValidator.SetError(edtDelayPrice, "нечисловое значение");
			}

			if (edtDelayPrice.Text.Length == 0)
			{
				e.Cancel |= true;
				erpValidator.SetError(edtDelayPrice, "обязательное значение");
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cbxFilms_SelectedIndexChanged(object sender, EventArgs e)
		{
			erpValidator.SetError(cbxFilms, string.Empty);
		}
	}
}
