using Clincic.DataAccesslayer;

using Clinic.Abstract;

using Clinicss.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Service
{
    public class lookupServess : IlookupServess
    {

        private readonly ApplicationDBcontext _applicationDBcontext;

        public lookupServess(ApplicationDBcontext _applicationDBcontext)
        {

            this._applicationDBcontext = _applicationDBcontext;


        }




        public List<SelectListItem> Gender()
        {
            return Enum.GetValues(typeof(Gender))
                                   .Cast<Gender>()
                                   .Select(hour => new SelectListItem
                                   {
                                       Value = ((int)hour).ToString(),
                                       Text = hour.ToString()
                                   })
                                   .ToList();
        }

        public IQueryable<SelectListItem>  AllCliniCs()
        {
            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.Clinic.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.clinicName
            }).OrderBy(c => c.Text).AsNoTracking();
            return applicationuser;
        }    
        
        public IQueryable<SelectListItem>  AllShifts()
        {
            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.SHifts.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).OrderBy(c => c.Text).AsNoTracking();
            return applicationuser;
        }
        

        public List<SelectListItem> VisitStutus()
        {
            return Enum.GetValues(typeof(Gender))
                                               .Cast<Visisttype>()
                                               .Select(hour => new SelectListItem
                                               {
                                                   Value = ((int)hour).ToString(),
                                                   Text = hour.ToString()
                                               })
                                               .ToList();
        }

        public List<SelectListItem> VisitType()
        {
            return Enum.GetValues(typeof(Gender))
                                               .Cast<VisitStatus>()
                                               .Select(hour => new SelectListItem
                                               {
                                                   Value = ((int)hour).ToString(),
                                                   Text = hour.ToString()
                                               })
                                               .ToList();
        }
    }
}
