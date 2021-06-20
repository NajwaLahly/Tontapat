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
    public class TroupeauController : Controller
    {
      
        [Route("Mestroupeau/Details/{id:int}")]
        public ActionResult Index(int id)
        {
            UtilisateurBU ubu = new();
            UtilisateurDetail ud = ubu.GetAllWithDetailById(id);

            return View(ud);
        }

        
        public ActionResult Details(int id)
        {
            TroupeauBU tbu = new();
            TroupeauDetail td = tbu.GetAllWithDetailById(id);
            return View(td);
        }

    }
}
