using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteDichVuDiChoThueCDIO4.Models
{
    public class signup
    {

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        public string MATKHAU { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập tên đăng nhập")]
        public string TENDN { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập số điện thoại")]
        
        public int SDT { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập địa chỉ")]
        public string DIACHI { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập họ tên")]
        public string HOTEN { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập email")]
        public string EMAIL { get; set; }
        public int LOAITK_ID { get; set; }

        [NotMapped]
        [Required]
        [Compare("MATKHAU")]
        public string F_MATKHAU { get; set; }

    }
}