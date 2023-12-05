using Entities;

namespace Repositories
{
    public interface IRatingRepository
    {
        Task creatRatingAsync(Rating rating);
    }
}