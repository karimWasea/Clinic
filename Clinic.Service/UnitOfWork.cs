using Clincic.DataAccesslayer;

using Clinic.Abstract;

namespace Clinic.Service
{
    public class UnitOfWork : IUnitOfWork
    {
 
        public readonly ApplicationDBcontext _context;
        public IlookupServess _lookupServess { get; }
        public IBaseServess _BaseServess { get; }
        public IClinic _Clinic { get; }
        public Idoctor _Idoctor { get; }

        public UnitOfWork(ApplicationDBcontext  dBcontext,lookupServess lookupServess , BaseServess baseServess , ClinicServess clinicServess , DoctorServess doctorServess) {
            _Clinic = clinicServess;
            _BaseServess = baseServess; 
             _context = dBcontext;
            _Idoctor = doctorServess;
            _lookupServess =lookupServess;
        }





        #region Implement the Dispose method to release resources
        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




        // Implement the finalizer to release unmanaged resources
        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion

    }
}
