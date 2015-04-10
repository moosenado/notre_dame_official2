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
        public ActionResult giftshop(string add_command, giftShopClass gsclass, string product_name, cart cart, int product_quantity)
        {
            if (add_command == "Add To Cart")
            {
                try
                {
                    cart.session_id = Session["name"].ToString();
                    cart.name = gsclass.product_name;
                    cart.prod_quantity = product_quantity;

                    //add one to cart counter
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            }

            ViewBag.strSession = Session["name"];
            var all_products = objGS.getProducts();
            return View(all_products);
        }

        public ActionResult product_details()
        {
            return View();
        }

        //public ActionResult (erwaitClass waitclass, string remove_command, string wait_patient_id, ER_wait_list waitlist, ER_wait_time waittime, string current_time)
        //{
        //    if (remove_command == "Remove")
        //    {
        //        try
        //        {
        //            //grab id from hidden value on form - convert string to int
        //            int id = Int32.Parse(waitclass.wait_patient_id);

        //            //grab time from hidden value and subtract from current time
        //            DateTime time_now_wait = DateTime.Now;
        //            DateTime dateValue;
        //            DateTime.TryParse(waitclass.current_time, out dateValue);
        //            TimeSpan span = time_now_wait.Subtract(dateValue);

        //            //set waittime in wait time table equal to span.totalseconds (amount of time patient has been waiting)
        //            waittime.patientid = 1;
        //            var timeseconds = span.TotalSeconds;
        //            int timeseconds_int = Convert.ToInt32(timeseconds);
        //            waittime.waittime = timeseconds_int;

        //            //remove patient from waitlist table and add new values into wait time table
        //            using (ndLinqClassDataContext objDelete_Insert = new ndLinqClassDataContext())
        //            {
        //                var delete_by_id = objDelete_Insert.ER_wait_lists.Single(x => x.Id == id);
        //                objDelete_Insert.ER_wait_lists.DeleteOnSubmit(delete_by_id);
        //                objDelete_Insert.ER_wait_times.InsertOnSubmit(waittime);
        //                objDelete_Insert.SubmitChanges();
        //            }

        //            ViewBag.erTimeAdmin = objER.getWaitTime();

        //            return RedirectToAction("ERwait_Patients");
        //        }

        //        catch (Exception ex)
        //        {
        //            ViewBag.Message = "Error:" + ex.Message.ToString();
        //        }

        //    }

        //    ViewBag.erTimeAdmin = objER.getWaitTime();

        //    //reload patient list to view
        //    var patients = objER.getWaitingPatientInfo();
        //    return View(patients);
        //}

    }
}
