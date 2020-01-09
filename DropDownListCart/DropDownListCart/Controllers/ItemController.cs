using DropDownListCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;
namespace DropDownListCart.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Item
        public ActionResult Save()
        {
            ViewBag.Items = db.Items.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Item item)
        {

            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                FlashMessage.Confirmation("Item Information saved successfully");
                return RedirectToAction("Save");
            }

            return RedirectToAction("Save");
        }
        public ActionResult GetPriceByName()
        {

            //var data = from aks in db.Items select new { aks.Name, aks.Price };]
            var data = db.Items;
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);

        }
        public JsonResult ShowDataOnTable()
        {
            
            var items = db.Items.ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        
    }
}