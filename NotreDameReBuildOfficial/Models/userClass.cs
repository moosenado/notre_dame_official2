using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace NotreDameReBuildOfficial.Models
{
    public class userClass: User
    {

        ndLinqClassDataContext objUser = new ndLinqClassDataContext();

        [DisplayName("Role")]
        public string roleTitle { get; set; }
        public IQueryable<userClass> getAllUsers()
        {
            var allUsers = from us in objUser.Users
                           join ro in objUser.roles on us.role_id equals ro.id
                          select new userClass()
                          {
                              id= us.id,
                              first_name = us.first_name,
                              last_name = us.last_name,
                              email = us.email,
                              phone = us.phone,
                              city = us.city,
                              province = us.province,
                              postal_code = us.postal_code,
                              roleTitle = ro.title
                          };
            return allUsers;
        }

        public User getUserByID(int _id)
        {
            var allUsers = (from us in objUser.Users
                            join ro in objUser.roles on us.role_id equals ro.id
                            where us.id == _id
                            select new userClass()
                           {
                               id = us.id,
                               first_name = us.first_name,
                               last_name = us.last_name,
                               email = us.email,
                               phone = us.phone,
                               city = us.city,
                               DOB = us.DOB,
                               province = us.province,
                               postal_code = us.postal_code,
                               user_name = us.user_name,
                               password = us.password,
                               role_id = us.role_id,
                               roleTitle = ro.title
                           }).SingleOrDefault();

            //return IQueryable Users for data bound control to bind
            return allUsers;

           
        }
        //Insert
        public bool commitInsert(User Users)
        {
            using (objUser)
            {
                objUser.Users.InsertOnSubmit(Users);
                objUser.SubmitChanges();
                return true;
            }
        }
        //Update
        public bool commitUpdateByAdmin(int _id, string _firstName, string _lastName, string _email, string _phone, string _city, string _province, string _posatlCode, DateTime _DOB, int _rollID, string _userName, string _password)
        {
            using (objUser)
            {
                var ObjUpUser = objUser.Users.Single(x => x.id == _id);
                ObjUpUser.first_name = _firstName; //setting table columns to new values being passed
                ObjUpUser.last_name = _lastName;
                ObjUpUser.email = _email;
                ObjUpUser.phone = _phone;
                ObjUpUser.city = _city;
                ObjUpUser.province = _province;
                ObjUpUser.postal_code = _posatlCode;
                ObjUpUser.DOB = _DOB;
                ObjUpUser.user_name = _userName;
                ObjUpUser.password = _password;
                ObjUpUser.role_id = _rollID;

                objUser.SubmitChanges();  //commit update to database
                return true;
            }
        }

        public bool commitDelete(int _id)
        {
            using (objUser)
            {
                var objDeleteUser = objUser.Users.Single(x => x.id == _id);
                objUser.Users.DeleteOnSubmit(objDeleteUser);  //delete command
                objUser.SubmitChanges(); //commit delete against database
                return true;

            }
        }

        public userClass login(string username, string password)
        {
            userClass user = (from us in objUser.Users
                              join ro in objUser.roles on us.role_id equals ro.id
                              where us.user_name == username && us.password == password
                              select new userClass()
                              {
                                  id = us.id,
                                  first_name = us.first_name,
                                  last_name = us.last_name,
                                  email = us.email,
                                  phone = us.phone,
                                  city = us.city,
                                  DOB = us.DOB,
                                  province = us.province,
                                  postal_code = us.postal_code,
                                  user_name = us.user_name,
                                  password = us.password,
                                  role_id = us.role_id,
                                  roleTitle = ro.title
                              }).SingleOrDefault();

            return user;
        }

        
    }
}