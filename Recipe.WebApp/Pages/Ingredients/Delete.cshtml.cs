using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Ingredients
{
        public class DeleteModel : PageModel
        {
            public readonly IIngredientService _ingredientService;
            public DeleteModel(IIngredientService ingredientService)
            {
                _ingredientService = ingredientService;
            }

            public IActionResult OnGet(int id)
            {
            _ingredientService.Delete(id);
                return Redirect("/Ingredients/retrieveall");
            }
        }
}
