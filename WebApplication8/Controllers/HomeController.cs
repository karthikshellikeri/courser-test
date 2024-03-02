using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Employee> employees = new EmpBAL().FetchEmployees();

            return View(employees);
        }

        public ActionResult Insert(Employee e)
        {
            Employee emp = new Employee();
            emp.EmpID = e.EmpID;
            emp.EmpName = e.EmpName;
            emp.Gender = e.Gender;
            emp.IsActive = e.IsActive;
            emp.JobCode = e.JobCode;
            emp.ProjectID = e.ProjectID;
            emp.DOB = e.DOB;
            emp.DOJ = e.DOJ;

            bool r = new EmpBAL().InsertEmployee(emp);

            return View(r);



        }
    }
}