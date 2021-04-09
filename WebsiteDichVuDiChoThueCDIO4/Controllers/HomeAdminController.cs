using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class HomeAdminController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: HomeAdmin
        public ActionResult Index()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            ViewBag.SoNguoiTruyCap = HttpContext.Application["PageVie"].ToString();// lấy số lượng người truy cập từ application
            ViewBag.ThongKeDoanhThu = thongkedoanhthu();// thống kê tổng doanh thu
            ViewBag.ThongKeDonDatHang = thongkedondathang();
            ViewBag.ThongKeSoTaiKhoan = thongketaikhoan();
            return View();
        }
        public decimal thongkedoanhthu()
        {
            decimal tongdoanhthu = (decimal)db.CHITIETDONHANGs.Sum(n => n.SOLUONGSP * n.DONGIA).Value;
            return tongdoanhthu;
        }
        public double thongkedondathang()
        {
            double dhh = db.DONHANGs.Count();
            return dhh;
        }
        public int thongketaikhoan()
        {
            int tk = db.TAIKHOANs.Count();
            return tk;
        }
        //public int thongkedoanhthuthang( int thang , int nam)
        //{
        //    int tongtien;
        //    var list = db.DONHANGs.Where(n => n.DATE.Value.Month == thang && n.DATE.Value.Year == nam);
        //    foreach(var item in list)
        //    {
        //        tongtien = tongtien + (int)item.CHITIETDONHANGs.Sum(n => n.SOLUONGSP * n.DONGIA);

        //    }
        //    return tongtien;
            
        //}
        public ActionResult MenuPartial()
        {
            var listSP = db.TAIKHOANs;
            return PartialView(listSP);
        }
        [HttpGet]
        public ActionResult DangXuat()
        {
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            session.UserName = null;
            session.UserID = 0;
            CommonConstants.USER_SESSION = null;
            return RedirectToAction("DangNhap", "Login");
        }
    }
}