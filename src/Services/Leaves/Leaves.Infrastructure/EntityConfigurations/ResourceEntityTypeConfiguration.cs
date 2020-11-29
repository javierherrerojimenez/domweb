using Leaves.Domain.AggregatesModel.ResourceAggregate;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Infrastructure.EntityConfigurations
{
    class ResourceEntityTypeConfiguration : IEntityTypeConfiguration<Resource>
    {
        
        public void Configure(EntityTypeBuilder<Resource> resourceConfiguration)
        {
            resourceConfiguration.ToTable("RESOURCES", LeavesContext.DEFAULT_SCHEMA);

            resourceConfiguration.HasKey(o => o.Id);

            resourceConfiguration.Ignore(b => b.DomainEvents);

            resourceConfiguration.Property<string>("ResourceCode").IsRequired();

            resourceConfiguration.HasIndex(p => new { p.ResourceCode }).IsUnique();

        }
    }
}
