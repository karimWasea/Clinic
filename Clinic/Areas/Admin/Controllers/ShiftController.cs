using Clinic.Abstract;
 using Clinic.Service;

using Clinicss.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ShiftController : Controller
    {
        IUnitOfWork _UnitOfWork;

        public ShiftController(UnitOfWork unitOfWork ) 
        
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
                return View(_UnitOfWork._Shifts.GetById(id));


            }
        }

        // POST: ClinicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SHiftsVm  sHiftsVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    _UnitOfWork._Shifts.Save(sHiftsVm);
                    TempData["Message"] = $" Successfully :{sHiftsVm.Name}";
                    TempData["MessageType"] = "Save";

                    return View();

                }
                return View(sHiftsVm);

            }
            catch
            {
                return View();
            }
        }
 
         
      


             

 
    }

 



}
