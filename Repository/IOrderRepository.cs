using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> creatOrder(Order order);
        Task<Order> getOrderById(int id);
    }
}