using Clinic.Abstract;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service;
using Clincic.DataAccesslayer;

using Clinicss.Models;

using Utalieties;

public class DoctorShiftervess : PaginationHelper<DoctorSHiftsVm>, IDoctorSHifts

{
    BaseServess _BaseServess { get; set; }
    Idoctor _doctor { get; set; }
        
        
        public DoctorShiftervess(  BaseServess baseServess , DoctorServess doctorServess ) 
    
    {

        _doctor= doctorServess; 
        _BaseServess = baseServess;
    }
    public void Save(DoctorSHiftsVm  doctorSHiftsVm)
    {
        try
        {
            var DoctorSHift = DoctorSHifts.Clone(doctorSHiftsVm);

            if (doctorSHiftsVm.Id == null || doctorSHiftsVm.Id==default)
            {
                _BaseServess._context.DoctorSHifts.Add(DoctorSHift);
            }
            else
            {
               _BaseServess. _context.DoctorSHifts.Update(DoctorSHift);
            }

            _BaseServess.ContexSaveChang();
        }
        catch (Exception ex)
        {
          
        }
    }
    public string GetdoctorName(Guid Doctorid)
    {


        return  _BaseServess._context.Doctor.SingleOrDefault(Doctor=>Doctor.Id== Doctorid).Name;
    }

    public DoctorSHiftsVm GetById(Guid Id)
    { 
            try
            {
                var DoctorSHifts = _BaseServess._context.DoctorSHifts
                    .Where(DoctorSHifts => DoctorSHifts.Id == Id)
                    .Select(DoctorSHifts => new DoctorSHiftsVm
                    {
                        Id = DoctorSHifts.Id,
                         DoctorId = DoctorSHifts.DoctorId,

                          SHiftsId = DoctorSHifts.SHiftsId,

                    })
                    .FirstOrDefault();


     


                return DoctorSHifts;
            }
            catch (Exception ex)
            {
            return new  ();

        }



    }

}

