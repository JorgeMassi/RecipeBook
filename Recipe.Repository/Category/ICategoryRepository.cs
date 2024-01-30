using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category Update(Category category);
        void Delete(int id);
        Category Retrieve(int id);
        List<Category> RetrieveAll();
        List<Category> RetrieveAllSearch(string search);
        Category RetrieveBy(int id);


		}
}
