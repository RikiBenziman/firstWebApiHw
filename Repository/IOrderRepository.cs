using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> creatOrderAsync(Order order);
        Task<Order> getOrderByIdAsync(int id);
    }
}