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
    public class DocsController : ControllerBase
    {
        private readonly VK21Context _context;

        public DocsController(VK21Context context)
        {
            _context = context;
        }

        // GET: api/Docs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doc>>> GetDoc()
        {
            return await _context.Doc.ToListAsync();
        }

        // GET: api/Docs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doc>> GetDoc(int id)
        {
            var doc = await _context.Doc.FindAsync(id);

            if (doc == null)
            {
                return NotFound();
            }

            return doc;
        }

        // PUT: api/Docs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoc(int id, Doc doc)
        {
            if (id != doc.DocId)
            {
                return BadRequest();
            }

            _context.Entry(doc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocExists(id))
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

        // POST: api/Docs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Doc>> PostDoc(Doc doc)
        {
            _context.Doc.Add(doc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoc", new { id = doc.DocId }, doc);
        }

        // DELETE: api/Docs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doc>> DeleteDoc(int id)
        {
            var doc = await _context.Doc.FindAsync(id);
            if (doc == null)
            {
                return NotFound();
            }

            _context.Doc.Remove(doc);
            await _context.SaveChangesAsync();

            return doc;
        }

        private bool DocExists(int id)
        {
            return _context.Doc.Any(e => e.DocId == id);
        }
    }
}
