using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

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

        // GET: api/<CategoiesController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
                IEnumerable<Category>Categories = await _categoryService.GetAllCategoryAsync();
                IEnumerable<CategoryDto>CategoriesDto = _mapper.Map <IEnumerable<Category>,IEnumerable<CategoryDto>> (Categories);
                return CategoriesDto;
        }
    }
}
