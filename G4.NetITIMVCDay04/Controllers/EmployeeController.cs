using G4.NetITIMVCDay04.Context;
using G4.NetITIMVCDay04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace G4.NetITIMVCDay04.Controllers
{
    public class EmployeeController : Controller
    {
        /*---------------------------------------------------------*/
        // Context
        CompanyContext companyContext = new CompanyContext();
        /*---------------------------------------------------------*/
        // Index - List of All Employees
        [HttpGet]
        public IActionResult Index()
        {
            var employees = companyContext.Employees.Include(emp => emp.Department);
            return View(employees);
        }
        /*---------------------------------------------------------*/
        // View Details - View Details of a specific Employee
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var employee = companyContext.Employees.Include(emp => emp.Department).FirstOrDefault(e => e.Id == id);
            if(employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        /*---------------------------------------------------------*/
        // Create - Get Method to show the form for creating a new Employee
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(companyContext.Departments, "Id", "DeptName");
            return View();
        }
        /*---------------------------------------------------------*/
        // Create - Post method to save a new Employee (Add To Data Base)
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            companyContext.Employees.Add(employee);
            companyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        // Edit - Get method to show the form for editing an employee
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }
            var employee = companyContext.Employees.Include(e => e.Department).FirstOrDefault(emp => emp.Id == id);
            if(employee == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(companyContext.Departments, "Id", "DeptName");
            return View(employee);
        }
        /*---------------------------------------------------------*/
        // Edit - Post method to save changes to an existing empyloyee
        [HttpPost]
        public IActionResult Edit(Employee employee) 
        {
            var oldEmployee = companyContext.Employees.FirstOrDefault(emp => emp.Id == employee.Id);
            if (oldEmployee == null)
            {
                return RedirectToAction("Index");
            }
            oldEmployee.Name = employee.Name;
            oldEmployee.Salary = employee.Salary;
            oldEmployee.Age = employee.Age;
            oldEmployee.DepartmentId = employee.DepartmentId;
            companyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        // Delete - Get method to confirm deletion of an Employee
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }
            var employee = companyContext.Employees.Include(e => e.Department).FirstOrDefault(emp => emp.Id == id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        /*---------------------------------------------------------*/
        // Delete - Post method to delete of an Employee
        [HttpPost]
        public IActionResult Delete(int id, string confirm)
        {
            if(confirm == "Yes")
            {
                var employee = companyContext.Employees.Include(e => e.Department).FirstOrDefault(emp => emp.Id == id);
                if (employee == null)
                {
                    return RedirectToAction("Index");
                }
                companyContext.Employees.Remove(employee);
                companyContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
    }
}
