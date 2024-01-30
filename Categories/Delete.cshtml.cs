using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        public readonly ICategoryService _categoryService;
        public DeleteModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult OnGet(int id)
        {
            _categoryService.Delete(id);
            return Redirect("/categories/retrieveall");
        }
    }
}
