using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class HomeKHController : Controller
    {
        
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        // GET: HomeKH
        [HttpGet]
        public ActionResult Index(int? page)
        {
            var UserSission = new UserLogin();
            UserSission.UserName = null;
            UserSission.UserID = 0;
            var listSP = db.SANPHAMs;
            // tạo biến số sản phẩm trên trang
            int pageSize = 6;
            //tao biến số trang hiện tại
            int pageNumber = (page ?? 1);
            return View(listSP.OrderBy(n => n.TENSP).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult DangKi(TAIKHOAN tk)
        {
            //them khách hàng vào csdl
            db.TAIKHOANs.Add(tk);
            db.SaveChanges();
            return View();
        }
        public ActionResult DangKiTaiKhoan()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult dangki1(signup tk)
        {
            if (ModelState.IsValid)
            {
                TAIKHOAN checktdn = db.TAIKHOANs.SingleOrDefault(n => n.TENDN == tk.TENDN);
                TAIKHOAN checkemail = db.TAIKHOANs.SingleOrDefault(n => n.EMAIL == tk.EMAIL);
                TAIKHOAN checksdt = db.TAIKHOANs.SingleOrDefault(n => n.SDT == tk.SDT);
                if (checktdn != null)
                {
                    ModelState.AddModelError("", "Đăng kí không thành công, tài khoản đã tồn tại");
                }
                else if (checkemail != null)
                {
                    ModelState.AddModelError("", "Đăng kí không thành công, địa chỉ email đã tồn tại");
                }
                else if (checksdt != null)
                {
                    ModelState.AddModelError("", "Đăng kí không thành công, số điện thoại đã tồn tại");
                }
                else 
                {
                    TAIKHOAN ADDTK = new TAIKHOAN();
                    ADDTK.MATKHAU = tk.MATKHAU;
                    ADDTK.TENDN = tk.TENDN;
                    ADDTK.SDT = tk.SDT;
                    ADDTK.DIACHI = tk.DIACHI;
                    ADDTK.HOTEN = tk.HOTEN;
                    ADDTK.EMAIL = tk.EMAIL;
                    ADDTK.LOAITK_ID = 1;
                    //them khách hàng vào csdl
                    db.TAIKHOANs.Add(ADDTK);
                    db.SaveChanges();
                    ModelState.AddModelError("", "Đăng kí thành công");
                }
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

            }




            return View("DangKiTaiKhoan");
        }
        public ActionResult DangNhap1(FormCollection f)
        {


            string tk = f["txttaikhoan"].ToString();
            string mk = f["txtmatkhau"].ToString();
            var tv = db.TAIKHOANs.Where(n => n.TENDN == tk && n.MATKHAU == mk);
            if (tv != null)
            {
                
                return View("Index");
            }
            else
            {
                
                return View();
            }
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

