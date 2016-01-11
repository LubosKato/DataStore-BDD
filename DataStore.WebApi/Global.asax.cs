using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using DataStore.Model.Events;
using DataStore.WebApi.EventDispatcher;
using DataStore.WebApi.IoC;

namespace DataStore.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureWindsor();

            // add in case you want to log EF
            //DbInterception.Add(new Shared.Logging.EFLogger());
        }

        private void ConfigureWindsor()
        {
            var container = new WindsorContainer().Install(new WindosrIoC());

            GlobalConfiguration.Configuration.DependencyResolver =
                new WindsorDependencyResolver(container);

            ServiceLocator.UserServiceFactory = container.Resolve<IUserServiceFactory>();

            DomainEvent.Dispatcher = new WindsorEventContainer(container.Kernel);
        }
    }
}
