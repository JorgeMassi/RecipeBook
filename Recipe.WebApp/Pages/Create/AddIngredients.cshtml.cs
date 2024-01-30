using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using RecipeBook.Model;
using RecipeBook.Repository;
using RecipeBook.Service;
using System.Security.Cryptography.Pkcs;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Create
{
	public class AddIngredientsModel : PageModel
	{
		private readonly IIngredientLineService _ingredientLineService;
		private readonly IIngredientService _ingredientService;
		private readonly IMeasureService _measureService;
		private readonly IRecipeService _recipeService;
		private readonly IRatingService _ratingService;

		public AddIngredientsModel(IIngredientLineService ingredientLineService, IIngredientService ingredientService, IMeasureService measureService, IRecipeService recipeService, IRatingService ratingService)
		{
			_ingredientLineService = ingredientLineService;
			_ingredientService = ingredientService;
			_measureService = measureService;
			_recipeService = recipeService;
			_ratingService = ratingService;
		}

		public List<Ingredient> Ingredients { get; set; }
		public List<IngredientLine> IngredientLines { get; set; }
		public List<Measure> Measures { get; set; }
		public List<Recipe> Recipes { get; set; }

		public Recipe Recipe { get; set; }
		public Ingredient Ingredient { get; set; }
		public Measure Measure { get; set; }

		public IngredientLine IngredientLine { get; set; }
		public LogIn SessionUser { get; set; }


		public void OnGet(Recipe recipe)
		{
			GetSessionUser();
			Recipe = _recipeService.Retrieve(recipe.Id);
			IngredientLines = _ingredientLineService.RetrieveAllByRecipeId(Recipe);
			Measures = _measureService.RetrieveAll();
			Ingredients = _ingredientService.RetrieveAll();

	
			
			
		}
		public IActionResult OnPost()
		{
			IngredientLine ingredientLine = new IngredientLine();

			Recipe recipe = new Recipe();
			recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);
			ingredientLine.Recipe = recipe;

			Ingredient ingredient = new Ingredient();
			ingredient.Name = Convert.ToString(Request.Form["ingredient"]);
			ingredientLine.Ingredient = _ingredientService.Create(ingredient);

			ingredientLine.Qtd = Convert.ToDouble(Request.Form["qtd"]);

			Measure measure = new Measure();
			measure.Name = Convert.ToString(Request.Form["measure"]);
			ingredientLine.Measure = _measureService.Create(measure);

			_ingredientLineService.Create(ingredientLine);
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

