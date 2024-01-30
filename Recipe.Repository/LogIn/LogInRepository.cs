using RecipeBook.Model;
using System;
using System.Data.SqlClient;

namespace RecipeBook.Repository
{

    public class LogInRepository : ILogInRepository
    {

        public LogIn? Login(string username, string password)
        {

            string sql = $"SELECT * FROM Users WHERE  username = '{username}'  AND password = CONVERT(VARCHAR(32), HashBytes('MD5', '{password}'), 2);";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            return null;
            
        }
       



        private LogIn Parse(SqlDataReader dataReader)
        {
            LogIn log = new LogIn();

            log.Id = Convert.ToInt32(dataReader["id"]); 
            log.UserName = Convert.ToString(dataReader["username"]);
            log.Password = Convert.ToString(dataReader["password"]);
            log.Name = Convert.ToString(dataReader["name"]);
            log.Email = Convert.ToString(dataReader["email"]);
            int isAdmin = Convert.ToInt32(dataReader["is_admin"]);
            if (isAdmin == 1)
                log.IsAdmin = true;
            else
                log.IsAdmin = false;

            int isBlocked = Convert.ToInt32(dataReader["is_blocked"]);
            if(isBlocked == 1)
                log.IsBlocked = true;
            else log.IsBlocked = false;
              
            return log;
        }
    }
}
