using Ninject;
using Physical.Services.AddingValueToTableServices;
using Physical.Services.ShowingTableServices;
using Physical.Services.TableCreationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Physical.Controllers
{
    //Ioc Container.
    public class NinjectController : DefaultControllerFactory
    {
        private IKernel _nenjectkernel;
        public NinjectController()
        {
            _nenjectkernel = new StandardKernel();
            AddBinding();
        }

        void AddBinding()
        {
            _nenjectkernel.Bind<IShowTableService>().To<ShowTableService>();
            _nenjectkernel.Bind<IAddValueService>().To<AddValueService>();
            _nenjectkernel.Bind<ICreationService>().To<CreationService>();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type ControllerType)
        {
            return ControllerType == null ? null : (IController)_nenjectkernel.Get(ControllerType);
        }
    }
}