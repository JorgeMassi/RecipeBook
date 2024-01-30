using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpGet]
        public IEnumerable<Favourite> GetAll()
        {
            return _favouriteService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Favourite Get(int id)
        {
            return _favouriteService.Retrieve(id);
        }

        [HttpPost]
        public Favourite Post(Favourite favourite)
        {

            return _favouriteService.Create(favourite);
        }

        [HttpPut]
        public Favourite Put(Favourite favourite)
        {
            return _favouriteService.Update(favourite);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _favouriteService.Delete(id);
        }
    }
}
