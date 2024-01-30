using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Ratings
{
    public class UpdateModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public UpdateModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        public Rating Rating { get; set; }

        public void OnGet(int id)
        {
            Rating = _ratingService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Rating rating = new Rating();
            rating.Id = Convert.ToInt32(Request.Form["id"]);
            rating.Name = Convert.ToString(Request.Form["name"]);

            _ratingService.Update(rating);
            return Redirect("/ratings/retrieveall");

        }
    }
}
