using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Dto;
using Fr.EQL.AI109.Tontapat.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fr.EQL.AI109.Tontapat.PresentationWeb.Controllers
{
    public class PropositionController : Controller
    {
        [HttpGet]
        public IActionResult Details(int id)
        {
            TerrainBU tbu = new();
            List<Terrain> terrains = tbu.GetAllByUtilisateurId(1);
            ViewBag.Terrains = terrains;

            TypeTonteBU ttbu = new();
            List<TypeTonte> tts = ttbu.GetAll();
            ViewBag.TypeTonte = tts;
            PropositionBU pbu = new();
            PropositionDetail pd = pbu.GetWithDetailsById(id);
            PrestationBU prbu = new();
            PrestationDetail prd = prbu.GetWithDetailsById(pd.IdPrestation);
            ViewBag.PrestationDetail = prd;
            return View(pd);
        }
        public IActionResult Accepter(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContreProposer(int id)
        {
            TerrainBU tbu = new();
            List<Terrain> terrains = tbu.GetAllByUtilisateurId(1);
            ViewBag.Terrains = terrains;

            TypeTonteBU ttbu = new();
            List<TypeTonte> tts = ttbu.GetAll();
            ViewBag.TypeTonte = tts;
            PropositionBU pbu = new();
            PropositionDetail pd = pbu.GetWithDetailsById(id);
            PrestationBU prbu = new();
            PrestationDetail prd = prbu.GetWithDetailsById(pd.IdPrestation);
            ViewBag.PrestationDetail = prd;
            return View(pd);
        }
        [HttpGet]
        public IActionResult Annuler(int id)
        {
            PropositionBU pbu = new();
            return View(pbu.GetWithDetailsById(id));
        }

        [HttpPost]
        public IActionResult Annuler(int id, PropositionDetail prod)
        {
            PropositionBU propbu = new();
            propbu.CancelProposition(prod);

            return View("Annulee");
        }
    }
}