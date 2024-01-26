

using Clinicss.Models;

namespace Clincic.DataAccesslayer
{
    public partial class Patient  
    {

        public static Patient Clone(VisitsVm VisitsVm) {


            return new Patient
            { 
             Id = VisitsVm.Id,
                  Address = VisitsVm.Address,    
                Age = VisitsVm.Age,       
                Birthdate = VisitsVm.Birthdate,
                 Name = VisitsVm.Name,
                  Email = VisitsVm.Email,   
                   Gender = VisitsVm.Gender 
                      , NationalID = VisitsVm.NationalID,   
                    PhoneNumber = VisitsVm.PhoneNumber
                
                  



            };
       
       }

    }
}
