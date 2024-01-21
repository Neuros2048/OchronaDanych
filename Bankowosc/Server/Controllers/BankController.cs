using System.Security.Claims;
using Bankowosc.Server.Services;
using Bankowosc.Shared.Dto;
using Bankowosc.Shared.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bankowosc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BankController : Controller
    {
        private BankService _bankService;

        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }
        
        [HttpPost("transaction"), Authorize(Roles = "USER")]
        public async Task<ActionResult<ServiceResponse<bool>>> makeTransaction(MakeTransactionDto transactionDto )
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _bankService.MakeTransaction(transactionDto, long.Parse(userId));
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        
        [HttpGet("history"), Authorize(Roles = "USER")]
        public async Task<ActionResult<ServiceResponse<List<PrzelewDto>>>> GetHistory()
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _bankService.UserTransaction( long.Parse(userId));
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        
        [HttpGet("AccountInfo"), Authorize(Roles = "USER")]
        public async Task<ActionResult<ServiceResponse<DaneKontaDto>>> GetAccountInfo()
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _bankService.UserAccountInfo( long.Parse(userId));
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("CreditCardInfo"), Authorize(Roles = "USER")]
        public async Task<ActionResult<ServiceResponse<KartaKredytowaDto>>> CreditCardInfo()
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _bankService.CreditCardInfo( long.Parse(userId));
            if (!response.Success)
            {
                return   Ok(response);
            }
            return Ok(response);
        }
        [HttpGet("UserInfo"), Authorize(Roles = "USER")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> UserInfo()
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _bankService.UserInfo( long.Parse(userId));
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
