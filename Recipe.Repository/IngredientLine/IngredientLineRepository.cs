using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public class IngredientLineRepository : IIngredientLineRepository
    {
        public IngredientLine Create(IngredientLine ingredientLine)
        {
            string sql = $"""
                    INSERT INTO Recipe_Ingredients (id_recipe, id_ingredient, qtd, id_measure) VALUES
                 ( '{ingredientLine.Recipe?.Id}','{ingredientLine.Ingredient?.Id}','{ingredientLine.Qtd}',
                 '{ingredientLine.Measure?.Id}');
                 """;
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Recipe_Ingredients");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = " DELETE FROM Recipe_Ingredients WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }
       
        public IngredientLine Retrieve(int id)
        {
            string sql = "SELECT * FROM Recipe_Ingredients WHERE id = " + id + ";";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new KeyNotFoundException(" Recipe_Ingredients Id : " + id + " not found!");
        }
        public List<IngredientLine> RetrieveAllByRecipeId(int recipeId)
        {
            string sql = "SELECT * FROM Recipe_Ingredients WHERE id_recipe = " + recipeId + ";";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            List<IngredientLine> ingredientLineList = new List<IngredientLine>();
            while (dataReader.Read())
            {
                IngredientLine ingredientLine = Parse(dataReader);
                ingredientLineList.Add(ingredientLine);
            }
            return ingredientLineList; ;
        }

        public IngredientLine Update(IngredientLine ingredientLine)
        {

            string sql = "UPDATE Recipe_Ingredients " +
                  "SET " +
                  " id_recipe =  '" + ingredientLine.Recipe.Id + "'," +
                  " id_ingredient = '" + ingredientLine.Ingredient.Id + "' ," +
                  " qtd = '" + ingredientLine.Qtd + "' ," +
                  " id_measure = '" + ingredientLine.Measure.Id + "' " +
                  " WHERE id = " + ingredientLine.Id + ";";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(ingredientLine.Id);
        }
        private IngredientLine Parse(SqlDataReader dataReader)
        {
            IngredientLine ingredientLine = new IngredientLine();
            ingredientLine.Id = Convert.ToInt32(dataReader["id"]);

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(dataReader["id_recipe"]);
            ingredientLine.Recipe = recipe;

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(dataReader["id_ingredient"]);
            ingredientLine.Ingredient = ingredient;

            ingredientLine.Qtd = Convert.ToDouble(dataReader["qtd"]);

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(dataReader["id_measure"]);
            ingredientLine.Measure = measure;

            return ingredientLine;
        }
    }
}
