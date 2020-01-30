using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Options
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
