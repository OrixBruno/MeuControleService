using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.App_Start
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFIlters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValidSessionFilter());
        }
    }
}