using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        public ActionResult SanPham1()
        {
            var listspmoi = db.SANPHAMs.Where(n => n.LOAIHANG_ID == 1);
            ViewBag.ListSP = listspmoi;
            return View();
        }
        
        public ActionResult SanPhamPartial()
        {
            //var listspmoi = db.SANPHAMs.Where(n => n.LOAIHANG_ID == 1);
            return PartialView();
        }
        // xây dựng 1 action  load sản phẩm theo mã sản phẩm
        public ActionResult SanPham(int? LoaiSP , int? NSX , int? page)
        {
            if (LoaiSP == null || NSX == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            // load sản phẩm theo tiêu chí loai sản phẩm và nhà sản xuất
            var listSP = db.SANPHAMs.Where(n => n.LOAIHANG_ID == LoaiSP && n.NSX_ID == NSX);
            if(listSP.Count()==0)
            {
                return HttpNotFound();
            }
            // tạo biến số sản phẩm trên trang
            int pageSize = 6;
            //tao biến số trang hiện tại
            int pageNumber = (page ?? 1);
            ViewBag.LoaiHang_ID = LoaiSP;
            ViewBag.NSX_ID = NSX;
            
            return View(listSP.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
        }
        
    }
}