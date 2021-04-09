using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteDichVuDiChoThueCDIO4.Models
{
    public class ItemGioHang
    {

        public int GIOHANG_ID { get; set; }
        public string TENSP { get; set; }
        public Nullable<double> GIASP { get; set; }
        public string HINHANH { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<int> SP_ID { get; set; }

        public double thanhtien { get; set; }

        public ItemGioHang(int iSP_ID)
        {
            using (QLDICHOTHUEEntities2 db = new QLDICHOTHUEEntities2())
            {
                this.SP_ID = iSP_ID;
                this.TENSP = db.SANPHAMs.Single(n => n.SP_ID == iSP_ID).TENSP;
                this.GIASP = db.SANPHAMs.Single(n => n.SP_ID == iSP_ID).GIASP;
                this.HINHANH = db.SANPHAMs.Single(n => n.SP_ID == iSP_ID).HINHANH;
                this.SOLUONG = 1;
                this.thanhtien = (double)(GIASP * SOLUONG);
            }
        }

    }
}