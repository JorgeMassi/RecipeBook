using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Categories
{
    public class RetrieveAllModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public RetrieveAllModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public LogIn SessionUser { get; set; }

        public void OnGet()
        {
            GetSessionUser();
            Categories = _categoryService.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            Category category = new Category();
            category.Name = Convert.ToString(Request.Form["name"]);

            _categoryService.Create(category);
            return Redirect("/categories/retrieveall");
        }
        private void GetSessionUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                SessionUser = JsonSerializer.Deserialize<LogIn>(user);
            }
        }
        
    }
}
