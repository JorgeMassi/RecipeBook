using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
	public class SearchService : ISearchService
	{
		private readonly ISearchRepository _searchRepository;
		private readonly IRecipeService _recipeService;
		private readonly ICategoryService _categoryService;
		private readonly IDifficultyService _difficultyService;
		private readonly IIngredientLineService _ingredientLineService;
		private readonly IUserService _userService;

		public SearchService(ISearchRepository searchRepository, IRecipeService recipeService, ICategoryService categoryService, IDifficultyService diffiultyService, IIngredientLineService ingredientLineService, IUserService userService)
		{
			_searchRepository = searchRepository;
			_recipeService = recipeService;
			_categoryService = categoryService;
			_difficultyService = diffiultyService;
			_ingredientLineService = ingredientLineService;
			_userService = userService;
		}

		public List<Search> RetrieveAll()
		{
			List<Search> searches = _searchRepository.RetrieveAll();

			foreach (Search search in searches)
			{

				search.RecipeWriter = _userService.Retrieve(search.RecipeWriter.Id);

				search.Category = _categoryService.Retrieve(search.Category.Id);

				search.Difficulty = _difficultyService.Retrieve(search.Difficulty.Id);

				search.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(search);
			}
			return searches;
		}

		public List<Search> RetrieveAllSearchCategory(string searchCategory)
		{
			List<Search> searches = _searchRepository.RetrieveAllSearchCategory(searchCategory);

			foreach (Search search in searches)
			{

				search.RecipeWriter = _userService.Retrieve(search.RecipeWriter.Id);

				search.Category = _categoryService.Retrieve(search.Category.Id);

				search.Difficulty = _difficultyService.Retrieve(search.Difficulty.Id);

				search.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(search);
			}
			return searches;
		}

		public List<Search> RetrieveAllSearchDifficulty(string searchDifficulty)
		{
			List<Search> searches = _searchRepository.RetrieveAllSearchDifficulty(searchDifficulty);

			foreach (Search search in searches)
			{

				search.RecipeWriter = _userService.Retrieve(search.RecipeWriter.Id);

				search.Category = _categoryService.Retrieve(search.Category.Id);

				search.Difficulty = _difficultyService.Retrieve(search.Difficulty.Id);

				search.IngredientLine = _ingredientLineService.RetrieveAllByRecipeId(search);
			}
			return searches;
		}
	}
}
