using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Clinic.Request;
using Clinic.Response;
using Clinic.Models;

namespace Clinic.Logic
{
    public class PersonLogic
    {
        public static PersonResponse MergePerson(PersonRequest personRequest) {
            return new PersonResponse
            {
                Id = personRequest.Id,
                FirstName = personRequest.FirstName,
                MiddleName = personRequest.MiddleName,
                LastName = personRequest.LastName,
                Age = personRequest.Age
            };
        }
    }
}
