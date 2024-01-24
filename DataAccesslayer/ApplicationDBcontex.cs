using Clincic.DataAccesslayer;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace Clincic.DataAccesslayer
{
    public class ApplicationDBcontext:  DbContext
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        {

        }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<Patient>  Patients { get; set; }
        public DbSet<SHifts>   SHifts { get; set; }
        public DbSet<DoctorSHifts> DoctorSHifts { get; set; }
        public DbSet<Visits>    Visits { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
    }
}
