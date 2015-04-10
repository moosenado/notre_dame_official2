using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class WaitTimeController : Controller
    {
        erwaitClass objER = new erwaitClass();

        public ActionResult erwait()
        {
            return PartialView(objER);
        }

    }
}
