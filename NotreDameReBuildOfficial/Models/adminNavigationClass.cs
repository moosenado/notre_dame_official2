using System;
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
    }
}