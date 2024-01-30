using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Ratings
{
    public class DeleteModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public DeleteModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public IActionResult OnGet(int id)
            {
                _ratingService.Delete(id);
                return Redirect("/ratings/retrieveall");
            }
    }
}
