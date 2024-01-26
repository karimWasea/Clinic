using Microsoft.AspNetCore.Mvc.Rendering;

using System.Reflection;

namespace Clinicss.Models
{
    public class VisitsVm : BaseVM
    {
        public IEnumerable<SelectListItem> ALLApintmentSlots { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> ALLVisisttype { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> ALLVisitStutus { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> gender { get; set; } = Enumerable.Empty<SelectListItem>();

        public DateTime VisitsApientment { get; set; }

        // Navigation property for many-to-many relationship
        public Visisttype Visisttype { get; set; }
        public VisitStatus VisitStutus { get; set; }
        public string patientName { get; set; }
        public string doctorName { get; set; }
        public string FilterBy { get; set; } =string.Empty;
        public int Age { get; set; }
        public Guid patientid { get; set; }
        public Guid doctorid { get; set; }
        public string Address { get; set; }
        public string NationalID { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }

        public string Email { get; set; }
    }


    
}
