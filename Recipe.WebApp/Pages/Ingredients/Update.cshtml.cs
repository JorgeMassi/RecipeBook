using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Ingredients
{
        public class UpdateModel : PageModel
        {
            private readonly IIngredientService _ingredientService;
            public UpdateModel(IIngredientService ingredientService)
            {
            _ingredientService = ingredientService;
            }
            public Ingredient Ingredient { get; set; }
            public void OnGet(int id)
            {
                Ingredient = _ingredientService.Retrieve(id);
            }
            public IActionResult OnPost()
            {
                Ingredient ingredient = new Ingredient();
                ingredient.Id = Convert.ToInt32(Request.Form["id"]);
                ingredient.Name = Convert.ToString(Request.Form["name"]);

            _ingredientService.Update(ingredient);
                return Redirect("/ingredients/retrieveall");

            }
        }
}
