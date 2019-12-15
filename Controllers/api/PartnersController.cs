﻿using System;
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
    public class PartnersController : ControllerBase
    {
        private readonly VK21Context _context;

        public PartnersController(VK21Context context)
        {
            _context = context;
        }

        // GET: api/Partners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partner>>> GetPartner()
        {
            return await _context.Partner.ToListAsync();
        }

        // GET: api/Partners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partner>> GetPartner(int id)
        {
            var partner = await _context.Partner.FindAsync(id);

            if (partner == null)
            {
                return NotFound();
            }

            return partner;
        }

        // PUT: api/Partners/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartner(int id, Partner partner)
        {
            if (id != partner.PartnerId)
            {
                return BadRequest();
            }

            _context.Entry(partner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(id))
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

        // POST: api/Partners
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Partner>> PostPartner(Partner partner)
        {
            _context.Partner.Add(partner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartner", new { id = partner.PartnerId }, partner);
        }

        // DELETE: api/Partners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Partner>> DeletePartner(int id)
        {
            var partner = await _context.Partner.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }

            _context.Partner.Remove(partner);
            await _context.SaveChangesAsync();

            return partner;
        }

        private bool PartnerExists(int id)
        {
            return _context.Partner.Any(e => e.PartnerId == id);
        }
    }
}
