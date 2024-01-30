using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Searching
{
    public class SearchMenuModel : PageModel
    {
        private readonly ICategoryService _categoryService;
		private readonly IRecipeService _recipeService;
		private readonly ISearchService _searchService;
		private readonly IDifficultyService _difficultyService;

		public SearchMenuModel(IDifficultyService difficultyService, ICategoryService categoryService, IRecipeService recipeService, ISearchService searchService)
		{
			_categoryService = categoryService;
			_recipeService = recipeService;
			_searchService = searchService;
			_difficultyService = difficultyService;
		}

		public List<Category> Categories { get; set; }
		public List<Recipe> Recipes { get; set; }
		public List<Search> Searches { get; set; }
		public List<Difficulty> Difficulties { get; set; }
        
		public Favourite Favourite { get; set; }
		public LogIn SessionUser {  get; set; }
		public Search Search { get; set; }



		public void OnGet(string categorySearch, string difficultySearch)
        {
			GetSessionUser();
			
			if (!string.IsNullOrEmpty(categorySearch))
			{
				Searches = _searchService.RetrieveAllSearchCategory(categorySearch);

			}
			else if (!string.IsNullOrEmpty(difficultySearch))
			{
				Searches = _searchService.RetrieveAllSearchDifficulty(difficultySearch);

			}
			else
			{
				Searches = _searchService.RetrieveAll();
			}
			Categories = _categoryService.RetrieveAll();
			Difficulties= _difficultyService.RetrieveAll();
		}
		

		public void OnPost()
		{
			Search recipe = new Search();
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
