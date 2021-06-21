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
        public IActionResult Accepter(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Annuler(int id)
        {
            PropositionBU pbu = new();
            return View(pbu.GetWithDetailsById(id));
        }

        [HttpPost]
        public IActionResult Annuler(int id,PropositionDetail pd)
        {
            PropositionBU propbu = new();
            PrestationBU prebu = new();
            Prestation p = prebu.GetWithDetailsById(propbu.GetWithDetailsById(id).IdPrestation);
            propbu.CancelProposition(p);
            ViewBag.Prestation = p;
            return View("Annulee");
        }
    }
}
