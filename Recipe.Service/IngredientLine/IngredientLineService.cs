using RecipeBook.Model;
using RecipeBook.Repository;

namespace RecipeBook.Service
{
    public class IngredientLineService : IIngredientLineService
    {
        private readonly IIngredientLineRepository _ingredientLineRepository;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasureService _measureService;
       
        public IngredientLineService(IIngredientLineRepository ingredientLineRepository, IIngredientService ingredientService, IMeasureService measureService)
        {
            _ingredientLineRepository = ingredientLineRepository;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public IngredientLine Create(IngredientLine ingredientLine)
        {
            return _ingredientLineRepository.Create(ingredientLine);
        }

        public void Delete(int id)
        {
            _ingredientLineRepository.Delete(id);
        }

        public IngredientLine Retrieve(int id)
        {
            return _ingredientLineRepository.Retrieve(id);
        }

        public List<IngredientLine> RetrieveAllByRecipeId(Recipe recipe)
        {
            List<IngredientLine> ingredientLines = _ingredientLineRepository.RetrieveAllByRecipeId(recipe.Id);

            foreach (IngredientLine ingredientLine in ingredientLines)
            {

                ingredientLine.Recipe = recipe;
                ingredientLine.Ingredient = _ingredientService.Retrieve(ingredientLine.Ingredient.Id);

                ingredientLine.Measure = _measureService.Retrieve(ingredientLine.Measure.Id);
            }
            return ingredientLines;
        }

        public IngredientLine Update(IngredientLine ingredientLine)
        {
            return _ingredientLineRepository.Update(ingredientLine);
        }
    }
}
