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
    public class SheetController : ControllerBase
    {
        ISheetBusiness sheetBusiness = new SheetBusiness();
        // GET: api/Sheet/5
        [HttpGet("{id:int}", Name = "GetSheet")]
        public Sheet Get(int id)
        {
            Sheet sheet = new Sheet();
            sheet = sheetBusiness.FindById(id);
            return sheet;
        }

        // POST: api/Sheet
        [HttpPost]
        public IActionResult Post([FromBody] Sheet value)
        {
            Sheet sheet = new Sheet();
            sheet = sheetBusiness.Create(value);
            if (sheet != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/Sheet/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Sheet value)
        {
            Sheet sheet = new Sheet();
            sheet = sheetBusiness.Update(id, value);
            if (sheet != null)
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
            response = sheetBusiness.Delete(id);
            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
