using AutoMapper;
using GYMmanagement.Interfaces;
using GYMmanagement.Interfaces.RepstroyInterfaces;
using GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces;
using GYMmanagement.Repostories;
using GYMmanagement.Repostories.UserRepostoies;

namespace GYMmanagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepostory UserRepostory => new UserRepository(_context);
        public IMemberRepostory MemberRepostory  => new MemberRepostory(_context, _mapper);
        public IEmployeeRepostory EmployeeRepostory => new EmployeeRepostory(_context, _mapper);
        public ITrainerRepostory TrainerRepostory => new TrainerRepostory(_context, _mapper);
        public IClassRepostory ClassRepostory => new ClassRepostory(_context, _mapper);
        public IPaymentRepostory PaymentRepostory => new PaymentRepostory(_context,_mapper);
        public IScheduleRepostory ScheduleRepostory => new ScheduleRepostory(_context, _mapper);
        public IFeedbackRepostory FeedbackRepostory => new FeedbackRepostory(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
