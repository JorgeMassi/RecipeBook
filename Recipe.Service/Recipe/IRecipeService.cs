using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public interface IRecipeService
    {
        Recipe Create(Recipe recipe);
        Recipe Update(Recipe recipe);
        void Delete(int id);
        Recipe Retrieve(int id);
        List<Recipe> RetrieveAll();
        Recipe RetrieveByUser(int id);
        List<Recipe> RetrieveAllByUser(int id);
        List<Recipe> RetrieveAllAppprovedRecipe();
        List<Recipe> ToApproved();
        Recipe ToApprovedUpdate(int id);


	}
}
