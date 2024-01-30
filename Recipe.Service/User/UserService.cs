using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

		public User isAdminUpdate(int id)
		{
			return _userRepository.isAdminUpdate(id);
		}

		public User isBlockedUpdate(int id)
		{
			return _userRepository.isBlockedUpdate(id);
		}

		public User Retrieve(int id)
        {
            return _userRepository.Retrieve(id);
        }

        public List<User> RetrieveAll()
        {
            return _userRepository.RetrieveAll();
        }
		

		public User Update(User user)
        {
            return _userRepository.Update(user);
        }
    }
}
