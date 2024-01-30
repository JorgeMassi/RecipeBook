using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface IIngredientLineRepository
    {
        IngredientLine Create(IngredientLine ingredientLine);
        IngredientLine Update(IngredientLine ingredientLine);
        void Delete(int id);
        IngredientLine Retrieve(int id);
        List<IngredientLine> RetrieveAllByRecipeId(int recipeId);
    }
}
