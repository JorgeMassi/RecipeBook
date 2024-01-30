using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Users.Users

{
	public class RetrieveModel : PageModel
	{

		private readonly IUserService _userService;
		private readonly ILogInService _logInService;

		public RetrieveModel(IUserService userService, ILogInService logInService)
		{
			_logInService = logInService;
			_userService = userService;
		}

		public List<User> Users { get; set; }
		public List<LogIn> LogIns { get; set; }
		public User User { get; set; }
		public LogIn SessionUser { get; set; }


		public void OnGet(int id)
		{
			GetSessionUser();
			User = _userService.Retrieve(id);
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
