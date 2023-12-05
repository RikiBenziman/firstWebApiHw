using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        MySuperMarketContext _MySuperMarketContext;
        public CategoryRepository(MySuperMarketContext _mySuperMarketContext)
        {
            _MySuperMarketContext = _mySuperMarketContext;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _MySuperMarketContext.Categories.ToListAsync();
        }
    }
}
