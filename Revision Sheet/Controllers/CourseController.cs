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
        [HttpGet("{id:int}", Name = "GetCourse")]
        public Course Get(int id)
        {
            Course course = new Course();
            course = courseBusiness.FindById(id);
            return course;
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
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Course value)
        {
            Course course = new Course();
            course = courseBusiness.Update(id, value);
            if (course != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bool reponse = false;
            reponse = courseBusiness.Delete(id);

            if (reponse)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
