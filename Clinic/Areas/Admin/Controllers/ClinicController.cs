using Clinic.Abstract;
using Clinic.Models.VModels;
using Clinic.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ClinicController : Controller
    {
        IUnitOfWork _UnitOfWork;

        public ClinicController(UnitOfWork unitOfWork ) 
        
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
                return View();


            }
        }

        // POST: ClinicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClinicVm  clinic)
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
