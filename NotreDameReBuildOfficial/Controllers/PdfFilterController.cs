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

        public ActionResult Pdf(string Category) // 
        {

            var pdf = objPdf.getPdfsByCategory(Category); //calls method getPdfs from model
            return View(pdf); //list view of all categories
        }

        public ActionResult Details(string Category) // 
        {

            var pdf = objPdf.getPdfsBySelectedCategory(Category); //calls method getPdfs from model
            return View(pdf); //list view of all categories
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
