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
    public class MoveTypesController : ControllerBase
    {
        private readonly VK21Context _context;

        public MoveTypesController(VK21Context context)
        {
            _context = context;
        }

        // GET: api/MoveTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoveType>>> GetMoveType()
        {
            return await _context.MoveType.ToListAsync();
        }

        // GET: api/MoveTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoveType>> GetMoveType(string id)
        {
            var moveType = await _context.MoveType.FindAsync(id);

            if (moveType == null)
            {
                return NotFound();
            }

            return moveType;
        }

        // PUT: api/MoveTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoveType(string id, MoveType moveType)
        {
            if (id != moveType.MoveTypeId)
            {
                return BadRequest();
            }

            _context.Entry(moveType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveTypeExists(id))
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

        // POST: api/MoveTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MoveType>> PostMoveType(MoveType moveType)
        {
            _context.MoveType.Add(moveType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MoveTypeExists(moveType.MoveTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMoveType", new { id = moveType.MoveTypeId }, moveType);
        }

        // DELETE: api/MoveTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MoveType>> DeleteMoveType(string id)
        {
            var moveType = await _context.MoveType.FindAsync(id);
            if (moveType == null)
            {
                return NotFound();
            }

            _context.MoveType.Remove(moveType);
            await _context.SaveChangesAsync();

            return moveType;
        }

        private bool MoveTypeExists(string id)
        {
            return _context.MoveType.Any(e => e.MoveTypeId == id);
        }
    }
}
