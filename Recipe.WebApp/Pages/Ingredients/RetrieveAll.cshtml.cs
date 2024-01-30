using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Ingredients
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IIngredientService _ingredientService;

        public RetrieveAllModel(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public List<Ingredient> Ingredients { get; set; }
        public Ingredient Ingredient { get; set; }
        public LogIn SessionUser { get; set; }

        public void OnGet()
        {
            GetSessionUser();
            Ingredients = _ingredientService.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = Convert.ToString(Request.Form["name"]);
 
            _ingredientService.Create(ingredient);
            return Redirect("/ingredients/retrieveall");
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
