using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductController>

        IProductService _productService;

        public ProductsController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProduct(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            try
            {
                return await _productService.getAllProduct( desc,  minPrice,  maxPrice,  categoryIds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     }
}
