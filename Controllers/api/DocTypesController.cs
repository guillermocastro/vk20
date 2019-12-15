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
    public class DocTypesController : ControllerBase
    {
        private readonly VK21Context _context;

        public DocTypesController(VK21Context context)
        {
            _context = context;
        }

        // GET: api/DocTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocType>>> GetDocType()
        {
            return await _context.DocType.ToListAsync();
        }

        // GET: api/DocTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocType>> GetDocType(string id)
        {
            var docType = await _context.DocType.FindAsync(id);

            if (docType == null)
            {
                return NotFound();
            }

            return docType;
        }

        // PUT: api/DocTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocType(string id, DocType docType)
        {
            if (id != docType.DocTypeId)
            {
                return BadRequest();
            }

            _context.Entry(docType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocTypeExists(id))
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

        // POST: api/DocTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DocType>> PostDocType(DocType docType)
        {
            _context.DocType.Add(docType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocTypeExists(docType.DocTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocType", new { id = docType.DocTypeId }, docType);
        }

        // DELETE: api/DocTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocType>> DeleteDocType(string id)
        {
            var docType = await _context.DocType.FindAsync(id);
            if (docType == null)
            {
                return NotFound();
            }

            _context.DocType.Remove(docType);
            await _context.SaveChangesAsync();

            return docType;
        }

        private bool DocTypeExists(string id)
        {
            return _context.DocType.Any(e => e.DocTypeId == id);
        }
    }
}
