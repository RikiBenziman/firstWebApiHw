

using Entities;
using Repository;

 namespace Service
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User getUserByUserNameAndPassword(string UserName, string Password)
        {
            User newUser = _userRepository.getUserByUserNameAndPassword(UserName, Password);
            if (newUser != null) return newUser;
            else return null;
        }
        public User createNewUser(User user)
        {
            User newUser = _userRepository.createNewUser(user);
            if (newUser != null) return newUser;
            else return null;
        }

        public void update(int id, User userToUpdate)
        {
            _userRepository.update(id, userToUpdate);
        }




        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

    }
}