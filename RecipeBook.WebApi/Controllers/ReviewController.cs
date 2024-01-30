using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public IEnumerable<Review> Get()
        {
            return _reviewService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Review Get(int id)
        {
            return _reviewService.Retrieve(id);
        }

        [HttpPost]
        public Review Post([FromBody] Review review)
        {
            return _reviewService.Create(review);
        }

        [HttpPut("{id}")]
        public Review Put(Review review)
        {
            return _reviewService.Update(review);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reviewService.Delete(id);
        }
    }
}
