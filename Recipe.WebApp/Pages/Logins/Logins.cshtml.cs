using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Logins
{
	public class LogInModel : PageModel
	{
		public readonly ILogInService _logInService;


		public LogInModel(ILogInService logInService)
		{
			_logInService = logInService;

		}

		public LogIn SessionUser { get; set; }
		public User User { get; set; }

		public void OnGet()
		{
			GetSessionUser();
		}

		public IActionResult OnPost()
		{
			if (SetSessionUser())
			{
				return Redirect("/index");
			}
			else
			{
				return Redirect("/Logins/logins");

			}

		}
		public bool SetSessionUser()
		{
			string username = Convert.ToString(Request.Form["username"]);
			string password = Convert.ToString(Request.Form["password"]);
			LogIn? log = _logInService.Login(username, password);
			if (log == null) { return false; }

			string jsonString = JsonSerializer.Serialize(log);
			HttpContext.Session.SetString("user", jsonString);
			return true;

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
