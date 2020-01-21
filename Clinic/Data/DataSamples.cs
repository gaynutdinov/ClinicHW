using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Clinic.Models;
using Clinic.Response;

namespace Clinic.Data
{
    public class DataSamples
    {
        public static void Initialize(ClinicContext context)
        {

            context.Database.EnsureCreated();

            Passport passport = new Passport
            {
                Id = System.Guid.NewGuid(),
                Series = 1111,
                Numer = 222222,
                UnitNumber = 160001,
                IssuedBy = "Отдел УФМС",
                IssuedOn = new DateTime(2015, 7, 20),
                ValidUntil = new DateTime(2035, 7, 20)
            };

            if (!context.Passports.Any())
            {
                context.Passports.AddRange(
                    passport,
                    new Passport
                    {
                        Id = System.Guid.NewGuid(),
                        Series = 5555,
                        Numer = 333333,
                        UnitNumber = 160001,
                        IssuedBy = "Отдел УФМС",
                        IssuedOn = new DateTime(2015, 7, 20),
                        ValidUntil = new DateTime(2035, 7, 20)
                    }
                    );
            }


            if (!context.PersonsR.Any())
            {
                context.PersonsR.AddRange(
                    new PersonResponse
                    {
                        Id = System.Guid.NewGuid(),
                        FirstName = "Иван",
                        MiddleName = "Иванов",
                        LastName = "Иванович",
                        Age = 21
                        //PassportId = passport.Id,
                        //Passport = passport
                    },
                    new PersonResponse
                    {
                        Id = System.Guid.NewGuid(),
                        FirstName = "Степан",
                        MiddleName = "Саврасов",
                        LastName = "Семенович",
                        Age = 21
                        //PassportId = passport.Id,
                        //Passport = passport
                    }
                    );
            }
            context.SaveChanges();
        }
    }

}
