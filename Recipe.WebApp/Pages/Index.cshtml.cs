using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
       
        

        public IndexModel(ILogger<IndexModel> logger, ILogInService logInService)
        {
            _logger = logger;
        }

        public LogIn SessionUser { get; set; }
        public void OnGet()
        {
            GetSessionUser();
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