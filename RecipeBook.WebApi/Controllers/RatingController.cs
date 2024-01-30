using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController( IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public IEnumerable<Rating> GetAll()
        {
            return _ratingService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Rating Get(int id)
        {
            return _ratingService.Retrieve(id);
        }

        [HttpPost]
        public Rating Post(Rating recipe)
        {

            return _ratingService.Create(recipe);
        }

        [HttpPut]
        public Rating Put(Rating recipe)
        {
            return _ratingService.Update(recipe);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _ratingService.Delete(id);
        }
    }
}
