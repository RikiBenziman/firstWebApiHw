using Entities;

namespace Service
{
    public interface IUserService
    {
        int checkPassword(string password);
        Task<User> createNewUserAsync(User user);
        Task<User> getUserByUserNameAndPasswordAsync(string UserName, string Password);
        Task<User> updateAsync(int id, User userToUpdate);
        Task<User> getUserByIdAsync(int id);
    }
}