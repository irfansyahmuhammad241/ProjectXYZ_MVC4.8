using ProjectXYZ_MVC4._8.Models;
using ProjectXYZ_MVC4._8.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace ProjectXYZ_MVC4._8.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyServices _companyServices;

        public CompanyController(CompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        // GET: Companies
        public ActionResult Index()
        {
            var companies = _companyServices.GetCompany();
            return View(companies);
        }

        // GET: Companies Details
        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var company = _companyServices.GetCompanyID(id);
            if (company == null) return HttpNotFound();
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
  
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Handle file upload
                    HttpPostedFileBase companyPhoto = Request.Files["CompanyPhoto"];

                    if (companyPhoto != null && companyPhoto.ContentLength > 0)
                    {
                        using (var binaryReader = new BinaryReader(companyPhoto.InputStream))
                        {
                            company.CompanyPhoto = binaryReader.ReadBytes(companyPhoto.ContentLength);
                        }
                    }

                    // Set ApprovalStatus here if needed

                    _companyServices.CreateCompany(company, companyPhoto);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
                }
            }

            return View(company);
        }


        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var company = _companyServices.GetCompanyID(id);
            if (company == null) return HttpNotFound();
            return View(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                var result = _companyServices.UpdateCompany(company);

                if (result == 1)
                {
                    return RedirectToAction("Index");
                }
                else if (result == 0)
                {
                    return HttpNotFound();
                }
            }

            return View(company);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var company = _companyServices.GetCompanyID(id);
            if (company == null) return HttpNotFound();
            return View(company);
        }
    }
}