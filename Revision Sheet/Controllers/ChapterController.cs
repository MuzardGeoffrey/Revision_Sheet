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
    public class ChapterController : ControllerBase
    {
        IChapterBusiness chapterBusiness = new ChapterBusiness();

        // GET: api/Chapter/5
        [HttpGet("{id:int}", Name = "GetChapter")]
        public Chapter Get(int id)
        {
            Chapter chapter = new Chapter();
            chapter = chapterBusiness.FindById(id);
            return chapter;
        }

        // POST: api/Chapter
        [HttpPost()]
        public IActionResult Post([FromBody] Chapter value)
        {
            Chapter chapter = new Chapter();
            chapter = chapterBusiness.Create(value);
            if (chapter != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/Chapter/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Chapter value)
        {
            Chapter chapter = new Chapter();
            chapter = chapterBusiness.Update(id, value);
            if (chapter != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bool response = false;
            response = chapterBusiness.Delete(id);
            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
