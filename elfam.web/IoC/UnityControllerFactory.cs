using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Exceptions;
using Microsoft.Practices.Unity;

namespace elfam.web.IoC
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            IController controller;
            if (controllerType == null)
            {
                throw new NotFoundException();
            }

            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                throw new ArgumentException(
                    string.Format("Type requested is not a controller: {0}", controllerType.Name), "controllerType");
            }
            try
            {
                controller = MvcUnityContainer.Container.Resolve(controllerType) as IController;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Error resolving controller {0}", controllerType.Name), ex);
            }
            return controller;
        }
    }
}
