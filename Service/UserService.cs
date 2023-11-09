

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
            return newUser != null?  newUser:null;
        }
        public async Task<User> createNewUser(User user)
        {
            if (checkPassword(user.Password) < 2)
                return null;
            User newUser = await _userRepository.createNewUser(user);
            return newUser != null ? newUser : null;
        }

        public async Task<User> update(int id, User userToUpdate)
        {
            if (checkPassword(userToUpdate.Password) < 2)
                return null;
            await _userRepository.update(id, userToUpdate);
            return userToUpdate;
        }

        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
        public async Task<User> getUserById(int id)
        {
            User newUser = await _userRepository.getUserById(id);
            return newUser != null ? newUser : null;
        }
    }
}