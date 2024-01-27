using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Abstract
{
    public interface IlookupServess
    {
        public List<SelectListItem> Gender();

         public List<SelectListItem> VisitStutus();
        public List<SelectListItem> VisitType( );
        public IQueryable<SelectListItem> AllCliniCs();
        public IQueryable<SelectListItem> AllShifts();


    }
}
