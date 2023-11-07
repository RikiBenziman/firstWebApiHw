using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> getAllProduct(Product product);
    }
}