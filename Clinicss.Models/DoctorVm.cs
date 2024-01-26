using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

 
namespace Clinicss.Models
{
    public class DoctorVm : BaseVM
    {
        public IEnumerable<SelectListItem> listGender { get; set; } = Enumerable.Empty<SelectListItem>();
        [Required(ErrorMessage = "is requred")]
        public string Name { get; set; }
        [Required(ErrorMessage = "is requred")]

        public int Age { get; set; }

        [Required(ErrorMessage = "is requred")]

        public string Address { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string NationalID { get; set; }
        [Required(ErrorMessage = "is requred")]

        public DateTime Birthdate { get; set; }
 
        public DateTime StartShif { get; set; }
        public DateTime Endshift { get; set; }
        [Required(ErrorMessage = "is requred")]

        public Gender Gender { get; set; }
        [Required(ErrorMessage = "is requred")]

        public decimal Salary { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string Title { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string phonenumber { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string Email { get; set; }
        [Required(ErrorMessage = "is requred")]

        public DateTime HiringDate { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string Specialty { get; set; }
      }


    
}
