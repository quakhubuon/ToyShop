using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace ToyShop.Models.BUS
{
    public class LoaiSanPhamBus
    {
        public static IEnumerable<LoaiSanPham> DanhSachLSP()
        {
            var db = new ToyShopEntities11();
            return db.LoaiSanPhams.Where(item => item.TinhTrangLSP == 0);
        }
    }
}