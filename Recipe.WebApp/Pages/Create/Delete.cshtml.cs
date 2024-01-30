using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Create
{
    public class DeleteModel : PageModel
    {
		public readonly IIngredientLineService _ingredientLineService;
		public DeleteModel(IIngredientLineService ingredientLineService)
		{
			_ingredientLineService = ingredientLineService;
		}

		public List<IngredientLine> IngredientLines { get; set; }
		public Recipe Recipe { get; set; }

		public IActionResult OnGet(int recipeId, int id)
		{
			_ingredientLineService.Delete(id);
			return Redirect($"/Create/AddIngredients?id={recipeId}");
		}
	}
}

