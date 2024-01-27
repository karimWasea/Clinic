using Clincic.DataAccesslayer;

using Clinic.Abstract;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utalieties
{
    public class DbInitializers : IDbInitializer
    {
        private readonly ApplicationDBcontext _context;

        public DbInitializers(ApplicationDBcontext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetAppliedMigrations().Count() > 0)
                    _context.Database.Migrate();
            }
            catch (Exception)
            {
                throw;
            }

            if (!_context.Clinic.Any())
            {
                var clinicData = new List<(string clinicName, int numberOfDoctors, bool isOpen, string location)>
                {
                
                };

                var clinics = new List<Clincic.DataAccesslayer.Clinic>();
                foreach (var clinic in clinicData)
                {
                    clinics.Add(new Clincic.DataAccesslayer.Clinic
                    {
                        clinicName = clinic.clinicName,
                        numberOfDoctors = clinic.numberOfDoctors,
                        isOpen = clinic.isOpen,
                        location = clinic.location
                    });
                }

                _context.Clinic.AddRange(clinics);
                _context.SaveChanges();
            }
        }
    }
}

