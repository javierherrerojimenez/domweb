using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Domain.AggregatesModel.LeaveTypeAggregate;
using Leaves.Domain.AggregatesModel.ResourceAggregate;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Infrastructure.EntityConfigurations
{
    class LeaveEntityTypeConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> leaveConfiguration)
        {
            leaveConfiguration.ToTable("LEAVES", LeavesContext.DEFAULT_SCHEMA);

            leaveConfiguration.HasKey(o => o.Id);

            leaveConfiguration.Ignore(b => b.DomainEvents);

            // Patrol HiLo: https://www.talkingdotnet.com/use-hilo-to-generate-keys-with-entity-framework-core/
            //leaveConfiguration.Property(o => o.Id)
            //    .UseHiLo("orderseq", LeavesContext.DEFAULT_SCHEMA);

            leaveConfiguration
                .Property<int?>("_resourceId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ResourceId")
                .IsRequired();

            leaveConfiguration
               .Property<int?>("_leaveTypeId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("LeaveTypeId")
               .IsRequired();


            leaveConfiguration
                .Property<int>("_leaveStatusId")
                // .HasField("_orderStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("LeaveStatusId")
                .IsRequired();

            //var navigation = leaveConfiguration.Metadata.FindNavigation(nameof(Leave.LeaveType));

            //// DDD Patterns comment:
            ////Set as field (New since EF 1.1) to access the OrderItem collection property through its field
            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //LeaveReason value object persisted as owned entity type supported since EF Core 2.0
            leaveConfiguration
                .OwnsOne(o => o.LeaveReason, a =>
                {
                    a.WithOwner();
                });

            leaveConfiguration.Property<DateTime>("DateStart").IsRequired();
            leaveConfiguration.Property<DateTime>("DateEnd").IsRequired();
            leaveConfiguration.Property<string>("Comments").IsRequired(false);
            leaveConfiguration.Property<bool>("IsNew").IsRequired();
            //leaveConfiguration.HasOne<PaymentMethod>()
            //    .WithMany()
            //    // .HasForeignKey("PaymentMethodId")
            //    .HasForeignKey("_paymentMethodId")
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);

            leaveConfiguration.HasOne<Resource>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("_resourceId");

            leaveConfiguration.HasOne<LeaveType>()
               .WithMany()
               .IsRequired()
               .HasForeignKey("_leaveTypeId");

            leaveConfiguration.HasOne(o => o.LeaveStatus)
                .WithMany()
                // .HasForeignKey("OrderStatusId");
                .HasForeignKey("_leaveStatusId");
        }
    }
}
