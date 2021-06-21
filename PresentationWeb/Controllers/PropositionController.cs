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
    
        [HttpGet]
        public IActionResult ForcerReponse(int id)
        {
            PropositionBU pbu = new();
            PropositionDetail pd = pbu.GetWithDetailsById(id);
            NegociationBU nbu = new();
            NegociationDetail nd = nbu.GetWithDetailsById((int)pd.IdNegociation);
            PrestationBU prestbu = new();
            PrestationDetail prestd = prestbu.GetWithDetailsById(nd.IdPrestation);

            PropositionDetail pEleveurMechant = new();
            pEleveurMechant.DateDebutPrestation = new DateTime(2022, 04, 01);
            pEleveurMechant.DateFinPrestation = new DateTime(2023, 04, 01);
            pEleveurMechant.TypeInstallation = false;
            pEleveurMechant.IdTypeTonte = 1;
            pEleveurMechant.PrixPropose = 51666.99;
            pEleveurMechant.Description = "Salut mon p'tit bonhomme,\nc'est toi qui me forces à répondre aussi vite à tes demandes ? C'est que j'ai pas que ça à faire moi.\nTiens, une offre qui te plaira je suis sûr.\nBon oral et au plaisir";
            pEleveurMechant.IdNegociation = nd.Id;
            pEleveurMechant.DateCreation = DateTime.Now;
            pEleveurMechant.IdUtilisateur = prestd.IdEleveur;
            pEleveurMechant.IdTerrain = prestd.IdTerrain;


            pbu.SendContreProposition(id, pEleveurMechant);



            return View("../Prestation/Details", prestd);
        }
    }
}