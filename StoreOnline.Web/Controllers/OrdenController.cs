using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StoreOnline.Web.Controllers
{
    public class OrdenController : Controller
    {
        // GET: OrdenController
        public ActionResult Index()
        {
            List<Models.Orden> Orden = new List<Models.Orden>();

            Orden.Add(new Models.Orden() { IdOrden = 2050, IdCliente = 3022, DireccionCliente = "Av. Maximo Gomez", CiudadCliente = "Villa Mella" });

            return View(Orden);
        }

        // GET: OrdenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenController/Create
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

        // GET: OrdenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenController/Edit/5
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

        // GET: OrdenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenController/Delete/5
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
