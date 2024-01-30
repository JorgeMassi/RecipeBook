using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;
using RecipeBook.WebApp.Pages.Recipes;

namespace RecipeBook.WebApp.Pages.Users.Adm
{
    public class IsAdminUpdateModel : PageModel
    {
        private readonly IUserService _userService;

		public IsAdminUpdateModel(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult OnGet(int id)
        {
			_userService.isAdminUpdate(id);
			return Redirect("/Users/Adm/Retrieveall");
        }
    }
}
