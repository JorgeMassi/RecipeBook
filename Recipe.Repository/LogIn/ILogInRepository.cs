using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface ILogInRepository
    {
        LogIn? Login(string username, string password);
        
    }
}
