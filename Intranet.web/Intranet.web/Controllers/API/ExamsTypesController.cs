using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public ExamsTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ExamsTypes
        [HttpGet]
        public IEnumerable<ExamsType> GetExamsTypes()
        {
            return _context.ExamsTypes.OrderBy(pt => pt.Name);
        }

        // GET: api/ExamsTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamsType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var examsType = await _context.ExamsTypes.FindAsync(id);

            if (examsType == null)
            {
                return NotFound();
            }

            return Ok(examsType);
        }


    }
}