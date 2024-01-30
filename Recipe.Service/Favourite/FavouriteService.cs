using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;
        public FavouriteService(IFavouriteRepository favouriteRepository, IUserService userService, IRecipeService recipeService)
        {
            _favouriteRepository = favouriteRepository;
            _userService = userService;
            _recipeService = recipeService;
        }
        public Favourite Create(Favourite favourite)
        {
            return _favouriteRepository.Create(favourite);
        }
		public Favourite CreateBy(int user, int recipe)
        {
            return _favouriteRepository.CreateBy(user, recipe);
        }


		public void Delete(int id)
        {
            _favouriteRepository.Delete(id);
        }

        public Favourite Retrieve(int id)
        {
            return _favouriteRepository.Retrieve(id);
        }

        public List<Favourite> RetrieveAll()
        {
            List<Favourite> favourites = _favouriteRepository.RetrieveAll();

            foreach (Favourite favourite in favourites)
            {

                favourite.User = _userService.Retrieve(favourite.User.Id);

                favourite.Recipe = _recipeService.Retrieve(favourite.Recipe.Id);

            }
            return favourites;
        }

        public Favourite Update(Favourite favourite)
        {
            return _favouriteRepository.Update(favourite);
        }
    }
}
