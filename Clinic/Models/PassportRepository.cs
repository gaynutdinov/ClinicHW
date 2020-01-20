using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class PassportRepository
    {
        private ClinicContext db;

        //public PersonRepository()
        //{

        //    this.db = new ClinicContext();
        //}
        public IEnumerable<Passport> GetAll()
        {
            return db.Passports;
        }
        public Passport Get(int id)
        {
            return db.Passports.Find(id);
        }
        public void Create(Passport item)
        {
            db.Passports.Add(item);
        }

        public void Delete(int id)
        {
            Passport passport = db.Passports.Find(id);
            if (passport != null)
                db.Passports.Remove(passport);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Passport item)
        {
            db.Passports.Update(item);
        }
    }
}
