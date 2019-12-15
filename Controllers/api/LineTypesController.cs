using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vk20.Models;

namespace vk20.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineTypesController : ControllerBase
    {
        private readonly VK21Context _context;

        public LineTypesController(VK21Context context)
        {
            _context = context;
        }

        // GET: api/LineTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineType>>> GetLineType()
        {
            return await _context.LineType.ToListAsync();
        }

        // GET: api/LineTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineType>> GetLineType(string id)
        {
            var lineType = await _context.LineType.FindAsync(id);

            if (lineType == null)
            {
                return NotFound();
            }

            return lineType;
        }

        // PUT: api/LineTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineType(string id, LineType lineType)
        {
            if (id != lineType.LineTypeId)
            {
                return BadRequest();
            }

            _context.Entry(lineType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LineTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LineType>> PostLineType(LineType lineType)
        {
            _context.LineType.Add(lineType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LineTypeExists(lineType.LineTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLineType", new { id = lineType.LineTypeId }, lineType);
        }

        // DELETE: api/LineTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LineType>> DeleteLineType(string id)
        {
            var lineType = await _context.LineType.FindAsync(id);
            if (lineType == null)
            {
                return NotFound();
            }

            _context.LineType.Remove(lineType);
            await _context.SaveChangesAsync();

            return lineType;
        }

        private bool LineTypeExists(string id)
        {
            return _context.LineType.Any(e => e.LineTypeId == id);
        }
    }
}
