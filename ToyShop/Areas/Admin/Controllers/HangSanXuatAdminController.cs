using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToyShop.Areas.Admin.Controllers
{
    public class HangSanXuatAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/HangSanXuat
        public ActionResult Index()
        {
            var db = new ToyShopEntities11();
            return View(db.HangSanXuats.ToList());
        }

        // GET: Admin/HangSanXuat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/HangSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HangSanXuat/Create
        [HttpPost]
        public ActionResult Create(HangSanXuat hsx)
        {
            try
            {
                // TODO: Add insert logic here
                var db = new ToyShopEntities11();           
                db.HangSanXuats.Add(hsx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/HangSanXuat/Edit/5
        public ActionResult Edit(string id)
        {
            var db = new ToyShopEntities11();
            HangSanXuat hsx = db.HangSanXuats.FirstOrDefault(item => item.MaHangSanXuat == id);
            return View(hsx);
        }

        // POST: Admin/HangSanXuat/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, HangSanXuat hsx)
        {
            try
            {
                // TODO: Add update logic here
                var db = new ToyShopEntities11();
                db.HangSanXuats.AddOrUpdate(hsx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/HangSanXuat/Delete/5
        public ActionResult Delete(string id)
        {
            var db = new ToyShopEntities11();
            HangSanXuat hsx = db.HangSanXuats.FirstOrDefault(item => item.MaHangSanXuat == id);
            db.HangSanXuats.Remove(hsx);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Admin/HangSanXuat/Delete/5
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
