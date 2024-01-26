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
        public IVisits _Visits { get; }
        public ISHifts _Shifts { get; }
        public IDoctorSHifts _doctotshifts { get; }
        public IPatient _patient { get; }

        public UnitOfWork(ApplicationDBcontext  dBcontext,lookupServess lookupServess
            , BaseServess baseServess , 
            
            ClinicServess clinicServess , DoctorShiftervess doctorSHifts,
            DoctorServess doctorServess  , VisitServess visitServess ,SHiftsServess sHiftsServess , PatienteServess patienteServess) {
            _Clinic = clinicServess;
            _BaseServess = baseServess; 
             _context = dBcontext;
            _Idoctor = doctorServess;
            _lookupServess =lookupServess;
            _Visits = visitServess;
            _Shifts = sHiftsServess;
            _doctotshifts = doctorSHifts;
            _patient = patienteServess;    


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
