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
        public async Task<List<Product>> getAllProductAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            List<Product> products= await _ProductRepository.getAllProductAsync( desc, minPrice, maxPrice, categoryIds);
            return products != null ? products : null;
        }

    }
}
