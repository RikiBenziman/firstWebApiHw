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

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;

        }
        public async Task<Order> creatOrderAsync(Order order)
        {
            int[] productsId = new int[order.OrderItems.Count];
            for (int i = 0; i< order.OrderItems.Count; i++)
            {
                productsId[i] = order.OrderItems.ElementAt(i).ProductId;
            }
            List<Product> product = await _productRepository.getProductByIdAsync(productsId);
            double? orderSum = 0;
            for (int i = 0; i < order.OrderItems.Count; i++)
            {
                orderSum += order.OrderItems.ElementAt(i).Quantity * product.Find(p => p.ProductId==order.OrderItems.ElementAt(i).ProductId).ProductPrice;//product.ElementAt(i).ProductPrice;
            }
            if (orderSum != order.OrderSum)
            {
                _logger.LogWarning("the user do somthing not valid the user tryed still");
                return null;
            }

            Order newOrder = await _orderRepository.creatOrderAsync(order);
            return newOrder != null ? newOrder : null;

        }

    
    public async Task<Order> getOrderByIdAsync(int id)
    {
        Order newOrder = await _orderRepository.getOrderByIdAsync(id);
        return newOrder != null ? newOrder : null;
    }
}
}

