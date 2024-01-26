 
namespace Clinic.Abstract;
 
    public interface IUnitOfWork : IDisposable
{
    IlookupServess _lookupServess { get; }
     IBaseServess _BaseServess { get; }
     IClinic _Clinic { get; }
  
 
    }










