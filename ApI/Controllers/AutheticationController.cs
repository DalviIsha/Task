using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMS.Domain.Interface;

namespace TestMS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AutheticationController : ControllerBase
    {
        private IAuthentication _Authentication;
        public AutheticationController(IAuthentication Authentication)
        {
            Authentication = _Authentication;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route ("authentication")]
        public async Task<IActionResult> AuthenticationToken([FromBody] RefUser userDetails)
        {
           var token = _Authentication.GetAuthenticationToken(userDetails.UserName, userDetails.Password);
           if(token is null)
           {
            return NotFound();
           }
            return Ok(token);
        }
    }
}