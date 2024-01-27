using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinicss.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum Visisttype
    {
        [Display(Name = "Regular Checkup")]
        RegularCheckup,

        [Display(Name = "Emergency")]
        Emergency,

        [Display(Name = "Follow-Up")]
        FollowUp
    }

    public enum VisitStatus
    {
        [Display(Name = "Scheduled")]
        Scheduled,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "Completed")]
        Completed,

        [Display(Name = "Canceled")]
        Canceled
    }

    public enum Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female,

        [Display(Name = "Other")]
        Other
    }

}
