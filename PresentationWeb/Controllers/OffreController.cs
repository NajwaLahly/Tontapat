using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;

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
    }
}
