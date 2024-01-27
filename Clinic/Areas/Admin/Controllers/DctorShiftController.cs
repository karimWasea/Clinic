using Clincic.DataAccesslayer;

using Clinic.Abstract;
 using Clinic.Service;

using Clinicss.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DctorShiftController : Controller
    {
        IUnitOfWork _UnitOfWork;

        public DctorShiftController(UnitOfWork unitOfWork ) 
        
        {

            _UnitOfWork = unitOfWork;   
        }   
        // GET: ClinicController
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Save(Guid id , Guid Doctorid)
        {


            if (id == null || id == default)
            {
                var AddDoctorSHiftsVm = new DoctorSHiftsVm();
                AddDoctorSHiftsVm.DoctorId=Doctorid;
                AddDoctorSHiftsVm.DoctorName=_UnitOfWork._doctotshifts.GetdoctorName(Doctorid);
                AddDoctorSHiftsVm.ALLShifts = _UnitOfWork._lookupServess.AllShifts();
                 return View(AddDoctorSHiftsVm);

            }
            else
            {
                var UpdatedDoctorSHiftsVm = _UnitOfWork._doctotshifts.GetById(id);
                UpdatedDoctorSHiftsVm.DoctorName = _UnitOfWork._doctotshifts.GetdoctorName(Doctorid);
                UpdatedDoctorSHiftsVm.ALLShifts = _UnitOfWork._lookupServess.AllShifts();
                return View(UpdatedDoctorSHiftsVm);


            }
        }
        // GET: ClinicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DoctorSHiftsVm  doctorSHiftsVm)
        {
            try
            {
               

                if (ModelState.IsValid)
                {

                    _UnitOfWork._doctotshifts.Save(doctorSHiftsVm);
                    TempData["Message"] = $" Successfully  ";
                    TempData["MessageType"] = "Save";

                    return RedirectToAction(nameof(Index));

                }
                doctorSHiftsVm.DoctorName = _UnitOfWork._doctotshifts.GetdoctorName(doctorSHiftsVm.DoctorId);
                doctorSHiftsVm.ALLShifts = _UnitOfWork._lookupServess.AllShifts();
                return View(doctorSHiftsVm);

            }
            catch
            {
                return View();
            }
        }


  
 
         
      


             

 
    }

 



}
