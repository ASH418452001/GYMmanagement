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
    public class MemberRepostory : IMemberRepostory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MemberRepostory(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }


        public async Task<GetMemberDtO> GetMemberAsync(string username)
        {
            return await _context.Users.Where(x => x.UserName == username).
                Where(user => user.UserRoles.Any(role => role.Role.Name == "Member"))
                 .ProjectTo<GetMemberDtO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }





        public async Task<PagedList<GetMemberDtO>> GetMembersAsync(UserParams userParams)
        {
            var query = _context.Users.AsQueryable();
            query = query.Where(u => u.UserName != userParams.CurrentUsername);
            query = query.Where(user => user.UserRoles.Any(role => role.Role.Name == "Member"));


            return await PagedList<GetMemberDtO>.CreateAsync(query.AsNoTracking().ProjectTo<GetMemberDtO>
                (_mapper.ConfigurationProvider), userParams.PageNumber, userParams.PageSize);
        }

    }
}
