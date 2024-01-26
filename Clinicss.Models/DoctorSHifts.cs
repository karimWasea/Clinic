using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace Clinicss.Models
{
    public class DoctorSHiftsVm : BaseVM
    {
        public IEnumerable<SelectListItem> ALLShifts { get; set; } = Enumerable.Empty<SelectListItem>();
        [Required(ErrorMessage = "is requred")]

        public Guid DoctorId { get; set; }
        [Required(ErrorMessage = "is requred")]

        public Guid SHiftsId { get; set; }
        public string DoctorName { get; set; }

    }
}
