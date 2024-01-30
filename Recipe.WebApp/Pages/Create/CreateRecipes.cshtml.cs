using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using RecipeBook.Model;
using RecipeBook.Repository;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Create
{
    public class CreateRecipesModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;

        public CreateRecipesModel(ICategoryService categoryService, IDifficultyService difficultyService, IIngredientService ingredientService, IRecipeService recipeService, IMeasureService measureService, IRatingService ratingService, IIngredientLineService ingredientLineService, IUserService userService)
        {
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _recipeService = recipeService;
            _userService = userService;
        }

        public List<Category> Categories { get; set; }
        public List <Difficulty> Difficulties { get; set; }
        public List <Recipe> Recipes { get; set; }
        public List<User> Users { get; set; }


        public Recipe Recipe { get; set; }
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public User User { get; set; }
        
        public LogIn SessionUser {  get; set; }

        public void OnGet()
        {
            GetSessionUser();
            Users = _userService.RetrieveAll();
            Recipes = _recipeService.RetrieveAll();
            Categories = _categoryService.RetrieveAll(); 
            Difficulties = _difficultyService.RetrieveAll();
            

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

			recipe = _recipeService.Create(recipe);
            return Redirect($"/Create/AddIngredients?id={recipe.Id}");
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
