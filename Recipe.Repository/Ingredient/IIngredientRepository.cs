using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface IIngredientRepository
    {
        Ingredient Create(Ingredient ingredient);
        Ingredient Update(Ingredient ingredient);
        Ingredient Retrieve(int id);
        void Delete(int id);
        List<Ingredient> RetrieveAll();
    }
}
