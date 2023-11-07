using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        MySuperMarketContext _MySuperMarketContext;
        public ProductRepository(MySuperMarketContext _mySuperMarketContext)
        {
            _MySuperMarketContext = _mySuperMarketContext;
        }

        public async Task<List<Product>> getAllProduct(Product product)
        {
            return await _MySuperMarketContext.Products.ToListAsync();
            //return await _MySuperMarketContext.Users.Where(User => User.UserName == userName ).FirstOrDefaultAsync();
        }
    }
}
