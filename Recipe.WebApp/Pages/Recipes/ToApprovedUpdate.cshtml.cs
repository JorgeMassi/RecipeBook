using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Recipes
{
    public class ToApprovedUpdateModel : PageModel
    {
		private readonly IRecipeService _recipeService;

		public ToApprovedUpdateModel(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		public IActionResult OnGet(int id)
		{
			_recipeService.ToApprovedUpdate(id);
			return Redirect("/recipes/ToApproved");
		}
	}
}
