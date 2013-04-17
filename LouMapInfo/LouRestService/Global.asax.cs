using LouRestService.Services;
using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace LouRestService
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // Old Services => Soon to be deleted
            RouteTable.Routes.Add(new ServiceRoute("TimeService", new WebServiceHostFactory(), typeof(TimeService)));

            // New Services
            RouteTable.Routes.Add(new ServiceRoute("User", new WebServiceHostFactory(), typeof(UserService)));
        }
    }
}