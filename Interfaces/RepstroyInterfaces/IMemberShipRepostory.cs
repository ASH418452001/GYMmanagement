using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.DtOs.MemberShipDtO;
using GYMmanagement.Entities;
using GYMmanagement.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Interfaces.RepstroyInterfaces
{
    public interface IMemberShipRepostory
    {
        Task<Membership> GetMembershipByIdAsync(Guid id);
        void DeleteMembership(Membership membership);
        Task<bool> MembershipExist(string memberShipType);
        Task<ActionResult<List<Membership>>> GetMembershipAsync();
        void CreateMembership(Membership membership);
        Task Update(Create_UpdateMemberShipDtO updateMemberShipDtO, Guid Id);
    }
}