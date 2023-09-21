using GYMmanagement.Entities;

namespace GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces
{
    public interface IUserRepostory
    {
        void Update(User user);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByNameAsync(string username);

    }
}
