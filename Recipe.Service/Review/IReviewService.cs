using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public interface IReviewService
    {
        Review Create(Review review);
        Review Update(Review review);
        void Delete(int id);
        Review Retrieve(int id);
        List<Review> RetrieveAll();
		List<Review> RetrieveByRecipe(int id);
        double AvgRating(int id);
	}
}
