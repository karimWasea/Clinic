

using Clinicss.Models;

namespace Clincic.DataAccesslayer
{
    public partial class DoctorSHifts  
    {

        public static DoctorSHifts Clone(DoctorSHiftsVm DoctorSHiftsVm) {


            return new DoctorSHifts
            { 
             Id = DoctorSHiftsVm.Id,
              DoctorId = DoctorSHiftsVm.DoctorId
               , SHiftsId = DoctorSHiftsVm.SHiftsId,





            };
       
       }

    }
}
