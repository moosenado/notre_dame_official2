using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Infrastructure
{
    [CustomAuthorize("admin", "staff")]
    public class BaseController : Controller
    {

    }
}
