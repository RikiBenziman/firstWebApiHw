using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        MySuperMarketContext _mySuperMarketContext;

        public OrderRepository(MySuperMarketContext mySuperMarketContext)
        {
            _mySuperMarketContext = mySuperMarketContext;
        }
        public async Task<Order> creatOrder(Order newOrder)
        {
            await _mySuperMarketContext.Orders.AddAsync(newOrder);
            await _mySuperMarketContext.SaveChangesAsync();
            return newOrder;
        }
    }
}
