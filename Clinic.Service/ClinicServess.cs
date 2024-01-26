using Clinic.Abstract;
 
using ClinicUtilities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service;
using Clincic.DataAccesslayer;

using Clinicss.Models;

public class ClinicServess : PaginationHelper<ClinicVm>, IClinic

{
    BaseServess _BaseServess { get; set; }
        
        
        public ClinicServess(  BaseServess baseServess) 
    
    {  


        _BaseServess = baseServess;
    }
    public void Save(ClinicVm clinic)
    {
        try
        {
            var clinicModel = Clinic.Clone(clinic);

            if (clinic.Id == null || clinic.Id==default)
            {
                _BaseServess._context.Clinic.Add(clinicModel);
            }
            else
            {
               _BaseServess. _context.Clinic.Update(clinicModel);
            }

            _BaseServess.ContexSaveChang();
        }
        catch (Exception ex)
        {
          
        }
    }

    public ClinicVm GetById(Guid Id)
    { 
            try
            {
                var clinic = _BaseServess._context.Clinic
                    .Where(clinic => clinic.Id == Id)
                    .Select(clinic => new ClinicVm
                    {
                        Id = clinic.Id,
                        clinicName = clinic.clinicName,
                        isOpen = clinic.isOpen,
                        location = clinic.location,
                        numberOfDoctors = clinic.numberOfDoctors,
                    })
                    .FirstOrDefault();


     


                return clinic;
            }
            catch (Exception ex)
            {
            return new ClinicVm();

        }



    }

}

