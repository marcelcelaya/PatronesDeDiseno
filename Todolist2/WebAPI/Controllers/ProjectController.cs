using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("project")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService ProjectService)
        {

            _projectService = ProjectService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Project Project)
        {
            if (Project == null) return BadRequest("Request is null");
            int id = _projectService.Add(Project);
            if (id < 0) return BadRequest("Unable to Create Project");
            var payload = new { Id = id };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            Project u = _projectService.Get(id);
            if (u == null) return BadRequest();
            return Ok(u);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] Project us)
        {
            if (us == null) return BadRequest("Request is null");
            bool success = _projectService.Update(us);
            if (!success) return BadRequest("Unable to Update Project");
            return Ok(us);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            bool u = _projectService.Delete(id);
            if (u) return BadRequest();
            return Ok(u);
        }
        [Route("user/{id}")]
        [HttpGet]
        public IHttpActionResult GetUsersByProject([FromUri] int id)
        {
            if(id<= 0) return BadRequest();
            return(Ok(_projectService.GetUsers(id)));
        }
    }
}