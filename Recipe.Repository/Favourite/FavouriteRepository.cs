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
    public class FavouriteRepository : IFavouriteRepository
    {
        public Favourite Create(Favourite favourite)
        {
            string sql = $"""
                    INSERT INTO Favourites (id_user, id_recipe) VALUES ( '{favourite.User.Id}','{favourite.Recipe.Id}');
               """;
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Favourites");
            return Retrieve(maxId);
        }
        public Favourite CreateBy(int user, int recipe)
        {
            string sql = $"""
                INSERT INTO Favourites (id_user, id_recipe)
                SELECT Users.id AS id_user, Recipes.id AS id_recipe
                FROM Users INNER JOIN Recipes ON Users.id = {user} AND Recipes.id = {recipe};
                """;
			MSSQL.ExecuteNonQuery(sql);
			int maxId = MSSQL.GetMaxInt("id", "Favourites");
			return Retrieve(maxId);
		}

        public void Delete(int id)
        {
            string sql = " DELETE FROM Favourites WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Favourite Retrieve(int id)
        {
            string sql = "SELECT * FROM Favourites WHERE id = " + id + ";";

            SqlDataReader dataReader = MSSQL.Execute(sql);

            if (dataReader.Read())
            {
                return Parse(dataReader);
            }

            throw new KeyNotFoundException(" Favourite ID : " + id + " not found!");
        }

        public List<Favourite> RetrieveAll()
        {
            string sql = "SELECT * FROM Favourites;";

            SqlDataReader dataReader = MSSQL.Execute(sql);

            List<Favourite> favouriteList = new List<Favourite>();
            while (dataReader.Read())
            {
                Favourite favourite = Parse(dataReader);
                favouriteList.Add(favourite);
            }
            return favouriteList;

        }

        public Favourite Update(Favourite favourite)
        {
            string sql = $"""
                UPDATE Favourites SET id_user = {favourite.User.Id},id_recipe = {favourite.Recipe.Id}
               WHERE id = {favourite.Id};
               """;
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(favourite.Id);
        }

        private Favourite Parse(SqlDataReader dataReader)
        {
            Favourite favourite = new Favourite();
            favourite.Id = Convert.ToInt32(dataReader["id"]);

            User user = new User();
            user.Id = Convert.ToInt32(dataReader["id_user"]);
            favourite.User= user;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(dataReader["id_recipe"]);
            favourite.Recipe = recipe;

            return favourite;
        }
    }
}
