using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User createNewUser(User user);
        User getUserByUserNameAndPassword(string UserName, string Password);
        void update(int id, User userToUpdate);
    }
}