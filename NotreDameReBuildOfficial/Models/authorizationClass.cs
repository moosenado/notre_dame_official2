using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class authorizationClass
    {
        ndLinqClassDataContext objUser = new ndLinqClassDataContext();

        public List<userClass> Users { get; set; }


        public authorizationClass()
        {
            InitData();
        }

        private void InitData()
        {
            Users = new List<userClass>();

            userClass u;
            u = new userClass()
            {
                id = 1,
                user_name = "Kiyan",
                password = "123",
                roleTitle = "Admin"
            };
            Users.Add(u);

            u = new userClass()
            {
                id = 1,
                user_name = "Mina",
                password = "111",
                roleTitle = "Staff"
            };
            Users.Add(u);
        }
    }
}