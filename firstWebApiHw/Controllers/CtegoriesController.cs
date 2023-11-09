using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CtegoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CtegoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CtegoiesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            try
            {
                return await _categoryService.GetAllCategory();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
