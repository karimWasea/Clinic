

using Clinicss.Models;

namespace Clincic.DataAccesslayer
{
    public  partial class Doctor  
    {

       public static Doctor Clone(DoctorVm doctor) {


            return new Doctor
            { 
             Id = doctor.Id,
                  Address = doctor.Address,    
                Age = doctor.Age,       
                Birthdate = doctor.Birthdate,  
                
                Contractpath = doctor.Contractpath,
                   Gender = doctor.Gender,   
                Imgpath = doctor.Imgpath   ,
                Name = doctor.Name, NationalID = doctor.NationalID,
                Salary = doctor.Salary,  
                Specialty = doctor.Specialty,    
                    



            };
       
       }

    }
}
