using System.Reflection;
using System.Web.Http;
using Castle.Core.Configuration;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using DataStore.Handlers.Snapshots;
using DataStore.Model.Events.Interface;
using DataStore.Model.Events.Messages.Snapshots;
using DataStore.Repository.Abstractions;
using DataStore.Repository.Dapper;
using DataStore.Repository.Dapper.DataAccess;
using DataStore.Repository.Dapper.DataAccess.Interfaces;
using Shared.Membership.Service;

namespace DataStore.WebApi.IoC
{
    internal class WindosrIoC : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            var assem = Assembly.GetExecutingAssembly();
            container.Register(Classes.FromAssembly(assem).BasedOn<ApiController>().LifestyleTransient());

            container.AddFacility<TypedFactoryFacility>();

            container.Register(

                Component.For<IUserServiceFactory>().AsFactory(),
                
                Component.For<IUserService>().ImplementedBy<Shared.Membership.Service.UserService>().LifeStyle.PerWebRequest,
                Component.For<IDataBaseAccess>().ImplementedBy<DataBaseAccess>().LifeStyle.PerWebRequest,
                Component.For<IDataBaseSettings>().ImplementedBy<DataBaseSettings>().LifeStyle.PerWebRequest,

                Component.For<ISnapshotsRepository>().ImplementedBy<SnapshotsRepository>().LifeStyle.PerWebRequest,
                
                Component.For<IDomainHandler<SnapshotsGet>>().ImplementedBy<SnapshotsGetHandlerPersistance>().LifeStyle.PerWebRequest
                
                );
        }
    }
}