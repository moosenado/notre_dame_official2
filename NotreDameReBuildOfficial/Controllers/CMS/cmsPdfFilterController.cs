using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsPdfFilterController : Controller
    {
        PdfFilterClass objPdf = new PdfFilterClass(); //created instance of PdfFilterClass 

        public ActionResult Pdf() //method gets all pdf's using model and displays it on pdf view  
        {
            var pdf = objPdf.getPdfs(); //calls method getPdfs from model
            return View(pdf);
        }

        public ActionResult Details(int id)
        {
            var pdf = objPdf.getPdfByID(id);
            if (pdf == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(pdf);
            }
        }

        public ActionResult createPdf()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createPdf(HttpPostedFileBase file, PDF_Filter pdf)
        {
            //file upload verificaiton
            if ((ModelState.IsValid) && (file != null) && (file.ContentLength > 0))
            {

                var fileType = new[] { "pdf", "PDF", "Pdf" };
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);


                    if (!fileType.Contains(fileExt))
                        {
                            ModelState.AddModelError("file", "Invalid file type. Please choose file with .pdf extension only");
                            return View();
                        }


                        if (file.ContentLength > 4000000)
                            {
                                ModelState.AddModelError("photo", "The file size should not exceed 4MB");
                                return View();
                            }

                try
                {   //if all okay then uploads file to Content/uploads
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/uploads"), fileName);
                    file.SaveAs(path);
                    pdf.PdfTitle = fileName; //automatically inserts the name of the uploaded file 
                    pdf.PdfUrl = fileName; 
                    pdf.Tstamp = DateTime.Now; //automatically inserts datetime when form submitted 
                    objPdf.insertPdf(pdf);
                    return RedirectToAction("Pdf");
                    
                }
                catch
                {
                   
                    return View();
                }
            }
            return View();
        }
        public ActionResult Update(int id)
        {
            var pdf = objPdf.getPdfByID(id);
            if (pdf == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(pdf);
            }
        }
        [HttpPost]
        public ActionResult Update(int id, PDF_Filter pdf)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    pdf.Tstamp = DateTime.Now; //updates date and time whenever record is updated
                    objPdf.updatePdf(id, pdf.PdfTitle, pdf.PdfUrl, pdf.Category, pdf.Image, pdf.Tstamp, pdf.Descr, pdf.Lang, pdf.Department);
                    return RedirectToAction("Details/" + id);
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var pdf = objPdf.getPdfByID(id);
            if (pdf == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(pdf);
            }

        }
        [HttpPost]
        public ActionResult Delete(int id, PDF_Filter pdf)
        {

            try
            {
                objPdf.DeletePdf(id); //access pdf class model method DeletePdf
                return RedirectToAction("Pdf");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
