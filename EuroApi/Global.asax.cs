﻿using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Devtalk.EF.CodeFirst;
using EuroApi.Models;
using Microsoft.Web.Optimization;

namespace EuroApi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //Database.SetInitializer(new DontDropDbJustCreateTablesIfModelChanged<EuroApiContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<EuroApiContext>());

            //var db = new EuroApiContext();
            //db.Database.ExecuteSqlCommand("DELETE FROM dbo.KnockoutMatchResultBets where id >= {0}", 0);
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            BundleTable.Bundles.EnableDefaultBundles();

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            var installer = new OmidID.Web.Security.Installer
                                {
                                    MembershipProvider = System.Web.Security.Membership.Provider,
                                    RoleProvider = System.Web.Security.Roles.Provider
                                };
            //Install database:
            var installed = installer.CreateIfNotExist();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}