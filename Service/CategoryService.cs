using Entities;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            List<Category> categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories != null ? categories : null;
        }
    }
}
