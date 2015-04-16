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

        public navigation getNavByID(int _id)
        {
            var selectJob = objLinq.navigations.SingleOrDefault(x => x.id == _id);
            return selectJob;
        }


        public bool navUpdate(int _id, string _Title, string _Controller, string _PageView)
        {
            using (objLinq)
            {
                var upNav = objLinq.navigations.Single(x => x.id == _id);


                upNav.title = _Title;
                upNav.controller = _Controller;
                upNav.pageView = _PageView;
                objLinq.SubmitChanges();
                return true;
            }
        }


        public subNavigation getSubNavByID(int _id)
        {
            var selectJob = objLinq.subNavigations.SingleOrDefault(x => x.id == _id);
            return selectJob;
        }


        public bool subNavUpdate(int _id, string _Title, string _Controller, string _PageView)
        {
            using (objLinq)
            {
                var upNav = objLinq.subNavigations.Single(x => x.id == _id);


                upNav.title = _Title;
                upNav.controller = _Controller;
                upNav.pageView = _PageView;
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool navDelete(int _id)
        {
            using (objLinq)
            {
                var delJob = objLinq.navigations.Single(x => x.id == _id);

                objLinq.navigations.DeleteOnSubmit(delJob);
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool subNavDelete(int _id)
        {
            using (objLinq)
            {
                var delJob = objLinq.subNavigations.Single(x => x.id == _id);

                objLinq.subNavigations.DeleteOnSubmit(delJob);
                objLinq.SubmitChanges();
                return true;
            }
        }
    }
}