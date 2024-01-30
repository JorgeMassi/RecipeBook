using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Users
{
    public class DeleteModel : PageModel
    {
        public readonly IUserService _userService;
        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }
        public LogIn SessionUser { get; set; }

        public IActionResult OnGet(int id)
        {
            GetSessionUser();
            _userService.Delete(id);
            return Redirect("/users/retrieveall");
        }
		private void GetSessionUser()
		{
			string user = HttpContext.Session.GetString("user");
			if (user != null)
			{
				SessionUser = JsonSerializer.Deserialize<LogIn>(user);
			}
		}
	}
}
