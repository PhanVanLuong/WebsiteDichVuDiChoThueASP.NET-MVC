using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Models;
using WebsiteDichVuDiChoThueCDIO4.Conmon;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class ChiTietSPController : Controller
    {
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: ChiTietSP
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CTSanPham(int? SP_ID)
        {
            // Nếu không truyền vào id sản phẩm
            if (SP_ID == null )
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            // load sản phẩm theo tiêu chí loai sản phẩm và nhà sản xuất
            var listSP = db.SANPHAMs.Where(n => n.SP_ID == SP_ID);
            if (listSP.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(listSP);
        }

        public ActionResult PartialBL( int SP_ID)
        {
            
            var listBL = db.BINHLUANs.Where(n =>  n.SP_ID == SP_ID);

            return PartialView(listBL);
        }
        public ActionResult ThemBL(string NOIDUNG, int SP_ID, int DANHGIA, string url)
        {
            
            var session = (UserLogin)Session[WebsiteDichVuDiChoThueCDIO4.Conmon.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "Login");
            }
            BINHLUAN bl = new BINHLUAN();
            bl.SP_ID = SP_ID;
            bl.TK_ID = session.UserID;
            bl.NOIDUNG = NOIDUNG;
            bl.DANHGIA = DANHGIA;
            db.BINHLUANs.Add(bl);
            db.SaveChanges();
            

            return Redirect(url);
        }

        
        

    }
}