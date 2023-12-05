using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        MySuperMarketContext _MySuperMarketContext;
        public ProductRepository(MySuperMarketContext _mySuperMarketContext)
        {
            _MySuperMarketContext = _mySuperMarketContext;
        }

        public async Task<List<Product>> getAllProductAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _MySuperMarketContext.Products.Where(product =>
            (desc == null ? (true) : (product.ProductDescription.Contains(desc)))
            && (minPrice == null ? (true) : (product.ProductPrice >= minPrice))
            && (maxPrice == null ? (true) : (product.ProductPrice <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
            .Include(i => i.Category)
            .OrderBy(product => product.ProductPrice);
            
            List<Product> products = await query.ToListAsync();
           
            return products;
        }

        public async Task<List<Product>> getProductByIdAsync( int[] productIds)
        {
            var query = _MySuperMarketContext.Products.Where(p => productIds.Contains(p.ProductId));
            List<Product> products = await query.ToListAsync();
            return products;

        }
    }
}
