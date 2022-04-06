using ASPBackend.Controllers.Utility;
using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using ASPBackend.Models.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ScheduleController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IManagementEntityRepository _managementEntityRepository;
        private IJwtService _jwtService;
        private ITimeScheduleRepository _timeScheduleRepository;

        public ScheduleController(IUserRepository userRepository, IManagementEntityRepository managementEntityRepository, IJwtService jwtService, ITimeScheduleRepository timeScheduleRepository)
        {
            _userRepository = userRepository;
            _managementEntityRepository = managementEntityRepository;
            _jwtService = jwtService;
            _timeScheduleRepository = timeScheduleRepository;
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetToDosByDate([FromBody] DateObject date)
        {
            var user = await _jwtService.GetUser(Request.Cookies["jwt"]);
            if(user != null)
            {
                var manEnt = await _managementEntityRepository.GetManagementEntityByDate(date.GetDate(), user.UserId);
                return Ok(new {managementEntityId = manEnt.ManagementEntityId,
                    schedules = await _timeScheduleRepository.GetByManagementEntityAsync(manEnt.ManagementEntityId)});
            }
   
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> PostSchedule(ScheduleDTO schedule)
        {
            if (schedule != null)
            {
                var newTimeSchedule = new TimeSchedule()
                {
                    Name = schedule.Name,
                    Description = schedule.Description,
                    StartTime = schedule.GetStartTime(),
                    EndTime = schedule.GetEndTime(),
                    ManagementEntityId = schedule.ManagementEntityId,
                    ManagementEntity = await _managementEntityRepository.GetById(schedule.ManagementEntityId)
                };
                await _timeScheduleRepository.Insert(newTimeSchedule);
                return Ok(new {timeScheduleId = newTimeSchedule.TimeScheduleId});
            }
            return BadRequest();
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSchedule(ScheduleUpdate schedule)
        {
            if(schedule != null)
            {
                var storedTimeSchedule = await _timeScheduleRepository.GetById(schedule.TimeScheduleId);
                storedTimeSchedule.Name = schedule.Name;
                storedTimeSchedule.Description = schedule.Description;
                storedTimeSchedule.StartTime = schedule.GetStartTime();
                storedTimeSchedule.EndTime = schedule.GetEndTime();
                await _timeScheduleRepository.Save();
                return Ok(new { message = "success" });
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSchedule([FromBody]int scheduleId)
        {
            await _timeScheduleRepository.Delete(scheduleId);
            return Ok(new { message = "success" });

        }
    }
}
