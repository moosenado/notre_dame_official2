﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class giftShopClass
    {
        public string file { get; set; }

        public string file_update { get; set; }

        public string product_name { get; set; }

        public string product_price { get; set; }

        public string add_command { get; set; }

        public string delete_command { get; set; }

        public int product_quantity { get; set; }

        public string product_id { get; set; }

        public string checkoutTotal { get; set; }

        public string checkout_command { get; set; }

        public string totalAmount { get; set; }

        ndLinqClassDataContext objGS = new ndLinqClassDataContext();

        public IQueryable<product> getProducts()
        {
            var allProducts = objGS.products.Select(x => x);
            return allProducts;
        }
        public List<checkoutcart> getPurchases()
        {
            var allItems = (from x in objGS.checkouts
                          join y in objGS.carts
                          on x.session_id equals y.session_id 
                          select new { y.name, y.prod_quantity, y.session_id, y.price, x.firstname, x.lastname, x.message, x.cardname, x.cardtype, x.expirydate, x.securitycode, x.deliv_status, x.patientname, x.orderdate, x.totalpaid, x.Id });

            List<checkoutcart> objCheckoutCart = new List<checkoutcart>();

            foreach (var purchase in allItems.OrderByDescending(x => x.Id))
            {
                checkoutcart obj = new checkoutcart();

                obj.name = purchase.name;
                obj.prod_quantity = purchase.prod_quantity;
                obj.session_id = purchase.session_id;
                obj.price = purchase.price;
                obj.firstname = purchase.firstname;
                obj.lastname = purchase.lastname;
                obj.message = purchase.message;
                obj.cardname = purchase.cardname;
                obj.cardtype = purchase.cardtype;
                obj.expirydate = purchase.expirydate;
                obj.securitycode = purchase.securitycode;
                obj.deliv_status = purchase.deliv_status;
                obj.patientname = purchase.patientname;
                obj.orderdate = purchase.orderdate.ToString();
                obj.totalpaid = purchase.totalpaid;
                obj.id = purchase.Id;
                   

                objCheckoutCart.Add(obj);

            }

            return objCheckoutCart;
        }
        public IQueryable<cart> getCart(string session)
        {
            var allCartProducts = (from x in objGS.carts
                                   where x.session_id == session
                                   select x);
            return allCartProducts;
        }
        public product getProductByID(int _id)
        {
            var all_product_id = objGS.products.SingleOrDefault(x => x.Id == _id);
            return all_product_id;
        }

        public bool insertProduct(product product_table)
        {
            using (objGS)
            {
                objGS.products.InsertOnSubmit(product_table);
                objGS.SubmitChanges();
                return true;
            }
        }
        public bool insertPurchase(checkout checkout)
        {
            using (objGS)
            {
                objGS.checkouts.InsertOnSubmit(checkout);
                objGS.SubmitChanges();
                return true;
            }
        }
        public bool productUpdate(int _id, string _name, decimal _price, string _description, string _image)
        {
            using (objGS)
            {
                var update = objGS.products.Single(x => x.Id == _id); //SELECT where chosen ID matches ID in the table
                update.name = _name;
                update.price = _price;
                update.description = _description;
                update.image = _image;
                objGS.SubmitChanges(); // Update database
                return true;
            }
        }
        public bool productDelete(int _id)
        {
            using (objGS)
            {
                var delete = objGS.products.Single(x => x.Id == _id);
                objGS.products.DeleteOnSubmit(delete); //delete user on submission
                objGS.SubmitChanges(); //commit deletetion change to the database
                return true;
            }
        }
        public bool cartproductDelete(int _id)
        {
            using (objGS)
            {
                var delete = objGS.carts.Single(x => x.Id == _id);
                objGS.carts.DeleteOnSubmit(delete); //delete user on submission
                objGS.SubmitChanges(); //commit deletetion change to the database
                return true;
            }
        }
        
        //see how many session entries exist in the cart (cart count)
        public int getCartCount(string session)
        {
            int cartCount = (from x in objGS.carts
                             where x.session_id == session
                             select x).Count();
            return cartCount;
        }

    }
}