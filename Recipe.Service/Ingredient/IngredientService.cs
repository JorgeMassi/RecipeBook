using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public Ingredient Create(Ingredient ingredient)
        {
            return _ingredientRepository.Create(ingredient);
        }

        public void Delete(int id)
        {
            _ingredientRepository.Delete(id);
        }

        public Ingredient Retrieve(int id)
        {
            return _ingredientRepository.Retrieve(id);
        }

        public List<Ingredient> RetrieveAll()
        {
            return _ingredientRepository.RetrieveAll();
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return _ingredientRepository.Update(ingredient);
        }
    }
}
