using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class GiftShopController : Controller
    {
        giftShopClass objGS = new giftShopClass();
        public ActionResult giftshop()
        {
            var all_products = objGS.getProducts();
            return View(all_products);
        }

        public ActionResult product_details()
        {
            return View();
        }

    }
}
