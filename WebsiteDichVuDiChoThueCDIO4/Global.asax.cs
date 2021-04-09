using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteDichVuDiChoThueCDIO4
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application["PageVie"] = 0;
        }
        protected void Session_Start()
        {
            Application.Lock();// d¨´ng ?? ??ng b? h¨®a
            Application["PageVie"] = (int)Application["PageVie"] + 1;
            //Application["Online"] = (int)Application["Online"] + 1;
            Application.UnLock();
        }
    }
}
