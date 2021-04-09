using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDichVuDiChoThueCDIO4.Models
{
    public class LoginModel
    {
        public static int UserID { get;  set; }
        [Required(ErrorMessage ="Mời bạn nhập tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        public string Password { get; set; }

        

        public bool RememberMe { get; set; }
    }
}