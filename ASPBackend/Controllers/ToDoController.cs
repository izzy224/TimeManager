using ASPBackend.Controllers.Utility;
using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using ASPBackend.Models.Utility;
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
        private IToDoStatusRepository _toDoStatusRepository;
        private IJwtService _jwtService;
        

        public ToDoController(IToDoRepository toDoRepository, IManagementEntityRepository managementEntityRepository, IJwtService jwtService, IToDoStatusRepository toDoStatusRepository)
        {   
            _toDoRepository = toDoRepository;            
            _managementEntityRepository = managementEntityRepository;
            _jwtService = jwtService;
            _toDoStatusRepository = toDoStatusRepository;
        }

        [HttpGet("statuses")]
        public async Task<IActionResult> GetToDoStatuses()
        {
            var statuses = await _toDoStatusRepository.GetAll();
            if (statuses != null)
                return Ok(statuses);
            return BadRequest();
        }
        //POST : api/todo/get - for the reason that I cant send get request with body, because of Fetch API
        [HttpPost("get")]
        public async Task<IActionResult> GetToDosByDate([FromBody] DateObject date)
        {
            var user = await _jwtService.GetUser(Request.Cookies["jwt"]);
            var manEnt = await _managementEntityRepository.GetManagementEntityByDate(date.GetDate(), user.UserId);
            var statuses = await _toDoStatusRepository.GetAll();

            List<ToDoByStatus> todos = new List<ToDoByStatus>();

            foreach (var stat in statuses)
            {
                todos.Add(new ToDoByStatus()
                {
                    ToDoStatus = stat,
                    Todos = await _toDoRepository.GetAllByManagementEntityStatus(manEnt.ManagementEntityId, stat.ToDoStatusId)
                }
                );
            }

            if (todos != null)
                return Ok(new { todos, manEnt.ManagementEntityId });

            return NotFound();
        }
        public async Task<IActionResult> Post([FromBody] PostToDo toDo)
        {
            try {
            if (toDo == null)
            {
                return BadRequest("Invalid input");
            }
            var newTodo = new ToDo() { ManagementEntityId = toDo.ManagementEntityId, ToDoStatusId = toDo.ToDoStatusId, Name = toDo.Name, Description = toDo.Description};
            await _toDoRepository.Insert(newTodo);
            return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
