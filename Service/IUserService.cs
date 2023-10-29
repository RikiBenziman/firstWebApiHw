using Entities;

namespace Service
{
    public interface IUserService
    {
        int checkPassword(string password);
        User createNewUser(User user);
        User getUserByUserNameAndPassword(string UserName, string Password);
        void update(int id, User userToUpdate);
    }
}