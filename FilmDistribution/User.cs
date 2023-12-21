using System.Data;
using System.Data.OleDb;

namespace FilmDistribution
{
	internal class User
	{
		private string _connectionString;

		public User(string connectionString)
		{
			_connectionString = connectionString;
		}

		public DataTable Add(string Login, string Password)
		{
			string encodedPassword = Logic.Encrypter.HashPassword(Password);

			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbCommand command = new OleDbCommand("SELECT TOP 1 id FROM Users", connection);
				OleDbDataReader reader = command.ExecuteReader();
				
				command.CommandText = "INSERT INTO Users ([Login], [Password], isAdmin) VALUES (@login, @password, @isAdmin)";
				command.Parameters.AddWithValue("login", Login);
				command.Parameters.AddWithValue("password", encodedPassword);
				command.Parameters.AddWithValue("isAdmin", !reader.HasRows); //первый вносимый в бвзу пользователь становится админом
				reader.Close();
				var r = command.ExecuteNonQuery();

				return GetByLogin(Login);
			}
		}


		public DataTable GetByLogin(string Login)
		{
			DataTable table = new DataTable();
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbDataAdapter adapter = new OleDbDataAdapter();
				OleDbCommand command = new OleDbCommand("SELECT id, [Login], [Password], [isReset], [isAdmin] FROM Users WHERE [Login] = @login", connection);
				command.Parameters.Add("@login", OleDbType.VarChar, 50).Value = Login;
				adapter.SelectCommand = command;
				adapter.Fill(table);
			}
			return table;
		}

		public void Change(string Login, string Password)
		{
			string encodedPassword = Logic.Encrypter.HashPassword(Password);
			using (OleDbConnection connection = new OleDbConnection(_connectionString))
			{
				connection.Open();
				OleDbCommand command = new OleDbCommand("UPDATE Users SET [Password] = @password, [isReset] = false WHERE Login = @login", connection);
				command.Parameters.AddWithValue("password", encodedPassword);
				command.Parameters.AddWithValue("login", Login);
				command.ExecuteNonQuery();
			}
		}
	}
}
