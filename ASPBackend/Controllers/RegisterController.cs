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
        //private IConfiguration _configuration;

        //public RegisterController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login([FromBody] User userLogin)
        //{
        //    var user = Authenticate(userLogin);

        //    if (user != null)
        //    {
        //        var token = Generate(user);
        //        return Ok(token);
        //    }

        //    return NotFound("User not found");
        //}
    }
}
