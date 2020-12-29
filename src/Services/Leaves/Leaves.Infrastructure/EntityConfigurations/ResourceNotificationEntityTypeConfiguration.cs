using Leaves.Domain.AggregatesModel.ResourceAggregate;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Infrastructure.EntityConfigurations
{
    class ResourceNotificationEntityTypeConfiguration : IEntityTypeConfiguration<ResourceNotification>
    {
        public void Configure(EntityTypeBuilder<ResourceNotification> resourceNotificationConfiguration)
        {
            resourceNotificationConfiguration.ToTable("RESOURCE_NOTIFICATIONS", LeavesContext.DEFAULT_SCHEMA);

            resourceNotificationConfiguration.HasKey(o => o.Id);

            resourceNotificationConfiguration.Ignore(b => b.DomainEvents);

            //resourceNotificationConfiguration.Property(o => o.Id)
            //    .UseHiLo("orderitemseq");

            resourceNotificationConfiguration.Property<int>("LeaveId")
                .IsRequired();

            resourceNotificationConfiguration.Property<int>("ResourceId")
                .IsRequired();

            resourceNotificationConfiguration
                .Property<DateTime>("_lastUpdate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("LastUpdate")
                .IsRequired();
        }
    }
}
