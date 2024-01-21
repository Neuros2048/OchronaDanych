using Bankowosc.Server.Entities;
using Bankowosc.Server.Services;
using Bankowosc.Shared.Dto;
using Bankowosc.Shared.Message;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bankowosc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpGet("Secret"), Authorize]
        public string SecretText()
        {
            return "secret";
        }
        [HttpGet("Test")]
        public async Task<ActionResult<ServiceResponse<string>>> Test()
        {
            var response = await _authService.Login2();
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDTO userLoginDTO)
        {
            var response = await _authService.Login(userLoginDTO.Login, userLoginDTO.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("register"), Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<ServiceResponse<RegisterRespondDto>>> Register(UserRegisterDTO userRegisterDTO)
        {
            
            if (userRegisterDTO.ConfirmPassword != userRegisterDTO.Password)
            {
                return BadRequest(new ServiceResponse<RegisterRespondDto>
                {
                    Success = false,
                    Message = "Passwords are not the same"
                });
            }
           

            var response = await _authService.Register(userRegisterDTO);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpPost("change-password"), Authorize(Roles = "USER")]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword(ChangePasswordDto changePasswordDto)
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangePassword(changePasswordDto, int.Parse(userId));
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        
    }
}
