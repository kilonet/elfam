using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using elfam.web.Binders;
using elfam.web.Dao;
using elfam.web.IoC;
using elfam.web.Models;
using elfam.web.Services;
using elfam.web.Utils;
using Microsoft.Practices.Unity;

namespace elfam.web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

//            routes.MapRoute("catch_all", "{*url}", new {controller = "Home", action = "NotWorking"});

            routes.MapRoute(null, "Unsubscribe/{email}/{signature}",
                new { controller = "Subscriber", action = "Unsubscribe" });

            routes.MapRoute(null, "UnsubscribeUser/{email}/{signature}",
                        new { controller = "Subscriber", action = "UnsubscribeUser" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            var s = Settings.Instance;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartBinder());
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            ConfigureUnity();
        }

        private void ConfigureUnity()
        {
            IUnityContainer container = new UnityContainer()
                .RegisterType<IDaoTemplate, DaoTemplate>()
                .RegisterType<CategoryService>()
                .RegisterType<MailService>()
                .RegisterType<OrderService>();
            
            MvcUnityContainer.Container = container;
            ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));
        }

    }
}