using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Models.VModels
{
    public    class ClinicVm : BaseVM
    {
        public string clinicName { get; set; }
        public int numberOfDoctors { get; set; }
        public bool isOpen { get; set; }
        public string location { get; set; }
         
    }
}
