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
    public class ManagerController : Controller
    {
        private readonly ManagerServices _managerServices;

        public ManagerController(ManagerServices managerServices)
        {
            _managerServices = managerServices;
        }

        // GET: Manager
        public ActionResult Index()
        {
            var manager = _managerServices.GetAllManager();
            return View(manager);
        }

        // GET: Manager Details
        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var manager = _managerServices.GetManagerId(id);
            if (manager == null) return HttpNotFound();
            return View(manager);
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manager manager)
        {
            if (ModelState.IsValid)
            {
                   
                    // Call the service with the manager object
                    _managerServices.CreateNewManager(manager);
                    return RedirectToAction("Index");
                
             
            }

            return View(manager);
        }

        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var manager = _managerServices.GetManagerId(id);
            if (manager == null) return HttpNotFound();
            return View(manager);
        }

        // POST: Manager/Edit/5
        [HttpPost]
        public ActionResult Edit(Manager manager)
        {
            if (ModelState.IsValid)
            {
                var result = _managerServices.UpdateManager(manager);

                if (result == 1)
                {
                    return RedirectToAction("Index");
                }
                else if (result == 0)
                {
                    return HttpNotFound();
                }
            }

            return View(manager);
        }

        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var manager = _managerServices.GetManagerId(id);
            if (manager == null) return HttpNotFound();
            return View(manager);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _managerServices.DeleteManager(id);
            return RedirectToAction("Index");
        }
    }

}