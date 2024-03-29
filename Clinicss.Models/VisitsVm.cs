﻿using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Clinicss.Models
{
    public class VisitsVm : BaseVM
    {
        public IEnumerable<SelectListItem> ALLApintmentSlots { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> ALLVisisttype { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> ALLVisitStutus { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> gender { get; set; } = Enumerable.Empty<SelectListItem>();
        [Required(ErrorMessage = "is requred")]

        public DateTime VisitsApientment { get; set; }
        [Required(ErrorMessage = "is requred")]
         
        public Visisttype Visisttype { get; set; }
        [Required(ErrorMessage = "is requred")]

        public VisitStatus VisitStutus { get; set; }

        public string patientName { get; set; }
        public string doctorName { get; set; }
        public string FilterBy { get; set; } =string.Empty;
        [Required(ErrorMessage = "is requred")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a numeric value.")]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]

        public int Age { get; set; }
        [Required(ErrorMessage = "is requred")]

        public Guid patientid { get; set; }
        [Required(ErrorMessage = "is requred")]

        public Guid doctorid { get; set; }
            [Required(ErrorMessage = "is requred")]

        public string Address { get; set; }
        [Required(ErrorMessage = "is requred")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a numeric value.")]
 
        public string NationalID { get; set; }
        [Required(ErrorMessage = "is requred")]
        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Invalid phone number")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "is requred")]

        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "is requred")]

        public Gender Gender { get; set; }
        [Required(ErrorMessage = "is requred")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]


        public string Email { get; set; }
    }


    
}
