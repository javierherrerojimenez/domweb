using Autofac;
using Leaves.API.Queries;
using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Domain.AggregatesModel.ResourceAggregate;
using Leaves.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leaves.API.Infrastructure.AutofacModules
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

            builder.RegisterType<LeaveRepository>()
                .As<ILeaveRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new LeaveQueries(QueriesConnectionString))
                .As<ILeaveQueries>()
                .InstancePerLifetimeScope();


            //builder.RegisterAssemblyTypes(typeof(CreateLeaveCommandHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
