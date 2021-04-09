using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteDichVuDiChoThueCDIO4.Models.Dao
{
    public class UserDao
    {
        QLDICHOTHUEEntities2 db = null;
        public UserDao()
        {
            db = new QLDICHOTHUEEntities2();
        }
        public long Insert (TAIKHOAN tk)
        {
            db.TAIKHOANs.Add(tk);
            db.SaveChanges();
            return tk.TK_ID;
        }
        public TAIKHOAN GetByID (string UserName)
        {
            return db.TAIKHOANs.SingleOrDefault(x=>x.TENDN== UserName);
        }
        public bool Login (string User , string Password)
        {
            var result = db.TAIKHOANs.Count(n => n.TENDN == User && n.MATKHAU == Password);
            if(result > 0)
            {
                return true;
            }   
            else
            {
                return false;
            }    
        }
        
    }
}