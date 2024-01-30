using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasureService _measureService;

        public MeasureController( IMeasureService measureService)
        {
            _measureService = measureService;
        }

        [HttpGet]
        public IEnumerable<Measure> GetAll()
        {
            return _measureService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Measure Get(int id)
        {
            return _measureService.Retrieve(id);
        }

        [HttpPost]
        public Measure Post(Measure recipe)
        {

            return _measureService.Create(recipe);
        }

        [HttpPut]
        public Measure Put(Measure recipe)
        {
            return _measureService.Update(recipe);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _measureService.Delete(id);
        }
    }
}
