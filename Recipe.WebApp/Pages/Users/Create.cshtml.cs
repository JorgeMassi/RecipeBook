using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Users
{
	public class CreateModel : PageModel
	{
		private readonly IUserService _userService;

		public CreateModel(IUserService userService)
		{
			_userService = userService;
		}

		public List<User> Users { get; set; }
		public User User { get; set; }
		public LogIn SessionUser { get; set; }

		public void onGet()
		{
			GetSessionUser();

		}

		public IActionResult OnPost()
		{
			User user = new User();
			user.UserName = Convert.ToString(Request.Form["username"]);
			user.Password = Convert.ToString(Request.Form["password"]);
			user.Name = Convert.ToString(Request.Form["name"]);
			user.Email = Convert.ToString(Request.Form["email"]);
			user.IsAdmin = Convert.ToBoolean(Request.Form["User.IsAdmin"]);
			user.IsBlocked = Convert.ToBoolean(Request.Form["User.IsBlocked"]);

			_userService.Create(user);
            return Redirect("/Logins/logins");
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
