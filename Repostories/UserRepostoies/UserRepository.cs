using GYMmanagement.Data;
using GYMmanagement.Entities;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GYMmanagement.Repostories.UserRepostoies
{
    public class UserRepository : IUserRepostory
    {
        private readonly DataContext _context;


        public UserRepository(DataContext context)
        {
            _context = context;

        }


        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }


        public async Task<User> GetUserByNameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }



        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }


    }
}
