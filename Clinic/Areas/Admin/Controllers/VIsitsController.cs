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
        public ActionResult CreatApiontment(Guid VistId , Guid Doctorid , Guid   patientid)
        {


            if ((VistId == null || VistId == default) && patientid== Guid.Empty)
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
            else if(VistId != Guid.Empty|| VistId != default)
            {
              
                var UpdatedVisit = _UnitOfWork._Visits.GetById(VistId);
                UpdatedVisit.ALLApintmentSlots = _apintmentSlots.AvailableAppointments(Doctorid);
                UpdatedVisit.doctorName = _UnitOfWork._doctotshifts.GetdoctorName(Doctorid);
                UpdatedVisit.ALLVisitStutus = _UnitOfWork._lookupServess.VisitStutus();
                UpdatedVisit.ALLVisisttype = _UnitOfWork._lookupServess.VisitType();
                UpdatedVisit.gender = _UnitOfWork._lookupServess.Gender();
                 return View(UpdatedVisit);


            } 
            else
            {

                var ExistePatient = _UnitOfWork._patient.GetById(patientid);
                ExistePatient.ALLApintmentSlots = _apintmentSlots.AvailableAppointments(Doctorid);
                ExistePatient.doctorName = _UnitOfWork._doctotshifts.GetdoctorName(Doctorid);
                ExistePatient.ALLVisitStutus = _UnitOfWork._lookupServess.VisitStutus();
                ExistePatient.ALLVisisttype = _UnitOfWork._lookupServess.VisitType();
                ExistePatient.gender = _UnitOfWork._lookupServess.Gender();
                ExistePatient.doctorid = Doctorid;
                return View(ExistePatient);

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
