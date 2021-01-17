using Duties.Domain.AggregatesModel.DutyAggregate;
using Duties.Domain.AggregatesModel.ResourceAggregate;
using Duties.Domain.SeedWork;
using Duties.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Duties.Infrastructure.Data
{
    public class DutiesContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "duties_db";
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Duty> Duties { get; set; }

        private readonly IMediator _mediator;

        public DutiesContext(DbContextOptions<DutiesContext> options) : base(options)
        {

        }

        public DutiesContext(DbContextOptions<DutiesContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("DutiesContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ResourceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DutyEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

    /// <summary>
    /// Esta clase se necesita para crear la base de datos al ejecutar el comando siguiente dado que el proyecto principal (API) no contiene el DbContext: & "C:\Users\Javier Herrero\.dotnet\tools\dotnet-ef" migrations --project ../Leaves.Infrastructure add InitialCreate
    /// You can tell the migration how to create your DbContext by implementing the IDesignTimeDbContextFactory<TContext> interface: If a class implementing this interface is found in either the same project as the derived DbContext or in the application's startup project, the tools bypass the other ways of creating the DbContext and use the design-time factory instead.
    /// https://entityframeworkcore.com/knowledge-base/56363374/-error-unable-to-create-an-object-of-type--appdbcontext---for-the-different-patterns-supported-at-design-time-
    /// </summary>
    public class DutiesContextDesignFactory : IDesignTimeDbContextFactory<DutiesContext>
    {
        public DutiesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DutiesContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=duties_db;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new DutiesContext(optionsBuilder.Options, new NoMediator());
        }

        class NoMediator : IMediator
        {
            public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
            {
                return Task.CompletedTask;
            }

            public Task Publish(object notification, CancellationToken cancellationToken = default)
            {
                return Task.CompletedTask;
            }

            public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.FromResult<TResponse>(default(TResponse));
            }

            public Task<object> Send(object request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
        }
    }
}
