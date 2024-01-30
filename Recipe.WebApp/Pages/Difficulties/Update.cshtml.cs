using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Difficulties
{
    public class UpdateModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;


        public UpdateModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public Difficulty Difficulty { get; set; }
        public LogIn SessionUser { get; set; }
        public void OnGet(int id)
        {
            GetSessionUser();
            Difficulty = _difficultyService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["id"]);
            difficulty.Name = Convert.ToString(Request.Form["name"]);

            _difficultyService.Update(difficulty);
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
