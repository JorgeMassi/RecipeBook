using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Recipes
{
    public class ToApprovedModel : PageModel
    {
		private readonly IRecipeService _recipeService;
		private readonly IUserService _userService;
		private readonly ICategoryService _categoryService;
		private readonly IDifficultyService _difficultyService;
		private readonly IIngredientLineService _ingredientLineService;
		private readonly IReviewService _reviewService;
		private readonly ILogInService _logInService;

		public ToApprovedModel(IRecipeService recipeService, IUserService userService, ICategoryService categoryService, IDifficultyService difficultyService, IIngredientLineService ingredientLineService, IReviewService reviewService, ILogInService logInService)
		{
			_recipeService = recipeService;
			_userService = userService;
			_categoryService = categoryService;
			_difficultyService = difficultyService;
			_ingredientLineService = ingredientLineService;
			_reviewService = reviewService;
			_logInService = logInService;
		}

		public List<Recipe> Recipes { get; set; }
		public List<Category> Categories { get; set; }
		public List<User> Users { get; set; }
		public List<Difficulty> Difficulties { get; set; }
		public List<IngredientLine> IngredientLines { get; set; }
		public List<Review> Reviews { get; set; }

		public Recipe Recipe { get; set; }
		public User User { get; set; }
		public Review Review { get; set; }
		public LogIn SessionUser { get; set; }
		public void OnGet()
		{
			GetSessionUser();
			Recipes = _recipeService.ToApproved();

			foreach (Recipe recipe in Recipes)
			{
				recipe.Category = _categoryService.Retrieve(recipe.Category.Id);
				recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
				recipe.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(recipe);

			}

		}

		public IActionResult OnPost()
		{
			Recipe recipe = new Recipe();
			recipe.Title = Convert.ToString(Request.Form["title"]);

			User user = new User();
			user.Id = Convert.ToInt32(Request.Form["id_user"]);
			recipe.RecipeWriter = user;

			Category category = new Category();
			category.Id = Convert.ToInt32(Request.Form["id_category"]);
			recipe.Category = category;

			recipe.PreparationTime = Convert.ToInt32(Request.Form["preparation_time"]);
			recipe.PreparationMethod = Convert.ToString(Request.Form["preparation_methods"]);

			Difficulty difficulty = new Difficulty();
			difficulty.Id = Convert.ToInt32(Request.Form["id_difficulty"]);
			recipe.Difficulty = difficulty;

			IngredientLine ingredient = new IngredientLine();
			ingredient.Id = Convert.ToInt32(Request.Form["id_ingredients"]);
			recipe.IngredientLine.Add(ingredient);

			_recipeService.Create(recipe);
			return Redirect("/recipes/retrieveall");
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

