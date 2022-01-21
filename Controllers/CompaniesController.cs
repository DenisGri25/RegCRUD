using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegCRUD.Models;

namespace RegCRUD.Controllers
{
    public class CompaniesController : Controller
    {

        private CompaniesDataAccessLayer _companiesDataAccessLayer = null;

        public CompaniesController()
        {
            _companiesDataAccessLayer = new CompaniesDataAccessLayer();
        }
        
        // GET: CompaniesController
        public ActionResult Index()
        {
            var companies = _companiesDataAccessLayer.GetAllCompanies();
            return View(companies);
        }

        // GET: CompaniesController/Details/5
        public ActionResult Details(int id)
        {
            var companies = _companiesDataAccessLayer.GetCompaniesData(id);
            return View(companies);
        }

        // GET: CompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Companies companies)
        {
            try
            {
                _companiesDataAccessLayer.AddCompanies(companies);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            var companies = _companiesDataAccessLayer.GetCompaniesData(id);
            return View(companies);
        }

        // POST: CompaniesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Companies companies)
        {
            try
            {
                _companiesDataAccessLayer.UpdateCompanies(companies);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            var companies = _companiesDataAccessLayer.GetCompaniesData(id);
            return View(companies);
        }

        // POST: CompaniesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Companies companies)
        {
            try
            {
                _companiesDataAccessLayer.DeleteCompanies(companies.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
