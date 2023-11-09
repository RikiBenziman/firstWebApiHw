using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> creatOrder(Order order);
    }
}