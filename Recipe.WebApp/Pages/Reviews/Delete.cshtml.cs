using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Reviews
{
    public class DeleteModel : PageModel
    {
		public readonly IReviewService _reviewService;

		public DeleteModel(IReviewService reviewService)
		{
			_reviewService = reviewService;
		}

		public IActionResult OnGet(int id)
		{
			_reviewService.Delete(id);
			return Redirect("/reviews/retrieveall");
		}
	}
}
