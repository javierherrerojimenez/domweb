using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Domain.AggregatesModel.ResourceAggregate;
using Leaves.Domain.SeedWork;
using Leaves.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leaves.Infrastructure.Data
{
    /// <summary>
    /// DBContext único para todos los agregados. UnitOfWork se ocupará de gestionar todos los objetos de los diferentes agregados modificados en una única transacción
    /// </summary>
    public class LeavesContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "leaves_db";

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        private readonly IMediator _mediator;

        public LeavesContext(DbContextOptions<LeavesContext> options) : base(options) 
        { 
        }

        public LeavesContext(DbContextOptions<LeavesContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("OrderingContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeaveEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveStatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceEntityTypeConfiguration());
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Esta clase se necesita para crear la base de datos al ejecutar el comando siguiente dado que el proyecto principal (API) no contiene el DbContext: & "C:\Users\Javier Herrero\.dotnet\tools\dotnet-ef" migrations --project ../Leaves.Infrastructure add InitialCreate
    /// You can tell the migration how to create your DbContext by implementing the IDesignTimeDbContextFactory<TContext> interface: If a class implementing this interface is found in either the same project as the derived DbContext or in the application's startup project, the tools bypass the other ways of creating the DbContext and use the design-time factory instead.
    /// https://entityframeworkcore.com/knowledge-base/56363374/-error-unable-to-create-an-object-of-type--appdbcontext---for-the-different-patterns-supported-at-design-time-
    /// </summary>
    public class OrderingContextDesignFactory : IDesignTimeDbContextFactory<LeavesContext>
    {
        public LeavesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LeavesContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LeavesDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new LeavesContext(optionsBuilder.Options, new NoMediator());
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
