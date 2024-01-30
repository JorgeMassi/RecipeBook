using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
	public class SearchRespository : ISearchRepository
	{
		public List<Search> RetrieveAll()
		{
			string sql = "SELECT * From Recipes WHERE is_approved = 1;";
			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<Search> searches = new List<Search>();
				while (dataReader.Read())
				{
				Search search = Parse(dataReader);
				searches.Add(search);
				}

				return searches;
			}

			public List<Search> RetrieveAllSearchCategory(string searchCategory)
		{
			string sql = $"SELECT * FROM Categories INNER JOIN Recipes ON Categories.id = Recipes.id_category " +
				$"WHERE(LOWER(Categories.name) LIKE '%{searchCategory}%' OR UPPER(Categories.name) LIKE '%{searchCategory}%') AND Recipes.is_approved = 1;";

			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<Search> searchByCategory = new List<Search>();
			while (dataReader.Read())
			{
				Search search = Parse(dataReader);
				searchByCategory.Add(search);
			}
			return searchByCategory;
		}

		public List<Search> RetrieveAllSearchDifficulty(string searchDifficulty) 
		{
			string sql = $"SELECT * FROM Difficulties INNER JOIN Recipes ON Difficulties.id = Recipes.id_difficulty " +
				$"WHERE(LOWER(Difficulties.name) LIKE '%{searchDifficulty}%' OR UPPER(Difficulties.name) LIKE '%{searchDifficulty}%') AND Recipes.is_approved = 1;";

			SqlDataReader dataReader = MSSQL.Execute(sql);
			List<Search> searchByDifficulty = new List<Search>();
			while (dataReader.Read())
			{
				Search search = Parse(dataReader);
				searchByDifficulty.Add(search);
			}
			return searchByDifficulty;

		}
		private Search Parse(SqlDataReader dataReader)
		{
			Search search = new Search();
			search.Id = Convert.ToInt32(dataReader["id"]);

			search.Title = Convert.ToString(dataReader["title"]);

			User user = new User();
			user.Id = Convert.ToInt32(dataReader["id_user"]);
			search.RecipeWriter = user;

			Category category = new Category();
			category.Id = Convert.ToInt32(dataReader["id_category"]);
			search.Category = category;

			search.PreparationTime = Convert.ToInt32(dataReader["preparation_time"]);
			search.PreparationMethod = Convert.ToString(dataReader["preparation_methods"]);

			Difficulty difficulty = new Difficulty();
			difficulty.Id = Convert.ToInt32(dataReader["id_difficulty"]);
			search.Difficulty = difficulty;

			search.IsApproved = Convert.ToBoolean(dataReader["is_approved"]);

			return search;
		}
	}
}
