using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IConfiguration _configuration;
        private IUserRepository _userRepository;

        public RegisterController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> Post([FromBody] User User)
        {
            try
            {
                User.UserRoleId = 1;
                await _userRepository.CreateUserAsync(User);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
    }
