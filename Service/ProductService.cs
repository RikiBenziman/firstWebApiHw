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
        public async Task<Product> getAllProduct(Product product)
        {

            Product products = await _ProductRepository.getAllProduct(product);
            if (products != null) return products;
                    return null;
           
        }

    }
}
