using CAFE.API.Repositories.Interfaces;
using CAFE.DATA.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CAFE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository  _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            return _userRepository.GetUsers().Result;
        }

        // GET api/<UserController>/5
        [HttpGet("GetUserById/{id}")]
        public User GetUsersById(int id)
        {
            return _userRepository.GetUserById(id).Result;
        }
        // GET api/<UserController>/5
        [HttpGet("GetUsersByName/{name}")]
        public List<User> GetUsersById(string name)
        {
            return _userRepository.GetUsersByName(name).Result;
        }
        // POST api/<UserController>
        [HttpPost("Add")]
        public User Add([FromBody] User usr)
        {
            return _userRepository.AddUser(usr).Result;
        }

        // PUT api/<UserController>/5
        [HttpPut("Update")]
        public User Update([FromBody] User usr)
        {
            return _userRepository.UpdateUser(usr).Result;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("Delete/{id}")]
        public bool Delete(int id)
        {
            return _userRepository.Delete(id).Result;
        }
    }
}
