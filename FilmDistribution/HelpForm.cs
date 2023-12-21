using System;
using System.Windows.Forms;

namespace FilmDistribution
{
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();
			web.Navigate(new Uri($"{Application.StartupPath}\\help\\help.htm"));
		}
	}
}
