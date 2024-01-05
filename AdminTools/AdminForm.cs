using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

namespace AdminTools
{
	public partial class AdminForm : Form
	{
		private string _connectionString;
		private string _queryUsers;
		private string _queryPermissions;
		private string _queryMissPermiss;
		private DataSet _dataSet;
		private BindingSource _bsUsers;
		private BindingSource _bsPermissions;
		private Dictionary<string, string> _args;

		public AdminForm(string args)
		{
			InitializeComponent();
			_args = JsonSerializer.Deserialize<Dictionary<string, string>>(args);
			_connectionString = _args["connectionString"];
			_queryUsers = "SELECT id, Login, isReset FROM Users";
			_queryPermissions = "SELECT Permissions.id, Permissions.idUser, Permissions.idMenuItem, R, W, E, D" +
				" , itemTitle" +
				" FROM Permissions" +
				" INNER JOIN MenuItems ON MenuItems.id = Permissions.idMenuItem" +
				" ORDER BY compose";
			_queryMissPermiss = "SELECT id FROM MenuItems WHERE id NOT IN (SELECT DISTINCT idMenuItem FROM Permissions)";

			_dataSet = new DataSet();
			_bsUsers = new BindingSource();
			_bsPermissions = new BindingSource();

			ReloadData();

			dgvUsers.AllowUserToAddRows = false;
			dgvUsers.AllowUserToDeleteRows = false;
			dgvUsers.ReadOnly = true;
			dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvUsers.AutoGenerateColumns = false;
			dgvUsers.DataSource = _bsUsers;
			dgvUsers.Columns.AddRange(new DataGridViewColumn[]
			{
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "id",
					Visible = false
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "Login",
					HeaderText = "логин",
					Width = 100
				},
				new DataGridViewCheckBoxColumn()
				{
					DataPropertyName = "isReset",
					HeaderText = "",
					Width = 25
				}
			});

