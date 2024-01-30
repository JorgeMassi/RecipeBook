using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Measures
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public RetrieveAllModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        public List<Measure> Measures { get; set; }
        public Measure Measure { get; set; }
        public LogIn SessionUser { get; set; }

        public void OnGet()
        {
            GetSessionUser();
            Measures = _measureService.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            Measure measure = new Measure();
            measure.Name = Convert.ToString(Request.Form["name"]);

            _measureService.Create(measure);
            return Redirect("/measures/retrieveall");
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
