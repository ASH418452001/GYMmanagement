using AutoMapper;
using GYMmanagement.DtOs.MemberShipDtO;
using GYMmanagement.Entities;
using GYMmanagement.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GYMmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MembershipController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost("Insert-MemberShipTypes")]
        public async Task<ActionResult<Membership>> CreateMemberShipType([FromQuery] Create_UpdateMemberShipDtO createMembership)
        {
            if (await _uow.MemberShipRepostory.MembershipExist(createMembership.MemberShipType)) 
            return BadRequest("this MemberShipType is Exist Already");


            var memberShipType = _mapper.Map<Membership>(createMembership);

            _uow.MemberShipRepostory.CreateMembership(memberShipType);
            return Ok();



        }

        [HttpGet]
        public async Task<ActionResult<List<Membership>>> GetMemberShipsAsync()
        {
            return await _uow.MemberShipRepostory.GetMembershipAsync();
        }

        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPut]
        public async Task<ActionResult> UpdateMembership(Create_UpdateMemberShipDtO updateMemberShipDtO, Guid Id)
        {
            await _uow.MemberShipRepostory.Update(updateMemberShipDtO, Id);

            if (await _uow.Complete())
                return Ok();
            return BadRequest("Failed to update MemberShip");


        }


        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMemberShip(Guid id)
        {


            var membership = await _uow.MemberShipRepostory.GetMembershipByIdAsync(id);

            _uow.MemberShipRepostory.DeleteMembership(membership);



            if (await _uow.Complete()) return Ok("Been Deleted");

            return BadRequest("Problem deleting this MemberShip");
        }



    }
}
