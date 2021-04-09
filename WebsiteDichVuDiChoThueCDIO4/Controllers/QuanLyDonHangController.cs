using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: QuanLyDonHang
        public ActionResult QuanLyDonHang()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            var list = db.DONHANGs;
            return View(list);
        }
    }
}