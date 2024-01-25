namespace Clincic.DataAccesslayer
{
    public   partial class Clinic : BaseEntity
    {

        public string clinicName{ get; set; }
        public int numberOfDoctors { get; set; }
        public bool isOpen { get; set; }
        public string location { get; set; }
        public virtual ICollection<Doctor>  Doctors { get; set; }

    }
}
