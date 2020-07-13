using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Revision_Sheet.Business;
using Revision_Sheet.BusinessObject;
using Revision_Sheet.IBusiness;

namespace Revision_Sheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserBusiness userBusiness = new UserBusiness();
        /*
        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/
        /*
        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (userBusiness.Login(user) != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
