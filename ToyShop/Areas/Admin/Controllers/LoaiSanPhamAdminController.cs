using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToyShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LoaiSanPhamAdminController : Controller
    {
        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            var db = new ToyShopEntities11();
            return View(db.LoaiSanPhams.ToList());
        }

        // GET: Admin/LoaiSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsx)
        {
            try
            {
                // TODO: Add insert logic here
                var db = new ToyShopEntities11();
                db.LoaiSanPhams.Add(lsx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPham/Edit/5
        public ActionResult Edit(string id)
        {
            var db = new ToyShopEntities11();
            LoaiSanPham lsx = db.LoaiSanPhams.FirstOrDefault(item => item.MaLoaiSanPham == id);
            return View(lsx);
        }

        // POST: Admin/LoaiSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add update logic here
                var db = new ToyShopEntities11();
                db.LoaiSanPhams.AddOrUpdate(lsp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPham/Delete/5
        public ActionResult Delete(string id)
        {
            var db = new ToyShopEntities11();
            LoaiSanPham lsp = db.LoaiSanPhams.FirstOrDefault(item => item.MaLoaiSanPham == id);
            db.LoaiSanPhams.Remove(lsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Admin/LoaiSanPham/Delete/5
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
