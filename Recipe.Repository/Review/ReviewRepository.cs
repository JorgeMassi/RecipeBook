using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecipeBook.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        public Review Create(Review review)
        {
            string sql = $"""
                INSERT INTO Reviews (comment, id_user, id_rating, id_recipe) VALUES
                ( '{review.Comment}', {review.RecipeWriter?.Id},{review.Rating?.Id},{review.Recipe?.Id});
                """;
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Reviews");
            return Retrieve(maxId);
        }
        public void Delete(int id)
        {
            string sql = " DELETE FROM Reviews WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Review Retrieve(int id)
        {
            string sql = "SELECT * FROM Reviews WHERE id = " + id + ";";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new KeyNotFoundException(" Review Id : " + id + " not found!");
        }
		public List<Review> RetrieveByRecipe(int id)
		{
			string sql = "SELECT * FROM Reviews WHERE id_recipe = " + id + ";";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<Review> reviews = new List<Review>();
			while (dataReader.Read())
			{
				Review review = Parse(dataReader);
				reviews.Add(review);
			}
			return reviews;
		}

		public List<Review> RetrieveAll()
        {
            string sql = "SELECT * FROM Reviews;";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            List<Review> reviews = new List<Review>();
            while (dataReader.Read())
            {
                Review review = Parse(dataReader);
                reviews.Add(review);
            }
            return reviews;
        }
		public double AvgRating(int id)
		{
            
			string sql = "SELECT (CAST(SUM(id_rating) as float) / COUNT(id_rating)) as avg  from Reviews WHERE id_recipe =" + id + ";";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			if (dataReader.Read())
			{
				return Convert.ToDouble(dataReader["avg"]);
			}
			throw new KeyNotFoundException(" Review Id : " + id + " not found!");
		}


		public Review Update(Review review)
        {
            string sql = "UPDATE Reviews " +
                 "SET " +
                 "comment =  '" + review.Comment + "' , " +
                 " id_user = " + review.RecipeWriter?.Id + "', " +
                 " id_rating = " + review.Rating?.Id + " ' ," +
                 " id_recipe = " + review.Recipe?.Id + " ', " +
                 " WHERE id = " + review.Id + ";";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(review.Id);
        }
        private Review Parse(SqlDataReader dataReader)
        {
            Review review = new Review();
            review.Id = Convert.ToInt32(dataReader["id"]);
            review.Comment = Convert.ToString(dataReader["comment"]);

            User user = new User();
            user.Id = Convert.ToInt32(dataReader["id_user"]);
            review.RecipeWriter = user;

            Rating rating = new Rating();
            rating.Id = Convert.ToInt32(dataReader["id_rating"]);
            review.Rating = rating;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(dataReader["id_recipe"]);
            review.Recipe = recipe;

            return review;
        }
    }
    
}
