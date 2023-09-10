using GYMmanagement.Entities;

namespace GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces
{
    public interface IUserRepostory
    {
        void Update(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string username);

    }
}
