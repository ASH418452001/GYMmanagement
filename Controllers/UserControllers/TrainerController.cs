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
    public class TrainerController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public TrainerController(ITokenService tokenService, UserManager<User> userManager,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _mapper = mapper;
            _uow = unitOfWork;
        }





        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPost("RegisterForTrainer")]
        public async Task<ActionResult<UserDtO>> RegisterForTrainer([FromQuery] TrainerDtO trainerDtO)
        {
            if (await UserExist(trainerDtO.UserName)) return BadRequest("this username been taken");

            var user = _mapper.Map<User>(trainerDtO);
            user.UserName = trainerDtO.UserName.ToLower();


            var result = await _userManager.CreateAsync(user, trainerDtO.Password); ;
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Trainer");
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
        [HttpGet("Get-All-Trainers")]
        public async Task<ActionResult<IEnumerable<GetTrainerDtO>>> GetAllTrainers([FromQuery] UserParams userParams)
        {
            var currentUser = await _uow.UserRepostory.GetUserByNameAsync(User.GetUsername());




            var users = await _uow.TrainerRepostory.GetTrainersAsync(userParams);


            Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages));

            return Ok(users);
        }






        //[Authorize(Policy = "RequireEmplyeeRoleOrTrainerRole")]
        [HttpGet("{username}")]
        public async Task<ActionResult<GetTrainerDtO>> GetTrainerByUsername(string username)
        {
            return await _uow.TrainerRepostory.GetTrainerAsync(username);
        }




        //[Authorize(Policy = "RequireEmplyeeRoleOrTrainerRole")]
        [HttpPut]
        public async Task<ActionResult> UpdateUser(UpdateTrainerDtO updateTrainerDtO)
        {
            var user = await _uow.UserRepostory.GetUserByNameAsync(User.GetUsername());

            _mapper.Map(updateTrainerDtO, user);


            _uow.UserRepostory.Update(user);

            if (await _uow.Complete()) return NoContent();

            return BadRequest("Failed to update user");
        }

    }
}
