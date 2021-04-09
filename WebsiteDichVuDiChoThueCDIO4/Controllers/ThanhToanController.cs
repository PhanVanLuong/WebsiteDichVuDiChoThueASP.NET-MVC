using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class ThanhToanController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: ThanhToan
        [HttpGet]
        public ActionResult ThanhToan()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }


            var listSP = db.GIOHANGs.Where(n => n.TK_ID == session.UserID);



            return View(listSP);
        }

        [HttpPost]
        public ActionResult ThanhToan(DONHANG donhang)
        {
            int thanhtien=0;
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            DONHANG dh = new DONHANG();
            dh.HOTEN = donhang.HOTEN;
            dh.EMAIL = donhang.EMAIL;
            dh.DIACHI = donhang.DIACHI;
            dh.SDT = donhang.SDT;
            dh.DATE = DateTime.Now;
            dh.TK_ID = session.UserID;
            dh.THANHTIEN = donhang.THANHTIEN;
            db.DONHANGs.Add(dh);
            db.SaveChanges();
            var listSP = db.GIOHANGs.Where(n => n.TK_ID == session.UserID);
            foreach (var item in listSP)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.DH_ID = dh.DH_ID;
                ctdh.DONGIA = item.GIASP;
                ctdh.SOLUONGSP = item.SOLUONG;
                ctdh.TENSP = item.TENSP;
                ctdh.SP_ID = item.SP_ID;
                ctdh.HINHANH = item.HINHANH;
                GIOHANG listgh = db.GIOHANGs.SingleOrDefault(n => n.SP_ID == item.SP_ID && n.TK_ID == session.UserID);
                SANPHAM listsp = db.SANPHAMs.SingleOrDefault(n => n.SP_ID == item.SP_ID);
                if(listsp.SOLUONGTON >= item.SOLUONG)
                {
                    listsp.SOLUONGTON = listsp.SOLUONGTON - item.SOLUONG;
                }    
                else
                {
                    ViewBag.thongbao = "soluongkhongdu";
                }    
                db.GIOHANGs.Remove(listgh);
                db.CHITIETDONHANGs.Add(ctdh);
                
            }
            
            
            db.SaveChanges();
            ViewBag.thongbao="ok";
            ModelState.AddModelError("", "Thanh toán thành công");
            return Redirect("ThanhToan");
            
            //return RedirectToAction("ThanhToan", "ThanhToan");

        }
    }
}