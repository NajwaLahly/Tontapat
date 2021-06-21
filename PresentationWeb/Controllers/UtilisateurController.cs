using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.PresentationWeb.Controllers
{
    
    public class UtilisateurController : Controller
    {
        [Route("utilisateur/details/{id:int}")]
        public IActionResult Eleveur(int id)
        {
            UtilisateurBU bu = new();
            UtilisateurDetail ud = bu.GetAllWithDetailById(id);
            
            OffreBU bu2 = new();
            List<OffreDetail> offresDetails = bu2.GetAllWithDetailsByUtilisateurId(id);
            ViewBag.OffresDetails = offresDetails;

            EvaluationBU ebu= new();
            List<EvaluationDetail> evaluationsDetails = ebu.GetAllWithDetailsByEleveurId(id);
            ViewBag.EvaluationsDetails = evaluationsDetails;

            return View(ud);
        }

        [HttpGet]
        [Route("Utilisateur/Profil/{id:int}")]
        public IActionResult Update(int id)
        {
            UtilisateurBU bu = new();
            UtilisateurDetail ud = bu.GetAllWithDetailById(id);

            return View("Profil", ud);
        }

        [HttpPost]
        [Route("Utilisateur/Profil/{id:int}")]
        public IActionResult Update(UtilisateurDetail util)
        {
            UtilisateurBU bu = new UtilisateurBU();
        
            if (ModelState.IsValid)
            {
                bu.MAJ(util);
                return View("Success");
            }
            else
            {
            
                UtilisateurDetail ud = bu.GetAllWithDetailById(1);

                return View("Profil");
            } 
          
        }
    }
}
