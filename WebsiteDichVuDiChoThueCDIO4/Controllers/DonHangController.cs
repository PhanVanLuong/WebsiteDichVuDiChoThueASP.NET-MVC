using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Models;
using WebsiteDichVuDiChoThueCDIO4.Conmon;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class DonHangController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: DonHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiDonHang()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }

            var LisDH = db.DONHANGs.Where(n => n.TK_ID == session.UserID);
            return View(LisDH);
        }

        public ActionResult ChiTietDonHang (int DH_ID)
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            var lisCTDH = db.CHITIETDONHANGs.Where(n => n.DH_ID == DH_ID);
            return View(lisCTDH);
        }
        public ActionResult XoaDonHang(int DH_ID)
        {
            
            DONHANG checkSP = db.DONHANGs.SingleOrDefault(n => n.DH_ID == DH_ID);
                
            
            
            if (checkSP != null)
            {
              
                

                // xóa sản phẩm trong giỏ hàng
                db.DONHANGs.Remove(checkSP);
                var listctdh = db.CHITIETDONHANGs.Where(n => n.DH_ID == DH_ID);
                foreach (var item in listctdh)
                {
                    SANPHAM listsp = db.SANPHAMs.SingleOrDefault(n => n.SP_ID == item.SP_ID);
                    listsp.SOLUONGTON = listsp.SOLUONGTON + item.SOLUONGSP;
                    db.SaveChanges();
                }
                db.SaveChanges();
                ViewBag.TBXoaDonHang = "Xóa đơn hàng thành công";
                return RedirectToAction("HienThiDonHang");



            }
            else
            {
                // Nếu không có thì thêm giỏ hàng vào csdl
                Response.StatusCode = 404;
                return null;

            }
        }
    }
}