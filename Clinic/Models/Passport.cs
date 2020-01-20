using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Passport : Document
    {
        public int Series { get; set; }
        public int Numer { get; set; }
        public int UnitNumber { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
