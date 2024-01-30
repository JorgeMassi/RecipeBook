using RecipeBook.Model;
using System.Data.SqlClient;

namespace RecipeBook.Repository
{
    // public class DifficultyRepository : Repository<Difficulty, int>
    public class DifficultyRepository : IDifficultyRepository
    {

        public Difficulty Create(Difficulty difficulty)
        {
            string sql = $"""
                INSERT INTO Difficulties (name) VALUES ( ' {difficulty.Name}');
                """;
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Difficulties");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = " DELETE FROM Difficulties WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Difficulty Retrieve(int id)
        {
            string sql = "SELECT * FROM Difficulties WHERE id = " + id + ";";

            SqlDataReader dataReader = MSSQL.Execute(sql);

            if (dataReader.Read())
            {
                return Parse(dataReader);
            }

            throw new KeyNotFoundException(" Difficulty ID : " + id + " not found!");
        }
        public Difficulty RetrieveBy(int id)
        {
			string sql = $"SELECT * FROM Difficulties INNER JOIN Recipes ON Difficulties.id = Recipes.id_difficulty WHERE Recipes.id ={id};";
			SqlDataReader dataReader = MSSQL.Execute(sql);

			if (dataReader.Read())
			{
				return Parse(dataReader);
			}

			throw new KeyNotFoundException(" Difficulty ID : " + id + " not found!");
		}

        public List<Difficulty> RetrieveAll()
        {
            string sql = "SELECT * FROM Difficulties;";

            SqlDataReader dataReader = MSSQL.Execute(sql);

            List<Difficulty> difficultyList = new List<Difficulty>();
            while (dataReader.Read())
            {
                Difficulty difficulty = Parse(dataReader);
                difficultyList.Add(difficulty);
            }
            return difficultyList;
        }

        public Difficulty Update(Difficulty difficultyUpdate)
        {
            string sql = $"""
                UPDATE Difficulties SET name =  '{difficultyUpdate.Name}' WHERE id =  {difficultyUpdate.Id};
                """;
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(difficultyUpdate.Id);
        }

        private Difficulty Parse(SqlDataReader dataReader)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(dataReader["id"]);
            difficulty.Name = Convert.ToString(dataReader["name"]);
            return difficulty;
        }
    }
}
