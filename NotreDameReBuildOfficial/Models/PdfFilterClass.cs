using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



//using System.Web.Mvc.SelectList;

namespace NotreDameReBuildOfficial.Models
{
    public class PdfFilterClass
    {
        //create instance of ndLinqClass object
        ndLinqClassDataContext objPdf = new ndLinqClassDataContext();

        public IQueryable<PDF_Filter> getPdfs() 
        {
            var allPdfs = objPdf.PDF_Filters.Select(x => x);
            return allPdfs;
        }
        public PDF_Filter getPdfByID(int _id)
        {
            var allPdf = objPdf.PDF_Filters.SingleOrDefault(x => x.id == _id); //gets all pdfs and stores it in allPdf variable
            return allPdf; //returns the result set and allows it to be displayed
        }

        /////////////////////******Public Methods*******///////////////////////////////////////

        public IQueryable<PDF_Filter> getPdfsByCategory()
        {
            //var s = (from p in PDF_Filter
            //         select p.PDF_Filter).Distinct();
            //return s;

            var allPdfs = objPdf.PDF_Filters.Select(x => x.Category).Distinct();
            return allPdfs;

            //var allPdfs = objPdf.PDF_Filters.GroupBy(x => x.Category).Select(x => x.FirstOrDefault());
            //return allPdfs;

        }

        public IQueryable<PDF_Filter> getPdfsBySelectedCategory(string _Category)
        {
            var allPdf = objPdf.PDF_Filters.OrderByDescending(x => x.Category == _Category).Take(10); //
            return allPdf; //returns the result set and allows it to be displayed
        }

        //// ***********Public Methods END*********** ///////////////////////////////////////////
     

        public bool insertPdf(PDF_Filter pdf) //created instance of PDF_Filter table 
        {
            using (objPdf) //using makes sure data disposed after its used
            {
                objPdf.PDF_Filters.InsertOnSubmit(pdf);
                objPdf.SubmitChanges();
                return true;

            }
        }

        public bool updatePdf(int _id, string _PdfTitle, string _PdfUrl, string _Category, string _Image, DateTime _Tstamp, string _Descr, string _Lang, string _Department)
        {
            using (objPdf)
            {
                var pdfUpd = objPdf.PDF_Filters.Single(x => x.id == _id);
                //passing new values into each table column
                pdfUpd.PdfTitle = _PdfTitle;
                pdfUpd.PdfUrl = _PdfUrl;
                pdfUpd.Category = _Category;
                pdfUpd.Image = _Image;
                pdfUpd.Tstamp = _Tstamp;
                pdfUpd.Descr = _Descr;
                pdfUpd.Lang = _Lang;
                pdfUpd.Department = _Department;
                return true;
            }
        }
        public bool DeletePdf(int _id)
        {
            using (objPdf)
            {
                var pdfDel = objPdf.PDF_Filters.Single(x => x.id == _id);
                objPdf.PDF_Filters.DeleteOnSubmit(pdfDel);
                objPdf.SubmitChanges();
                return true;
            }
        }

    }
}