using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;

namespace GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces
{
    public interface ITrainerRepostory
    {
        Task<PagedList<GetTrainerDtO>> GetTrainersAsync(UserParams userParams);

        Task<GetTrainerDtO> GetTrainerAsync(string username);
    }
}
