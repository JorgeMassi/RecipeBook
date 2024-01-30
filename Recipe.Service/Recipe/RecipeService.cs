using RecipeBook.Model;
using RecipeBook.Repository;
using RecipeBook.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserService  _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;
        private readonly IIngredientLineService _ingredientLineService;

        public RecipeService(IRecipeRepository recipeRepository, IUserService userService, ICategoryService categoryService, IDifficultyService difficultyService, IIngredientLineService ingredientLineService)
        {
            _recipeRepository = recipeRepository;
            _userService = userService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _ingredientLineService = ingredientLineService;
        }

        public Recipe Create(Recipe recipe)
        {
            return _recipeRepository.Create(recipe);
        }

        public void Delete(int id)
        {
            _recipeRepository.Delete(id);
        }

        public Recipe Retrieve(int id)
        {
            Recipe recipe = _recipeRepository.Retrieve(id);

            recipe.RecipeWriter = _userService.Retrieve(recipe.RecipeWriter.Id);

            recipe.Category = _categoryService.Retrieve(recipe.Category.Id);


            recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);

           recipe.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(recipe);
            return recipe;
        }
        public Recipe RetrieveByUser(int id)
        {
            Recipe recipe = _recipeRepository.RetrieveByUser(id);

            recipe.RecipeWriter = _userService.Retrieve(recipe.RecipeWriter.Id);

            recipe.Category = _categoryService.Retrieve(recipe.Category.Id);

            recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);

            recipe.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(recipe);
            return recipe;

        }


        public List<Recipe> RetrieveAll()
        {
            List<Recipe> recipes = _recipeRepository.RetrieveAll();

            foreach (Recipe recipe in recipes)
            {

                recipe.RecipeWriter = _userService.Retrieve(recipe.RecipeWriter.Id);

                recipe.Category = _categoryService.Retrieve(recipe.Category.Id);

                recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);

                recipe.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(recipe);
            }
            return recipes;
        }
		public List<Recipe> RetrieveAllByUser(int id)
		{
			List<Recipe> recipes = _recipeRepository.RetrieveAllByUser(id);

			foreach (Recipe recipe in recipes)
			{

				recipe.RecipeWriter = _userService.Retrieve(recipe.RecipeWriter.Id);

				recipe.Category = _categoryService.Retrieve(recipe.Category.Id);

				recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);

				recipe.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(recipe);
			}
			return recipes;
		}

		public Recipe Update(Recipe recipe)
        {
            return _recipeRepository.Update(recipe);
        }

		public List<Recipe> RetrieveAllAppprovedRecipe()
		{
			List<Recipe> recipes = _recipeRepository.RetrieveAllAppprovedRecipe();

			foreach (Recipe recipe in recipes)
			{

				recipe.RecipeWriter = _userService.Retrieve(recipe.RecipeWriter.Id);

				recipe.Category = _categoryService.Retrieve(recipe.Category.Id);

				recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);

				recipe.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(recipe);
			}
			return recipes;
		}

		public List<Recipe> ToApproved()
		{
			List<Recipe> recipes = _recipeRepository.ToApproved();

			foreach (Recipe recipe in recipes)
			{

				recipe.RecipeWriter = _userService.Retrieve(recipe.RecipeWriter.Id);

				recipe.Category = _categoryService.Retrieve(recipe.Category.Id);

				recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);

				recipe.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(recipe);
			}
			return recipes;
		}

		public Recipe ToApprovedUpdate(int id)
		{
			return _recipeRepository.ToApprovedUpdate(id);
		}
	}
}
