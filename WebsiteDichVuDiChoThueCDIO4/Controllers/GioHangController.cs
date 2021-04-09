using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;


namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class GioHangController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();

        
        // GET: GioHang
        public ActionResult XemGioHang()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }

            
            var listSP = db.GIOHANGs.Where(n => n.TK_ID == session.UserID);



            return View(listSP);
        }

        public ActionResult ThemGioHang(int SP_ID , string iurl)
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            // kiểm tra đã đăng nhập chưa
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            // kiểm tra mã sản phẩm xem hợp lệ hay chưa
            SANPHAM listSP = db.SANPHAMs.SingleOrDefault(n => n.SP_ID == SP_ID);
            if(listSP==null)
            {
                // trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            int soluong = 1;
            //trường hợp một sản phẩm đã tồn tại trong giỏ hàng
           GIOHANG checkSP = db.GIOHANGs.SingleOrDefault(n => n.SP_ID == SP_ID && n.TK_ID ==session.UserID );
            if (checkSP != null)
            {
                // kiểm tra số lượng tồn trước khi cho khách hàng thêm sản phẩm
                checkSP.SOLUONG = checkSP.SOLUONG +1;
                db.SaveChanges();
                ViewData["Greeting"] = "true";
                return Redirect(iurl);
            }else
            {
                // Nếu không có thì thêm giỏ hàng vào csdl
                GIOHANG dh = new GIOHANG(SP_ID, session.UserID);
                db.GIOHANGs.Add(dh);
                db.SaveChanges();
                ViewData["Greeting"] = "true";
                return Redirect(iurl);

            }


        }
        
        public ActionResult XoaGioHang(int MaSP)
        {
            // kiểm tra mã sản phẩm xem hợp lệ hay chưa
            SANPHAM listSP = db.SANPHAMs.SingleOrDefault(n => n.SP_ID == MaSP);
            if (listSP == null)
            {
                // trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;

            }
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            //trường hợp một sản phẩm đã tồn tại trong giỏ hàng
            GIOHANG checkSP = db.GIOHANGs.SingleOrDefault(n => n.SP_ID == MaSP && n.TK_ID ==session.UserID);
            if (checkSP != null)
            {
                // xóa sản phẩm trong giỏ hàng
                db.GIOHANGs.Remove(checkSP);
                db.SaveChanges();
                return RedirectToAction("XemGioHang");



            }
            else
            {
                // Nếu không có thì thêm giỏ hàng vào csdl
                Response.StatusCode = 404;
                return null;

            }
        }

        public ActionResult SuaGioHang(GIOHANG model, int MaSP)
        {
            // kiểm tra mã sản phẩm xem hợp lệ hay chưa
            SANPHAM listSP = db.SANPHAMs.SingleOrDefault(n => n.SP_ID == MaSP);
            if (listSP == null)
            {
                // trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;

            }
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];

            //trường hợp một sản phẩm đã tồn tại trong giỏ hàng
            GIOHANG checkSP = db.GIOHANGs.SingleOrDefault(n => n.SP_ID == MaSP && n.TK_ID == session.UserID);
            if (checkSP != null)
            {
                // xóa sản phẩm trong giỏ hàng
                checkSP.SOLUONG = model.SOLUONG;
                db.SaveChanges();
                return RedirectToAction("XemGioHang");



            }
            else
            {
                // Nếu không có thì thêm giỏ hàng vào csdl
                Response.StatusCode = 404;
                return null;

            }
        }





        public ActionResult GioHangPartial()
        {
            
            return PartialView();
        }
    }
}