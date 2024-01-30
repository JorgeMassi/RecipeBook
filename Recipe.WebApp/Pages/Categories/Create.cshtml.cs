using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public LogIn SessionUser { get; set; }

        public IActionResult OnGet()
        {
            GetSessionUser();

            if (SessionUser.IsAdmin)
            {
                Categories = _categoryService.RetrieveAll();
            }

            return Redirect("/Logins/logins");


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

            if (user is not null)
            {
                SessionUser = JsonSerializer.Deserialize<LogIn>(user);
            }

        }
    }
}
