using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToyShop.Areas.Admin.Controllers
{
    public class DatHangAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/DatHangAdmin
        public ActionResult Index(int ?page)
        {
            var db = new ToyShopEntities11();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var db2 = db.AspNetUsers.ToList();
            ViewBag.ListNguoiDung = db2;
            return View(db.DonHangs.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/DatHangAdmin/Details/5
        public ActionResult Details(int id)
        {
            var db = new ToyShopEntities11();
            DonHang dh = db.DonHangs.FirstOrDefault(item => item.MaDonHang == id);

            var db2 = db.AspNetUsers.ToList();
            ViewBag.ListNguoiDung = db2;

            var db3 = db.ChiTietDonHangs.Where(item => item.MaDonHang == id).ToList();
            ViewBag.ListChiTietDonHang = db3;

            var db4 = db.SanPhams.ToList();
            ViewBag.ListSanPham = db4;

            return View(dh);
        }

        public ActionResult Update()
        {
            var db = new ToyShopEntities11();
            string TinhTrang = Request.Form["TinhTrang"];
            int id = Convert.ToInt32(Request.Form["MaDonHang"]);
            DonHang dh = db.DonHangs.FirstOrDefault(item => item.MaDonHang == id);           
            dh.TinhTrang = TinhTrang;
            db.DonHangs.AddOrUpdate(dh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/DatHangAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DatHangAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DatHangAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DatHangAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DatHangAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new ToyShopEntities11();
            DonHang dh = db.DonHangs.FirstOrDefault(item => item.MaDonHang == id);
      
            db.DonHangs.Remove(dh);
            db.ChiTietDonHangs.RemoveRange(db.ChiTietDonHangs.Where(item => item.MaDonHang == id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Admin/DatHangAdmin/Delete/5
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
