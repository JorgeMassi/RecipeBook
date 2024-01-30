using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Recipes
{
    public class RetrieveByModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;
        private readonly IIngredientLineService _ingredientLineService;
        private readonly IReviewService _reviewService;
        private readonly ILogInService _logInService;
        private readonly IIngredientService _ingredditService;
        private readonly IMeasureService _measureService;

        public RetrieveByModel(IMeasureService measureService, IRecipeService recipeService, IUserService userService, ICategoryService categoryService, IDifficultyService difficultyService, IIngredientLineService ingredientLineService, IReviewService reviewService, ILogInService logInService)
        {
            _recipeService = recipeService;
            _userService = userService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _ingredientLineService = ingredientLineService;
            _reviewService = reviewService;
            _logInService = logInService;
            _measureService = measureService;
        }

        public List<Recipe> Recipes { get; set; }
        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }
        public List<Difficulty> Difficulties { get; set; }
        public List<IngredientLine> IngredientLines { get; set; }
        public List<Review> Reviews { get; set; }

        public IngredientLine IngredientLine { get; set; }
        public Category Category { get; set; }
        public Measure Measure { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        public User User { get; set; }
        public Review Review { get; set; }
        public LogIn SessionUser { get; set; }
        public void OnGet(int id)
        {
            GetSessionUser();
            Recipe = _recipeService.Retrieve(id);
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

