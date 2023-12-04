using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/<CtegoiesController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
                IEnumerable<Category>Categories = await _categoryService.GetAllCategory();
                IEnumerable<CategoryDto>CategoriesDto = _mapper.Map <IEnumerable<Category>,IEnumerable<CategoryDto>> (Categories);
                return CategoriesDto;
        }
    }
}
