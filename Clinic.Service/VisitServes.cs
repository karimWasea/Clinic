using Clincic.DataAccesslayer;

using Clinic.Abstract;

using Clinicss.Models;

using Microsoft.EntityFrameworkCore;

using PagedList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utalieties;

namespace Clinic.Service
{
    public class VisitServess : PaginationHelper<VisitsVm>, IVisits
    {
        BaseServess _BaseServess { get; set; }
        IPatient _patient { get; set; }

        public VisitServess(BaseServess baseServess, PatienteServess patient)

        {


            _BaseServess = baseServess;
            _patient = patient; 
        }
        public VisitsVm GetById(Guid Id)
        {
            try
            {
                var Visits = _BaseServess._context.Visits.Include(p => p.Patient).Include(d=>d.Doctor)
                    .Where(Visit => Visit.Id == Id)
                    .Select(Visit => new VisitsVm
                    {
                        Id = Visit.Id,
                        Address = Visit.Patient.Address,
                        Email = Visit.Patient.Email,
                        Age = Visit.Patient.Age,
                        patientName = Visit.Patient.Name,
                        PhoneNumber = Visit.Patient.PhoneNumber,
                        Gender = Visit.Patient.Gender,
                        NationalID = Visit.Patient.NationalID,
                        Birthdate = Visit.Patient.Birthdate,
                        Visisttype = Visit.Visisttype,
                        VisitStutus = Visit.VisitStutus,
                        VisitsApientment = Visit.VisitsApientment,
                        patientid = Visit.patientid,
                        doctorid = Visit.DoctorId,
                        doctorName = Visit.Doctor.Name,



                    })
                    .FirstOrDefault();





                return Visits;
            }
            catch (Exception ex)
            {
                return new();
            }







        }


        private Guid? GetExistingPatientId(VisitsVm entity)
        {
            var existingPatient = _BaseServess._context.Patients
                .FirstOrDefault(p => p.PhoneNumber == entity.PhoneNumber ||
                                     p.NationalID == entity.NationalID ||
                                     p.Email == entity.Email);

            return existingPatient?.Id;
        }

        public void Save(VisitsVm entity)
        {
            try
            {
                var existingPatientId = GetExistingPatientId(entity);

                if (existingPatientId == null)
                     _patient.Save(entity);
                else
                 entity.patientid = (Guid)existingPatientId;

                var visitsModel = Visits.Clone(entity);

                if (entity.Id == default || entity.Id == null)
                {
                    // Add new visit
                    _BaseServess._context.Visits.Add(visitsModel);
                }
                else
                {
                    // Update existing visit
                    _BaseServess._context.Visits.Update(visitsModel);
                }

                _BaseServess.ContexSaveChang();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., logging)
                throw; // Rethrow the exception or handle it based on requirements
            }
        }




        public IPagedList<VisitsVm> Search(VisitsVm VisitSm)
    {
        int pageNum = VisitSm.PagNumber ?? 1;

        var query = _BaseServess._context.Visits.Include(p => p.Patient).Include(v=>v.Doctor)
            .Where(Visit =>
                (VisitSm.FilterBy == null || Visit.Patient.Name.Contains(VisitSm.FilterBy) ||
                Visit.Doctor.Name.Contains(VisitSm.FilterBy) ||
              Visit.Patient.Address.Contains(VisitSm.FilterBy)||
                  Visit.Patient.Email.Contains(VisitSm.FilterBy)));

         var result = query.Select(Visit => new VisitsVm
         {
             Id = Visit.Id,
             Address = Visit.Patient.Address,
             Email = Visit.Patient.Email,
             Age = Visit.Patient.Age,
             patientName = Visit.Patient.Name,
             PhoneNumber = Visit.Patient.PhoneNumber,
             Gender = Visit.Patient.Gender,
             NationalID = Visit.Patient.NationalID,
             Birthdate = Visit.Patient.Birthdate,
             Visisttype = Visit.Visisttype,
             VisitStutus = Visit.VisitStutus,
             VisitsApientment = Visit.VisitsApientment,
             patientid = Visit.patientid,
             doctorid = Visit.DoctorId,
             doctorName = Visit.Doctor.Name,
         }).Distinct();  

        return Pagination(result, pageNum);
    }

     
}
}
