using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class QuanLyLoaiHangController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: QuanLyLoaiHang
        public ActionResult QuanLyLoaiHang()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            var list = db.LoaiHangs;
            return View(list);
        }

        public ActionResult ThemLH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemLH(LoaiHang item)
        {
            LoaiHang lh = new LoaiHang();
            lh.TENLOAIHANG = item.TENLOAIHANG;
            db.LoaiHangs.Add(lh);
            db.SaveChanges();
            return RedirectToAction("QuanLyLoaiHang", "QuanLyLoaiHang");
        }
    }
}