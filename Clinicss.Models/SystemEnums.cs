using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinicss.Models
{
    public enum VisitType
    {
        RegularCheckup,
        Emergency,
        FollowUp,
    }

    public enum VisitStatus
    {
        Scheduled,
        InProgress,
        Completed,
        Canceled,
    }
    public enum Gender
    {
        Male, femail, other
    }
}
