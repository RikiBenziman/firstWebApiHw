﻿using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // POST api/<OrdersController>
        
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            try
            {
                Order newOrder = await _userService.createNewUser(order);
                return newOrder != null ? CreatedAtAction(nameof(Get), new { id = order.OrderId }, order) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

 
    }
}
