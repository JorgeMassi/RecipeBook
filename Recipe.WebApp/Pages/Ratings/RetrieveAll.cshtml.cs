using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Ratings
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public RetrieveAllModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public List<Rating> Ratings { get; set; }
        public Rating Rating { get; set; }
        public LogIn SessionUser { get; set; }
       

        public void OnGet()
        {
            GetSessionUser();
            Ratings = _ratingService.RetrieveAll();
            
        }

        public IActionResult OnPost()
        {
            Rating rating = new Rating();
            rating.Name = Convert.ToString(Request.Form["name"]);

            _ratingService.Create(rating);
            return Redirect("/ratings/retrieveall");
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
