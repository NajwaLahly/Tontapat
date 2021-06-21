using Fr.EQL.AI109.Tontapat.Business;
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

        [HttpGet]
        // GET: PrestationController/Details/5
        public ActionResult Details(int id)
        {
            PrestationBU bu = new();
            PrestationDetail pd = bu.GetWithDetailsById(id);
            return View(pd);
        }

        [HttpGet]
        public ActionResult Negociation(int id)
        {

            PrestationBU pbu = new();
            PrestationDetail pd = pbu.GetWithDetailsById(id);
            TerrainBU tbu = new();
            List<Terrain> terrains = tbu.GetAllByUtilisateurId(pd.IdClient);
            ViewBag.Terrains = terrains;
            EspeceBU ebu = new();
            List<Espece> especes = ebu.GetAll();
            ViewBag.Especes = especes;
            TypeTonteBU ttbu = new();
            List<TypeTonte> tontes = ttbu.GetAll();
            ViewBag.TypesTonte = tontes;
            ViewBag.PrestationDetail = pd;
            return View();
        }

        [HttpPost]
        public IActionResult Negociation(PropositionDetail prd)
        {

            NegociationBU nbu = new();
            nbu.OpenNegociationInPrestation(prd);

            PrestationBU pbu = new();
            Prestation p = pbu.GetWithDetailsById((int)prd.Id);
            return View("Succes", p);

        }

/*        [HttpGet]
        public IActionResult Proposition(int id)
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
        }*/


        [HttpGet]
        public IActionResult Annuler(int id)
        {

            PrestationBU pbu = new();
            return View(pbu.GetById(id));
        }

        [HttpPost]
        public IActionResult Annuler(int id,Prestation p)
        { 
            PrestationBU pbu = new();
            pbu.CancelPrestation(p);
            return View("Annulee");
        }

        public void FaireValiderEleveur(int id)
        {
            PropositionBU pbu = new();
            pbu.FaireRepondreEleveur(id);
        }
    }


}
