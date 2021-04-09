using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        // GET: TimKiem
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        [HttpPost]
        public ActionResult KQTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.TENSP.Contains(sTuKhoa)).ToList();
            //phan trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SANPHAMs.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KQTimKiem(string sTuKhoa, int? page)
        {
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.TENSP.Contains(sTuKhoa)).ToList();
            //phan trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SANPHAMs.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
        }
    }
}
