using AutoMapper;
using GYMmanagement.DtOs.UsersDtO.Create;
using GYMmanagement.DtOs.UsersDtO;
using GYMmanagement.Entities;
using GYMmanagement.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Extension;
using GYMmanagement.Helpers;
using GYMmanagement.DtOs.UsersDtO.Update;
using GYMmanagement.Filters;

namespace GYMmanagement.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public MemberController(ITokenService tokenService, UserManager<User> userManager,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _mapper = mapper;
            _uow = unitOfWork;
        }


        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPost("RegisterForMember")]
        public async Task<ActionResult<UserDtO>> RegisterForMember([FromQuery] MemberDtO memberDtO)
        {
            if (await UserExist(memberDtO.UserName)) return BadRequest("this username been taken");

            var user = _mapper.Map<User>(memberDtO);
            user.UserName = memberDtO.UserName.ToLower();


            var result = await _userManager.CreateAsync(user, memberDtO.Password); ;
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return new UserDtO
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),

            };

        }



        private async Task<bool> UserExist(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }


        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpGet("Get-All-Members")]
        public async Task<ActionResult<IEnumerable<GetMemberDtO>>> GetAllMembers([FromQuery] UserParams userParams)
        {
            var currentUser = await _uow.UserRepostory.GetUserByNameAsync(User.GetUsername());




            var users = await _uow.MemberRepostory.GetMembersAsync(userParams);

            Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages));

            return Ok(users);
        }




        //[Authorize(Policy = "RequireEmplyeeRoleOrMemberRole")]
        [HttpGet("{username}")]
        public async Task<ActionResult<GetMemberDtO>> GetMemberByUsername(string username)
        {
            return await _uow.MemberRepostory.GetMemberAsync(username);
        }





        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPut("Just-For-Employee")]
        public async Task<ActionResult> UpdateMemberByEmployee(UpdateMemberByEmployeeDtO updateMemberByEmployee)
            
        {
            var user = await _uow.UserRepostory.GetUserByNameAsync(User.GetUsername());

            _mapper.Map(updateMemberByEmployee, user);


            _uow.UserRepostory.Update(user);

            if (await _uow.Complete()) return NoContent();

            return BadRequest("Failed to update user");
        }



        //[Authorize(Policy = "RequireMemberRole")]
        [HttpPut("Just-For-Member")]//this endpoint just for members to update from userinfomation their personal info.
        public async Task<ActionResult> UpdateMemberByMember(UpdateMemberDtO updateMemberDtO)

        {
            var user = await _uow.UserRepostory.GetUserByNameAsync(User.GetUsername());

            _mapper.Map(updateMemberDtO, user);


            _uow.UserRepostory.Update(user);

            if (await _uow.Complete()) return NoContent();

            return BadRequest("Failed to update user");
        }

    }
}
