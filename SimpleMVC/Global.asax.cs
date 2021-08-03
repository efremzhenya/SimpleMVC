using SimpleMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleMVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new BookDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var exception = context.Server.GetLastError();
            //if (exception is HttpRequestValidationException)
            //{
            //    Response.Clear();
            //    Response.StatusCode = 200;
            //    Response.Write(@"<html><head></head><body>hello</body></html>");
            //    Response.End();
            //    return;
            //}
        }
    }
}
