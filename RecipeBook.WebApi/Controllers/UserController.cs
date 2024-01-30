using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.Retrieve(id);
        }

       
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userService.Update(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public User Put(User user)
        {
            return _userService.Create(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
