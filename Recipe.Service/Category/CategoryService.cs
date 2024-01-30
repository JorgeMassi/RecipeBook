using RecipeBook.Model;
using RecipeBook.Repository;

namespace RecipeBook.Service
{
    // public class CategoryService : Service<Category, int>
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Create(Category category)
        {
            return _categoryRepository.Create(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public Category Retrieve(int id)
        {
            return _categoryRepository.Retrieve(id);
        }

        public Category RetrieveBy(int id)
        {
            return _categoryRepository.RetrieveBy(id);
        }
		public List<Category> RetrieveAll()
    {
        return _categoryRepository.RetrieveAll();
        }
		public List<Category> RetrieveAllSearch(string search)
        {
            return _categoryRepository.RetrieveAllSearch(search);
        }


		public Category Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
       
    }
}
