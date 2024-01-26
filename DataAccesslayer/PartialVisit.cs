

using Clinicss.Models;

namespace Clincic.DataAccesslayer
{
    public partial class Visits  
    {

        public static Visits Clone(VisitsVm VisitsVm) {


            return new Visits
            { 
             Id = VisitsVm.Id,
              Visisttype = VisitsVm.Visisttype,  
               VisitStutus = VisitsVm.VisitStutus,
                VisitsApientment = VisitsVm.VisitsApientment,   

                     
                    



            };
       
       }

    }
}
