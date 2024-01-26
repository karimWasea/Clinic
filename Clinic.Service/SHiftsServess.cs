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

public class SHiftsServess : PaginationHelper<SHiftsVm>, ISHifts

{
    BaseServess _BaseServess { get; set; }
        
        
        public SHiftsServess(  BaseServess baseServess) 
    
    {  


        _BaseServess = baseServess;
    }
    public void Save(SHiftsVm SHiftsVm)
    {
        try
        {
            var SHiftsModel = SHifts.Clone(SHiftsVm);

            if (SHiftsVm.Id == null || SHiftsVm.Id==default)
            {
                _BaseServess._context.SHifts.Add(SHiftsModel);
            }
            else
            {
               _BaseServess. _context.SHifts.Update(SHiftsModel);
            }

            _BaseServess.ContexSaveChang();
        }
        catch (Exception ex)
        {
          
        }
    }

    public SHiftsVm GetById(Guid Id)
    { 
            try
            {
                var SHifts = _BaseServess._context.SHifts
                    .Where(SHift => SHift.Id == Id)
                    .Select(SHift => new SHiftsVm
                    {
                        Id = SHift.Id,
                         Name = SHift.Name,
                          EndShift =    SHift.EndShift,
                           StartShift = SHift.StartShift
                      
                    })
                    .FirstOrDefault();


     


                return SHifts;
            }
            catch (Exception ex)
            {
            return new ();

        }



    }

}

