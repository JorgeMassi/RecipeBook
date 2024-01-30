using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBook.Model;

namespace RecipeBook.Repository
{
    public class RatingRepository : IRatingRepository
    {
        public Rating Create(Rating rating)
        {
            string sql = $"INSERT INTO Ratings (name) VALUES ( '{rating.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Ratings");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = " DELETE FROM Ratings WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Rating Retrieve(int id)
        {
            string sql = "SELECT * FROM Ratings WHERE id = " + id + ";";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new KeyNotFoundException(" Rating Id : " + id + " not found!");
        }

        public List<Rating> RetrieveAll()
        {
            string sql = "SELECT * FROM Ratings;";
            SqlDataReader dataReader = MSSQL.Execute(sql);

            List<Rating> ratings = new List<Rating>();
            while (dataReader.Read())
            {
                Rating rating = Parse(dataReader);
                ratings.Add(rating);
            }
            return ratings;
        }
       
        public Rating Update(Rating rating)
        {
            string sql = "UPDATE Ratings " +
                "SET " +
                "name =  '" + rating.Name +
                "' WHERE id = " + rating.Id + ";";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(rating.Id);
        }
        private Rating Parse(SqlDataReader dataReader)
        {
            Rating rating = new Rating();
            rating.Id = Convert.ToInt32(dataReader["id"]);
            rating.Name = Convert.ToString(dataReader["name"]);

            return rating;
        }
    }
}
