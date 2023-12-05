using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> getAllProductAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}