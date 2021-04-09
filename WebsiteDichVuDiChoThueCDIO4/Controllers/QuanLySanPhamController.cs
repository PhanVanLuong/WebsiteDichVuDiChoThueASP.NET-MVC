using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: QuanLySanPham
        public ActionResult QuanLySanPham()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            ViewBag.LOAIHANG_ID = new SelectList(db.LoaiHangs.OrderBy(n => n.TENLOAIHANG), "LOAIHANG_ID", "TENLOAIHANG");
            ViewBag.NCC_ID = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TENNCC), "NCC_ID", "TENNCC");
            ViewBag.NSX_ID = new SelectList(db.NHASANXUATs.OrderBy(n => n.TENNSX), "NSX_ID", "TENNSX");
            var listSP = db.SANPHAMs;
            return View(listSP);
        }
        [HttpGet]
        public ActionResult ThemSanPham()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            //load drowdownlist
            ViewBag.LOAIHANG_ID = new SelectList(db.LoaiHangs.OrderBy(n => n.TENLOAIHANG), "LOAIHANG_ID", "TENLOAIHANG");
            ViewBag.NCC_ID = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TENNCC), "NCC_ID", "TENNCC");
            ViewBag.NSX_ID = new SelectList(db.NHASANXUATs.OrderBy(n => n.TENNSX), "NSX_ID", "TENNSX");
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham( SANPHAM sp,HttpPostedFileBase HINHANH)
        {
            ViewBag.LOAIHANG_ID = new SelectList(db.LoaiHangs.OrderBy(n => n.TENLOAIHANG), "LOAIHANG_ID", "TENLOAIHANG");
            ViewBag.NCC_ID = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TENNCC), "NCC_ID", "TENNCC");
            ViewBag.NSX_ID = new SelectList(db.NHASANXUATs.OrderBy(n => n.TENNSX), "NSX_ID", "TENNSX");
            if(HINHANH.ContentLength>0)
            {
                // lấy tên hình ảnh
                var fileName = Path.GetFileName(HINHANH.FileName);
                //chuyển vào thư mục 
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                // nếu thư mục chứa hình ảnh rồi thì xuất ra thông báo
                if(System.IO.File.Exists(path))
                {
                    ViewBag.upload = "Hình đã tồn tại";
                    return View();
                }    
                else
                {
                    // lưu hình ảnh
                    HINHANH.SaveAs(path);
                    sp.HINHANH = fileName;
                    
                }
                

            }
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
            return RedirectToAction("QuanLySanPham");

        }
        [HttpGet]
        public ActionResult Sua(int? SP_ID)
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            if (SP_ID == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SANPHAM listSP = db.SANPHAMs.SingleOrDefault(n => n.SP_ID == SP_ID);
            if(listSP==null)
            {
                return HttpNotFound();
            }    
            ViewBag.LOAIHANG_ID = new SelectList(db.LoaiHangs.OrderBy(n => n.TENLOAIHANG), "LOAIHANG_ID", "TENLOAIHANG");
            ViewBag.NCC_ID = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TENNCC), "NCC_ID", "TENNCC");
            ViewBag.NSX_ID = new SelectList(db.NHASANXUATs.OrderBy(n => n.TENNSX), "NSX_ID", "TENNSX");
            return View(listSP);
        }
        [HttpPost]
        public ActionResult Sua(SANPHAM model)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLySanPham");
            }
            
            return View(model);
        }
        public ActionResult Xoa(int? SP_ID)
        {

            var listsp = db.SANPHAMs.SingleOrDefault(n => n.SP_ID == SP_ID);
           
            if (listsp == null)
            {
                // trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;

            }

            db.SANPHAMs.Remove(listsp);
            ViewBag.ThongBao = "Xóa thành công";
            db.SaveChanges();
            return RedirectToAction("QuanLySanPham");
        }
    }
}