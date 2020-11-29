using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Infrastructure.EntityConfigurations
{
    class LeaveStatusEntityTypeConfiguration : IEntityTypeConfiguration<LeaveStatus>
    {
        public void Configure(EntityTypeBuilder<LeaveStatus> leaveStatusConfiguration)
        {
            leaveStatusConfiguration.ToTable("LEAVE_STATUS", LeavesContext.DEFAULT_SCHEMA);

            leaveStatusConfiguration.HasKey(o => o.Id);

            leaveStatusConfiguration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            leaveStatusConfiguration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
