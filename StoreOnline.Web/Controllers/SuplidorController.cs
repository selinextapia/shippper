using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreOnline.Web.Models;
using System.Collections.Generic;

namespace StoreOnline.Web.Controllers
{
    public class SuplidorController : Controller
    {
        // GET: SuplidorController
        public ActionResult Index()
        {
            List<Models.Suplidor> suplidores = new List<Models.Suplidor>();

            suplidores.Add(new Models.Suplidor() { id=1, direccion= "Santiago de los Caballeros" , nombre = "Rodrigo", telefono = "809-555-6898"});
            suplidores.Add(new Models.Suplidor() { id=2, direccion= "Santo Domingo Este" , nombre = "Pedro", telefono = "809-555-7848"});

            return View(suplidores);

            
        }

        // GET: SuplidorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuplidorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuplidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuplidorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuplidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuplidorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuplidorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
