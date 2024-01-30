using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface IDifficultyRepository
    {
        Difficulty Create(Difficulty difficulty);
        Difficulty Update(Difficulty difficulty);
        List<Difficulty> RetrieveAll();
        void Delete(int id);
        Difficulty Retrieve(int id);
        Difficulty RetrieveBy(int id);

	}

}
