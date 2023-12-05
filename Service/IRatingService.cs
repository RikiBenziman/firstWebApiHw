using Entities;

namespace Services
{
    public interface IRatingService
    {
        Task creatRatingAsync(Rating rating);
    }
}