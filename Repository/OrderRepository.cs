using Entities;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        MySuperMarketContext _mySuperMarketContext;


        public OrderRepository(MySuperMarketContext mySuperMarketContext)
        {

            _mySuperMarketContext = mySuperMarketContext;
        }//
        public async Task<Order> creatOrderAsync(Order newOrder)
        {
            await _mySuperMarketContext.Orders.AddAsync(newOrder);
            await _mySuperMarketContext.SaveChangesAsync();
            return newOrder;
            
        }
        public async Task<Order> getOrderByIdAsync(int id)
        {
            return await _mySuperMarketContext.Orders.FindAsync(id);
        }
    }
}

