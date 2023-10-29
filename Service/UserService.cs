

using Entities;
using Repository;

 namespace Service
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public User getUserByUserNameAndPassword(string UserName, string Password)
        {
            User newUser = userRepository.getUserByUserNameAndPassword(UserName, Password);
            if (newUser != null) return newUser;
            else return null;
        }
        public User createNewUser(User user)
        {
            User newUser = userRepository.createNewUser(user);
            if (newUser != null) return newUser;
            else return null;
        }

        public void update(int id, User userToUpdate)
        {
           userRepository.update(id, userToUpdate); 
        }




        public int checkPassword( string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
                return result.Score;
        }

    }
}