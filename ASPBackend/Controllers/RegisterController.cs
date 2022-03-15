using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using Microsoft.AspNetCore.Authorization;
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

        public RegisterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User User)
        {
            try
            {
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
