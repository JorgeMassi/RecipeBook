using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        public Recipe Create(Recipe recipe)
        {
            int isApproved = (bool)recipe.IsApproved ? 1 : 0;

            string sql = $"""
                INSERT INTO Recipes 
                (title, id_user, id_category, preparation_time, preparation_methods, id_difficulty, is_approved)
                VALUES 
                ( '{recipe.Title}', {recipe.RecipeWriter?.Id} , {recipe.Category?.Id}, ' {recipe.PreparationTime}','{recipe.PreparationMethod}',
                {recipe.Difficulty?.Id},' {isApproved}');
                """;
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Recipes");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = " DELETE FROM Recipes WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Recipe Retrieve(int id)
        {
            string sql = "SELECT * FROM Recipes WHERE id = " + id + ";";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new KeyNotFoundException(" Recipe Id : " + id + " not found!");
        }
        public Recipe RetrieveByUser(int id)
        {
            string sql = "SELECT * FROM Recipes INNER JOIN Users ON Recipes.id_user = Users.id WHERE Users.id = " + id + ";";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new KeyNotFoundException(" Recipe User : " + id + " not found!");
        }
        public List<Recipe> RetrieveAll()
        {
            string sql = "SELECT * FROM Recipes;";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            List<Recipe> recipes = new List<Recipe>();
            while (dataReader.Read())
            {
                Recipe recipe = Parse(dataReader);
                recipes.Add(recipe);
            }
           
            return recipes;
        }
		public List<Recipe> RetrieveAllAppprovedRecipe()
		{
            string sql = "SELECT * From Recipes WHERE is_approved = 1;";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<Recipe> recipes = new List<Recipe>();
			while (dataReader.Read())
			{
				Recipe recipe = Parse(dataReader);
				recipes.Add(recipe);
			}

			return recipes;
		}

		public List<Recipe> RetrieveAllByUser(int id)
		{
			string sql = "SELECT * FROM Recipes INNER JOIN Users ON Recipes.id_user = Users.id WHERE Users.id = " + id + ";";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<Recipe> recipes = new List<Recipe>();
			while (dataReader.Read())
			{
				Recipe recipe = Parse(dataReader);
				recipes.Add(recipe);
			}

			return recipes;
		}
		public List<Recipe> ToApproved()
		{
			string sql = "SELECT * From Recipes WHERE is_approved = 0;";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<Recipe> recipes = new List<Recipe>();
			while (dataReader.Read())
			{
				Recipe recipe = Parse(dataReader);
				recipes.Add(recipe);
			}

			return recipes;
		}
		public Recipe ToApprovedUpdate(int id)
		{
            string sql = $"UPDATE Recipes Set is_approved = 1 WHERE id = {id};";

			MSSQL.ExecuteNonQuery(sql);
			return Retrieve(id);
		}

		public Recipe Update(Recipe recipe)
        {
            int isApproved = recipe.IsApproved ? 1 : 0;


            string sql = $"""
                UPDATE Recipes SET
                title = '{recipe.Title}',
                id_user = '{recipe.RecipeWriter.Id}',
                id_category = '{recipe.Category.Id}',
                preparation_time = '{recipe.PreparationTime}',
                preparation_methods = '{recipe.PreparationMethod}',
                is_approved = '{isApproved}'
                WHERE id = {recipe.Id};
                """;

            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(recipe.Id);
        }
        private Recipe Parse(SqlDataReader dataReader)
        {
            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(dataReader["id"]);

            recipe.Title = Convert.ToString(dataReader["title"]);

            User user = new User();
            user.Id = Convert.ToInt32(dataReader["id_user"]);
            recipe.RecipeWriter = user;

            Category category = new Category();
            category.Id = Convert.ToInt32(dataReader["id_category"]);
            recipe.Category = category;

            recipe.PreparationTime = Convert.ToInt32(dataReader["preparation_time"]);
            recipe.PreparationMethod = Convert.ToString(dataReader["preparation_methods"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(dataReader["id_difficulty"]);
            recipe.Difficulty = difficulty;

            recipe.IsApproved = Convert.ToBoolean(dataReader["is_approved"]);

            return recipe;
        }
       
    }
}
