using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
	public class UserRepository : IUserRepository
	{
		public User Create(User user)
		{
			int isAdmin = user.IsAdmin ? 1 : 0;
			int isBlocked = user.IsBlocked ? 1 : 0;

			string sql = $"""
			   INSERT INTO Users (username, password, name, email, is_admin, is_blocked) VALUES
			   ('{user.UserName}', CONVERT(VARCHAR(32), HashBytes('MD5', '{user.Password}'), 2) ,'{user.Name}', '{user.Email}', '{isAdmin}', '{isBlocked}');
			   """;
			MSSQL.ExecuteNonQuery(sql);
			int id = MSSQL.GetMaxInt("id", "Users");
			return Retrieve(id);
		}

		public void Delete(int id)
		{
			string sql = "DELETE FROM Users WHERE id = " + id + ";";
			MSSQL.ExecuteNonQuery(sql);
		}

		public User Retrieve(int id)
		{
			string sql = "SELECT * FROM Users WHERE id = " + id + ";";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception("User Id : " + id + " not found!");
		}

		public List<User> RetrieveAll()
		{
			string sql = "SELECT * FROM Users;";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<User> users = new List<User>();
			while (dataReader.Read())
			{
				User user = Parse(dataReader);
				users.Add(user);
			}
			return users;
		}
		public User isAdminUpdate(int id)
		{
			User user = new User();

			string sql = $" UPDATE Users Set is_admin = {(user.IsAdmin ? 0 : 1)} WHERE id = {id};";
			MSSQL.ExecuteNonQuery(sql);
			return Retrieve(id);
		}
		public User isBlockedUpdate(int id)
		{
			User user = new User();
			string sql = $" UPDATE Users Set is_blocked = {(user.IsBlocked ? 0: 1)} WHERE id = {id};";
			MSSQL.ExecuteNonQuery(sql);
			return Retrieve(id);
		}

		public User Update(User user)
		{
			int isAdmin = user.IsAdmin ? 1 : 0;
			int isBlocked = user.IsBlocked ? 1 : 0;

			string sql = "UPDATE Users SET" +
				" name = '" + user.Name + "'," +
				" email = '" + user.Email + " '," +
				" is_admin = '" + isAdmin + "'," +
				" is_blocked = '" + isBlocked + "' " +
				" WHERE id = '" + user.Id + "' ;";
			MSSQL.ExecuteNonQuery(sql);
			return Retrieve(user.Id);
		}

		private User Parse(SqlDataReader dataReader)
		{
			User user = new User();
			user.Id = Convert.ToInt32(dataReader["id"]);
			user.UserName = Convert.ToString(dataReader["username"]);
			user.Password = Convert.ToString(dataReader["password"]);
			user.Name = Convert.ToString(dataReader["name"]);
			user.Email = Convert.ToString(dataReader["email"]);
			user.IsAdmin = Convert.ToBoolean(dataReader["is_admin"]);
			user.IsBlocked = Convert.ToBoolean(dataReader["is_blocked"]);
			return user;
		}
	}
}
