﻿using System;
using System.Windows.Forms;

namespace FilmDistribution
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
