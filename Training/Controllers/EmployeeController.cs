using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Training.Models;

namespace Training.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext context;

        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            //List<Employee> employees = context.Employees.ToList();
            var employees = (from employee in context.Employees
                             join department in context.Departments on employee.DepartmentId equals department.IdDepartment
                             select new Employee
                             {
                                 EmployeeId = employee.EmployeeId,
                                 UserName = employee.UserName,
                                 Gender = employee.Gender,
                                 City = employee.City,
                                 DepartmentId = employee.DepartmentId,
                                 DepartmentName = department.NameDeparment
                             }).ToList();
            return View(employees);
        }
        public ActionResult Details(int id)
        {
            var employees = (from employee in context.Employees
                             join department in context.Departments on employee.DepartmentId equals department.IdDepartment
                             where employee.EmployeeId == id
                             select new Employee
                             {
                                 EmployeeId = employee.EmployeeId,
                                 UserName = employee.UserName,
                                 Gender = employee.Gender,
                                 City = employee.City,
                                 DepartmentId = employee.DepartmentId,
                                 DepartmentName = department.NameDeparment
                             }).ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Departments = this.context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepartmentName");
            ModelState.Remove("Department");
            if(ModelState.IsValid)
            {
                context.Employees.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.context.Departments.ToList();
            return View();
        }

        public ActionResult Edit(int id)
        {
            Employee employee = context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            ViewBag.Departments = this.context.Departments.ToList();
            return View("Create", employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepartmentName");
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                context.Employees.Update(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.context.Departments.ToList();
            return View("Create", model);
        }
    }
}
