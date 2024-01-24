using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Abstract
{
    public interface IlookupServess
    {
        public List<SelectListItem> AvailableAppointments(Guid doctorId, int chosenDayOffset = 5);

    }
}
