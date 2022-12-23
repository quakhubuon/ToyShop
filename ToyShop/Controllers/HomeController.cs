using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToyShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            var db = new ToyShopEntities11();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var query = db.SanPhams.Where(item => item.TinhTrang == 0).ToList().ToPagedList(pageNumber, pageSize);

            return View(query);
        }

        [HttpPost]
        public ActionResult Detail()
        {
            string id = Request.Form["MaSanPham"];

            var db = new ToyShopEntities11();            
            var db2 = db.HangSanXuats.ToList();
            var db3 = db.LoaiSanPhams.ToList();

            SanPham sp = db.SanPhams.FirstOrDefault(item => item.MaSanPham == id);

            sp.LuotXem += 1;
            db.SaveChanges();


            ViewBag.ListHangSanXuat = db2;
            ViewBag.ListLoaiSanPham = db3;

            return View(sp);
        }

        public ActionResult HangSanXuat(string id, int? page)
        {
            var db = new ToyShopEntities11();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var query = db.SanPhams.Where(item => item.MaHangSanXuat == id).ToList().ToPagedList(pageNumber, pageSize);

            return View(query);
        }

        public ActionResult LoaiSanPham(string id, int? page)
        {
            var db = new ToyShopEntities11();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var query = db.SanPhams.Where(item => item.MaLoaiSanPham == id).ToList().ToPagedList(pageNumber, pageSize);

            return View(query);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}