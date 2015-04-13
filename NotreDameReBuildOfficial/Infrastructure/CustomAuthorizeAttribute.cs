using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using NotreDameReBuildOfficial.Models;
using System.Web.Routing;

namespace NotreDameReBuildOfficial.Infrastructure
{
    public class CustomAuthorizeAttribute: AuthorizeAttribute
    {
        private readonly string[] allowroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorized = false; //base.AuthorizeCore(httpContext);
            //if (!authorized)
            //{
            //    return false;
            //}
            userClass db = new userClass();
            if (Util.CurrentUser != null)
            {
                foreach (string role in allowroles)
                {
                    if (Util.CurrentUser.roleTitle.ToLower() == role.ToLower())
                    {
                        authorized = true;
                        break;
                    }
                }
            }
            return authorized;
        }

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{

        //    base.OnAuthorization(filterContext);
        //}

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    //base.HandleUnauthorizedRequest(filterContext);
        //}
    }
}