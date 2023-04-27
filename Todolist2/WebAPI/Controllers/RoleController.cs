using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
namespace WebAPI.Controllers
{
    [RoutePrefix("Role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _RoleService;
        public RoleController(IRoleService RoleService)
        {

            _RoleService = RoleService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Role Role)
        {
            if (Role == null) return BadRequest("Request is null");
            int id = _RoleService.Add(Role);
            if (id < 0) return BadRequest("Unable to Create Role");
            var payload = new { Id = id };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            Role u = _RoleService.Get(id);
            if (u == null) return BadRequest();
            return Ok(u);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] Role us)
        {
            if (us == null) return BadRequest("Request is null");
            bool success = _RoleService.Update(us);
            if (!success) return BadRequest("Unable to Update Role");
            return Ok(us);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            bool u = _RoleService.Delete(id);
            if (u) return BadRequest();
            return Ok(u);
        }
    }
}
