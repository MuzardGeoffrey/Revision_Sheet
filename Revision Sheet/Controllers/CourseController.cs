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
    public class CourseController : ControllerBase
    {
        ICourseBusiness courseBusiness = new CourseBusiness();

        
        // GET: api/Course/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "pas dispo";
        }
        
        // POST: api/Course
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            Course course1 = new Course();
            course1 = courseBusiness.Create(course);
            if (course != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/Course/5
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
