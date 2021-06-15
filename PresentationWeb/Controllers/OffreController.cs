using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;

namespace Fr.EQL.AI109.Tontapat.PresentationWeb.Controllers
{
    public class OffreController : Controller
    {
        public IActionResult Index()
        {
            // Model : List of offres
            OffreBU bu = new();
            List<OffreDetail> od = bu.GetAllWithDetails();           
            return View(od);
        }

        public IActionResult Recherche()
        {
            // Model : List of offres
            TerrainBU tbu = new();
            List<Terrain> terrains = tbu.GetAllByUtilisateurId(1);
            ViewBag.Terrains = terrains;
            EspeceBU ebu = new();
            List<Espece> especes = ebu.GetAll();
            ViewBag.Especes = especes;
            return View();
        }

        public IActionResult ResultatRecherche()
        {
            TerrainBU tbu = new();
            List<Terrain> terrains = tbu.GetAllByUtilisateurId(1);
            ViewBag.Terrains = terrains;
            EspeceBU ebu = new();
            List<Espece> especes = ebu.GetAll();
            ViewBag.Especes = especes;
            TypeTonteBU ttbu = new();
            List<TypeTonte> tontes = ttbu.GetAll();
            ViewBag.Tontes = tontes;
            return View();
        }

    }
}
