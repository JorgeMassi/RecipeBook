using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Favourites
{
	public class RetrieveModel : PageModel
	{
		private readonly IFavouriteService _favouriteService;
		private readonly IUserService _userService;
		private readonly IRecipeService _recipeService;

		public RetrieveModel(IFavouriteService favouriteService, IUserService userService, IRecipeService recipeService)
		{
			_favouriteService = favouriteService;
			_userService = userService;
			_recipeService = recipeService;
		}

		public List<Favourite> Favourites { get; set; }
		public List<Recipe> Recipes { get; set; }

		public Recipe Recipe { get; set; }
		public Favourite Favourite { get; set; }
		public LogIn SessionUser { get; set; }
		public User User { get; set; }

		public void OnGet(int id)
		{
			GetSessionUser();
			Favourites = _favouriteService.RetrieveAll();
			User = _userService.Retrieve(id);
			Recipes = _recipeService.RetrieveAll();
		}

		public IActionResult OnPost()
		{
			Favourite favourite = new Favourite();
			favourite.Id = Convert.ToInt32(Request.Form["id"]);

			Recipe recipe = new Recipe();
			recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);
			favourite.Recipe = recipe;

			User user = new User();
			user.Id = Convert.ToInt32(Request.Form["id_user"]);
			favourite.User = user;

			_favouriteService.Create(favourite);
			return Redirect($"/Users/UserManager?id=");
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
