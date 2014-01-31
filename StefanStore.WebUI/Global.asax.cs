using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SportsStore.WebUI.Infrastructure;
using StefanStore.Infrastructure;
using StefanStore.Infrastructure.Concrete.NInject;
using StefanStore.WebUI.Binders;
using StefanStore.WebUI.Helpers;
using StefanStoreDTO.CartDto;

namespace StefanStore.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DoMVCRegistrations();

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            ModelBinders.Binders.Add(typeof(CartDto), new CartModelBinder());

            AddIocBindings();
        }

        private void DoMVCRegistrations()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddIocBindings()
        {
            foreach (var moduleToBindType in GetModuleToBindTypes())
            {
                IAppModule moduleToBindInstance = (IAppModule)Activator.CreateInstance(moduleToBindType);
                moduleToBindInstance.Bind(NInjectBinder.Instance);
            }
        }

        private List<Type> GetModuleToBindTypes()
        {
            var modulesToBindTypes = BrowseAssemblies();
            return modulesToBindTypes;
        }

        private List<Type> BrowseAssemblies()
        {
            List<Type> modulesToBindTypes=new List<Type>();
            foreach (var assembly in AssemblyLocator.GetBinFolderAssemblies())
            {
                modulesToBindTypes.AddRange(BrowseTypesInAssembly(assembly));
            }
            return modulesToBindTypes;
        }

        private List<Type> BrowseTypesInAssembly(Assembly assembly)
        {
            Type moduleType = typeof(IAppModule);
            List<Type> modulesToBind=new List<Type>();
            foreach (Type t in assembly.GetTypes())
            {
                if (moduleType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                    modulesToBind.Add(t);
            }
            return modulesToBind;
        }
    }
}