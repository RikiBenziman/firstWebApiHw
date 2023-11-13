using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }
        public async Task<List<Product>> getAllProduct(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            List<Product> products= await _ProductRepository.getAllProduct( desc, minPrice, maxPrice, categoryIds);
            return products != null ? products : null;
        }

    }
}
