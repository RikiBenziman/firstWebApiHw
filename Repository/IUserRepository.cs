using Entities;

namespace Repository
{
    public interface IUserRepository
    {
       Task<User> createNewUser(User user);
        Task<User> getUserByUserNameAndPassword(string UserName, string Password);
        Task<User> update(int id, User userToUpdate);
        Task<User> getUserById(int id);
    }
}