using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public interface ICategoryService
    {
        Category Create(Category category);
        Category Retrieve(int id);
        List<Category> RetrieveAll();
        Category Update(Category category);
        void Delete(int id);
        List<Category> RetrieveAllSearch(string search);
        Category RetrieveBy(int id);
		

		}
}
