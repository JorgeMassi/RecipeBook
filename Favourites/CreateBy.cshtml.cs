using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Favourites
{
    public class CreateByModel : PageModel
    {
        private readonly IFavouriteService _favouriteService;

		public CreateByModel(IFavouriteService favouriteService)
		{
			_favouriteService = favouriteService;
		}

        public LogIn SessionUser { get; set; }

		public IActionResult OnGet(int id)
        {
			GetSessionUser();
			_favouriteService.CreateBy(SessionUser.Id, id);
            return Redirect("/Recipes/RetrieveAll");
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
