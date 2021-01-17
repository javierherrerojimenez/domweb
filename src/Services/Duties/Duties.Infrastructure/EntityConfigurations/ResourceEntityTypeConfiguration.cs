using Duties.Domain.AggregatesModel.ResourceAggregate;
using Duties.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Duties.Infrastructure.EntityConfigurations
{
    class ResourceEntityTypeConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resourceConfiguration)
        {
            resourceConfiguration.ToTable("RESOURCES", DutiesContext.DEFAULT_SCHEMA);

            resourceConfiguration.HasKey(o => o.Id);

            resourceConfiguration.Ignore(b => b.DomainEvents);

            resourceConfiguration.Property<string>("ResourceCode").IsRequired();

            resourceConfiguration.HasIndex(p => new { p.ResourceCode }).IsUnique();
        }
    }
}
