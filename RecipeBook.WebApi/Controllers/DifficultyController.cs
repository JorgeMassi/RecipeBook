using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficultyService _difficultyService;

        public DifficultyController(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        [HttpGet]
        public IEnumerable<Difficulty> GetAll()
        {
            return _difficultyService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Difficulty Get(int id)
        {
            return _difficultyService.Retrieve(id);
        }

        [HttpPost]
        public Difficulty Post(Difficulty difficulty)
        {

            return _difficultyService.Create(difficulty);
        }

        [HttpPut]
        public Difficulty Put(Difficulty difficulty)
        {
            return _difficultyService.Update(difficulty);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _difficultyService.Delete(id);
        }
    }
}
