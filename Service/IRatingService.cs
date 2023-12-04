using Entities;

namespace Services
{
    public interface IRatingService
    {
        Task creatRating(Rating rating);
    }
}