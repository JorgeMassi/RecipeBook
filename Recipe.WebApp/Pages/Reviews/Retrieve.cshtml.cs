using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Reviews
{
	public class RetrieveModel : PageModel
	{
		private readonly IReviewService _reviewService;
		private readonly IRecipeService _recipeService;
		private readonly IRatingService _ratingService;
		private readonly IUserService _userService;
		private readonly ILogInService _logInService;

		public RetrieveModel(ILogInService logInService, IReviewService reviewService, IRecipeService recipeService, IRatingService ratingService, IUserService userService)
		{
			_reviewService = reviewService;
			_recipeService = recipeService;
			_ratingService = ratingService;
			_userService = userService;
			_logInService = logInService;
		}

		public List<Review> Reviews { get; set; }
		public List<Recipe> Recipes { get; set; }
		public List<Rating> Ratings { get; set; }
		public List<User> Users { get; set; }

		public Recipe Recipe { get; set; }
		public LogIn SessionUser { get; set; }
		public Review Review { get; set; }
		public Rating Rating { get; set; }

		public double review;

		public void OnGet(int id)
		{
			GetSessionUser();
			Recipe = _recipeService.Retrieve(id);
			Reviews = _reviewService.RetrieveByRecipe(Recipe.Id);
			review = _reviewService.AvgRating(Recipe.Id);
			Ratings = _ratingService.RetrieveAll();
			
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
			user.Id = Convert.ToInt32(Request.Form["user"]);
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
