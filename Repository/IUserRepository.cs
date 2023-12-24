using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
       Task<User> createNewUserAsync(User user);
        Task<User> getUserByUserNameAndPasswordAsync(string UserName, string Password);
        Task<User> updateAsync(int id, User userToUpdate);
        Task<User> getUserByIdAsync(int id);
    }
}