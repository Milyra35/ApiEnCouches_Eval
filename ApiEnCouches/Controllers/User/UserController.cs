using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiEnCouches.Controllers.User
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var name = User.FindFirstValue(ClaimTypes.Name);
            return Ok(new { Email = email, Name = name });
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login()
        //{

        //}


        //[HttpPost("register")]
        //public async Task<IActionResult> Register()
        //{

        //}
    }
}
