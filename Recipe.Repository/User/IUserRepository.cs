using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface IUserRepository
    {
        User Create(User user);
        User Update(User user);
        void Delete(int id);
        User Retrieve(int id);
        List<User> RetrieveAll();
        User isAdminUpdate(int id);
        User isBlockedUpdate (int id);

	}
}
