using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PetStar.Controllers;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace PetStar.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //var controllers = Assembly.GetExecutingAssembly()
            //        .GetTypes().Where(x => x.BaseType == typeof(BaseController)).ToList();

            //foreach (var controller in controllers)
            //{
            //    container.Register(Component.For(controller)
            //        .LifestyleTransient()
            //        .UsingFactoryMethod(() =>
            //        {
            //            var instance = Activator.CreateInstance(controller);
            //            if (instance is BaseController)
            //            {
            //                var baseController = instance as BaseController;
            //                baseController.Container = container;
            //            }
            //            return instance;
            //        }));
            //}

            container.Register(Classes.FromThisAssembly().BasedOn<Controller>().LifestyleScoped());
        }
    }
}