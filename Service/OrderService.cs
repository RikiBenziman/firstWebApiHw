using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> creatOrder(Order order)
        {
            Order newOrder = await _orderRepository.creatOrder(order);
            return newOrder != null ? newOrder : null;
        }
    }
}
