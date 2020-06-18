using System;
using Microsoft.AspNetCore.Mvc;
using Revision_Sheet.Business;
using Revision_Sheet.BusinessObject;
using Revision_Sheet.IBusiness;
using System.Text.Json;
using System.Threading.Tasks;

namespace Revision_Sheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBusiness userBusiness = new UserBusiness();

        // GET: api/User/5
        [HttpGet("{id:int}")]
        public string Get(int id)
        {
            User user = new User(userBusiness.FindById(id));
            string json = JsonSerializer.Serialize(user);
            return json;
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            
            if (user.FirstName != null && user.LastName != null && user.Login != null && user.Password != null)
            {
                userBusiness.Create(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/User/5
        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] User user)
        { 
            userBusiness.Update(id, user);
        }

        // DELETE: api/user/5
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            userBusiness.Delete(id);
        }
    }
}
