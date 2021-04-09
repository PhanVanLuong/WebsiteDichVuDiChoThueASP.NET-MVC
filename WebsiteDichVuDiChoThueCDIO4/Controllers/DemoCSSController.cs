using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class DemoCSSController : Controller
    {
        // GET: DemoCSS
        public ActionResult Index()
        {
            ViewBag.tt = "DMM";
            return View();
        }
    }
}