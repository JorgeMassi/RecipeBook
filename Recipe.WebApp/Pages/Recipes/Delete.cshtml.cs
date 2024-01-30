using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
		private readonly IRecipeService _recipeService;

		public DeleteModel(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		public IActionResult OnGet(int id)
		{
			_recipeService.Delete(id);
			return Redirect("/recipes/retrieveall");
		}
	}
}