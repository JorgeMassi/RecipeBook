using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Difficulties
{
    public class DeleteModel : PageModel
    {
        public readonly IDifficultyService _difficultyService;
        public DeleteModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public IActionResult OnGet(int id)
        {
            _difficultyService.Delete(id);
            return Redirect("/difficulties/retrieveall");
        }
    }
}
