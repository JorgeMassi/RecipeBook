using RecipeBook.Model;
using RecipeBook.Repository;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace RecipeBook.Repository
{
    //public class CategoryRepositoruy : Repository<Category, int>
    public class CategoryRepository : ICategoryRepository
    {
        public void Delete(int id)
        {
            string sql = "DELETE FROM Categories WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Category Create(Category category)
        {
            string sql = "INSERT INTO Categories (name) VALUES " +
                "( '" + category.Name + "');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Categories");
            return Retrieve(maxId);
        }

        public Category Retrieve(int id)
        {
            string sql = "SELECT * FROM Categories WHERE id = " + id + ";";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new KeyNotFoundException(" Category Id : " + id + " not found!");
        }

        public Category RetrieveBy(int id)
        {
            string sql = $"SELECT * FROM Categories INNER JOIN Recipes ON Categories.id = Recipes.id_category WHERE Recipes.id ={id};";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new KeyNotFoundException(" Category Id :  not found!");

		}
        public List<Category> RetrieveAllSearch(string search)
        {
            string sql = $"""
                SELECT * FROM Categories INNER JOIN Recipes ON Categories.id = Recipes.id_category 
                WHERE(LOWER(Categories.name) LIKE '%{search}%' OR UPPER(Categories.name) LIKE '%{search}%');
                """;

			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<Category> categoriesSearch = new List<Category>();
			while (dataReader.Read())
			{
				Category category = Parse(dataReader);
				categoriesSearch.Add(category);
			}
			return categoriesSearch;
		}

        public List<Category> RetrieveAll()
        {
            string sql = "SELECT * FROM Categories ORDER BY id ASC;";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            List<Category> categoriesList = new List<Category>();
            while (dataReader.Read())
            {
                Category category = Parse(dataReader);
                categoriesList.Add(category);
            }
            return categoriesList;
        }

        public Category Update(Category categoryUpdate)
        {
            string sql = $"""
                        UPDATE Categories SET name =  '{categoryUpdate.Name}' WHERE id = {categoryUpdate.Id};
                        """;
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(categoryUpdate.Id);
        }
       
        private Category Parse(SqlDataReader dataReader)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(dataReader["id"]);
            category.Name = Convert.ToString(dataReader["name"]);
            return category;
        }
    }
}
