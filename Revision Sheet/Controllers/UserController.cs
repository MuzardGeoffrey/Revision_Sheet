using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Revision_Sheet.Business;
using Revision_Sheet.BusinessObject;
using Revision_Sheet.IBusiness;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Revision_Sheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBusiness userBusiness = new UserBusiness();

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id:int}", Name = "Get")]
        public string Get(int id)
        {
            User user = new User(userBusiness.FindById(id));
            string json = JsonSerializer.Serialize(user);
            return json;
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
            User user = new User();
            String json = JsonSerializer.Serialize(value);
            user = JsonSerializer.Deserialize<User>(json);
            userBusiness.Create(user);
        }

        // PUT: api/User/5
        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] string value)
        {
            User user = new User();
            try
            {
                user = JsonSerializer.Deserialize<User>(value);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           
            userBusiness.Update(id, user);
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userBusiness.Delete(id);
        }
    }
}
