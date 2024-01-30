using RecipeBook.Model;

namespace RecipeBook.Service
{
    public interface IFavouriteService
    {
        Favourite Create(Favourite favourite);
        Favourite Update(Favourite favourite);
        void Delete(int id);
        Favourite Retrieve(int id);
        List<Favourite> RetrieveAll();
        Favourite CreateBy(int user, int recipe);


	}
}
