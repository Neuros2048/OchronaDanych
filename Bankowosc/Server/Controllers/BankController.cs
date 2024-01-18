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
        
        [HttpPost("transaction"), Authorize]
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
        
        [HttpGet("history"), Authorize]
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
        
        [HttpGet("AccountInfo"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<PrzelewDto>>>> GetAccountInfo()
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _bankService.UserAccountInfo( long.Parse(userId));
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
