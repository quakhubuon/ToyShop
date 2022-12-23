using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToyShop.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index()
        {  
            var db = new ToyShopEntities11();
            string currentUserId = User.Identity.GetUserId();
            var currentUser = db.AspNetUsers.FirstOrDefault(x => x.Id == currentUserId);
            var query = db.DonHangs.Where(item => item.MaNguoiDung == currentUserId);
            return View(query.ToList());
        }

        public ActionResult Detail(int id)
        {
            var db = new ToyShopEntities11();
            var query = db.ChiTietDonHangs.Where(item => item.MaDonHang == id);
            var query2 = db.SanPhams.ToList();
            ViewBag.ListSanPham = query2;
            return View(query.ToList());
        }
    }
}