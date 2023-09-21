using AutoMapper;
using GYMmanagement.Data;
using GYMmanagement.DtOs.MemberShipDtO;
using GYMmanagement.Entities;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces.RepstroyInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GYMmanagement.Repostories
{
    public class MembershipRepostory : IMemberShipRepostory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MembershipRepostory(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateMembership(Membership membership)
        {
            _context.Add(membership);
            _context.SaveChanges();
        }

        public void DeleteMembership(Membership membership)
        {
            _context.Remove(membership);
        }



        public async Task<ActionResult<List<Membership>>> GetMembershipAsync()
        {
            
           return await _context.Membership.ToListAsync();

        }

        public async Task<Membership> GetMembershipByIdAsync(Guid id)
        {
            var memberShipType =await _context.Membership.FindAsync(id);
            if (memberShipType == null) throw new Exception ("Not Found");
            return memberShipType;
        }

        public async Task<bool> MembershipExist(string memberShipType)
        {
            return await _context.Membership.AnyAsync(x => x.MemberShipType.ToLower() == memberShipType.ToLower());
        }

        public async Task Update(Create_UpdateMemberShipDtO updateMemberShipDtO, Guid Id)
        {
            var membership = await GetMembershipByIdAsync(Id);
            _mapper.Map(updateMemberShipDtO, membership);
            _context.Entry(membership).State = EntityState.Modified;



        }
    }
}
