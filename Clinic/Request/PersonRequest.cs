﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Clinic.Models;

namespace Clinic.Request
{
    public class PersonRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        //public Guid PassportId { get; set; }
        //public Passport Passport { get; set; }
    }
}
