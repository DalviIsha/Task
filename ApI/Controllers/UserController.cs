using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMS.Domain.Interface;

namespace TestMS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepo _IUserRepo;
        public UserController( IUserRepo iUserRepo)
        {
            _IUserRepo = iUserRepo;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route ("user")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDetails)
        {
           var result = _IUserRepo.CreateUser(userDetails);
            return Ok(result);
        }

        [HttpPut]
        [Route ("user")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDetails)
        {
           var result = _IUserRepo.CreateUser(userDetails);
            return Ok(result);
        }
        
        
    }
}