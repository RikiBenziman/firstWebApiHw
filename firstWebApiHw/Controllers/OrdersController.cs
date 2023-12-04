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
                OrderDto newOrderDto = _mapper.Map<Order, OrderDto>(newOrder);
                return newOrder != null ? CreatedAtAction(nameof(Get), new {id=newOrderDto.OrderId},newOrderDto) : NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            try
            {
                Order order = await _orderService.getOrderById(id);
                OrderDto orderDto = _mapper.Map<Order, OrderDto>(order);
                return order != null ? Ok(orderDto) : BadRequest("user didnt found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
