using AutoMapper;
using AutoMapper.QueryableExtensions;
using GYMmanagement.Data;
using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GYMmanagement.Repostories.UserRepostoies
{
    public class EmployeeRepostory : IEmployeeRepostory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepostory(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<GetEmployeeDtO> GetEmployeeAsync(string username)
        {
            return await _context.Users.Where(x => x.UserName == username).
                Where(user => user.UserRoles.Any(role => role.Role.Name == "Employee"))
                  .ProjectTo<GetEmployeeDtO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }




        public async Task<PagedList<GetEmployeeDtO>> GetEmployeesAsync(UserParams userParams)
        {
            var query = _context.Users.AsQueryable();
            query = query.Where(u => u.UserName != userParams.CurrentUsername);
            query = query.Where(user => user.UserRoles.Any(role => role.Role.Name == "Employee"));


            return await PagedList<GetEmployeeDtO>.CreateAsync(query.AsNoTracking().ProjectTo<GetEmployeeDtO>
                (_mapper.ConfigurationProvider), userParams.PageNumber, userParams.PageSize);
        }







    }
}
