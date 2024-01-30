using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Users
{
    public class UserManagerModel : PageModel
    {

        private readonly ILogInService _logInService;
        private readonly IUserService _userService;

        public UserManagerModel(IUserService userService, ILogInService logInService)
        {
            _userService = userService;
            _logInService = logInService;
        }

        public LogIn SessionUser { get; set; }
        public User User { get; set; }


        public void OnGet()
        {
            GetSessionUser();
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
