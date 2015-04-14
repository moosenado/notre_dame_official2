using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class navigationClass
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


        public bool InsertNav(navigation nav)
        {
            using (objLinq)
            {
                objLinq.navigations.InsertOnSubmit(nav);
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool InsertsubNav(subNavigation snav)
        {
            using (objLinq)
            {
                objLinq.subNavigations.InsertOnSubmit(snav);
                objLinq.SubmitChanges();
                return true;
            }
        }

    }
}