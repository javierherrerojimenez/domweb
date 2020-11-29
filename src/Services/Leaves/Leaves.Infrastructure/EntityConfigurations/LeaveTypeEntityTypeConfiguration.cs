using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Infrastructure.EntityConfigurations
{
    class LeaveTypeEntityTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> leaveTypeConfiguration)
        {
            leaveTypeConfiguration.ToTable("LEAVE_TYPES", LeavesContext.DEFAULT_SCHEMA);

            leaveTypeConfiguration.HasKey(o => o.Id);

            // leaveTypeConfiguration.Ignore(b => b.DomainEvents);
            leaveTypeConfiguration
                .Property<string>("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .IsRequired();

            leaveTypeConfiguration
                .Property<string>("_code")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Code")
                .IsRequired();

            leaveTypeConfiguration
                .Property<bool>("_isPaid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsPaid")
                .IsRequired();
        }

    }
}
