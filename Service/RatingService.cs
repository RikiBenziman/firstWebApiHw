using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;

namespace Services
{
    public class RatingService : IRatingService
    {
        IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public async Task creatRating(Rating rating)
        {
            await _ratingRepository.creatRating(rating);
        }
    }
}
