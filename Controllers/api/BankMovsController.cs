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
    public class BankMovsController : ControllerBase
    {
        private readonly VK21Context _context;

        public BankMovsController(VK21Context context)
        {
            _context = context;
        }

        // GET: api/BankMovs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankMov>>> GetBankMov()
        {
            return await _context.BankMov.ToListAsync();
        }

        // GET: api/BankMovs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankMov>> GetBankMov(int id)
        {
            var bankMov = await _context.BankMov.FindAsync(id);

            if (bankMov == null)
            {
                return NotFound();
            }

            return bankMov;
        }

        // PUT: api/BankMovs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankMov(int id, BankMov bankMov)
        {
            if (id != bankMov.BankMoveId)
            {
                return BadRequest();
            }

            _context.Entry(bankMov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankMovExists(id))
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

        // POST: api/BankMovs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BankMov>> PostBankMov(BankMov bankMov)
        {
            _context.BankMov.Add(bankMov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankMov", new { id = bankMov.BankMoveId }, bankMov);
        }

        // DELETE: api/BankMovs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BankMov>> DeleteBankMov(int id)
        {
            var bankMov = await _context.BankMov.FindAsync(id);
            if (bankMov == null)
            {
                return NotFound();
            }

            _context.BankMov.Remove(bankMov);
            await _context.SaveChangesAsync();

            return bankMov;
        }

        private bool BankMovExists(int id)
        {
            return _context.BankMov.Any(e => e.BankMoveId == id);
        }
    }
}
