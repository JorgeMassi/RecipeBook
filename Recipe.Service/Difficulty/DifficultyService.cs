using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    //public class DifficultyService : Service<Difficulty, int>
    public class DifficultyService : IDifficultyService
    {
        private readonly IDifficultyRepository _difficultyRepository;
        public DifficultyService(IDifficultyRepository difficultyRepository)
        {
            _difficultyRepository = difficultyRepository;
        }

        public Difficulty Create(Difficulty difficulty)
        {
            return _difficultyRepository.Create(difficulty);
        }

        public void Delete(int id)
        {
            _difficultyRepository.Delete(id);
        }

        public Difficulty Retrieve(int id)
        {
            return _difficultyRepository.Retrieve(id);
        }
		public Difficulty RetrieveBy(int id)
        {
            return _difficultyRepository.RetrieveBy(id);
        }

		public List<Difficulty> RetrieveAll()
        {
            return _difficultyRepository.RetrieveAll();
        }

        public Difficulty Update(Difficulty difficulty)
        {
            return _difficultyRepository.Update(difficulty);
        }
    }
}

