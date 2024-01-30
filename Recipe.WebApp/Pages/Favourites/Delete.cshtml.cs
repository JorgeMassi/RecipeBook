using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Favourites
{
    public class DeleteModel : PageModel
    {
		public readonly IFavouriteService _favouriteService;

		public DeleteModel(IFavouriteService favouriteService)
		{
			_favouriteService = favouriteService;
		}

		public IActionResult OnGet(int id, int userId)
		{
			_favouriteService.Delete(id);
			return Redirect($"/Users/UserManager?id={userId}");
		}
	}
}
