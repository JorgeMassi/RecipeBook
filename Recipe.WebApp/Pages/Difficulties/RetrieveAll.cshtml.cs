using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Difficulties
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;

        public RetrieveAllModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public List<Difficulty> Difficulties { get; set; }
        public Difficulty Difficulty { get; set; }
        public LogIn SessionUser { get; set; }

        public void OnGet()
        {
            GetSessionUser();
            Difficulties = _difficultyService.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Name = Convert.ToString(Request.Form["name"]);

            _difficultyService.Create(difficulty);
            return Redirect("/difficulties/retrieveall");
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
