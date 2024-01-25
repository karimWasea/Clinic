using Clinic.Models.VModels;

namespace Clincic.DataAccesslayer
{
    public  partial class Clinic  
    {

       public static Clinic Clone(ClinicVm clinicVm) {


            return new Clinic { 
             Id = clinicVm.Id,
                 clinicName = clinicVm.clinicName,
                  isOpen = clinicVm.isOpen, 
                    numberOfDoctors = clinicVm.numberOfDoctors,
                     location = clinicVm.location   




            };
       
       }

    }
}
