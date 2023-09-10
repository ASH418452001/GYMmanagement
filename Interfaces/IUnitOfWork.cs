using GYMmanagement.Interfaces.RepstroyInterfaces;
using GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces;

namespace GYMmanagement.Interfaces
{
    public interface IUnitOfWork
    {   
        IUserRepostory UserRepostory { get; }
        IMemberRepostory MemberRepostory { get; }
        ITrainerRepostory TrainerRepostory { get; }
        IEmployeeRepostory EmployeeRepostory { get; }
        IClassRepostory ClassRepostory { get; }
        IPaymentRepostory PaymentRepostory {get;}
        IScheduleRepostory ScheduleRepostory { get; }
        IFeedbackRepostory FeedbackRepostory { get; }

        Task<bool> Complete();
        bool HasChanges();
    }
}
