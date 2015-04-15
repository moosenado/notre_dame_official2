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

        public List<populatePublicNav> getpublicNav()
        {


            var allvol = (from x in objLinq.navigations
                          join y in objLinq.subNavigations
                          on x.id equals y.NavID into fullNav
                          from subY in fullNav.DefaultIfEmpty()
                          select new { x.id, x.title, subNav = (subY == null ? null : subY) });

            List<populatePublicNav> listobj = new List<populatePublicNav>();

            foreach (var rec in allvol)
            {
                populatePublicNav obj = new populatePublicNav();

                obj.id = rec.id;
                obj.title = rec.title;
                obj.subNav = rec.subNav;

                listobj.Add(obj);

            }

            return listobj;
        }


    }
}