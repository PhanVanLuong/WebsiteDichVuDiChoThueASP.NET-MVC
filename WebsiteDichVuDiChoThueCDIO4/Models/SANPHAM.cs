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
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.BINHLUANs = new HashSet<BINHLUAN>();
            this.CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            this.DANHGIAs = new HashSet<DANHGIA>();
            this.GIOHANGs = new HashSet<GIOHANG>();
            this.THANHTOANs = new HashSet<THANHTOAN>();
        }
    
        public int SP_ID { get; set; }
        public string TENSP { get; set; }
        public Nullable<double> GIASP { get; set; }
        public string MOTASP { get; set; }
        public string HINHANH { get; set; }
        public Nullable<int> LOAIHANG_ID { get; set; }
        public Nullable<int> NCC_ID { get; set; }
        public Nullable<int> NSX_ID { get; set; }
        public Nullable<int> SOLUONGTON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIA> DANHGIAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIOHANG> GIOHANGs { get; set; }
        public virtual LoaiHang LoaiHang { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHASANXUAT NHASANXUAT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }
    }
}
