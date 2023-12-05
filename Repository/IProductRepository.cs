using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> getAllProductAsync( string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<List<Product>> getProductByIdAsync(int[] productIds);
    }
}