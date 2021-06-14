using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.PresentationWeb.Controllers
{
    [Route("utilisateur/details/{id:int}")]
    public class UtilisateurController : Controller
    {
        public IActionResult Eleveur(int id)
        {
            UtilisateurBU bu = new();
            Utilisateur u = bu.GetById(id);
            
            OffreBU bu2 = new();
            List<OffreDetail> offres = bu2.GetAllWithDetailsByUtilisateurId(id);
            ViewBag.Offres = offres;

            return View(u);
        }
    }
}
