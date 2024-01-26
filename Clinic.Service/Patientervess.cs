using Clinic.Abstract;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service;
using Clincic.DataAccesslayer;

using Clinicss.Models;

using Microsoft.EntityFrameworkCore;

using Utalieties;

public class PatienteServess : PaginationHelper<VisitsVm>, IPatient

{
    BaseServess _BaseServess { get; set; }
        
        
        public PatienteServess(  BaseServess baseServess) 
    
    {  


        _BaseServess = baseServess;
    }
    public void Save(VisitsVm  PatientVm)
    {
        try
        {
            var PatientModel = Patient.Clone(PatientVm);

            if (PatientVm.patientid == null || PatientVm.patientid==default )
            {
               var SavedEntity=  _BaseServess._context.Patients.Add(PatientModel);

                PatientVm.patientid=SavedEntity.Entity.Id;
            }
            else
            {
                var SavedEntity = _BaseServess. _context.Patients.Update(PatientModel);
                PatientVm.patientid = SavedEntity.Entity.Id;

            }

            _BaseServess.ContexSaveChang();
        }
        catch (Exception ex)
        {
          
        }
    }

    public VisitsVm GetById(Guid Id)
    {
        try
        {
            var Visits = _BaseServess._context.Patients
                .Where(Patients => Patients.Id == Id)
                .Select(Patients => new VisitsVm
                {
                    Id = Patients.Id,
                    Address = Patients.Address,
                    Email = Patients.Email,
                    Age = Patients.Age,
                    patientName = Patients.Name,
                    PhoneNumber = Patients.PhoneNumber,
                    Gender = Patients.Gender,
                    NationalID = Patients.NationalID,
                    Birthdate = Patients.Birthdate,
                  
 


                })
                .FirstOrDefault();





            return Visits;
        }
        catch (Exception ex)
        {
            return new();
        }







    


}

}

