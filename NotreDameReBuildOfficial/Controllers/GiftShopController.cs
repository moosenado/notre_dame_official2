﻿using System;
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
        public ActionResult giftshop(string add_command, giftShopClass gsclass, string product_name, cart cart, string product_quantity, string product_price)
        {
            if (add_command == "Add To Cart")
            {
                try
                {
                    //add values to table
                    var session_id = Session["name"].ToString();
                    cart.session_id = session_id;
                    cart.name = gsclass.product_name;
                    cart.prod_quantity = gsclass.product_quantity;

                    decimal priceDec = decimal.Parse(gsclass.product_price);

                    if (gsclass.product_quantity > 1)
                    {
                        int prodInt = Convert.ToInt32(gsclass.product_quantity);
                        var officialPrice = prodInt * priceDec;
                        cart.price = officialPrice;
                    }
                    else
                    {
                        cart.price = priceDec;
                    }
                    

                    //insert into table
                    using (ndLinqClassDataContext objCartInsert = new ndLinqClassDataContext())
                    {
                        objCartInsert.carts.InsertOnSubmit(cart);
                        objCartInsert.SubmitChanges();
                    }

                    //Update Cart Count

                    var cartCountInc = objGS.getCartCount(session_id);
                    ViewBag.cartCount = cartCountInc;

                    //view message

                    ViewBag.Message = "Product Added To Cart";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            }

            //session id
            var session = Session["name"].ToString();
            ViewBag.strSession = session;

            //update cart count
            var cartCount = objGS.getCartCount(session);
            ViewBag.cartCount = cartCount;

            //get products
            var all_products = objGS.getProducts();
            return View(all_products);
        }

        public ActionResult product_details(int id, string add_command, giftShopClass gsclass, string product_name, cart cart, string product_quantity, string product_price)
        {
            if (add_command == "Add To Cart")
            {
                try
                {
                    //add values to table
                    var session_id = Session["name"].ToString();
                    cart.session_id = session_id;
                    cart.name = gsclass.product_name;
                    cart.prod_quantity = gsclass.product_quantity;

                    decimal priceDec = decimal.Parse(gsclass.product_price);
                    cart.price = priceDec;

                    //insert into table
                    using (ndLinqClassDataContext objCartInsert = new ndLinqClassDataContext())
                    {
                        objCartInsert.carts.InsertOnSubmit(cart);
                        objCartInsert.SubmitChanges();
                    }

                    //Update Cart Count

                    var cartCountInc = objGS.getCartCount(session_id);
                    ViewBag.cartCount = cartCountInc;

                    //view message

                    ViewBag.Message = "Product Added To Cart";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            }
            var product_id = objGS.getProductByID(id);

            //session id
            var session = Session["name"].ToString();

            if (product_id == null)
            {
                return View("giftshop"); // go to index
            }
            else
            {
                //update cart count
                var cartCount = objGS.getCartCount(session);
                ViewBag.cartCount = cartCount;

                return View(product_id);
            }
           
        }

        public ActionResult cart(string product_id, giftShopClass gsclass, cart cart, string delete_command)
        {
            if (delete_command == "Delete")
            {
                try
                {
                    int id = int.Parse(product_id);
                    using (ndLinqClassDataContext objCartDelete = new ndLinqClassDataContext())
                    {
                        var delete = objCartDelete.carts.Single(x => x.Id == id);
                        objCartDelete.carts.DeleteOnSubmit(delete);
                        objCartDelete.SubmitChanges();
                    }

                    ViewBag.Message = "Product Deleted";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            }

            //session id
            var session = Session["name"].ToString();

            //add items from cart
            var cartProducts = objGS.getCart(session);
            return View(cartProducts);
        }

        public ActionResult checkout(string checkoutTotal, giftShopClass gsclass)
        {
            ViewBag.checkoutNum = gsclass.checkoutTotal;
            return View();
        }

    }
}
