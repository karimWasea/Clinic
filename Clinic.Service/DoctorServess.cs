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
            throw new NotImplementedException();
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
                (doctorSm.Name == null || doctor.Name.Contains(doctorSm.Name))
                && (doctorSm.Address == null || doctor.Address.Contains(doctorSm.Address))
                && (doctorSm.NationalID == null || doctor.NationalID.Contains(doctorSm.NationalID))
                && (doctorSm.Specialty == null || doctor.Specialty.Contains(doctorSm.Specialty)));

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
            Imgpath = doctor.Imgpath,
            Gender = doctor.Gender,
            Contractpath = doctor.Contractpath,
            Endshift = doctor.DoctorSHifts.Select(ds => ds.SHifts.EndShift).FirstOrDefault(),
             StartShif= doctor.DoctorSHifts.Select(ds => ds.SHifts.StartShift).FirstOrDefault()
        }).Distinct();  

        return Pagination(result, pageNum);
    }

     
}
}
