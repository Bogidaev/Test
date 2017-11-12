using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using PetStar.Mapping;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PetStar.Installers
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        private static ISessionFactory factory;
        private static readonly object SyncObject = new object();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISessionFactory>()
                    .UsingFactoryMethod(SessionFactoryFactory));
        }

        private static ISessionFactory SessionFactoryFactory()
        {
            if (factory == null)
            {
                lock (SyncObject)
                {
                    if (factory == null)
                    {
                        var conf = new Configuration();

                        var map = new ModelMapper();
                        map.AddMappings(Assembly.GetExecutingAssembly()
                            .GetTypes().Where(x => x.BaseType != null && x.BaseType.Name == typeof(BaseMapping<>).Name).AsEnumerable());


                        conf.AddMapping(map.CompileMappingForAllExplicitlyAddedEntities());
                        factory = conf.Configure().BuildSessionFactory();
                    }
                }
            }

            return factory;
        }
    }
}