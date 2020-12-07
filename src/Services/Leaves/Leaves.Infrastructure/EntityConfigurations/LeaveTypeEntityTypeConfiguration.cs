using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Domain.AggregatesModel.LeaveTypeAggregate;
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

            leaveTypeConfiguration.Ignore(b => b.DomainEvents);

            leaveTypeConfiguration.Property<string>("Name").IsRequired();
            leaveTypeConfiguration.Property<string>("Code").IsRequired();
            leaveTypeConfiguration.Property<bool>("IsPaid").IsRequired();

            leaveTypeConfiguration.HasIndex(p => new { p.Code }).IsUnique();
        }

    }
}
