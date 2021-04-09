using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class QuanLyNhaSanXuatController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: QuanLyNhaSanXuat
        public ActionResult QuanLyNhaSanXuat()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            var list = db.NHASANXUATs;
            return View(list);
        }
        public ActionResult ThemNSX()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult ThemNSX(NHASANXUAT item)
        {
            NHASANXUAT nsx = new NHASANXUAT();
            nsx.TENNSX = item.TENNSX;
            nsx.THONGTIN = item.THONGTIN;
            db.NHASANXUATs.Add(nsx);
            db.SaveChanges();
            return RedirectToAction("QuanLyNhaSanXuat", "QuanLyNhaSanXuat");
        }
    }
}