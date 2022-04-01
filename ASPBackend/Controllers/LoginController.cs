using ASPBackend.Controllers.Utility;
using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using ASPBackend.Models.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ASPBackend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private IUserRepository _userRepository;
        private IJwtService _jwtService;

        public LoginController(IConfiguration configuration, IUserRepository userRepository, IJwtService jwtService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = await _userRepository.ValidateUser(userLogin);

            if (user != null)
            {
                var token = _jwtService.Generate(user);
                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                });
                return Ok(new {message="success", jwtToken=token,});
            }

            return NotFound("User not found");
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.ValidateToken(jwt);

                int userId = Int32.Parse(token.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                var user = await _userRepository.GetById(userId);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return await Task.Run(() =>
            {
                Response.Cookies.Delete("jwt");
                return Ok();
            });
        }

    }
}
