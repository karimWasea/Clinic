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

      

        // GET: ClinicController/Create
        public ActionResult Save(Guid id )
        {


            if (id == null)
            {
                return View();

            }
            else
            {
                return View(_UnitOfWork._Clinic.GetById(id));


            }
        }

        // POST: ClinicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClinicVm clinic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    _UnitOfWork._Clinic.Save(clinic);
                    TempData["Message"] = $" successfully!";
                    TempData["MessageType"] = "Save";

                    return View();

                }
                return View(clinic);

            }
            catch
            {
                return View();
            }
        }
 
         
      


             

 
    }

 



}
