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

        public VisitServess(BaseServess baseServess)

        {


            _BaseServess = baseServess;
        }
        public VisitsVm GetById(Guid Id)
        {
            try
            {
                var Visits = _BaseServess._context.Visits.Include(p => p.Patient)
                    .Where(Visit => Visit.Id == Id)
                    .Select(Visit => new VisitsVm
                    {
                        Id = Visit.Id,
                        Address = Visit.Patient.Address,
                        Email = Visit.Patient.Email,
                        Age = Visit.Patient.Age,
                        Name = Visit.Patient.Name,
                        PhoneNumber = Visit.Patient.PhoneNumber,
                        Gender = Visit.Patient.Gender,
                        NationalID = Visit.Patient.NationalID,
                        Birthdate = Visit.Patient.Birthdate,
                        Visisttype = Visit.Visisttype,
                        VisitStutus = Visit.VisitStutus,
                        VisitsApientment = Visit.VisitsApientment,
                        patientid = Visit.Patient.Id,



                    })
                    .FirstOrDefault();





                return Visits;
            }
            catch (Exception ex)
            {
                return new();
            }







        }
            public void Save(VisitsVm entity)
        {
            try
            {
 
                var VisitsModel = Visits.Clone(entity);

                if (entity.Id == null || entity.Id == default)
                {
                    _BaseServess._context.Visits.Add(VisitsModel);
                }
                else
                {
                    _BaseServess._context.Visits.Update(VisitsModel);
                }

                _BaseServess.ContexSaveChang();
            }
            catch (Exception ex)
            {

            }
        }

     

 
public IPagedList<VisitsVm> Search(VisitsVm VisitSm)
    {
        int pageNum = VisitSm.PagNumber ?? 1;

        var query = _BaseServess._context.Visits.Include(p => p.Patient)
            .Where(Visit =>
                (VisitSm.Name == null || Visit.Patient.Name.Contains(VisitSm.Name))
                && (VisitSm.Address == null || Visit.Patient.Address.Contains(VisitSm.Address))
                && (VisitSm.NationalID == null || Visit.Patient.NationalID.Contains(VisitSm.NationalID)));

         var result = query.Select(Visit => new VisitsVm
         {
             Id = Visit.Id,
             Address = Visit.Patient.Address,
             Email = Visit.Patient.Email,
             Age = Visit.Patient.Age,
             Name = Visit.Patient.Name,
             PhoneNumber = Visit.Patient.PhoneNumber,
             Gender = Visit.Patient.Gender,
             NationalID = Visit.Patient.NationalID,
             Birthdate = Visit.Patient.Birthdate,
             Visisttype = Visit.Visisttype,
             VisitStutus = Visit.VisitStutus,
             VisitsApientment = Visit.VisitsApientment,
             patientid = Visit.Patient.Id,
         }).Distinct();  

        return Pagination(result, pageNum);
    }

     
}
}
