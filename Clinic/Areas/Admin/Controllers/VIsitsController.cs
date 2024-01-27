using Clincic.DataAccesslayer;

using Clinic.Abstract;
using Clinic.Service;

using Clinicss.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Utalieties;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class VIsitsController : Controller
    {
      private  IUnitOfWork _UnitOfWork;
       private  ApintmentSlots _apintmentSlots;

        public VIsitsController(UnitOfWork unitOfWork , ApintmentSlots apintmentSlots  )

        {
             _apintmentSlots = apintmentSlots;
            _UnitOfWork = unitOfWork;
        }
        // GET: ClinicController
        public IActionResult Index(int? page, string FilterBy)
        {
            var VisitsVm = new VisitsVm();
            VisitsVm.FilterBy = FilterBy;
            VisitsVm.PagNumber = page;
            return View(_UnitOfWork._Visits.Search(VisitsVm));
        }



        // GET: ClinicController/Create
        public ActionResult CreatApiontment(Guid id , Guid Doctorid)
        {


            if (id == null || id == default)
            {
                var AddVisit = new VisitsVm();
                AddVisit.ALLApintmentSlots = _apintmentSlots.AvailableAppointments(Doctorid);
                AddVisit.ALLVisitStutus = _UnitOfWork._lookupServess.VisitStutus( );
                AddVisit.ALLVisisttype = _UnitOfWork._lookupServess.VisitType( );
                AddVisit.gender = _UnitOfWork._lookupServess.Gender();
                AddVisit.doctorName =_UnitOfWork._doctotshifts.GetdoctorName(Doctorid);
                AddVisit.doctorid = Doctorid;
                return View(AddVisit);

            }
            else
            {
                var UpdatedVisit = _UnitOfWork._Visits.GetById(id);
                UpdatedVisit.ALLApintmentSlots = _apintmentSlots.AvailableAppointments(Doctorid);
                UpdatedVisit.doctorName = _UnitOfWork._doctotshifts.GetdoctorName(Doctorid);

                UpdatedVisit.ALLVisitStutus = _UnitOfWork._lookupServess.VisitStutus();
                UpdatedVisit.ALLVisisttype = _UnitOfWork._lookupServess.VisitType();
                UpdatedVisit.gender = _UnitOfWork._lookupServess.Gender();
                //UpdatedVisit.doctorid = Doctorid;
                return View(UpdatedVisit);


            }
        }

        // POST: ClinicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatApiontment(VisitsVm  visitsVm)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    _UnitOfWork._Visits.Save( visitsVm);
                    TempData["Message"] = $" Successfully {visitsVm.VisitStutus}";
                    TempData["MessageType"] = "Save";

                    return RedirectToAction(nameof(Index));

                }
                visitsVm.ALLVisitStutus = _UnitOfWork._lookupServess.VisitStutus();
                visitsVm.ALLVisisttype = _UnitOfWork._lookupServess.VisitType();
                visitsVm.gender = _UnitOfWork._lookupServess.Gender();
                //visitsVm.doctorName = _UnitOfWork._doctotshifts.GetdoctorName(Doctorid);

                visitsVm.ALLApintmentSlots = _apintmentSlots.AvailableAppointments(visitsVm.doctorid);
 
                return View(visitsVm);

            }
            catch
            {
                return View();
            }
        }








    }





}
