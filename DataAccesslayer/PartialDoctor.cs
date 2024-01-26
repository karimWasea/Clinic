

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

                PhoneNumber = doctor.phonenumber,
                    Gender = doctor.Gender,   
                 Name = doctor.Name,
                NationalID = doctor.NationalID,
                Salary = doctor.Salary,  
                 
                Specialty = doctor.Specialty, 
                 Email = doctor.Email,
                  HiringDate = doctor.HiringDate,
                   Title = doctor.Title
                   , 
                    



            };
       
       }

    }
}
