using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Dto;
using Fr.EQL.AI109.Tontapat.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.PresentationWeb.Controllers
{
    public class PrestationController : Controller
    {
       

        // GET: PrestationController
        public ActionResult Index()
        {
            PrestationBU pbu = new();
            List<PrestationDetail> pds = pbu.GetAllByUtilisateurId(1);
            return View(pds);
        }

        // GET: PrestationController/Details/5
        public ActionResult Details(int id)
        {
            PrestationBU bu = new();
            PrestationDetail pd = bu.GetWithDetailsById(id);
            return View(pd);
        }

        // GET: PrestationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrestationController/Create
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

        // GET: PrestationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestationController/Edit/5
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

        // GET: PrestationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestationController/Delete/5
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
        [HttpGet]
        public ActionResult Negociation()
        {
            
            PrestationBU pbu = new();
            PrestationDetail pd = pbu.GetWithDetailsById(1);
            TerrainBU tbu = new();
            List<Terrain> terrains = tbu.GetAllByUtilisateurId(pd.IdClient);
            ViewBag.Terrains = terrains;
            EspeceBU ebu = new();
            List<Espece> especes = ebu.GetAll();
            ViewBag.Especes = especes;
            TypeTonteBU ttbu = new();
            List<TypeTonte> tontes = ttbu.GetAll();
            ViewBag.TypesTonte = tontes; 
            return View(pd);
        }

        [HttpPost]
        public IActionResult Negociation(Proposition pr)
        {
            return View("Resultats");
        }
    }
}
