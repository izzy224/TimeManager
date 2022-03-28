using ASPBackend.Controllers.Utility;
using ASPBackend.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ToDoController : ControllerBase
    {
        private IToDoRepository _toDoRepository;
        private IManagementEntityRepository _managementEntityRepository;
        private IJwtService _jwtService;

        public ToDoController(IToDoRepository toDoRepository, IManagementEntityRepository managementEntityRepository, IJwtService jwtService)
        {
            _toDoRepository = toDoRepository;            
            _managementEntityRepository = managementEntityRepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetToDosByDate([FromBody]DateTime date)
        {
            var user = await _jwtService.GetUser(Request.Cookies["jwt"]);
            var manEnt = await _managementEntityRepository.GetManagementEntityByDate(date, user.UserId);
            var todos = await _toDoRepository.GetAllByManagementEntity(manEnt.ManagementEntityId);
            if (todos != null)
                return Ok(todos);
            
            return NotFound();
        }

    }
}
