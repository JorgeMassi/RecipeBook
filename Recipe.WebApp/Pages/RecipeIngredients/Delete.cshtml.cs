using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.RecipeIngredients
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

		public IActionResult OnGet(int id, int recipeId)
		{
			_ingredientLineService.Delete(id);
			return Redirect($"/RecipeIngredients/Update?id={recipeId}");
		}
	}
}
