using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using System.Collections.Generic;
using SportsStore.WebUI.Infrastructure;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelBinders.Binders.Add(typeof(Cart), new SportsStore.WebUI.Binders.CartModelBinder());
        }
    }
}