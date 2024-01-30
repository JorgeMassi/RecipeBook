using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
	public interface ISearchRepository
	{
		List<Search> RetrieveAllSearchCategory(string searchCategory);
		List<Search> RetrieveAllSearchDifficulty(string searchDifficulty);
		List<Search> RetrieveAll();
	}
}
