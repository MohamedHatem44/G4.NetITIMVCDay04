using G4.NetITIMVCDay04.Context;
using Microsoft.AspNetCore.Mvc;

namespace G4.NetITIMVCDay04.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext companyContext = new CompanyContext();
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            var departments = companyContext.Departments;
            return View(departments);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var department = companyContext.Departments.Find(id);
            //if (department == null)
            //{
            //    return NotFound();
            //}
            if (department == null)
            {
                return RedirectToAction("Index");
            }
            return View(department);
        }
        /*---------------------------------------------------------*/
    }
}
