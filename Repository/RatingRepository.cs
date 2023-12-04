using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        MySuperMarketContext _MySuperMarketContext;

        public RatingRepository(MySuperMarketContext mySuperMarketContext)
        {
            _MySuperMarketContext = mySuperMarketContext;
        }

        public async Task creatRating(Rating rating)
        {
            await _MySuperMarketContext.Ratings.AddAsync(rating);
            _MySuperMarketContext.SaveChangesAsync();
        }
    }
}
