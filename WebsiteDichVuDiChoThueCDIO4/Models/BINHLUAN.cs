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
    
    public partial class BINHLUAN
    {
        public Nullable<int> SP_ID { get; set; }
        public Nullable<int> TK_ID { get; set; }
        public string NOIDUNG { get; set; }
        public int BL_ID { get; set; }
        public Nullable<int> DANHGIA { get; set; }
    
        public virtual TAIKHOAN TAIKHOAN { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
