using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Reviews
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IReviewService _reviewService;
        private readonly IRecipeService _recipeService;
        private readonly IRatingService _ratingService;
        private readonly IUserService _userService;

        public RetrieveAllModel(IReviewService reviewService, IRecipeService recipeService, IRatingService ratingService, IUserService userService)
        {
            _reviewService = reviewService;
            _recipeService = recipeService;
            _ratingService = ratingService;
            _userService = userService;
        }

        public List<Review> Reviews { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<User> Users { get; set; }

        public Rating Rating { get; set; }
        public LogIn SessionUser { get; set; }
        public Review Review { get; set; }

        public void OnGet(int id)
        {
           GetSessionUser();
            Reviews = _reviewService.RetrieveAll();
            Recipes = _recipeService.RetrieveAll();
            Ratings = _ratingService.RetrieveAll();  
            Users = _userService.RetrieveAll();
            
        }

        public IActionResult OnPost(int id)
        {
            Review review = new Review();
            review.Comment = Convert.ToString(Request.Form["Comment"]);

            Recipe recipe = new Recipe();
            recipe.Id = id;
            review.Recipe = recipe;

            Rating rating = new Rating();
            rating.Id = Convert.ToInt32(Request.Form["rating"]);
            review.Rating = rating;

            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["user_id"]);
            review.RecipeWriter = user;

            _reviewService.Create(review);
            return Redirect("/reviews/retrieveall");
        }
        private void GetSessionUser()
        {
            string user = HttpContext.Session.GetString("user");

            if (user is not null)
            {
                SessionUser = JsonSerializer.Deserialize<LogIn>(user);
                
            }
            
        }
    }
}
