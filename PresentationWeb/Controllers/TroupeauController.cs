using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.PresentationWeb.Controllers
{
    public class TroupeauController : Controller
    {
      
        [Route("Mestroupeau/Details/{id:int}")]
        public ActionResult Index(int id)
        {
            UtilisateurBU ubu = new();
            UtilisateurDetail ud = ubu.GetAllWithDetailById(id);

            return View(ud);
        }

        // GET: TroupeauController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TroupeauController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TroupeauController/Create
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

        // GET: TroupeauController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TroupeauController/Edit/5
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

        // GET: TroupeauController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TroupeauController/Delete/5
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
