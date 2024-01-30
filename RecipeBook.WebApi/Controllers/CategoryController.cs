using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _categoryService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryService.Retrieve(id);
        }

        [HttpPost]
        public Category Post(Category category)
        {

            return _categoryService.Create(category);
        }

        [HttpPut]
        public Category Put(Category category)
        {
            return _categoryService.Update(category);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _categoryService.Delete(id);
        }
    }
}
