using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

 
namespace Clinicss.Models
{
    public class DoctorVm : BaseVM
    {
        public IEnumerable<SelectListItem> listGender { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> ALLclinecs { get; set; } = Enumerable.Empty<SelectListItem>();
        [Required(ErrorMessage = "is requred")]
        public string Name { get; set; }
        [Required(ErrorMessage = "is requred")]
         [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a numeric value.")]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "is requred")]

        public string Address { get; set; }
        [Required(ErrorMessage = "is requred")]
         [RegularExpression(@"^\d+$", ErrorMessage = "NationalID must be a numeric value.")]
        public string NationalID { get; set; }
        public string FilterBy { get; set; } =string.Empty; 
        [Required(ErrorMessage = "is requred")]

        public DateTime Birthdate { get; set; }
 
        public DateTime StartShif { get; set; }
        public DateTime Endshift { get; set; }
        [Required(ErrorMessage = "is requred")]

        public Gender Gender { get; set; }
        [Required(ErrorMessage = "is requred")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a numeric value.")]

        public decimal Salary { get; set; }
        public Guid clinicid { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string Title { get; set; }
        [Required(ErrorMessage = "is requred")]
         [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Invalid phone number")]

        public string phonenumber { get; set; }
        [Required(ErrorMessage = "is requred")]
         [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "is requred")]

        public DateTime HiringDate { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string Specialty { get; set; }
      }


    
}
