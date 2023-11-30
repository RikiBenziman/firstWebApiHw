using Entities;
using Microsoft.Extensions.Logging;
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
        IProductRepository _productRepository;
        ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository,IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;

        }
        public async Task<Order> creatOrder(Order order)
        {
            int[] productsId =new int[order.OrderItems.Count];
            for(int i=0;i< order.OrderItems.Count; i++)
            {
                productsId[i] = order.OrderItems.ElementAt(i).ProductId;
            }
            var product = await _productRepository.getProductById(productsId);
            double? orderSum = 0;
            for(int i = 0; i < product.Count; i++)
            {
               orderSum += product.ElementAt(i).ProductPrice * order.OrderItems.ElementAt(i).Quantity;
            }
            if (orderSum != (double)order.OrderSum)
            {
             _logger.LogWarning("the user do somthing not valid the user tryed still");
             return null;
            }

            Order newOrder = await _orderRepository.creatOrder(order);
            return newOrder != null ? newOrder : null;
        }
    }
}
