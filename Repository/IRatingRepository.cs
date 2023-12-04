using Entities;

namespace Repositories
{
    public interface IRatingRepository
    {
        Task creatRating(Rating rating);
    }
}