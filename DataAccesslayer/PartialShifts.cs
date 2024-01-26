

using Clinicss.Models;

namespace Clincic.DataAccesslayer
{
    public partial class SHifts 
    {

        public static SHifts Clone(SHiftsVm SHiftsVm ){


            return new SHifts
            { 
             Id = SHiftsVm.Id,
                 EndShift = SHiftsVm.EndShift,
                  Name = SHiftsVm.Name,
                   StartShift = SHiftsVm.StartShift,    




            };
       
       }

    }
}
