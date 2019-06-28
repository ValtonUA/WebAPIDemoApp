using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using DemoAPI.Models;
using Autofac.Integration.WebApi;

namespace DemoAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
  
            ContainerBuilder builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<CardRepository>().As<IRepository<Card>>();
            builder.RegisterType<UserRepository>().As<IRepository<User>>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var path = Server.MapPath("/test_log.txt");
            TextFileLogger.CreateInstance(path);
            builder.RegisterInstance(TextFileLogger.GetInstance()).As<ILogger>();
            IContainer container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
