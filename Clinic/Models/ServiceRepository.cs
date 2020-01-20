using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class ServiceRepository
    {
        private ClinicContext db;

        //public PersonRepository()
        //{

        //    this.db = new ClinicContext();
        //}
        public IEnumerable<Service> GetAll()
        {
            return db.Services;
        }
        public Service Get(int id)
        {
            return db.Services.Find(id);
        }
        public void Create(Service item)
        {
            db.Services.Add(item);
        }

        public void Delete(int id)
        {
            Service service = db.Services.Find(id);
            if (service != null)
                db.Services.Remove(service);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Service item)
        {
            db.Services.Update(item);
        }
    }
    
}
