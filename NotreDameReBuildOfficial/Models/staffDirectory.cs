using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class staffDirectory
    {
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();

        public IQueryable<staff_info>getStaff()
        {
            var allStaff = objLinq.staff_infos.Select(x => x);
            return allStaff;
        }

        public staff_info getStaffByID(int _id)
        {
            var selectStaff = objLinq.staff_infos.SingleOrDefault(x => x.id == _id);
            return selectStaff;
        }

        public bool insertStaff(staff_info staff)
        {
            using (objLinq)
            {
                objLinq.staff_infos.InsertOnSubmit(staff);
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool updateStaff(int _id, int _staffID, string fname, string lname, string department, string role, string gender, string city, string province, string zip)
        {
            using (objLinq)
            { 
                var upStaff = objLinq.staff_infos.Single(x => x.id == _id);
                upStaff.staff_id = _staffID;
                upStaff.firstname = fname;
                upStaff.lastname = lname;
                upStaff.department = department;
                upStaff.role = role;
                upStaff.gender = gender;
                upStaff.city = city;
                upStaff.province = province;
                upStaff.zip_code = zip;
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool deleteStaff(int _id)
        {
            using (objLinq)
            {
                var deleteStaff = objLinq.staff_infos.Single(x => x.id == _id);

                objLinq.staff_infos.DeleteOnSubmit(deleteStaff);
                objLinq.SubmitChanges();
                return true;
            }
        }

    }
}