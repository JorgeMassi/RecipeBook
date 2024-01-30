using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface IReviewRepository
    {
        Review Create(Review review);
        Review Update(Review review);
        void Delete(int id);
        Review Retrieve(int id);
		List<Review> RetrieveByRecipe(int id);
		List<Review> RetrieveAll();
        double AvgRating(int id);

	}
}
