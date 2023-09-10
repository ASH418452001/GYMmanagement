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
    public class EmployeeController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public EmployeeController(ITokenService tokenService, UserManager<User> userManager,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _mapper = mapper;
            _uow = unitOfWork;
        }



        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPost("RegisterForEmployee")]
        public async Task<ActionResult<UserDtO>> Register([FromQuery] EmployeeDtO employeeDtO)
        {
            if (await UserExist(employeeDtO.UserName)) return BadRequest("this username been taken");

            var user = _mapper.Map<User>(employeeDtO);
            user.UserName = employeeDtO.UserName.ToLower();


            var result = await _userManager.CreateAsync(user, employeeDtO.Password); ;
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Employee");
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
        [HttpGet("Get-All-Employees")]
        public async Task<ActionResult<IEnumerable<GetEmployeeDtO>>> GetAllEmployees([FromQuery] UserParams userParams)
        {
            var currentUser = await _uow.UserRepostory.GetUserByNameAsync(User.GetUsername());




            var users = await _uow.EmployeeRepostory.GetEmployeesAsync(userParams);
            //var employees = users.Where(u => !string.IsNullOrEmpty(u.Position)).ToList();
            Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages));

            return Ok(users);
        }






        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpGet("{username}")]
        public async Task<ActionResult<GetEmployeeDtO>> GetEmployeeByUsername(string username)
        {
            return await _uow.EmployeeRepostory.GetEmployeeAsync(username);
        }




        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPut]
        public async Task<ActionResult> UpdateUser(UpdateEmployeeDtO updateEmployeeDtO)
        {
            var user = await _uow.UserRepostory.GetUserByNameAsync(User.GetUsername());

            _mapper.Map(updateEmployeeDtO, user);


            _uow.UserRepostory.Update(user);

            if (await _uow.Complete()) return NoContent();

            return BadRequest("Failed to update user");
        }


    }
}
