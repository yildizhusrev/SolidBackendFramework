using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using TmTFramework.Business.DependencyResolvers.Ninject;
using TmTFramework.Core.CrossCuttingConcerns.Security.Web;
using TmTFramework.Core.Utilities.Mvc.Infrastructure;

namespace TmTFramework.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public static string DatabaseName = HttpContext.Current.Request.Url.Host;
        //public static string DatabaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GeneralConnectionLocal"].ConnectionString.Replace("databasename", DatabaseName);
        //public static string DatabaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GeneralConnectionServer"].ConnectionString.Replace("databasename", DatabaseName);


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);



            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));

        }
            public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }

                var encTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {

            }

        }
    }
}

