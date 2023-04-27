using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
namespace WebAPI.Controllers
{
    [RoutePrefix("Task")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _TaskService;
        public TaskController(ITaskService TaskService)
        {

            _TaskService = TaskService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Task Task)
        {
            if (Task == null) return BadRequest("Request is null");
            int id = _TaskService.Add(Task);
            if (id < 0) return BadRequest("Unable to Create Task");
            var payload = new { Id = id };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            Task u = _TaskService.Get(id);
            if (u == null) return BadRequest();
            return Ok(u);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] Task us)
        {
            if (us == null) return BadRequest("Request is null");
            bool success = _TaskService.Update(us);
            if (!success) return BadRequest("Unable to Update Task");
            return Ok(us);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            bool u = _TaskService.Delete(id);
            if (u) return BadRequest();
            return Ok(u);
        }
    }
}
