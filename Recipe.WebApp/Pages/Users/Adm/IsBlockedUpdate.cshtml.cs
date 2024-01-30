using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Users.Adm
{
	public class IsBlockedUpdateModel : PageModel
	{
		private readonly IUserService _userService;

		public IsBlockedUpdateModel(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult OnGet(int id)
		{
			_userService.isBlockedUpdate(id);
			return Redirect("/Users/Adm/Retrieveall");
		}
	}
}
