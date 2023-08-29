using GYMmanagement.Entities;

namespace GYMmanagement.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
