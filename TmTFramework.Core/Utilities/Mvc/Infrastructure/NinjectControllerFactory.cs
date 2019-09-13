﻿using System;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
using System.Web.Routing;

namespace TmTFramework.Core.Utilities.Mvc.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _kernel.Get(controllerType);
        }
    }
}