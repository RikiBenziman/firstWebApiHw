using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductController>

        IProductService _productService;
        IMapper _mapper;

        public ProductsController(IProductService ProductService, IMapper mapper)
        {
            _productService = ProductService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get(string? desc, int? minPrice, int? maxPrice,[FromQuery] int?[] categoryIds)
        {
                IEnumerable<Product> products = await _productService.getAllProductAsync(desc, minPrice, maxPrice, categoryIds);
                IEnumerable<ProductDto> productsDto = _mapper.Map< IEnumerable<Product>, IEnumerable< ProductDto> >(products);
                return productsDto;
        }
     }
}
