using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;

namespace GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces
{
    public interface IMemberRepostory
    {
        Task<PagedList<GetMemberDtO>> GetMembersAsync(UserParams userParams);
        Task<GetMemberDtO> GetMemberAsync(string username);

    }
}
