

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

        public async Task<User> getUserByUserNameAndPassword(string UserName, string Password)
        {
            User newUser = await _userRepository.getUserByUserNameAndPassword(UserName, Password);
            if (newUser != null) return newUser;
            else return null;
        }
        public User createNewUser(User user)
        {
            User newUser = _userRepository.createNewUser(user);
            if (newUser != null) return newUser;
            else return null;
        }

        public async Task update(int id, User userToUpdate)
        {
            await _userRepository.update(id, userToUpdate);
        }




        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

    }
}