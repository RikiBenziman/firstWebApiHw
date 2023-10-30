using Entities;
using System.Text.Json;


namespace Repository
{
    public class UserRepository : IUserRepository
    {
        string url = "../myUsers.txt";
        public async Task<User> getUserByUserNameAndPassword(string UserName, string Password)
        {
            using (StreamReader reader = System.IO.File.OpenText(url))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user =  JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == UserName && user.Password == Password)
                        return user;
                }

            }
            return null;
        }

        public User createNewUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(url).Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(url, userJson + Environment.NewLine);
            return user;

        }

        public async Task update(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(url))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(url);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(url, text);
            }
        }
    }
}