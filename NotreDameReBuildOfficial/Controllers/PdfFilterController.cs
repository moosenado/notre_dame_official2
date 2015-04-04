using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class PdfFilterController : Controller
    {
        PdfFilterClass objPdf = new PdfFilterClass(); //created instance of PdfFilterClass 

        public ActionResult Pdf() //method gets all pdf's using model and displays it on pdf view  
        {

            var pdf = objPdf.getPdfsByCategory(); //calls method getPdfs from model
            return View(pdf);
        }

        public ActionResult Details(string Category)
        {
            var pdf = objPdf.getPdfsBySelectedCategory(Category);
            if (pdf == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(pdf);
            }

        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}    
