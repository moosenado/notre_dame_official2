using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Infrastructure
{
    public class Util
    {

        public static userClass CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["CurrentUser"] != null)
                    return HttpContext.Current.Session["CurrentUser"] as userClass;

                return null;
            }
            set
            {
                HttpContext.Current.Session["CurrentUser"] = value;
            }
        }
    }
}