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
    public class MovsController : ControllerBase
    {
        private readonly VK21Context _context;

        public MovsController(VK21Context context)
        {
            _context = context;
        }

        // GET: api/Movs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mov>>> GetMov()
        {
            return await _context.Mov.ToListAsync();
        }

        // GET: api/Movs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mov>> GetMov(int id)
        {
            var mov = await _context.Mov.FindAsync(id);

            if (mov == null)
            {
                return NotFound();
            }

            return mov;
        }

        // PUT: api/Movs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMov(int id, Mov mov)
        {
            if (id != mov.MoveId)
            {
                return BadRequest();
            }

            _context.Entry(mov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovExists(id))
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

        // POST: api/Movs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mov>> PostMov(Mov mov)
        {
            _context.Mov.Add(mov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMov", new { id = mov.MoveId }, mov);
        }

        // DELETE: api/Movs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mov>> DeleteMov(int id)
        {
            var mov = await _context.Mov.FindAsync(id);
            if (mov == null)
            {
                return NotFound();
            }

            _context.Mov.Remove(mov);
            await _context.SaveChangesAsync();

            return mov;
        }

        private bool MovExists(int id)
        {
            return _context.Mov.Any(e => e.MoveId == id);
        }
    }
}
