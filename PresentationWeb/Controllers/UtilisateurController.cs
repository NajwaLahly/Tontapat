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

        [Route("Utilisateur/Profil/{id:int}")]
        public IActionResult Profil(int id)
        {
            UtilisateurBU bu = new();
            UtilisateurDetail ud = bu.GetAllWithDetailById(id);

            return View(ud);
        }
    }
}
