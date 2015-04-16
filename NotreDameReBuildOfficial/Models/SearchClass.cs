//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace NotreDameReBuildOfficial.Models
//{
//    public class SearchClass
//    {
//        //create instance of ndLinqClass object
//        public ndLinqClassDataContext objSearch = new ndLinqClassDataContext();

//        public bool insertSearch(Search search) //created instance of search table 
//        {
//            using (objSearch) //using makes sure data disposed after its used
//            {
//                objSearch.Searches.InsertOnSubmit(search);
//                objSearch.SubmitChanges();
//                return true;

//            }
//        }
//    }
//}