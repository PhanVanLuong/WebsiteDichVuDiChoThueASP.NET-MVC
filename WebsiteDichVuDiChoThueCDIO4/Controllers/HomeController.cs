using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        public ActionResult Index()
        {
            var listKH = from KH in db.TAIKHOANs select KH;

            return View(listKH);
        }
        public ActionResult MenuPartial()
        {
            var listSP = db.SANPHAMs;
            return PartialView(listSP);
        }

        public ActionResult Partial()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            var sol = db.GIOHANGs.Count(n => n.TK_ID == session.UserID);
            return PartialView(sol);
        }

        
        
    }
}