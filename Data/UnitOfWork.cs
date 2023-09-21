using AutoMapper;
using GYMmanagement.Entities;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces;
using GYMmanagement.Interfaces.RepstroyInterfaces;
using GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces;
using GYMmanagement.Repostories;
using GYMmanagement.Repostories.UserRepostoies;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GYMmanagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
   

        public UnitOfWork(DataContext context , IMapper mapper, IHttpContextAccessor httpContextAccessor  )
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            
        }

        public IUserRepostory UserRepostory => new UserRepository(_context);
        public IMemberRepostory MemberRepostory  => new MemberRepostory(_context, _mapper);
        public IEmployeeRepostory EmployeeRepostory => new EmployeeRepostory(_context, _mapper);
        public ITrainerRepostory TrainerRepostory => new TrainerRepostory(_context, _mapper);
        public IClassRepostory ClassRepostory => new ClassRepostory(_context, _mapper, _httpContextAccessor);
        public IPaymentRepostory PaymentRepostory => new PaymentRepostory(_context,_mapper);
        public IScheduleRepostory ScheduleRepostory => new ScheduleRepostory(_context, _mapper);
        public IFeedbackRepostory FeedbackRepostory => new FeedbackRepostory(_context, _mapper);
        public IAttendanceRepostory AttendanceRepostory => new AttendanceRepostory(_context, _mapper);
        public IMemberShipRepostory MemberShipRepostory => new MembershipRepostory(_context, _mapper);

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
