using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;


namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // POST api/<OrdersController>
        IOrderService _orderService;
        IMapper _mapper;
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpPost]  //=======creatOrder;
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto orderDto)
        {
            try
            {
                Order Order = _mapper.Map< OrderDto,Order>(orderDto);
                Order newOrder = await _orderService.creatOrder(Order);
                return newOrder != null ? CreatedAtAction(nameof(Get), new { id = orderDto.UserId }, orderDto) : NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        private string Get(int id)
        {
            return " ";
        }
    }
}
