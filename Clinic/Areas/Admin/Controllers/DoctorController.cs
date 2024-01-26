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
        public IActionResult Index(int? page, string FilterBy)
        {
            var doctrvm = new DoctorVm();
            doctrvm.FilterBy = FilterBy;
            doctrvm.PagNumber = page;
            return View(_UnitOfWork._Idoctor.Search(doctrvm));
        }

      

        // GET: ClinicController/Create
        public ActionResult Save(Guid id )
        {
             

            if (id == null ||id==default)
            { var AddDoctor= new DoctorVm();
                AddDoctor.listGender = _UnitOfWork._lookupServess.Gender();
                AddDoctor.ALLclinecs = _UnitOfWork._lookupServess.AllCliniCs();
                return View(AddDoctor);

            }
            else
            {
                var UpdatedDoctor = _UnitOfWork._Idoctor.GetById(id);
                UpdatedDoctor.listGender = _UnitOfWork._lookupServess.Gender();
                UpdatedDoctor.ALLclinecs = _UnitOfWork._lookupServess.AllCliniCs();
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
               
                if (ModelState.IsValid)
                {
                   
                    _UnitOfWork._Idoctor.Save(doctor);
                    TempData["Message"] = $" Successfully {doctor.Name}";
                    TempData["MessageType"] = "Save";

                    return RedirectToAction(nameof(Index));

                }
                doctor.listGender = _UnitOfWork._lookupServess.Gender();
                doctor.ALLclinecs = _UnitOfWork._lookupServess.AllCliniCs();

                return View(doctor);

            }
            catch
            {
                return View();
            }
        }
 
         
      


             

 
    }

 



}
