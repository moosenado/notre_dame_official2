﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class adminNavigationClass
    {
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();

        public IQueryable<admin_navigation> getallNav()
        {
            var allNav = objLinq.admin_navigations.Select(x => x);
            return allNav;
        }

        public IQueryable<admin_subNavigation> getallNavByID(int _id)
        {
            var allvol = (from x in objLinq.admin_subNavigations
                          where x.navID == _id
                          select x);
            return allvol;
        }

        public List<populateNav> getAdminNav()
        {
            

            var allvol = (from x in objLinq.admin_navigations
                          join y in objLinq.admin_subNavigations
                          on x.id equals y.navID into fullNav
                          from subY in fullNav.DefaultIfEmpty()
                          select new {x.id, x.title, x.icon, subNav = (subY == null ? null : subY)});

            List<populateNav> listobj = new List<populateNav>();

            foreach(var rec in allvol)
            {
                populateNav obj = new populateNav();

                obj.id = rec.id;
                obj.title = rec.title;
                obj.icon = rec.icon;
                obj.subNav = rec.subNav;

                listobj.Add(obj);

            }

            return listobj;
        }

        public bool InsertNav(admin_navigation nav)
        {
            using (objLinq)
            {
                objLinq.admin_navigations.InsertOnSubmit(nav);
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool InsertsubNav(admin_subNavigation snav)
        {
            using (objLinq)
            {
                objLinq.admin_subNavigations.InsertOnSubmit(snav);
                objLinq.SubmitChanges();
                return true;
            }
        }

        public admin_navigation getadminNavByID(int _id)
        {
            var selectJob = objLinq.admin_navigations.SingleOrDefault(x => x.id == _id);
            return selectJob;
        }


        public bool adminNavUpdate(int _id, string _Title, string _Controller, string _PageView)
        {
            using (objLinq)
            {
                var upNav = objLinq.admin_navigations.Single(x => x.id == _id);


                upNav.title = _Title;
                upNav.controller = _Controller;
                upNav.pageView = _PageView;
                objLinq.SubmitChanges();
                return true;
            }
        }


        public admin_subNavigation getadminSubNavByID(int _id)
        {
            var selectJob = objLinq.admin_subNavigations.SingleOrDefault(x => x.id == _id);
            return selectJob;
        }


        public bool adminSubNavUpdate(int _id, string _Title, string _Controller, string _PageView)
        {
            using (objLinq)
            {
                var upNav = objLinq.admin_subNavigations.Single(x => x.id == _id);


                upNav.title = _Title;
                upNav.controller = _Controller;
                upNav.pageView = _PageView;
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool adminNavDelete(int _id)
        {
            using (objLinq)
            {
                var delJob = objLinq.admin_navigations.Single(x => x.id == _id);

                objLinq.admin_navigations.DeleteOnSubmit(delJob);
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool adminsubNavDelete(int _id)
        {
            using (objLinq)
            {
                var delJob = objLinq.admin_subNavigations.Single(x => x.id == _id);

                objLinq.admin_subNavigations.DeleteOnSubmit(delJob);
                objLinq.SubmitChanges();
                return true;
            }
        }
    }
}