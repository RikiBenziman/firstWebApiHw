using Entities;

namespace Service
{
    public interface IUserService
    {
        int checkPassword(string password);
        Task<User> createNewUser(User user);
        Task<User> getUserByUserNameAndPassword(string UserName, string Password);
        Task<User> update(int id, User userToUpdate);
        Task<User> getUserById(int id);
    }
}