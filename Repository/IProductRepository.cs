using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> getAllProduct();
    }
}