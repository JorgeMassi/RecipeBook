using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;


        public IngredientController( IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredientService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Ingredient Get(int id)
        {
            return _ingredientService.Retrieve(id);
        }

        [HttpPost]
        public Ingredient Post(Ingredient ingredient)
        {

            return _ingredientService.Create(ingredient);
        }

        [HttpPut]
        public Ingredient Put(Ingredient ingredient)
        {
            return _ingredientService.Update(ingredient);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _ingredientService.Delete(id);
        }
    }
}
