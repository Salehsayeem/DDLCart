using CartWithJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CartWithJS.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Save()
        {
            ViewBag.Carts = db.Carts.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Cart cart)
        {

            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Save");
            }

            return RedirectToAction("Save");
        }
        public ActionResult GetPriceByName()
        {
            var data = db.Carts;
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);

        }
    }
    
}