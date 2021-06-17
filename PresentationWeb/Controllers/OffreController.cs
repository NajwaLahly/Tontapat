using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;
using Fr.EQL.AI109.Tontapat.Dto;

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
        [HttpGet]
        public IActionResult Recherche()
        {
            // Model : List of offres
            TerrainBU tbu = new();
            List<Terrain> terrains = tbu.GetAllByUtilisateurId(1);
            ViewBag.Terrains = terrains;

            EspeceBU ebu = new();
            List<Espece> especes = ebu.GetAll();
            ViewBag.Especes = especes;

            TypeTonteBU ttbu = new();
            List<TypeTonte> typesTonte = ttbu.GetAll();
            ViewBag.TypesTonte = typesTonte;

            FreqInterventionBU fibu = new();
            List<FreqIntervention> freqsIntervention = fibu.GetAll();
            ViewBag.FreqsIntervention = freqsIntervention;

            return View();
        }
        [HttpPost]
        public IActionResult Recherche(RechercheOffreDto rod)
        {
            OffreBU ob = new();
            List<OffreDetail> resultats = ob.RechercherOffre(rod);
            ViewBag.Rod = rod;
            return View("Resultats",resultats);
        }

        public IActionResult Details(int id)
        {
            EspeceBU ebu = new();
            List<Espece> especes = ebu.GetAll();
            ViewBag.Especes = especes;

            TypeTonteBU ttbu = new();
            List<TypeTonte> typesTonte = ttbu.GetAll();
            ViewBag.TypesTonte = typesTonte;

            TerrainBU t = new();
            List<Terrain> terrains = t.GetAllByUtilisateurId(1); ;
            ViewBag.Terrains = terrains;

            OffreBU bu = new();
            OffreDetail od = bu.GetWithDetailsById(id);
            EvaluationBU ebu = new();
            ViewBag.Evaluations = ebu.GetAllWithDetailsByOffreId(id);

            return View(od);
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
