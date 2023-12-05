

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

        public async Task<User> getUserByUserNameAndPasswordAsync(string UserName, string Password)
        {
            User newUser = await _userRepository.getUserByUserNameAndPasswordAsync(UserName, Password);
            return newUser != null?  newUser:null;
        }
        public async Task<User> createNewUserAsync(User user)
        {
            if (checkPassword(user.Password) < 2)
                return null;
            User newUser = await _userRepository.createNewUserAsync(user);
            return newUser != null ? newUser : null;
        }

        public async Task<User> updateAsync(int id, User userToUpdate)
        {
            if (checkPassword(userToUpdate.Password) < 2)
                return null;
            await _userRepository.updateAsync(id, userToUpdate);
            return userToUpdate;
        }

        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
        public async Task<User> getUserByIdAsync(int id)
        {
            User newUser = await _userRepository.getUserByIdAsync(id);
            return newUser != null ? newUser : null;
        }
    }
}