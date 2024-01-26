namespace Clinicss.Models
{
    public class ClinicVm : BaseVM
    {
        public string clinicName { get; set; }
        public int numberOfDoctors { get; set; }
        public bool isOpen { get; set; }
        public string location { get; set; }

    }
}
