using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: QuanLyTaiKhoan
        public ActionResult QuanLyTaiKhoan()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            var listTK = db.TAIKHOANs;
            return View(listTK);
        }
        public ActionResult XoaTaiKhoan(int TK_ID)
        {
            var listTK = db.TAIKHOANs.SingleOrDefault(n => n.TK_ID == TK_ID);
            if (listTK == null)
            {
                // trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;

            }

            db.TAIKHOANs.Remove(listTK);
            ViewBag.ThongBao = "Xóa thành công";
            db.SaveChanges();
            return Redirect("QuanLyTaiKhoan");
        }

        public ActionResult ThemTaiKhoan()
        {
            
            return View();
        }
        
        public ActionResult ThemTaiKhoan1(TAIKHOAN taikhoan)
        {
            var listtk = db.TAIKHOANs;
            foreach(var item in listtk)
            {
                if (item.TENDN == taikhoan.TENDN && item.EMAIL == taikhoan.EMAIL)
                {
                    ViewBag.ThongBao = "thatbai";
                }
                else
                {
                    
                    //tk.LOAITAIKHOAN = taikhoan.LOAITK_ID;
                    
                    ViewBag.ThongBao = "thanhcong";
                }    
            }
            if(ViewBag.ThongBao=="thanhcong")
            {
                TAIKHOAN tk = new TAIKHOAN();
                tk.MATKHAU = taikhoan.MATKHAU;
                tk.TENDN = taikhoan.TENDN;
                tk.SDT = taikhoan.SDT;
                tk.DIACHI = taikhoan.DIACHI;
                tk.HOTEN = taikhoan.HOTEN;
                tk.EMAIL = taikhoan.EMAIL;
                tk.LOAITK_ID = 1;
                db.TAIKHOANs.Add(tk);
            }    
            db.SaveChanges();
            return Redirect("ThemTaiKhoan");
        }
    }
}