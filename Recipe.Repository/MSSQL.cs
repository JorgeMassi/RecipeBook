using System.Data.SqlClient;

namespace RecipeBook.Repository
{
    public class MSSQL
    {


        //private static readonly string _connectionString = @"Server=localhost,1433;Database=RECIPES_FINAL;" +
        // "User Id = sa; Password= <YourStrong@Passw0rd>; MultipleActiveREsultSets=true";


        private static readonly string _connectionString = @"Server=DESKTOP-SANCFFA\SQLEXPRESS01;Database=RECIPES;Trusted_Connection=True;";

        private static readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);

        private static bool _isClose = true;

        public static SqlDataReader Execute(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteReader();
        }

        public static int ExecuteNonQuery(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }

        public static int GetMaxInt(string columnName, string tableName)
        {
            string sql = "SELECT max(" + columnName + ") AS MAX_ID FROM "
                + tableName + " ;";
            SqlDataReader dataReader = Execute(sql);
            if (dataReader.Read())
            {
                return Convert.ToInt32(dataReader["MAX_ID"]);
            }
            return -1;
        }

        private static void HangUpCall()
        {
            if (_isClose)
            {
                _sqlConnection.Open();
                _isClose = !_isClose;
            }
            else
            {
                _sqlConnection.Close();
                _sqlConnection.Open();
            }
        }
    }
}
