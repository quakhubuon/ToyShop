using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShop.Models.BUS
{
    public class HangSanXuatBus
    {
        public static IEnumerable<HangSanXuat> DanhSachHSX()
        {
            var db = new ToyShopEntities11();
            return db.HangSanXuats.Where(item => item.TinhTrangHSX == 0);
        }
    }
}