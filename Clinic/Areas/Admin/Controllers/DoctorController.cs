using Clinic.Abstract;
 using Clinic.Service;

using Clinicss.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DoctorController : Controller
    {
        IUnitOfWork _UnitOfWork;

        public DoctorController(UnitOfWork unitOfWork ) 
        
        {

            _UnitOfWork = unitOfWork;   
        }   
        // GET: ClinicController
        public ActionResult Index()
        {
            return View();
        }

      

        // GET: ClinicController/Create
        public ActionResult Save(Guid id )
        {
             

            if (id == null ||id==default)
            { var AddDoctor= new DoctorVm();
                AddDoctor.listGender = _UnitOfWork._lookupServess.Gender();
                return View(AddDoctor);

            }
            else
            {
                var UpdatedDoctor = _UnitOfWork._Idoctor.GetById(id);
                UpdatedDoctor.listGender = _UnitOfWork._lookupServess.Gender();
                return View(UpdatedDoctor);


            }
        }

        // POST: ClinicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DoctorVm   doctor)
        {
            try
            {
                doctor.listGender = _UnitOfWork._lookupServess.Gender();

                if (ModelState.IsValid)
                {
                   
                    _UnitOfWork._Idoctor.Save(doctor);
                    TempData["Message"] = $" Successfully {doctor.Name}";
                    TempData["MessageType"] = "Save";

                    return View();

                }
                return View(doctor);

            }
            catch
            {
                return View();
            }
        }
 
         
      


             

 
    }

 



}
