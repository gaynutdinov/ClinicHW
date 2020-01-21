using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using Clinic.Request;
using Clinic.Response;
using Clinic.Models;
using Clinic.Logic;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ClinicContext _context;

        public PersonController(ClinicContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<PersonResponse>> PostPerson(PersonRequest personRequest)
        {

            if (personRequest.Id == null)
            {
                return BadRequest();
            }

            PersonResponse personResponse = PersonLogic.MergePerson(personRequest);
            _context.Persons.Add(personResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = personResponse.Id }, personResponse);
        }


        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPersons()
        {
           
            return await _context.Persons.ToListAsync();


        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> GetPerson(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(Guid id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonResponse>> DeletePerson(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return person;
        }

        private bool PersonExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
