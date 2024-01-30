using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientLineController : ControllerBase
    { 
        private readonly IIngredientLineService _ingredientLineService;

        public IngredientLineController( IIngredientLineService ingredientLineService)
        { 
         _ingredientLineService = ingredientLineService;
        }

        [HttpGet]
        public IEnumerable<IngredientLine> GetAll(int recipeId)
        {
            return _ingredientLineService.RetrieveAllByRecipeId(recipeId);
        }

        [HttpGet("{id}")]
        public IngredientLine Get(int id)
        {
            return _ingredientLineService.Retrieve(id);
        }

        [HttpPost]
        public IngredientLine Post(IngredientLine ingredientLine)
        {

            return _ingredientLineService.Create(ingredientLine);
        }

        [HttpPut]
        public IngredientLine Put(IngredientLine ingredientLine)
        {
            return _ingredientLineService.Update(ingredientLine);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _ingredientLineService.Delete(id);
        }
    }

}
