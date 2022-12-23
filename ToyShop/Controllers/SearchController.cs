using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer.Symbols;

namespace ToyShop.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(int? page, string keyword)
        {
            var db = new ToyShopEntities11();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var item = db.SanPhams.Where(x => x.TenSanPham.Contains(keyword) && x.TinhTrang == 0).ToList().ToPagedList(pageNumber, pageSize);
            return View(item);
        }
    }
}