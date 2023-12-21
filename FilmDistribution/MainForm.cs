using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace FilmDistribution
{
	public partial class MainForm : Form
	{
		private int _authorizedUserId;
		private bool _isAdmin;
		private string _connectionString;
		private DataTable _dataTable;

		public MainForm()
		{
			InitializeComponent();
			_authorizedUserId = -1;
			_isAdmin = false;
			_connectionString = ConfigurationManager.ConnectionStrings["FilmDistribution.Properties.Settings.AccessDBConnector"].ConnectionString;
			_dataTable = new DataTable();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			using (LoginForm loginForm = new LoginForm(_connectionString))
			{
				loginForm.ShowDialog(this);
				_authorizedUserId = loginForm.userId;
				_isAdmin = loginForm.isAdmin;
				if (_authorizedUserId == -1)
				{
					Application.Exit();
				}
			}

			LoadMenu();

		}

		private void LoadMenu()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter adapter = new OleDbDataAdapter();
				StringBuilder strQuery = new StringBuilder("SELECT m.id, m.idParent, m.itemTitle, m.libName, m.className, m.compose");
				strQuery.Append(!_isAdmin ? ", p.W, p.E, p.D" : ", 'true' AS W, 'true' AS E, 'true' AS D");
				strQuery.Append(" FROM MenuItems AS m");
				strQuery.Append(!_isAdmin ? " INNER JOIN Permissions p ON p.idMenuItem = m.id WHERE p.idUser = @idUser AND p.R" : "");
				strQuery.Append(" ORDER BY m.compose");
				OleDbCommand command = new OleDbCommand(strQuery.ToString(), connection);
				command.Parameters.Add("@idUser", OleDbType.Integer).Value = _authorizedUserId;
				adapter.SelectCommand = command;
				adapter.Fill(_dataTable);

				PrepareMenu(mainMenu, 0, _dataTable);
				ToolStripMenuItem itemWindows = new ToolStripMenuItem("Окно");
				mainMenu.Items.Add(itemWindows);
				mainMenu.MdiWindowListItem = itemWindows;

				ToolStripMenuItem content = new ToolStripMenuItem("Содержание");
				content.Click += this.ContentItem_Click;

				ToolStripMenuItem about = new ToolStripMenuItem("О программе");
				about.Click += this.AboutItem_Click;

				ToolStripMenuItem mi = new ToolStripMenuItem("Помощь");
				mi.DropDownItems.Add(content);
				mi.DropDownItems.Add(about);

				mainMenu.Items.Add(mi);
			}
		}

		private void PrepareMenu(object sender, int deep, DataTable t)
		{
			DataRow[] currentLevelItems = t.Select($"idParent = {deep}");
			foreach (DataRow item in currentLevelItems)
			{
				ToolStripMenuItem i = new ToolStripMenuItem(item["itemTitle"].ToString());
				if (item["libName"].Equals(DBNull.Value))
				{
					PrepareMenu(i, (int)item["id"], t);
				}
				else
				{

					i.Tag = item["id"];
					i.Click += this.menuItem_Click;
				}

				if (sender is MenuStrip)
				{
					MenuStrip menu = (MenuStrip)sender;
					menu.Items.Add(i);
				}
				else if (sender is ToolStripMenuItem)
				{
					ToolStripMenuItem menu = (ToolStripMenuItem)sender;
					menu.DropDownItems.Add(i);
				}
			}
		}

		private void menuItem_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem item = sender as ToolStripMenuItem;
				DataRow[] r = _dataTable.Select($"id = {item.Tag}");

				Assembly a = Assembly.LoadFrom($"{r[0]["libName"]}.dll"); // загрузка библиотеки
				Type[] types = a.GetTypes(); // запрос всех классов
				int i;
				for (i = 0; i < types.Length; i++) // поиск класса, приписанного пункту меню
					if (types[i].Name == $"{r[0]["className"]}") break;
				if (i == types.Length)
				{
					MessageBox.Show($"Класс {r[0]["libName"]}.{r[0]["className"]} отсутствует в библиотеке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				for (int x = 0; x < this.MdiChildren.Length; x++)
				{
					if (this.MdiChildren[x].Name == r[0]["className"].ToString())
					{
						Form tempChild = (Form)this.MdiChildren[x];
						tempChild.Hide();
						tempChild.Show();
						return;
					}
				}

				ConstructorInfo[] ci = types[i].GetConstructors(); // запрос всех конструкторов класса
				int j;
				for (j = 0; j < ci.Length; j++) // поиск конструктора у найденного класса
				{
					ParameterInfo[] pi = ci[j].GetParameters();
					if ((pi.Length == 1) && (pi[0].Name == "args"))
					{
						Dictionary<string, string> args = new Dictionary<string, string>()
						{
							{ "connectionString", _connectionString },
							{ "W", r[0]["W"].ToString() },
							{ "E", r[0]["E"].ToString() },
							{ "D", r[0]["D"].ToString() },
						};
						string json = JsonSerializer.Serialize<Dictionary<string, string>>(args);

						dynamic obj = ci[j].Invoke(new Object[] { json });
						obj.MdiParent = this;
						obj.Show();
						break;
					}
				}
				if (j == ci.Length)
				{
					MessageBox.Show("Подходящий конструктор в классе не обнаружен.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
		}

		private void ContentItem_Click(object sender, EventArgs e)
		{
			HelpForm h = new HelpForm();
			h.MdiParent = this;
			h.Show();
		}

		private void AboutItem_Click(object sender, EventArgs e)
		{
			using (AboutForm about = new AboutForm())
			{
				about.ShowDialog(this);
			}
		}
	}
}
