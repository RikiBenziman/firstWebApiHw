
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
        public async Task creatRatingAsync(Rating rating)
        {
            await _ratingRepository.creatRatingAsync(rating);
        }
    }
}
