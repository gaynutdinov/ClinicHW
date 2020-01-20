using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public int Coast { get; set; }
    }
}
