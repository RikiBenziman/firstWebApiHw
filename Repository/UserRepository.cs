using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace Repository
{
    public class UserRepository : IUserRepository
    {
        MySuperMarketContext _MySuperMarketContext;
        public UserRepository(MySuperMarketContext _mySuperMarketContext)
        {
            _MySuperMarketContext = _mySuperMarketContext;
        }

        string url = "../myUsers.txt";
        public async Task<User> getUserByUserNameAndPassword(string userName, string password)
        {
            return await _MySuperMarketContext.Users.Where(User => User.UserName == userName && User.Password == password).FirstOrDefaultAsync();
        }

        public async Task<User> createNewUser(User user)
        {
            await _MySuperMarketContext.Users.AddAsync(user);
            _MySuperMarketContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> update(int id, User userToUpdate)
        {
            userToUpdate.UserId=id;
            _MySuperMarketContext.Users.Update(userToUpdate);
            _MySuperMarketContext.SaveChangesAsync();
            return userToUpdate;
        }
       public async Task<User> getUserById(int id)
        {
            return await _MySuperMarketContext.Users.Where(User => User.UserId == id).FirstOrDefaultAsync();
        }
    }
}