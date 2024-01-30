using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public interface IIngredientService
    {
        Ingredient Create(Ingredient ingredient);
        Ingredient Update(Ingredient ingredient);
        void Delete(int id);
        Ingredient Retrieve(int id);
        List<Ingredient> RetrieveAll();
    }
}
