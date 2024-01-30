using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Users.Adm
{
    public class UpdateModel : PageModel
    {
        public readonly IUserService _userService;
        public UpdateModel(IUserService userService)
        {
            _userService = userService;
        }
        public User User { get; set; }
        public LogIn SessionUser { get; set; }

        public void OnGet(int id)
        {
            GetSessionUser();
            User = _userService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["id"]);
            user.UserName = Convert.ToString(Request.Form["username"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.Name = Convert.ToString(Request.Form["name"]);
            user.Email = Convert.ToString(Request.Form["email"]);

            _userService.Update(user);
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
