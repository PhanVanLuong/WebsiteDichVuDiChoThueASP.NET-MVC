using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDichVuDiChoThueCDIO4.Conmon;
using WebsiteDichVuDiChoThueCDIO4.Models;
using WebsiteDichVuDiChoThueCDIO4.Models.Dao;

namespace WebsiteDichVuDiChoThueCDIO4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
            if (result)
            {
                    var ktq = db.TAIKHOANs.Count(n => n.TENDN == model.UserName && n.MATKHAU == model.Password && n.LOAITK_ID == 1);
                    if(ktq >0)
                    {
                        var user = dao.GetByID(model.UserName);
                        var UserSission = new UserLogin();
                        UserSission.UserName = user.TENDN;
                        UserSission.UserID = user.TK_ID;
                        Session.Add(CommonConstants.USER_SESSION, UserSission);
                        Response.Write("<script>alert('Đăng Nhập thanh công');</script>");
                        return RedirectToAction("Index", "HomeKH");
                    }
                    else
                    {
                        var user = dao.GetByID(model.UserName);
                        var UserSission = new UserLogin();
                        UserSission.UserName = user.TENDN;
                        UserSission.UserID = user.TK_ID;
                        Session.Add(CommonConstants.USER_SESSION, UserSission);
                        Response.Write("<script>alert('Đăng Nhập thanh công');</script>");
                        return RedirectToAction("Index", "HomeAdmin");
                    }    
                        
                    
                
                    
                

                
                }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng");
            }
            }
            //else
            //{
            //    return View("Index");
            //}
            return View("DangNhap");
        }
        public ActionResult DangNhap()
        {
            return View();
        }

    }
    }
