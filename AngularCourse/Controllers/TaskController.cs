using AngularCourseBE.Models;
using AngularCourseBE.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AngularCourseBE.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController()
        {
            _taskService = new TaskService();
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            IEnumerable<TaskListItem> tasks = _taskService.GetAll();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            bool exists = _taskService.TryGet(id, out Task task);

            return exists
                ? Ok(task)
                : (IActionResult)NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] Task task)
        {
            bool exists = _taskService.TryUpdate(id, task);

            return exists
                ? Ok(task)
                : (IActionResult)NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            bool exists = _taskService.TryDelete(id);

            return exists
                ? Ok()
                : (IActionResult)NotFound();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] Task task)
        {
            _taskService.CreateTask(task);
            return Ok();
        }
    }
}