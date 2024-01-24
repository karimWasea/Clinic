using Clincic.DataAccesslayer;

using Clinic.Abstract;

namespace Clinic.Service
{
    public class UnitOfWork : IUnitOfWork
    {
 
        public readonly ApplicationDBcontext _context;
        public IlookupServess _lookupServess { get; }

        public UnitOfWork(lookupServess  lookupServess) {



            _lookupServess=lookupServess;
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
