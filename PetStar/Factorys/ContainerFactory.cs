using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PetStar.Installers;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace PetStar.Factorys
{
    public class ContainerFactory
    {
        private static IWindsorContainer сontainer;
        private static readonly object SyncObject = new object();

        public static IWindsorContainer GetCurrent()
        {
            if (сontainer == null)
            {
                lock (SyncObject)
                {
                    if (сontainer == null)
                    {
                        сontainer = new WindsorContainer();
                        //сontainer.Install(new ControllerInstaller());
                        //сontainer.Install(new NHibernateInstaller());
                        //сontainer.Install(new ProvidersInstaller());
                        //сontainer.Install(new WebApiInstaller());
                        сontainer.Install(FromAssembly.This());
                        GlobalConfiguration.Configuration.DependencyResolver = new DependencyResolver(сontainer.Kernel);
                        сontainer.Register(Component.For<IWindsorContainer>().Instance(сontainer));
                    }
                }
            }
            return сontainer;
        }
    }
}