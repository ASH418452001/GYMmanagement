using AutoMapper;
using GYMmanagement.Data;
using GYMmanagement.DtOs.MemberShipDtO;
using GYMmanagement.Entities;

using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MembershipController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost("Insert-MemberShipTypes")]
        public async Task<ActionResult<Membership>> CreateMemberShipType([FromQuery] Create_UpdateMemberShipDtO create_Update)
        {
            var memberShipType = new Membership
            {
                MemberShipType = create_Update.MemberShipType,
                Description = create_Update.Description,
                Price = create_Update.Price,
                Duration = create_Update.Duration,
                Benefits = create_Update.Benefits

            };
            _context.Membership.Add(memberShipType);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<Membership>(memberShipType));
        }





    }
}
