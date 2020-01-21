using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Clinic.Response;

namespace Clinic.Models
{
    public class ClinicContext : DbContext
    {
        public DbSet<PersonResponse> PersonsR { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employeers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Service> Services { get; set; }


        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
