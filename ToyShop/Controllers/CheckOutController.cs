using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models.BUS;

namespace ToyShop.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var db = new ToyShopEntities11();
            var currentUser = db.AspNetUsers.FirstOrDefault(x => x.Id == currentUserId);
            return View(currentUser);
        }

        public ActionResult Order(FormCollection form)
        {
            try
            {
                var db = new ToyShopEntities11();
                List<CartItem> cart = (List<CartItem>)Session["cart"];

                DonHang dh = new DonHang();
 
                dh.MaNguoiDung = form["MaNguoiDung"];
                dh.TongTien = cart.Sum(item => item.product.Gia * item.quantity);
                dh.GhiChu = form["GhiChu"];
                dh.SoDienThoai = form["SoDienThoai"];
                if (form["DiaChi2"] != null)
                {
                    dh.DiaChi = form["DiaChi2"];
                }
                else
                {
                    dh.DiaChi = form["DiaChi"];
                }
                dh.PhuongThucThanhToan = form["PhuongThucThanhToan"];
                dh.TinhTrang = "0";
                dh.NgayThanhToan = DateTime.Today;
                dh.NgayGiaoHang = DateTime.Today.AddDays(7);
                db.DonHangs.Add(dh);
                
                db.SaveChanges();
                db.Entry(dh).GetDatabaseValues();
                int id = dh.MaDonHang;

                foreach (var item in cart)
                {
                    ChiTietDonHang ct = new ChiTietDonHang();
                    ct.MaDonHang = id;
                    ct.MaSanPham = item.product.MaSanPham;
                    ct.SoLuong = item.quantity;
                    ct.Gia = item.product.Gia;
                    db.ChiTietDonHangs.Add(ct);
                    db.SaveChanges();
                }
                
                cart.Clear();
                return View("OrderSuccess");
            }
            catch
            {
                return Content("Đặt hàng thất bại");
            }                  
        }
    }
}