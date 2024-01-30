using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService (IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public Rating Create(Rating rating)
        {
            return _ratingRepository.Create(rating);
        }

        public void Delete(int id)
        {
            _ratingRepository.Delete(id);
        }

        public Rating Retrieve(int id)
        {
            return _ratingRepository.Retrieve(id);
        }
	


		public List<Rating> RetrieveAll()
        {
            return _ratingRepository.RetrieveAll();
        }

        public Rating Update(Rating rating)
        {
            return _ratingRepository.Update(rating);
        }
    }
}
