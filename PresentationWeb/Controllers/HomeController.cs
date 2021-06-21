using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb.Controllers
{
    public class HomeController : Controller
    {     
        public IActionResult Index()
        {
            PrestationBU pbu = new();
            ViewBag.prestations = pbu.GetAllEnCoursByUtilisateurId(1);
            OffreBU obu = new();
            ViewBag.offres = obu.GetLatest(3);
            TerrainBU tbu = new();
            ViewBag.terrains = tbu.GetLatest(1,3);
            return View();
        }

    }
}
