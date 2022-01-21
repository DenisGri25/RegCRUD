using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegCRUD.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RegCRUD.Controllers
{
    public class EmployeesController : Controller
    {

        private EmployeesDataAccessLayer _employeesDataAccessLayer = null;

        public EmployeesController()
        {
            _employeesDataAccessLayer = new EmployeesDataAccessLayer();
        }
        
        // GET: EmployeesController
        public ActionResult Index()
        {
            var employees = _employeesDataAccessLayer.GetAllEmployee();  
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            var employees = _employeesDataAccessLayer.GetEmployeesData(id);
            return View(employees);
        }


        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employees employee)
        {
            try
            {
                _employeesDataAccessLayer.AddEmployees(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var employees = _employeesDataAccessLayer.GetEmployeesData(id);  
            return View(employees);  
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employees employees)
        {
            try
            {
                _employeesDataAccessLayer.UpdateEmployees(employees);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            var employees = _employeesDataAccessLayer.GetEmployeesData(id);
            return View(employees);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employees employees)
        {
            try
            {
                _employeesDataAccessLayer.DeleteEmployees(employees.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
