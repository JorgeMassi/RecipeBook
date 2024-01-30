using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public class MeasureRepository : IMeasureRepository
    {
        public Measure Create(Measure measure)
        {
            string sql = $"INSERT INTO Measures (name) VALUES('{measure.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("id", "Measures");
            return Retrieve(maxId);

        }

        public void Delete(int id)
        {
            string sql = " DELETE FROM Measures WHERE id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Measure Retrieve(int id)
        {
            string sql = "SELECT * FROM Measures WHERE id = " + id + ";";
            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new KeyNotFoundException(" Measure Id : " + id + " not found!");
        }

        public List<Measure> RetrieveAll()
        {
            string sql = "SELECT * FROM Measures;";
            SqlDataReader dataReader = MSSQL.Execute(sql);

            List<Measure> measures = new List<Measure>();
            while (dataReader.Read())
            {
                Measure measure = Parse(dataReader);
                measures.Add(measure);
            }
            return measures;
        }

        public Measure Update(Measure measure)
        {
            string sql = "UPDATE Measures " +
                "SET " +
                "name =  '" + measure.Name +
                "' WHERE id = " + measure.Id + ";";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(measure.Id);
        }
        private Measure Parse(SqlDataReader dataReader)
        {
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(dataReader["id"]);
            measure.Name = Convert.ToString(dataReader["name"]);
            return measure;
        }
    }
}
