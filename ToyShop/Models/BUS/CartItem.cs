using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShop.Models.BUS
{
    public class CartItem
    {
        public SanPham product { get; set; }    
        public int quantity { get; set; }

        public CartItem(SanPham product, int quantity) { 
            this.product = product;
            this.quantity = quantity;
        }

    }
}