using System.Diagnostics;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PetStar.Servise;
using PetStar.Servise.Impl;

namespace PetStar.Installers
{
    public class ProvidersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUsersServise>().ImplementedBy<UserManagerServise>().LifestyleTransient());
            container.Register(Component.For<IAlbumsServise>().ImplementedBy<AlbumsServise>().LifestyleTransient()); 
        }
    }
}