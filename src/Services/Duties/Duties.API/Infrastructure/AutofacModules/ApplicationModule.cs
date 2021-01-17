using Autofac;
using Duties.Domain.AggregatesModel.DutyAggregate;
using Duties.Domain.AggregatesModel.ResourceAggregate;
using Duties.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duties.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string constr)
        {
            QueriesConnectionString = constr;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ResourceRepository>()
                .As<IResourceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DutyRepository>()
                .As<IDutyRepository>()
                .InstancePerLifetimeScope();

            //builder.Register(c => new LeaveQueries(QueriesConnectionString))
            //    .As<ILeaveQueries>()
            //    .InstancePerLifetimeScope();


            //builder.RegisterAssemblyTypes(typeof(CreateLeaveCommandHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
