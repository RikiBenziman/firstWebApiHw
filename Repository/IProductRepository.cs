using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> getAllProduct( string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<List<Product>> getProductById(int[] productIds);
    }
}