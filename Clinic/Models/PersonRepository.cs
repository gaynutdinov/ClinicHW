using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Clinic.Response;

namespace Clinic.Models
{
    public class PersonRepository : IRepository<PersonResponse>
    {
        //private readonly LibraryContext _context;

        //public AuthorsController(LibraryContext context)
        //{
        //    _context = context;
        //}


        private ClinicContext db;

        public PersonRepository(ClinicContext context)
        {

            db = context;
        }
        public IEnumerable<PersonResponse> GetAll()
        {
            return db.Persons;
        }
        public PersonResponse Get(int id)
        {
            return db.Persons.Find(id);
        }
        public void Create(PersonResponse item)
        {
            db.Persons.Add(item);
        }

        public void Delete(int id)
        {
            PersonResponse person = db.Persons.Find(id);
            if (person != null)
                db.Persons.Remove(person);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(PersonResponse item)
        {
            db.Persons.Update(item);
        }
    }
}
