//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteDichVuDiChoThueCDIO4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class THANHTOAN
    {
        public int TT_ID { get; set; }
        public string DIACHI { get; set; }
        public string TENSP { get; set; }
        public Nullable<int> SOLUONGSP { get; set; }
        public Nullable<int> SDT { get; set; }
        public Nullable<double> THANHTIEN { get; set; }
        public Nullable<double> PHIGIAOHANG { get; set; }
        public Nullable<int> TK_ID { get; set; }
        public Nullable<int> SP_ID { get; set; }
        public Nullable<int> GH_ID { get; set; }
    
        public virtual GIAOHANG GIAOHANG { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
