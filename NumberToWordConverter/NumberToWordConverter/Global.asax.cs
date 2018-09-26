using NumericToWord.App_Start;
using NumericToWord.Framework.Implementation;
using NumericToWord.Framework.Interface;
using NumericToWord.Repository;
using NumericToWord.Repository.Contracts;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace NumericToWord
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            //Base Registrations Begin
            container.Register<ILogger, FileLogger>(Lifestyle.Singleton);
            container.Register<IConverterRepository, ConverterRepository>(Lifestyle.Singleton);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
