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

            return View();
        }
        [HttpPost]
        public IActionResult Recherche(RechercheOffreDto rod)
        {
            OffreBU ob = new();
            List<OffreToPrestationDto> resultats = ob.RechercherOffre(rod);
            ViewBag.Rod = rod;
            TerrainBU tbu = new();
            List<Terrain> terrains = tbu.GetAllByUtilisateurId(1);
            ViewBag.Terrains = terrains;
            EspeceBU ebu = new();
            List<Espece> especes = ebu.GetAll();
            ViewBag.Especes = especes;
            TypeTonteBU ttbu = new();
            List<TypeTonte> tontes = ttbu.GetAll();
            ViewBag.Tontes = tontes;
            DistanceVillesBU dvbu = new();
            ViewBag.Dvbu = dvbu;
            return View("Resultats", resultats);
        }

        public IActionResult Details(int id, int idTerrain)
        {
            EspeceBU esbu = new();
            List<Espece> especes = esbu.GetAll();
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

        [HttpGet]
        public IActionResult Details(int id)
        {
            EspeceBU esbu = new();
            List<Espece> especes = esbu.GetAll();
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

            DistanceVillesBU dvbu = new();
            ViewBag.Dvbu = dvbu;

            return View(od);
        }

        [HttpGet]
        //[HttpGet("{idOffre}/{idTerrain}/{idTypeTonte}/{distance}/{nbBetes}/{typeInstallation}/{dateDebut}/{dateFin}/{duree}/{prixInstallationBetail}/{prixInstallationCloture}/{prixBetail}/{prixIntervention}/{prixService}/{prixTVA}/{prixTotal}")]
        public IActionResult DetailsPrestation(
            [FromQuery] int idOffre,
            [FromQuery] int idTerrain,
            [FromQuery] int idTypeTonte,
            [FromQuery] double distance,
            [FromQuery] int nbBetes,
            [FromQuery] bool? typeInstallation,
            [FromQuery] string dateDebut,
            [FromQuery] string dateFin,
            [FromQuery] int duree,
            [FromQuery] double PrixInstallationBetail,
            [FromQuery] double prixInstallationCloture,
            [FromQuery] double prixBetail,
            [FromQuery] double prixIntervention,
            [FromQuery] double prixService,
            [FromQuery] double prixTVA,
            [FromQuery] double prixTotal)
        {
            OffreToPrestationDto otpdto = new();
            otpdto.IdOffre = idOffre;
            Console.WriteLine("===============================" + otpdto.IdOffre);
            otpdto.IdTerrain = idTerrain;
            otpdto.IdTypeTonte = idTypeTonte;
            otpdto.Distance = distance;
            otpdto.NbBetes = nbBetes;
            otpdto.TypeInstallation = typeInstallation;
            otpdto.DateDebut = DateTime.ParseExact(dateDebut, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            otpdto.DateFin = DateTime.ParseExact(dateFin, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            otpdto.Duree = duree;
            otpdto.PrixInstallationBetail = PrixInstallationBetail;
            otpdto.PrixInstallationCloture = prixInstallationCloture;
            otpdto.PrixBetail = prixBetail;
            otpdto.PrixIntervention = prixIntervention;
            otpdto.PrixService = prixService;
            otpdto.PrixTVA = prixTVA;
            otpdto.PrixTotal = prixTotal;

            OffreBU obu = new();
            otpdto = obu.GetOffreToPrestation(otpdto);

            EspeceBU esbu = new();
            List<Espece> especes = esbu.GetAll();
            ViewBag.Especes = especes;

            TypeTonteBU ttbu = new();
            List<TypeTonte> typesTonte = ttbu.GetAll();
            ViewBag.TypesTonte = typesTonte;

            TerrainBU t = new();
            List<Terrain> terrains = t.GetAllByUtilisateurId(1); ;
            ViewBag.Terrains = terrains;

            EvaluationBU ebu = new();
            ViewBag.Evaluations = ebu.GetAllWithDetailsByOffreId(otpdto.IdOffre);

            return View(otpdto);
        }
        [HttpPost]
        public IActionResult DetailsPrestation(OffreToPrestationDto otpdto)
        {
            OffreBU obu = new();
            otpdto = obu.GetOffreToPrestation(otpdto);
            return View("Recapitulatif", otpdto);
        }

        [HttpPost]
        public IActionResult Recapitulatif(OffreToPrestationDto otpdto)
        {
            OffreBU obu = new();
            otpdto = obu.GetOffreToPrestation(otpdto);
            return View("Paiement", otpdto);
        }
        [HttpGet]
        public IActionResult Paiement(
            [FromQuery] int idOffre,
            [FromQuery] int idTerrain,
            [FromQuery] int idTypeTonte,
            [FromQuery] double distance,
            [FromQuery] int nbBetes,
            [FromQuery] bool? typeInstallation,
            [FromQuery] string dateDebut,
            [FromQuery] string dateFin,
            [FromQuery] int duree,
            [FromQuery] double PrixInstallationBetail,
            [FromQuery] double prixInstallationCloture,
            [FromQuery] double prixBetail,
            [FromQuery] double prixIntervention,
            [FromQuery] double prixService,
            [FromQuery] double prixTVA,
            [FromQuery] double prixTotal)
        {
            OffreToPrestationDto otpdto = new();
            otpdto.IdOffre = idOffre;
            Console.WriteLine("===============================" + otpdto.IdOffre);
            otpdto.IdTerrain = idTerrain;
            otpdto.IdTypeTonte = idTypeTonte;
            otpdto.Distance = distance;
            otpdto.NbBetes = nbBetes;
            otpdto.TypeInstallation = typeInstallation;
            otpdto.DateDebut = DateTime.ParseExact(dateDebut, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            otpdto.DateFin = DateTime.ParseExact(dateFin, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            otpdto.Duree = duree;
            otpdto.PrixInstallationBetail = PrixInstallationBetail;
            otpdto.PrixInstallationCloture = prixInstallationCloture;
            otpdto.PrixBetail = prixBetail;
            otpdto.PrixIntervention = prixIntervention;
            otpdto.PrixService = prixService;
            otpdto.PrixTVA = prixTVA;
            otpdto.PrixTotal = prixTotal;
            
            OffreBU obu = new();
            otpdto = obu.GetOffreToPrestation(otpdto);
            PrestationBU pbu = new();

            //pbu.Insert(p);
            return View(otpdto);
        }

        public IActionResult NouvellePrestation(
            [FromQuery] int idOffre,
            [FromQuery] int idTerrain,
            [FromQuery] int idTypeTonte,
            [FromQuery] double distance,
            [FromQuery] int nbBetes,
            [FromQuery] bool? typeInstallation,
            [FromQuery] string dateDebut,
            [FromQuery] string dateFin,
            [FromQuery] int duree,
            [FromQuery] double prixInstallationBetail,
            [FromQuery] double prixInstallationCloture,
            [FromQuery] double prixBetail,
            [FromQuery] double prixIntervention,
            [FromQuery] double prixService,
            [FromQuery] double prixTVA,
            [FromQuery] double prixTotal)
        {
            OffreToPrestationDto otpdto = new();
            otpdto.IdOffre = idOffre;
            Console.WriteLine("===============================" + otpdto.IdOffre);
            otpdto.IdTerrain = idTerrain;
            otpdto.IdTypeTonte = idTypeTonte;
            otpdto.Distance = distance;
            otpdto.NbBetes = nbBetes;
            otpdto.TypeInstallation = typeInstallation;
            otpdto.DateDebut = DateTime.ParseExact(dateDebut, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            otpdto.DateFin = DateTime.ParseExact(dateFin, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            otpdto.Duree = duree;
            otpdto.PrixInstallationBetail = prixInstallationBetail;
            otpdto.PrixInstallationCloture = prixInstallationCloture;
            otpdto.PrixBetail = prixBetail;
            otpdto.PrixIntervention = prixIntervention;
            otpdto.PrixService = prixService;
            otpdto.PrixTVA = prixTVA;
            otpdto.PrixTotal = prixTotal;

            OffreBU obu = new();
            otpdto = obu.GetOffreToPrestation(otpdto);
            PrestationBU pbu = new();
            pbu.ConvertAndInsert(otpdto);
            return View("Succes");
        }
        /* [HttpPost]
         public IActionResult Paiement(OffreToPrestationDto otpdto)
         {
             OffreBU obu = new();
             otpdto = obu.GetOffreToPrestation(otpdto);
             PrestationBU pbu = new();

             //pbu.Insert(p);
             return View("Succes", otpdto);
         }*/

        public ActionResult Succes()
        {

            return View();
        }

        public ActionResult Recapitulatif()
        {

            return View();
        }


    }
}
