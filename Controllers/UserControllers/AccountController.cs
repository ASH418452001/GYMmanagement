using GYMmanagement.DtOs.UsersDtO;
using GYMmanagement.Entities;
using GYMmanagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GYMmanagement.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;



        public AccountController(ITokenService tokenService, UserManager<User> userManager)

        {
            _tokenService = tokenService;
            _userManager = userManager;


        }



        [HttpPost("Login")]
        public async Task<ActionResult<UserDtO>> Login([FromBody] LoginDtO loginDtO)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDtO.Username);

            if (user == null) return Unauthorized("invalid username");

            var result = await _userManager.CheckPasswordAsync(user, loginDtO.Password);

            if (!result) return Unauthorized("invalid Password");

            return new UserDtO
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),

            };
        }





    }
}






