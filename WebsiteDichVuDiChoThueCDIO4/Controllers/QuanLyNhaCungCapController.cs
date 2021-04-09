using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class QuanLyNhaCungCapController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: QuanLyNhaCungCap
        public ActionResult QuanLyNhaCungCap()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            var list = db.NHACUNGCAPs;
            return View(list);
        }

        public ActionResult ThemNCC()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNCC(NHACUNGCAP item)
        {
            NHACUNGCAP ncc = new NHACUNGCAP();
            ncc.TENNCC = item.TENNCC;
            ncc.DIACHI = item.DIACHI;
            ncc.EMAIL = item.EMAIL;
            db.NHACUNGCAPs.Add(ncc);
            db.SaveChanges();
            return RedirectToAction("QuanLyNhaCungCap", "QuanLyNhaCungCap");
        }
    }
}