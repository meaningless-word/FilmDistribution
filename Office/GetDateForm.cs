using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Office
{
	public partial class GetDateForm : Form
	{
		public DateTime SelectedDate;
		public GetDateForm()
		{
			InitializeComponent();
			dtpDate.Value = DateTime.Now;
		}

		public GetDateForm(string ask)
		{
			InitializeComponent();
			lblAsk.Text = ask;
			dtpDate.Value = DateTime.Now;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			SelectedDate = dtpDate.Value.Date;
			this.Close();
		}
	}
}
