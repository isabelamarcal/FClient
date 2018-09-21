using FClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FClient.Controllers
{
    public class EstablishmentController : Controller
    {

        private EstablishmentRepository repository = new EstablishmentRepository();

        // GET: Establishment
        public ActionResult Index()
        {
            try
            {
                return View(repository.GetAll());

            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return HttpNotFound();

            }
        }

        // GET: Establishment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Establishment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Establishment/Create
        [HttpPost]
        public ActionResult Create(Establishment establishment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Save(establishment);
                    return RedirectToAction("Index");
                }
                else {
                    return View(establishment);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Establishment/Edit/5
        public ActionResult Edit(int id)
        {
            var establishment = repository.GetById(id);

            if (establishment == null)
            {
                return HttpNotFound();
            }

            return View(establishment);
        }

        // POST: Establishment/Edit/5
        [HttpPost]
        public ActionResult Edit(Establishment establishment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Update(establishment);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(establishment);
                }
            }
            catch
            {
                return View();
            }
        }

      

        // POST: Establishment/Delete/5
        [HttpPost]
        public ActionResult Delete(Establishment establishment)
        {
            try
            {
                repository.Delete(establishment);
                return Json(repository.GetAll());
                
            }
            catch
            {
                return View();
            }
        }
    }
}
