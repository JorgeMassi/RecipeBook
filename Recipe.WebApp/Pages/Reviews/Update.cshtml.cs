using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Reviews
{
    public class UpdateModel : PageModel
    {
            private readonly IReviewService _reviewService;
            private readonly IRecipeService _recipeService;
            private readonly IRatingService _ratingService;
            private readonly IUserService _userService;

            public UpdateModel(IReviewService reviewService, IRecipeService recipeService, IRatingService ratingService, IUserService userService)
            {
                _reviewService = reviewService;
                _recipeService = recipeService;
                _ratingService = ratingService;
                _userService = userService;
            }

            public List<Review> Reviews { get; set; }
            public List<Recipe> Recipes { get; set; }
            public List<Rating> Rating { get; set; }
            public List<User> Users { get; set; }
            public Review Review { get; set; }
            public void OnGet(int id)
        {
            Review = _reviewService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Review review = new Review();
            review.Id = Convert.ToInt32(Request.Form["id"]);
            review.Comment = Convert.ToString(Request.Form["comment"]);

            _reviewService.Update(review);
            return Redirect("/reviews/retrieveall");

        }
    }
}
