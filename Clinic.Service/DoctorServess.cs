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
    public class DoctorServess : PaginationHelper<DoctorVm>, Idoctor
    {
        BaseServess _BaseServess { get; set; }

        public DoctorServess(BaseServess baseServess)

        {


            _BaseServess = baseServess;
        }
        public DoctorVm GetById(Guid Id)
        {

           return  _BaseServess._context.Doctor
                .Include(doctor => doctor.DoctorSHifts)
                    .ThenInclude(doctorShifts => doctorShifts.SHifts)
                .Where(doctor =>doctor.Id == Id)    .
                    

           Select(doctor => new DoctorVm
            {
                Id = doctor.Id,
                Specialty = doctor.Specialty,
                Address = doctor.Address,
                NationalID = doctor.NationalID,
                Name = doctor.Name,
                Age = doctor.Age,
                Birthdate = doctor.Birthdate,
                Salary = doctor.Salary,
                 Gender = doctor.Gender,
                  Email = doctor.Email,
                   Title = doctor.Title,
                    HiringDate = doctor.HiringDate,
                     
                 Endshift = doctor.DoctorSHifts.Select(ds => ds.SHifts.EndShift).FirstOrDefault(),
                StartShif = doctor.DoctorSHifts.Select(ds => ds.SHifts.StartShift).FirstOrDefault()
            }).FirstOrDefault();
 
        
    }

        public void Save(DoctorVm entity)
        {
            try
            {
                var clinicModel = Doctor.Clone(entity);

                if (entity.Id == null || entity.Id == default)
                {
                    _BaseServess._context.Doctor.Add(clinicModel);
                }
                else
                {
                    _BaseServess._context.Doctor.Update(clinicModel);
                }

                _BaseServess.ContexSaveChang();
            }
            catch (Exception ex)
            {

            }
        }

     

 
public IPagedList<DoctorVm> Search(DoctorVm doctorSm)
    {
        int pageNum = doctorSm.PagNumber ?? 1;

        var query = _BaseServess._context.Doctor
            .Include(doctor => doctor.DoctorSHifts)
                .ThenInclude(doctorShifts => doctorShifts.SHifts)
            .Where(doctor =>
                (doctorSm.FilterBy == null || doctor.Name.Contains(doctorSm.FilterBy)||
                doctor.Address.Contains(doctorSm.FilterBy)
                || doctor.NationalID.Contains(doctorSm.FilterBy)
               || doctor.Specialty.Contains(doctorSm.FilterBy)));

         var result = query.Select(doctor => new DoctorVm
        {
            Id = doctor.Id,
            Specialty = doctor.Specialty,
            Address = doctor.Address,
            NationalID = doctor.NationalID,
            Name = doctor.Name,
            Age = doctor.Age,
            Birthdate = doctor.Birthdate,
            Salary = doctor.Salary,
             Gender = doctor.Gender,
             Email = doctor.Email,
             Title = doctor.Title,
             HiringDate = doctor.HiringDate,
             Endshift = doctor.DoctorSHifts.Select(ds => ds.SHifts.EndShift).FirstOrDefault(),
             StartShif= doctor.DoctorSHifts.Select(ds => ds.SHifts.StartShift).FirstOrDefault()
        }).Distinct();  

        return Pagination(result, pageNum);
    }

     
}
}
