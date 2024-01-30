using RecipeBook.Model;

namespace RecipeBook.Repository
{
    public interface IRecipeRepository
    {
        Recipe Create(Recipe recipe);
        Recipe Update(Recipe recipe);
        void Delete(int id);
        Recipe Retrieve (int id);
        List<Recipe> RetrieveAll ();
        Recipe RetrieveByUser(int id);
        List<Recipe> RetrieveAllByUser(int id);
        List<Recipe> RetrieveAllAppprovedRecipe();
        List<Recipe> ToApproved();
        Recipe ToApprovedUpdate(int id);

	}
}
