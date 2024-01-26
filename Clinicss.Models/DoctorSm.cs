namespace Clinicss.Models
{
    public class DoctorSm : BaseVM
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string NationalID { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        //public Gender Gender { get; set; }

        public string Specialty { get; set; }
        public decimal Salary { get; set; }
        public string Imgpath { get; set; }
        public string Contractpath { get; set; }
    }
}
