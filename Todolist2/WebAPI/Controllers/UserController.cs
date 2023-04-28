using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Model;

namespace WebAPI.Controllers
{

    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {

            _userService = userService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] User user)
        {
            if (user == null) return BadRequest("Request is null");
            int id = _userService.Add(user);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            User u = _userService.Get(id);
            if (u == null) return BadRequest();
            return Ok(u);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] User us)
        {
            if (us == null) return BadRequest("Request is null");
            bool success = _userService.Update(us);
            if (!success) return BadRequest("Unable to Update User");
            return Ok(us);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            bool u = _userService.Delete(id);
            if (u) return BadRequest();
            return Ok(u);
        }
        [Route("projects/{id}")]
        [HttpGet]
        public IHttpActionResult GetProjects([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            List<Project> projectList = _userService.GetProjects(id).ToList();
            return Ok(projectList);
        }
        [Route("{idUser}/projects/{idProject}")]
        [HttpPost]
        public IHttpActionResult RelateProject([FromUri] int idUser, [FromUri] int idProject)
        {
            if (idUser <= 0) return BadRequest();
            if(idProject <= 0) return BadRequest();
            return Ok(_userService.RelateProject(idUser,idProject));
        }
        [Route("login")]
        [HttpPost]
        public IHttpActionResult LoginUser([FromBody] UserDTO user)
        {   
            if(user.Email == null) return BadRequest();
            if(user.Password == null) return BadRequest();
            return Ok(_userService.Login(user.Email, user.Password));
        }
    }
} 