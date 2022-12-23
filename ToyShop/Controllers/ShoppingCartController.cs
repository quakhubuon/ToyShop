using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models.BUS;

namespace ToyShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private int existing(string id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].product.MaSanPham == id)
                    return i;
            }
            return -1;
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            string id = Request.Form["MaSanPham"];
            if (Session["cart"] == null)
            {                
                var db = new ToyShopEntities11();
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem(db.SanPhams.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                var db = new ToyShopEntities11();
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                int index = existing(id);
                if (index == -1)
                    cart.Add(new CartItem(db.SanPhams.Find(id), 1));
                else
                    cart[index].quantity++;
                Session["cart"] = cart;
            }
            return View("Index");
        }

        public ActionResult AddToCartQuantity(FormCollection form)
        {
            if (Session["cart"] == null)
            {
                var db = new ToyShopEntities11();
                List<CartItem> cart = new List<CartItem>();
                string id = form["MaSanPham"];
                int quantity = Convert.ToInt32(form["quantity"]);
                cart.Add(new CartItem(db.SanPhams.Find(id), quantity));
                Session["cart"] = cart;
            }
            else
            {
                var db = new ToyShopEntities11();
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                string id = form["MaSanPham"];
                int quantity = Convert.ToInt32(form["quantity"]);
                int index = existing(id);
                if (index == -1)
                    cart.Add(new CartItem(db.SanPhams.Find(id), quantity));
                else
                    cart[index].quantity += quantity;
                Session["cart"] = cart;
            }
            return View("Index");
        }

        public ActionResult Update(FormCollection form)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            string id = form["MaSanPham"];
            int quantity = Convert.ToInt32(form["quantity"]);
            foreach(var item in cart)
            {
                if(item.product.MaSanPham == id)
                    item.quantity = quantity;
            }
            Session["cart"] = cart;
            return View("Index");
        }

        public ActionResult DeleteAll()
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            Session.Clear();
            return View("Index");
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(string id)

        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            int index = existing(id);
            if (index != -1)
                cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Index");
        }
    }
}
