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
    public class TerrainController : Controller
    {
        
        public ActionResult Index(int id)
        {
            TerrainBU ubu = new();
            List<TerrainDetail> td = ubu.GetAllWithDetailByUtilisateurId(id);
            return View(td);
        }

        [Route("terrain/nouveau")]
        public IActionResult New()
        {
            VilleBU vbu = new();
            List<Ville> villes = vbu.GetAll();
            ViewBag.Villes = villes;

            TypeTerrainBU tbu = new();
            List<TypeTerrain> types = tbu.GetAll();
            ViewBag.Types = types;

            TypeClotureBU tcbu = new();
            List<TypeCloture> clotures = tcbu.GetAll();
            ViewBag.Clotures = clotures;

            TypeVegeToxiqueBU tvbu = new();
            List<TypeVegeToxique> vegetations = tvbu.GetAll();
            ViewBag.Vegetations = vegetations;

            bool nouveau = true;
            ViewBag.Nouveau = nouveau;

            return View("Edition");
        }

        [Route("terrain/nouveau")]
        [HttpPost]
        public IActionResult New(Terrain t)
        {
            if(ModelState.IsValid)
            {
                TerrainBU tbu = new();
                tbu.Insert(t);
                return View("Success");
            }
            else
            {
                return View("Edition");
            }
        }

        [HttpGet]
        [Route("terrain/modifier/{id:int}")]
        public IActionResult Update(int id)
        {
            TerrainBU trbu = new();
            TerrainDetail t = trbu.GetTerrainDetailById(id);

            VilleBU vbu = new();
            List<Ville> villes = vbu.GetAll();
            ViewBag.Villes = villes;

            TypeTerrainBU tbu = new();
            List<TypeTerrain> types = tbu.GetAll();
            ViewBag.Types = types;

            TypeClotureBU tcbu = new();
            List<TypeCloture> clotures = tcbu.GetAll();
            ViewBag.Clotures = clotures;

            TypeVegeToxiqueBU tvbu = new();
            List<TypeVegeToxique> vegetations = tvbu.GetAll();
            ViewBag.Vegetations = vegetations;

            bool nouveau = false;
            ViewBag.Nouveau = nouveau;
            return View("Edition", t);



        }

    }
}
