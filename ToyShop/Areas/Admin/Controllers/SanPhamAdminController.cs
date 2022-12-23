using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToyShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SanPhamAdminController : Controller
    {
        // GET: Admin/SanPhamAdmin
        public ActionResult Index(int? page)
        {
            var db = new ToyShopEntities11();
            var db2 = db.HangSanXuats.ToList();
            var db3 = db.LoaiSanPhams.ToList();

            ViewBag.ListHangSanXuat = db2;
            ViewBag.ListLoaiSanPham = db3;

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(db.SanPhams.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {
            var db = new ToyShopEntities11();
            var db2 = db.HangSanXuats.ToList();
            var db3 = db.LoaiSanPhams.ToList();

            ViewBag.ListHangSanXuat = db2;
            ViewBag.ListLoaiSanPham = db3;

            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                // TODO: Add insert logic here
                var db = new ToyShopEntities11();
                var hpf = HttpContext.Request.Files[0];
                if(hpf.ContentLength > 0)
                {
                    string filename = sp.MaSanPham;
                    string fullPathWithFileName = "~/Asset/images/" + filename + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh = sp.MaSanPham + ".png";
                }             
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            var db = new ToyShopEntities11();
            SanPham sp = db.SanPhams.FirstOrDefault(item => item.MaSanPham == id);

            var db2 = db.HangSanXuats.ToList();
            var db3 = db.LoaiSanPhams.ToList();

            ViewBag.ListHangSanXuat = db2;
            ViewBag.ListLoaiSanPham = db3;

            return View(sp);
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, SanPham sp)
        {
            try
            {
                // TODO: Add update logic here
                var db = new ToyShopEntities11();
                SanPham temp = db.SanPhams.FirstOrDefault(item => item.MaSanPham == id);
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string filename = sp.MaSanPham;
                    string fullPathWithFileName = "~/Asset/images/" + filename + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh = sp.MaSanPham + ".png";
                }
                else
                {
                    sp.Hinh = temp.Hinh;
                }
                db.SanPhams.AddOrUpdate(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            var db = new ToyShopEntities11();
            SanPham sp = db.SanPhams.FirstOrDefault(item => item.MaSanPham == id);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
