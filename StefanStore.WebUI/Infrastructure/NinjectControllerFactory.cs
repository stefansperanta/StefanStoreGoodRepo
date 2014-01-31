using System;
using System.Web.Mvc;
using System.Web.Routing;
using StefanStore.Infrastructure.Concrete.NInject;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public NinjectControllerFactory()
        {}
        protected override IController GetControllerInstance(RequestContext
        requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) NInjectBinder.Instance.Get(controllerType);
        }}
}