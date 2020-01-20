using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.Models;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : ControllerBase
    {
        private readonly ClinicContext _context;

        public PassportController(ClinicContext context)
        {
            _context = context;
        }

        // GET: api/Passport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passport>>> GetPassports()
        {
            return await _context.Passports.ToListAsync();
        }

        // GET: api/Passport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passport>> GetPassport(Guid id)
        {
            var passport = await _context.Passports.FindAsync(id);

            if (passport == null)
            {
                return NotFound();
            }

            return passport;
        }

        // PUT: api/Passport/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassport(Guid id, Passport passport)
        {
            if (id != passport.Id)
            {
                return BadRequest();
            }

            _context.Entry(passport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassportExists(id))
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

        // POST: api/Passport
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Passport>> PostPassport(Passport passport)
        {
            _context.Passports.Add(passport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassport", new { id = passport.Id }, passport);
        }

        // DELETE: api/Passport/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Passport>> DeletePassport(Guid id)
        {
            var passport = await _context.Passports.FindAsync(id);
            if (passport == null)
            {
                return NotFound();
            }

            _context.Passports.Remove(passport);
            await _context.SaveChangesAsync();

            return passport;
        }

        private bool PassportExists(Guid id)
        {
            return _context.Passports.Any(e => e.Id == id);
        }
    }
}
