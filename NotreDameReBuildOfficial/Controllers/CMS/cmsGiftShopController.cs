using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsGiftShopController : Controller
    {
        giftShopClass objGS = new giftShopClass();

        public ActionResult products()
        {
            var allproducts = objGS.getProducts();
            return View(allproducts);
        }

        public ActionResult insert_product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insert_product(giftShopClass gs, product product_table, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Images/Products"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                        gs.file = file.FileName;

                        product_table.image = gs.file;

                        objGS.insertProduct(product_table);

                        ViewBag.Message = "New Product Added Successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "Error:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "Please Select a File";
                }
            }
            return View();
        }

        public ActionResult update_product(int id)
        {
            var product_id = objGS.getProductByID(id);

            if (product_id == null)
            {
                return View("products");
            }
            else
            {
                return View(product_id);
            }
        }
        [HttpPost]
        public ActionResult update_product(int id, giftShopClass img_update, product product_table, HttpPostedFileBase file_update)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file_update != null) //if user uploads a new image
                    {
                        string path = Path.Combine(Server.MapPath("~/Images/Products"), Path.GetFileName(file_update.FileName));
                        file_update.SaveAs(path);

                        img_update.file = file_update.FileName;

                        product_table.image = img_update.file;
                    }

                    //if the user does not upload a new image, this will execute using the hidden value on the page

                    objGS.productUpdate(id, product_table.name, product_table.price, product_table.description, product_table.image);

                    return RedirectToAction("products");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            }
            return View();
        }


        public ActionResult delete_product(int id)
        {
            // Check to see if user id exists and handle it
            var product_delete = objGS.getProductByID(id);

            if (product_delete == null)
            {
                return View("products");
            }
            else
            {
                return View(product_delete);
            }
        }

        [HttpPost]
        public ActionResult delete_product(int id, product product_table)
        {
            try
            {
                objGS.productDelete(id); // commit delete to the database
                return RedirectToAction("products"); //redirect to Index
            }
            catch
            {
                return View(); //return to original view if an error occurs
            }
        }

    }
}