			dgvPermissions.AllowUserToAddRows = false;
			dgvPermissions.AllowUserToDeleteRows = false;
			dgvPermissions.ReadOnly = false;
			dgvPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvPermissions.AutoGenerateColumns = false;
			dgvPermissions.DataSource = _bsPermissions;
			dgvPermissions.Columns.AddRange(new DataGridViewColumn[]
			{
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "id",
					Visible = false
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "itemTitle",
					HeaderText = "пункт меню",
					Width = 150,
					ReadOnly = true
				},
				new DataGridViewCheckBoxColumn()
				{
					DataPropertyName = "R",
					HeaderText = "R",
					Width = 25
				},
				new DataGridViewCheckBoxColumn()
				{
					DataPropertyName = "W",
					HeaderText = "W",
					Width = 25
				},
				new DataGridViewCheckBoxColumn()
				{
					DataPropertyName = "E",
					HeaderText = "E",
					Width = 25
				},
				new DataGridViewCheckBoxColumn()
				{
					DataPropertyName = "D",
					HeaderText = "D",
					Width = 25
				}
			});

		}

		private void ReloadData()
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				int iFirstRow = -1;
				if (dgvUsers.Rows.Count > 0 && dgvUsers.FirstDisplayedCell != null) { iFirstRow = dgvUsers.FirstDisplayedCell.RowIndex; }
				Point cell = dgvUsers.CurrentCellAddress;

				connection.Open();
				if (_dataSet.Relations.Contains("relation")) { _dataSet.Relations.Remove("relation"); }
				if (_dataSet.Tables.Contains("Permissions")) { _dataSet.Tables["Permissions"].Clear(); }
				if (_dataSet.Tables.Contains("MissPermiss")) { _dataSet.Tables["MissPermiss"].Clear(); }
				if (_dataSet.Tables.Contains("Users")) { _dataSet.Tables["Users"].Clear(); }
				btnCreateAccess.DataBindings.Clear();

				OleDbDataAdapter da = new OleDbDataAdapter();
				da.SelectCommand = new OleDbCommand(_queryUsers, connection);
				da.Fill(_dataSet, "Users");
				da.SelectCommand = new OleDbCommand(_queryPermissions, connection);
				da.Fill(_dataSet, "Permissions");
				da.SelectCommand = new OleDbCommand(_queryMissPermiss, connection);
				da.Fill(_dataSet, "MissPermiss");

				_dataSet.Relations.Add("relation", _dataSet.Tables["Users"].Columns["id"], _dataSet.Tables["Permissions"].Columns["idUser"]);
				_bsUsers.DataSource = _dataSet;
				_bsUsers.DataMember = "Users";
				_bsPermissions.DataSource = _bsUsers;
				_bsPermissions.DataMember = "relation";

				if (iFirstRow > -1 && iFirstRow < dgvUsers.Rows.Count) { dgvUsers.FirstDisplayedScrollingRowIndex = iFirstRow; }
				dgvUsers.MultiSelect = false;
				if (cell.X > -1) { dgvUsers.Rows[cell.Y].Cells[cell.X].Selected = true; }
				dgvUsers.MultiSelect = true;
			}
		}

		private void btnResetPassword_Click(object sender, EventArgs e)
		{
			if (dgvUsers.CurrentRow.Index == -1) { return; }
			using (GetPasswordForm f = new GetPasswordForm())
			{
				if (f.ShowDialog(this) == DialogResult.OK)
				{
					using (OleDbConnection connection = new OleDbConnection(_connectionString))
					{
						connection.Open();
						string queryUpdate = "UPDATE [Users] SET [Password] = @pwd, isReset = true WHERE [id] = @id";
						OleDbCommand cmd = new OleDbCommand(queryUpdate, connection);
						cmd.Parameters.Add("@pwd", OleDbType.VarChar).Value = f.Password;
						cmd.Parameters.Add("@id", OleDbType.Integer).Value = dgvUsers.CurrentRow.Cells[0].Value;
						cmd.ExecuteNonQuery();
						connection.Close();
						ReloadData();
					}
				}
			}
		}

		private void btnCreateAccess_Click(object sender, EventArgs e)
		{
			if (dgvUsers.CurrentRow.Index == -1) { return; }
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				string queryUpdate = "INSERT INTO Permissions (idMenuItem, idUser, R, W, E, D)" +
				" SELECT [MenuItems.id], @idUser, 0, 0, 0, 0" +
				" FROM MenuItems" +
				" LEFT JOIN Permissions ON (Permissions.idMenuItem = MenuItems.id AND Permissions.idUser = @idUser)" +
				" WHERE Permissions.id IS NULL";
				OleDbCommand cmd = new OleDbCommand(queryUpdate, connection);
				cmd.Parameters.Add("@idUser", OleDbType.Integer).Value = dgvUsers.CurrentRow.Cells[0].Value;
				cmd.ExecuteNonQuery();
				connection.Close();
				ReloadData();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				string queryUpdate = "UPDATE Permissions SET R = @R, W = @W, E = @E, D = @D WHERE id = @id";
				OleDbCommand cmd = new OleDbCommand(queryUpdate, connection);
				cmd.Parameters.Add("@R", OleDbType.Boolean);
				cmd.Parameters.Add("@W", OleDbType.Boolean);
				cmd.Parameters.Add("@E", OleDbType.Boolean);
				cmd.Parameters.Add("@D", OleDbType.Boolean);
				cmd.Parameters.Add("@id", OleDbType.Integer);

				foreach (DataGridViewRow r in dgvPermissions.Rows)
				{
					cmd.Parameters["@R"].Value = r.Cells[2].Value;
					cmd.Parameters["@W"].Value = r.Cells[3].Value;
					cmd.Parameters["@E"].Value = r.Cells[4].Value;
					cmd.Parameters["@D"].Value = r.Cells[5].Value;
					cmd.Parameters["@id"].Value = r.Cells[0].Value;
					cmd.ExecuteNonQuery();
				}
				connection.Close();
			}
		}
	}
}
