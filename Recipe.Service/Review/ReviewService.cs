using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IRecipeService _recipeService;
        private readonly IRatingService _ratingService;
        private readonly IUserService _userService;

        public ReviewService(IReviewRepository reviewRepository, IRecipeService recipeService, IRatingService ratingService, IUserService userService)
        {
            _reviewRepository = reviewRepository;
            _recipeService = recipeService;
            _ratingService = ratingService;
            _userService = userService;
        }

        public Review Create(Review review)
        {
           return _reviewRepository.Create(review);
        }

        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
        }

        public Review Retrieve(int id)
        {
           return _reviewRepository.Retrieve(id);   
        }
		public List<Review> RetrieveByRecipe(int id)
        {
			List<Review> reviews = _reviewRepository.RetrieveByRecipe(id);

			foreach (Review review in reviews)
			{
				review.RecipeWriter = _userService.Retrieve(review.RecipeWriter.Id);

				review.Rating = _ratingService.Retrieve(review.Rating.Id);

				review.Recipe = _recipeService.Retrieve(review.Recipe.Id);

			}
			return reviews;

		}
		public double AvgRating(int id)
        {
            return Math.Round(_reviewRepository.AvgRating(id),1);
        }

		public List<Review> RetrieveAll()
        {
            List<Review> reviews = _reviewRepository.RetrieveAll();

            foreach (Review review in reviews)
            {
                review.RecipeWriter = _userService.Retrieve(review.RecipeWriter.Id);

                review.Rating = _ratingService.Retrieve(review.Rating.Id);

                review.Recipe = _recipeService.Retrieve(review.Recipe.Id);

            }
            return reviews;
        }

        public Review Update(Review review)
        {
            return _reviewRepository.Update(review);
        }
    }
}
