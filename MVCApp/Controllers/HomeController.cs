using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DataLibrary.BusinessLogic;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee sign up.";
            return View();
        }

        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Here are some folks who work here.";
            var data = EmployeeProcessor.LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var row in data)
            {
                var em = new EmployeeModel
                {
                    employeeID = row.employeeID,
                    firstName=row.firstName,
                    lastName=row.lastName,
                    emailAddress=row.Email,
                    confirmEmail=row.Email
                };
                employees.Add(em);
            }
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                int recordsCreated =  EmployeeProcessor.CreateEmployee(model.employeeID, model.firstName, model.lastName, model.emailAddress);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}