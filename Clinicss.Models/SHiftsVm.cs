using System.ComponentModel.DataAnnotations;

namespace Clinicss.Models
{
    public class SHiftsVm : BaseVM
    {
        [Required(ErrorMessage = "Email is required")]

        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]

        public DateTime StartShift { get; set; }

        public DateTime EndShift { get; set; }

    }
}
