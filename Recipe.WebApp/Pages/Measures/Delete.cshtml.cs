using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Measures
{
    public class DeleteModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public DeleteModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }
        public IActionResult OnGet(int id)
        {
            _measureService.Delete(id);
            return Redirect("/measures/retrieveall");
        }
    }
}
