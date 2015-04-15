using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class createPageClass
    {
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();

        public IQueryable<navigation> getallNav()
        {
            var allNav = objLinq.navigations.Select(x => x);
            return allNav;
        }

        public IQueryable<subNavigation> getallNavByID(int _id)
        {
            var allvol = (from x in objLinq.subNavigations
                          where x.NavID == _id
                          select x);
            return allvol;
        }

        public bool InsertPage(subNavigation snav)
        {
            using (objLinq)
            {
                objLinq.subNavigations.InsertOnSubmit(snav);
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool InsertData(createPage page)
        {
            using (objLinq)
            {
                objLinq.createPages.InsertOnSubmit(page);
                objLinq.SubmitChanges();
                return true;
            }
        }


        public subNavigation getpageByID(int _id)
        {
            var selectVol = objLinq.subNavigations.SingleOrDefault(x => x.id == _id);
            return selectVol;
        }

        public createPage getDataByID(int _id)
        {
            var selectData = objLinq.createPages.SingleOrDefault(x => x.subPageID == _id);
            return selectData;
        }

    }
}