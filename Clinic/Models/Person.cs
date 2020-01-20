using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid PassportId { get; set; }
        public Passport Passport { get; set; }

        //public Person(Guid Id, string FirstNam, string MiddleName, string LastName, int Age) 
        //{
        //    this.Id = Id;
        //    this.FirstName = FirstName;
        //    this.MiddleName = MiddleName;
        //    this.LastName = LastName;
        //    this.Age = Age;
        //    PassportId = '';
        //    Passport = null;
        //}

    }
}
