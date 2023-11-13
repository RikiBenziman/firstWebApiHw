using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> getAllProduct(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}