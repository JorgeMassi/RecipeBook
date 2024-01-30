using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.RecipeIngredients
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasureService _measureService;

        public RetrieveAllModel(IIngredientLineService ingredientLineService, IIngredientService ingredientService, IMeasureService measureService)
        {
            _ingredientLineService = ingredientLineService;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public List<IngredientLine> IngredientLines { get; set; }
        public List <Ingredient> Ingredients { get; set; }
        public List<Measure> Measures { get; set; }
        public IngredientLine Ingredient { get; set; }

        public LogIn SessionUser { get; set; }

        public void OnGet(Recipe recipe)
        {
            GetSessionUser();
            IngredientLines = _ingredientLineService.RetrieveAllByRecipeId(recipe);
            Measures = _measureService.RetrieveAll();
            Ingredients = _ingredientService.RetrieveAll();

        }

        public IActionResult OnPost()
        {
            IngredientLine ingredientLine = new IngredientLine();

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);
            ingredientLine.Ingredient = ingredient;

            ingredientLine.Qtd = Convert.ToDouble(Request.Form["qtd"]);

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id_measure"]);
            ingredientLine.Measure = measure;

            _ingredientLineService.Create(ingredientLine);
            return Redirect("/recipeingredients/retrieveall");
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

