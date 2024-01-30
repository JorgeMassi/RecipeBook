using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Recipes
{
    public class UpdateModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;
        private readonly IIngredientLineService _ingredientLineService;
        private readonly IUserService _userService;

        public UpdateModel(IRecipeService recipeService, IUserService userService, ICategoryService categoryService, IDifficultyService difficultyService, IIngredientLineService ingredientLineService)
        {
            _recipeService = recipeService;
            _userService = userService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _ingredientLineService = ingredientLineService;
        }

        public List<Recipe> Recipes { get; set; }
        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }
        public List<Difficulty> Difficulties { get; set; }
        public List<IngredientLine> IngredientLines { get; set; }

        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public Recipe Recipe { get; set; }
        public LogIn SessionUser { get; set; }
        public void OnGet(int id)
        {
            GetSessionUser();
            Recipe = _recipeService.Retrieve(id); 
            Categories = _categoryService.RetrieveAll();
            Category = _categoryService.RetrieveBy(Recipe.Id);
            Difficulties = _difficultyService.RetrieveAll();
            Difficulty = _difficultyService.RetrieveBy(Recipe.Id);

        }

        public IActionResult OnPost()
        {
            Recipe recipe = new Recipe();

            recipe.Id = Convert.ToInt32(Request.Form["id"]);
            recipe.Title = Convert.ToString(Request.Form["title"]);

            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["id_user"]);
            recipe.RecipeWriter = user;

            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["category"]);
            recipe.Category = category;

            recipe.PreparationTime = Convert.ToInt32(Request.Form["preparation_time"]);
            recipe.PreparationMethod = Convert.ToString(Request.Form["preparation_methods"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["difficulty"]);
            recipe.Difficulty = difficulty;

             _recipeService.Update(recipe);
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
