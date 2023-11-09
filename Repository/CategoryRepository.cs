using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        MySuperMarketContext _MySuperMarketContext;
        public CategoryRepository(MySuperMarketContext _mySuperMarketContext)
        {
            _MySuperMarketContext = _mySuperMarketContext;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _MySuperMarketContext.Categories.ToListAsync();
        }
    }
}
