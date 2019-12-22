using AngularCourseBE.Models;
using AngularCourseBE.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace AngularCourseBE.Controllers
{
    [Authorize]
    [RoutePrefix("api/tasks")]
    public class TaskController : ApiController
    {
        private readonly TaskService _taskService;

        public TaskController()
        {
            _taskService = new TaskService();
        }

        [HttpGet]
        [Route]
        public IHttpActionResult GetAll()
        {
            IEnumerable<TaskListItem> tasks = _taskService.GetAll();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            bool exists = _taskService.TryGet(id, out Task task);

            return exists
                ? Ok(task)
                : (IHttpActionResult)NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Update(int id, [FromBody] Task task)
        {
            bool exists = _taskService.TryUpdate(id, task);

            return exists
                ? Ok(task)
                : (IHttpActionResult)NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            bool exists = _taskService.TryDelete(id);

            return exists
                ? Ok()
                : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        [Route()]
        public IHttpActionResult Create([FromBody] Task task)
        {
            _taskService.CreateTask(task);
            return Ok();
        }
    }
}