using Microsoft.AspNetCore.Mvc;
using Revision_Sheet.Business;
using Revision_Sheet.BusinessObject;
using Revision_Sheet.IBusiness;
using System.Collections.Generic;
using System.Text.Json;

namespace Revision_Sheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness userBusiness = new UserBusiness();
        
        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello" };
        }

        // GET: api/User/5
        [HttpGet("{id:int}", Name = "GetUser")]
        public User Get(int id)
        {
            User user = new User();
            user = userBusiness.FindById(id);
            return user;
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user.Login != null && user.Password != null)
            {
                User userResponse = new User();
                userResponse = userBusiness.Create(user);
                if (userResponse != null)
                {
                return Ok();
                }
            }
                return BadRequest();
        }

        // PUT: api/User/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            User userResponse = new User();
            userResponse = userBusiness.Update(id, user);
            if (userResponse != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/user/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bool response = false;
            response = userBusiness.Delete(id);
            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}