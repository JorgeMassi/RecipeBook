using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface IFavouriteRepository
    {
        Favourite Create(Favourite favourite);
        Favourite Update(Favourite favourite);
        Favourite Retrieve(int id);
        void Delete(int id);
        List<Favourite> RetrieveAll();
        Favourite CreateBy(int user, int recipe);



	}
}
