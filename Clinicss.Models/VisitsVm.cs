using System.Reflection;

namespace Clinicss.Models
{
    public class VisitsVm : BaseVM
    {
          
            public DateTime VisitsApientment { get; set; }

            // Navigation property for many-to-many relationship
            public VisitStutus Visisttype { get; set; }
            public VisitStutus VisitStutus { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid patientid { get; set; }
        public string Address { get; set; }
        public string NationalID { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }

        public string Email { get; set; }
    }


    
}
