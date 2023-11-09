using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> creatOrder(Order newOrder);
    }
}