using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Services;
using DTO;
using System.Collections.Generic;
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
        public async Task<IEnumerable<ProductDto>> GetAllProduct(string? desc, int? minPrice, int? maxPrice,[FromQuery] int?[] categoryIds)
        {
            try
            {
                IEnumerable<Product> products = await _productService.getAllProduct(desc, minPrice, maxPrice, categoryIds);
                IEnumerable<ProductDto> productsDto = _mapper.Map< IEnumerable<Product>, IEnumerable< ProductDto> >(products);
                return productsDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     }
}
