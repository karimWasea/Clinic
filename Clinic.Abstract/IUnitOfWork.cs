 
namespace Clinic.Abstract;
 
    public interface IUnitOfWork : IDisposable
{
    IlookupServess _lookupServess { get; }
     IBaseServess _BaseServess { get; }
     IClinic _Clinic { get; }
    Idoctor _Idoctor { get; }   
     IVisits _Visits { get; }
     ISHifts _Shifts { get; }   
     IDoctorSHifts _doctotshifts { get; }
     IPatient _patient { get; } 

}










