using RecipeBook.Model;
using RecipeBook.Repository;

namespace RecipeBook.Service
{
    public class LogInService : ILogInService
    {
        private readonly ILogInRepository _logInRepository;

        public LogInService(ILogInRepository logInrepository)
        {
            _logInRepository = logInrepository;
        }

        public LogIn? Login(string username, string password)
        {
                return _logInRepository.Login(username, password);
        }
       
    }

}
