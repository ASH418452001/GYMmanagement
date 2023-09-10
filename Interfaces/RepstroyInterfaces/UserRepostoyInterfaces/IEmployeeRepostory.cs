using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;

namespace GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces
{
    public interface IEmployeeRepostory
    {
        Task<GetEmployeeDtO> GetEmployeeAsync(string username);
        Task<PagedList<GetEmployeeDtO>> GetEmployeesAsync(UserParams userParams);
    }
}
