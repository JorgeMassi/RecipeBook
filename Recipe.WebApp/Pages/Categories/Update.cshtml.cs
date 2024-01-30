using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Categories
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _categoryService;


        public UpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public Category Category { get; set; }
        public LogIn SessionUser { get; set; }

        public void OnGet(int id)
        {
            GetSessionUser();
            Category = _categoryService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);

            _categoryService.Update(category);
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
