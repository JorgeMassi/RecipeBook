using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        public Ingredient Create(Ingredient ingredient)
        {
            string sql = $"INSERT INTO Ingredients (name) VALUES ( '{ingredient.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Ingredients");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = " DELETE FROM Ingredients WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Ingredient Retrieve(int id)
        {
            string sql = "SELECT * FROM Ingredients WHERE id = " + id + ";";

            SqlDataReader dataReader = MSSQL.Execute(sql);

            if (dataReader.Read())
            {
                return Parse(dataReader);
            }

            throw new KeyNotFoundException(" Ingredients Id : " + id + " not found!");
        }

        public List<Ingredient> RetrieveAll()
        {
            string sql = "SELECT * FROM Ingredients;";

            SqlDataReader dataReader = MSSQL.Execute(sql);

            List<Ingredient> ingredientList = new List<Ingredient>();
            while (dataReader.Read())
            {
                Ingredient ingredient = Parse(dataReader);
                ingredientList.Add(ingredient);
            }
            return ingredientList;
        }

        public Ingredient Update(Ingredient ingredient)
        {
            string sql = "UPDATE Ingredients " +
               "SET " +
               " name =  '" + ingredient.Name +
               "' WHERE id = " + ingredient.Id + ";";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(ingredient.Id);
        }
        private Ingredient Parse(SqlDataReader dataReader)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(dataReader["id"]);
            ingredient.Name = Convert.ToString(dataReader["name"]);
            return ingredient;
        }
    }
}
