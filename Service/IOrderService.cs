using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> creatOrderAsync(Order newOrder);
        Task<Order> getOrderByIdAsync(int id);
    }
}