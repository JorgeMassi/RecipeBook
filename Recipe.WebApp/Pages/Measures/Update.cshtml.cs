using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeBook.Model;
using RecipeBook.Service;

namespace RecipeBook.WebApp.Pages.Measures
{
    public class UpdateModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public UpdateModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }
        public Measure Measure { get; set; }

        public void OnGet(int id)
        {
            Measure = _measureService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id"]);
            measure.Name = Convert.ToString(Request.Form["name"]);

            _measureService.Update(measure);
            return Redirect("/measures/retrieveall");

        }
    }
}
