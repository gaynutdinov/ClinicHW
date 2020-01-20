using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Clinic.Models
{
    public class PersonRepository : IRepository<Person>
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
        public IEnumerable<Person> GetAll()
        {
            return db.Persons;
        }
        public Person Get(int id)
        {
            return db.Persons.Find(id);
        }
        public void Create(Person item)
        {
            db.Persons.Add(item);
        }

        public void Delete(int id)
        {
            Person person = db.Persons.Find(id);
            if (person != null)
                db.Persons.Remove(person);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Person item)
        {
            db.Persons.Update(item);
        }
    }
}
