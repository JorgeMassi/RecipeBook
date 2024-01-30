using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        public RecipeController (IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public IEnumerable<Recipe> GetAll()
        {
            return _recipeService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return _recipeService.Retrieve(id);
        }

        [HttpPost]
        public Recipe Post(Recipe recipe)
        {

            return _recipeService.Create(recipe);
        }

        [HttpPut]
        public Recipe Put(Recipe recipe)
        {
            return _recipeService.Update(recipe);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _recipeService.Delete(id);
        }
    }
}
